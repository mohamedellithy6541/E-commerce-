namespace Basket.Core.Entities
{
    public class BasketCheckout
    {
        public string userName { get; set; }
        public decimal TotalPrice { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? AddressLine { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpireDate { get; set; }
        public string? CVV { get; set; }
        public int paymentMethod { get; set; }

    }
}
