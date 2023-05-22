
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crud_api.Model
{
    public class Person
    {

        [Key]
        [Display(Name = "ID")]
        public Guid person_Id { get; set; }
        [Display(Name = "Name")]
        public string person_Name { get; set; }

        [Display(Name = "Email")]
        public string person_Email { get; set; }

        [Display(Name = "Address")]
        public string person_Address { get; set; }

        [Display(Name = "Phone")]
        public long person_Phone { get; set; }

       /* public int device_Id { get; set; }

         public Device Device { get; set; }*/
           



    }
    
}
