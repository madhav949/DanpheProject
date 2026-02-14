namespace HMS.Models
{
    public class Doctor : Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public  StaffRole role {  get; set; }

    }
}
