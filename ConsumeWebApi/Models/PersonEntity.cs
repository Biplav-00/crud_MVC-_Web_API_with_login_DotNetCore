using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ConsumeWebApi.Models
{
    public class PersonEntity
    {
        public Guid person_Id { get; set; }
       
        public string person_Name { get; set; }

        
        public string person_Email { get; set; }

        
        public string person_Address { get; set; }

        
        public long person_Phone { get; set; }
    }
}
