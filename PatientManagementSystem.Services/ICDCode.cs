namespace PatientManagementSystem.Services
{
    public class ICDCode
    {
        public string Name { get; set; }
        public string[] Inclusions { get; set; }
        public string[] ExcludesOne { get; set; }
        public string[] ExcludesTwo { get; set; }
        public string Description { get; set; }
        public string Valid { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
    }
}
