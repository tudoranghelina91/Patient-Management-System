namespace PatientManagementSystem.Domain
{
    public abstract class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] SSN { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string Email { get; set; }
        public string EmergencyContactNumber { get; set; }
    }
}
