namespace crud_api.Model
{
    public class UpdatePersonRequest
    {
        public string person_Name { get; set; }

        public string person_Email { get; set; }

        public string person_Address { get; set; }

        public long person_Phone { get; set; }
    }
}
