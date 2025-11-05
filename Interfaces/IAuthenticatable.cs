namespace OOP_finalProject.Interfaces
{
    public interface IAuthenticatable
    {
        bool ValidateCredentials(string username, string password);
        string GetRole();
    }
}
