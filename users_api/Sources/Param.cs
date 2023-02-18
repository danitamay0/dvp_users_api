namespace users_api.Sources
{
    public class Param
    {
        public Param(string name, string value) {        
            this.name = name;
            this.value = value;
        }
    
        public string name { get; set; }
        public string value { get; set; }

        
    }
}
