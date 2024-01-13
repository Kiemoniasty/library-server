namespace Library_WebServer.Models.Requests.Login
{
    public class LoginRequestBaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginRequestBaseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public LoginRequestBaseModel(
            string firstName,
            string lastName)
        {
            Name = firstName;
            Password = lastName;
        }
    }
}
