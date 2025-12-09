using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        //Many to One Relationship with Country
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        // One to Many Relationship with Towns
        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}
