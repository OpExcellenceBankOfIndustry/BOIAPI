
using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserAccess;
using BOI.BOIApplications.Application.Contracts.Persistence;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login;
using BOI.BOIApplications.IdentityManagement.HTMLBuilder;
using BOI.BOIApplications.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using BOI.BOIApplications.Persistence.Repository;
using AutoMapper;

namespace BOI.BOIApplications.IdentityManagement.Services
{
    public class UserAccess : IUserAccess
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserDetail> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly SignInManager<UserDetail> _signInManager;
        private readonly IEmailRepository _emailRepository;

        public UserAccess(IMapper mapper, IOptions<JWTSettings> options, UserManager<UserDetail> userManager, RoleManager<UserRole> roleManager,SignInManager<UserDetail> signInManager, IEmailRepository emailRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtSettings = options.Value;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailRepository = emailRepository;
        }
        public async Task<UserLoginDetailViewModel> Login(LoginViewModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email.ToLower());
            var passwordSignInResult = await _signInManager.PasswordSignInAsync(model.Email.ToLower(), model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                
                return new UserLoginDetailViewModel { Status = "Error", ErrorMessage = "User Login Failed" };
            }
            else
            {
                
                var userViewModel = _mapper.Map<UserLoginDetailViewModel>(user);
                if (userViewModel.DefaultPassword) model.DefaultPassword = true;
                model.UserId = userViewModel.Id;

                //var userRoles = await _userManager.GetRolesAsync(user);
                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}
                var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.BusinessName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.SerialNumber, user.RCNumber),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

               

                var options = new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Path = "/",
                    IsEssential = true
                };

                userViewModel.JwtToken = CreateUserToken(user);
                userViewModel.Status = "Success";
                userViewModel.Message = "User Authenticated successfully!";
                return userViewModel;
            }
            
        }


        public async Task<ForgetPasswordViewModel> ForgetPassword(ForgetPasswordViewModel model)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email.ToLower());

                var pwd = GenerateRandomPassword();               
                user.DefaultPassword = true;

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, pwd);
                if (result.Succeeded)
                {
                               
                    await _userManager.UpdateAsync(user);

                    var enqueueEmail = new Email
                    {
                        Subject = "BOI Loan Portal Reset Password",
                        Sender = "oawopetu@boi.ng",
                        ToRecipient = user.Email,
                        BccRecipient = "cofoma@boi.ng",
                        Message = ResetPassword.GenerateHtmlMail(user.BusinessName, user.Email, pwd, "https://www.boi.ng/"),
                        IsHtml = true,
                        Channel = "Loan Portal",
                        DateLogged = DateTime.Now,
                        Sent = false
                    };

                    await _emailRepository.AddAsync(enqueueEmail);
                    return model;
                }

                var error = string.Empty;
                foreach (var item in result.Errors)
                {
                    var _item = item.Description; 
                    error += _item + "<br/>";
                }

                model.Message = "Unable to Reset User's Password";
                model.ErrorMessage = error;

                return model;

            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                //return BadRequest(ex.Message); 
                return model;
            }
        }


        public async Task<ChangePasswordViewModel> ChangePassword(ChangePasswordViewModel model)
        {

            try
            {
                if (model.NewPassword != model.ConfirmPassword)
                {
                    model.Message = "Password and ConfirmPassword must be the same.";
                    return model;
                }
                if (model.OldPassword == model.NewPassword)
                {
                    model.Message = "Old and New Password cannot be the same.";
                    return model;

                }
                var user = await _userManager.FindByEmailAsync(model.Email.ToLower());

                var query = await _signInManager.PasswordSignInAsync(model.Email.ToLower(), model.OldPassword, false, false);

                if (query.Succeeded)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        var _user = await _userManager.FindByIdAsync(user.Id.ToString());
                        _user.DefaultPassword = false;
                        await _userManager.UpdateAsync(_user);

                        var enqueueEmail = new Email
                        {
                            Subject = "BOI Loan Portal Change Password",
                            Sender = "oawopetu@boi.ng",
                            ToRecipient = _user.Email,
                            BccRecipient = "cofoma@boi.ng",
                            Message = ChangePasswordEmail.GenerateHtmlMail(_user.BusinessName, _user.Email, model.NewPassword, "https://www.boi.ng/"),
                            IsHtml = true,
                            Channel = "Loan Portal",
                            DateLogged = DateTime.Now,
                            Sent = false
                        };

                        await _emailRepository.AddAsync(enqueueEmail);
                        return model;

                    }

                    var error = string.Empty;
                    foreach (var item in result.Errors)
                    {
                        var _item = item.Description;  //.Replace("'", " ");
                        error += _item + "<br/>";
                    }
                    model.Message = "Unable to Reset User's Password";
                    model.ErrorMessage = error;
                    return model;
                }
                //return BadRequest(ResponseMessage.ErrorResponseMessage("UserName or Password InCorrect"));
                model.Message = "Unable to Reset User's Password";
                return model;

            }
            catch (Exception)
            {
                //_logger.LogError(ex.Message);
                //return BadRequest(ex.Message); 
                return model;
            }
        }

        public static string GenerateRandomPassword(PasswordOptions? opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 10,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public string CreateUserToken(UserDetail user)
        {
            try
            {
                var secretKey = _jwtSettings.Secret;
                var issuer = _jwtSettings.ValidIssuer;
                var audience = _jwtSettings.ValidAudience;
                string userObject = JsonConvert.SerializeObject(user);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("UserData", userObject) }),
                    Expires = DateTime.UtcNow.AddMinutes(600),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                //ex.LogError();
                return String.Empty;
            }
        }

    }
}
