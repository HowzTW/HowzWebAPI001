using System;
using Google.Cloud.Datastore.V1;

namespace HowzWebAPI001.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PersonId { get; set; }
        public string Password { get; set; }

        public Employee()
        {
        }

        public Employee(Entity entity)
        {
            Id = entity.Key.Path[0].Id;
            Name = (string)entity["Name"];
            Password = (string)entity["Password"];
            PersonId = (string)entity["PersonId"];
        }
    }
}
