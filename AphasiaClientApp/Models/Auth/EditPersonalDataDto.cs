namespace AphasiaClientApp.Models.Auth
{
    public class EditPersonalDataDto
    {

         
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Email { get; set; }

        public string City { get; set; }
        public string HouseNbr { get; set; }
        public string PhoneNumber { get; set; }     
        public string PostalCode  { get; set; }
        public string Street { get; set; }
          
    }
}
