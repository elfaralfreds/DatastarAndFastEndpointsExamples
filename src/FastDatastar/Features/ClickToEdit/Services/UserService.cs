public class UserService
{
    public static User CurrentUser { get; internal set; }

    static UserService()
    {
        CurrentUser = ResetUser();
    }

    public static User ResetUser()
    {
        return new User
        {
            Firstname = "John",
            Lastname = "Doe",
            Email = "joe@blow.com"
        };
    }
}