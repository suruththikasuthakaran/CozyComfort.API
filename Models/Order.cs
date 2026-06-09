namespace CozyComfort.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BlanketId { get; set; }
        public Blanket Blanket { get; set; }
        
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        
        public int Quantity { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Fulfilled", "Rejected"
    }
}
