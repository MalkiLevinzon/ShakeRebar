namespace Rebar.Modles
{
    public class Invoice
    {
        public List<OrderModle>? Orders  { get; set; }
        public int Total { get; set; }
        public Invoice(List<OrderModle> orders)
        {
        Orders = orders;
            int sum = 0;
         orders.ForEach(item => sum += item.TotalPrice);
            Total = sum;
        
        }
    }
}
