namespace BPKB.Models
{
    public class UserModel
    {
        public  string Username { get; set; }
        public string Password { get; set; }
        public List<string> ValidationMessages { get; set; }
    }
}
