using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Infrastructure.HTMLBuilder
{
    public static class ChangePasswordEmail
    {
        public static string GenerateHtmlMail(string? businessName, string username, string password, string appUrl)
        {

            return $@"<!doctype html>
<html lang=""en-US"">

<head>
    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"" />
    <title>Reset Password Email Template</title>
    <meta name=""description"" content=""Reset Password Email Template."">
</head>

<body marginheight=""0"" topmargin=""0"" marginwidth=""0"" style=""margin: 0px; background-color: #f2f3f8;"" leftmargin=""0"">
    <!--100% body table-->
    <table cellspacing=""0"" border=""0"" cellpadding=""0"" width=""100%"" bgcolor=""#f2f3f8""
        style=""@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;"">
        <tr>
            <td>
                <table style=""background-color: #f2f3f8; max-width:670px;  margin:0 auto;"" width=""100%"" border=""0""
                    align=""center"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=""text-align:center;"">
                          <a href=""{appUrl}"" title=""logo"" target=""_blank"">
                            <img width=""60"" src="""" title=""logo"" alt=""logo"">
                          </a>
                        </td>
                    </tr>
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width=""95%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""
                                style=""max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);"">
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style=""padding:0 35px;"">
                                      <p style=""color:#455056; font-size:20px;line-height:44px; margin:0; text-align: left;"">Dear {businessName},</p> 
                                      <br>
                                      <br>
                                        <h1 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;"">Welcome to BOI LOAN Portal</h1>
                                        <span
                                            style=""display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:18rem;""></span>
                                        <p style=""color:#455056; font-size:15px;line-height:24px; margin:0;"">
                                           Password was Changed successfully    </p>
                                      <br><br>
                                      <h4 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:22px;font-family:'Rubik',sans-serif;"">What's next?</h4>
                                        <span
                                            style=""display:inline-block; vertical-align:middle; margin:9px 0 26px; border-bottom:1px solid #cecece; width:18rem;""></span>
                                      <p style=""color:#455056; font-size:15px;line-height:24px; margin:0;"">
                                           You will need the credentials below to sign in on the platform. Click the link below to log in.<b>**Please ensure you change your password from the default password once you log in.</b>
                                        </p>
                                     
                                        <p style=""text-align: justify""><b>Username:</b> {username}</p>
								<p style=""text-align: justify""><b>Password:</b> {password}</p>
                                                                            </td>
                                </tr>
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=""text-align:center;"">
                            <p style=""font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;"">&copy; <strong>{appUrl}</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!--/100% body table-->
</body>

</html>";
        }

    }
}
