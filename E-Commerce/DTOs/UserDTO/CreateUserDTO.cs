namespace E_Commerce.DTO.UserDTO
{
    public record CreateUserDTO
    {
        public string FirstName { get; set; } = String.Empty;
      
        public string LastName { get; set; } = String.Empty;
     
        public string Email { get; set; } = String.Empty;
     
        public string Password { get; set; } = String.Empty;
       
        public string Phone {  get; set; } = String.Empty;
        
    }
}
