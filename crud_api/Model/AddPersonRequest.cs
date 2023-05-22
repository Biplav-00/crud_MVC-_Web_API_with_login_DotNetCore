namespace crud_api.Model
{
    public class AddPersonRequest
    {
        public string person_Name { get; set; }

        public string person_Email { get; set; }

        public string person_Address { get; set; }

        public long person_Phone { get; set; }

        //public Device device { get; set; }
    }
}
