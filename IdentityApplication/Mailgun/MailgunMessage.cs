using System;
using System.IO;
using Microsoft.AspNet.Identity;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace IdentityApplication.Mailgun
{
  public class MailGunMessage
  {
    private static string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["MailgunApiKey"];

    private static string pubKey = System.Web.Configuration.WebConfigurationManager.AppSettings["MailgunPublicValidationKey"];
    
    private static string fromEmail = System.Web.Configuration.WebConfigurationManager.AppSettings["Mailgun-VerifyAcc-FromEmail"];

    private static string senderDomainName = System.Web.Configuration.WebConfigurationManager.AppSettings["Your-Domain-Name"];

    public static Task<IRestResponse> SendAccountVerificationEmail(IdentityMessage message)
    {
      RestClient client = new RestClient();
      client.BaseUrl = new Uri("https://api.mailgun.net/v3");
      client.Authenticator = new HttpBasicAuthenticator("api", apiKey);
      RestRequest request = new RestRequest();
      request.AddParameter("domain", senderDomainName, ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter("from", fromEmail);
      request.AddParameter("to", message.Destination);
      request.AddParameter("subject", message.Subject);
      request.AddParameter("text", "Hi! Your new account at Mike Gell Demo has been created.");
      request.AddParameter("html", message.Body);
      //request.AddParameter("html", "<html>Hi! Your new account at <i>Mike Gell Demo</i> has been created. Please confirm your email address using the link below.<br /><br />LINK GOES HERE</html>");
      request.Method = Method.POST;

      Task<IRestResponse> task = client.ExecuteTaskAsync(request);
      return task;
    }
  }
}