namespace AphasiaClientApp.Models.MainPanel
{
    public class PatientMainPanelResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public string Id { get; set; }  
        public string DId { get; set; } 
        public string Name { get; set; }    
        public string SurrName { get; set; }    
    }
}
