using BOI.BOIApplications.Application.Contracts.MicrosoftIdentity.UserManager;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity;
using BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails;
using BOI.BOIApplications.IdentityManagement.HTMLBuilder;
using BOI.BOIApplications.Domain.Entities;
//using BOI.BOIApplications.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Policy;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace BOI.BOIApplications.IdentityManagement.Services
{
    public class UserManager : IUserManager
    {
       
        private readonly UserManager<UserDetail> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly IEmailRepository _emailRepository;
        private readonly IConfiguration _configuration;


        public UserManager(UserManager<UserDetail> userManager, RoleManager<UserRole> roleManager, IEmailRepository emailRepository, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailRepository = emailRepository;
            _configuration = configuration;

        }
        public async Task<UserDetailViewModel> UserRegistration(UserDetailViewModel userDetail)
        {
            try
            {
                if (userDetail.Password != userDetail.ConfirmPassword)
                {
                    userDetail.ModelMessage = "Password and ConfirmPassword must be the same.";
                    return userDetail;
                }
                if (!await _roleManager.RoleExistsAsync(userDetail.RoleName))
                {
                    throw new Exception(string.Format("Invalid Role [{0}]", userDetail.RoleName));
                }
                var user = new UserDetail()
                {
                    UserName = userDetail.Email.ToLower(),
                    Email = userDetail.Email.ToLower(),
                    PhoneNumber = userDetail.PhoneNumber,
                    BusinessName = userDetail.BusinessName,
                    BusinessType = userDetail.BusinessType,
                    BusinessLocation = userDetail.BusinessLocation,
                    RCNumber = userDetail.RCNumber,
                    UserRole = "Customer",
                    RegisteredDate = DateTime.Now,
                    DefaultPassword = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Isdeleted = false
                };

                var res = await _userManager.CreateAsync(user, userDetail.Password);
                
                if (!res.Succeeded)
                {
                    foreach (var err in res.Errors)
                    {
                        userDetail.ErrorMessage += err + " ";
                    }
                    userDetail.ModelMessage = "User Creation Failed";
                    return userDetail;
                }
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var enCode = HttpUtility.UrlEncode(code);

                // var callbackUrl = "https://localhost:7041/api/UserManagement/ConfirmEmail?email={Email}&code={code}";

                var baseURL = _configuration["BaseSettings:BaseURL"];
                var callbackUrl = baseURL + "api/UserManagement/ConfirmEmail?email={Email}&code={code}";
                callbackUrl = callbackUrl.Replace("{Email}", userDetail.Email).Replace("{code}", enCode);

                var enqueueEmail = new Email
                {
                    Subject = "BOI Loan Portal User Registration",
                    Sender = "oawopetu@boi.ng",
                    ToRecipient = userDetail.Email,
                    BccRecipient = "cofoma@boi.ng",
                    Message = RegisterUser.GenerateHtmlMail(userDetail.BusinessName, userDetail.Email, callbackUrl),
                    IsHtml = true,
                    Channel = "Loan Portal",
                    DateLogged = DateTime.Now,
                    Sent = false
                };

               await _emailRepository.AddAsync(enqueueEmail);
                // await _userManager.AddToRoleAsync(user, userDetail.RoleName);

                return userDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ConfirmEmail(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email.ToLower());
            
            if (user != null)
            {
               var emailConfirm = await _userManager.ConfirmEmailAsync(user, code);
               if (emailConfirm.Succeeded)
                {
                    user.EmailConfirmed = true;
                    var gg = await _userManager.UpdateAsync(user);
                    return true;
                }
              
            }
            return false;
        }

        private static int GetRandomNumber(int range)
        {
            int response = 0;
            try
            {
                //Generate random number
                Random random = new Random();
                response = random.Next(range);
                return response;
            }
            catch (Exception)
            {
                  
                return response;
            }
        }
        private static string GetRandomString(int length)
        {
            string response = String.Empty;
            try
            {
                //Generate random string
                Random random = new Random();
                StringBuilder str_build = new StringBuilder();
                char letter;
                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
                response = str_build.ToString();
                return response;
            }
            catch (Exception)
            {
                
                return response;
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
    }
}
