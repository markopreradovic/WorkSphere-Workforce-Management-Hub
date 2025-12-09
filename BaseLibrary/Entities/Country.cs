

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        //One to Many Relationship with Cities
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
