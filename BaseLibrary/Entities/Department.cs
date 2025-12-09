using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        //Many to One Relationship with GeneralDepartment
        public int GeneralDepartmentId { get; set; }
        public GeneralDepartment? GeneralDepartment { get; set; }

        // One to Many Relationship with Branches
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
