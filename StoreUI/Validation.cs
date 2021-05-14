using System;
using System.Net.Mail;
namespace StoreUI
{
    public class Validation
    {
        
         public bool IsValidEmail(string emailaddress)
{
    try
    {
        MailAddress m = new MailAddress(emailaddress);

        return true;
    }
    catch (FormatException)
    {
        return false;
    }
}

    }

   
}