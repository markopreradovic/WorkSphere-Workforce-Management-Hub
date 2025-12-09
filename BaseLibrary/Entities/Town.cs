using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {

        //One to many Relationship with Employees
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

        //Many to One Relationship with City
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
