namespace Domain.Persistence
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int ShoppingBagID { get; set; }

        public Product Product { get; set; }
        public ShoppingBag ShoppingBag { get; set; }
    }
}
