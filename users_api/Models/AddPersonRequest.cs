namespace users_api.Models
{
    public class AddPersonRequest
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string identifier { get; set; }
        public string email { get; set; }
        public string type_identifier { get; set; }

    }
}
