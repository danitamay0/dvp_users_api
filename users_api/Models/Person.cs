using System.ComponentModel.DataAnnotations;

namespace users_api.Models
{
    public class Person
    {
        public Person()
        {
            id = Guid.NewGuid().ToString("N");
        }
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string identifier { get; set; }
        public string email { get; set; }
        public string type_identifier { get; set; }

        public DateTime created_date { get; set; } = DateTime.Now;


    }
}
