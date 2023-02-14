namespace App.Models
{
    public class UserProfile
    {
        public string nickname { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string updated_at { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }
        public string sub { get; set; }
    }
}
