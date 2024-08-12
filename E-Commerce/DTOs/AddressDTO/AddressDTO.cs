namespace E_Commerce.DTO.AddressDTO {
    public record AddressDTO {
        public string Country { get; set; } = String.Empty;

        public string City { get; set; } = String.Empty;

        public string Region { get; set; } = String.Empty;

        public string PostalCode { get; set; } = String.Empty;
        
        public string Phone { get; set; } = String.Empty;
    }
    
}