using System.ComponentModel.DataAnnotations;

namespace crud_api.Model
{
    public class Device
    {
        [Key]
        public int device_Id { get; set; }
        public string device_Name { get; set; }
    }


}
