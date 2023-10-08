namespace Core.WebModel.Request
{
    public class UserWebRequest
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set;}
        public string? Email { get; set;}

        // Field only to assign, or search roles
        public string? RoleName { get; set; }
    }
}
