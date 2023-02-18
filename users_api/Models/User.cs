using System.ComponentModel.DataAnnotations;

namespace users_api.Models
{
    public class User
    {
        public User()
        {
            id = Guid.NewGuid().ToString("N");
        }
        public string id { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public DateTime created_date { get; set; } = DateTime.Now;

    }
}
