namespace AphasiaClientApp.Models.Management
{
    public class PatientExerciseModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string ImageSrc { get; set; }
        public string Name { get; set; }
    }
}
