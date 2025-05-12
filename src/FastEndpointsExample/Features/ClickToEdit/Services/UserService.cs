public class UserService
{
    public User CurrentUser { get; private set; }

    public UserService()
    {
        CurrentUser = ResetUser();
    }

    public User ResetUser()
    {
        return new User
        {
            Firstname = "John",
            Lastname = "Doe",
            Email = "joe@blow.com"
        };
    }
}