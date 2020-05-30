namespace CoinappStation.models
{
    public class CurrentUser
    {
        public string FirebaseToken { get; set; }
        public string LocalId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string FederatedId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmailVerified { get; set; } 
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
    }
}
