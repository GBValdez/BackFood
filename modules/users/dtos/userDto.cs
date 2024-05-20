
namespace project.users.dto
{
    public class userDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public Boolean isActive { get; set; }
        public List<string> roles { get; set; }
        public string address { get; set; }
        public string token { get; set; }

    }
}