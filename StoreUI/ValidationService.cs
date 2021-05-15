using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace StoreUI
{
    public class ValidationService:IValidationService
    {
        
         public string ValidateEmail(string prompt)
{
    bool  repeat;
    string response="";
    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");  
    do{
        Console.WriteLine(prompt);
        response=Console.ReadLine();
        repeat=String.IsNullOrEmpty(response);
    if (repeat)Console.WriteLine("Email field is required");
         
    else
    {
        Match match = regex.Match(response); 
        repeat=match.Success;
     
    if (!repeat)  Console.WriteLine("Invalid Email Address");

      
  
    }


}while (repeat);

return response;

}

 public string ValidateName(string input)
        {
            string response;
            bool repeat;
            do
            {
                Console.WriteLine(input);
                response = Console.ReadLine();
                repeat = String.IsNullOrWhiteSpace(response);
                if (repeat) Console.WriteLine("Please input a non empty string");
            } while (repeat);
            return response;
        }

    }

   
}