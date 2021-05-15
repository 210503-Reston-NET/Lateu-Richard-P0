namespace StoreUI
{
    public interface IValidationService
    {
         string ValidateEmail(string emailaddress);
         string ValidateName(string input);
    }
}