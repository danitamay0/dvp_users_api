using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data;
using users_api.Data;
using users_api.Models;
using users_api.Sources;

namespace users_api.Controllers
{
    
    [ApiController]
    [Route("person")]
    public class PersonController
    {
        private readonly DoubleVPartnersDbContext dbContext;

        public PersonController(DoubleVPartnersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("list")]
        public dynamic GetPeople()
        {
            DataTable tPeople = DBData.Listar("get_people");
            string jsonPeople = JsonConvert.SerializeObject(tPeople);
            return new { message = "success", success = true, result = JsonConvert.DeserializeObject<List<PersonResponse>>(jsonPeople) };
        }

        [HttpPost]
        [Route("save")]
        public async Task<dynamic> SavePeople( AddPersonRequest person )
        {

            var newPerson = new Person() { first_name = person.first_name, last_name = person.last_name, identifier = person.identifier, email = person.email, type_identifier= person.type_identifier };

            await dbContext.People.AddAsync(newPerson);
            await dbContext.SaveChangesAsync();

        
            return new { message= true ? "Person added succes" : "Error to add person", success = true};
        }
    }
}
