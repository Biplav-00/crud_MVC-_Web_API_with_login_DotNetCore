using System.ComponentModel.DataAnnotations;

namespace crud_api.Model
{
    public class User
    {
        [Key]
        public Guid user_Id { get; set; }
        public string user_Name { get; set; }
        public string user_Password { get; set; }
    }
}
