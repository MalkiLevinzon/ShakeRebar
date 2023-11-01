using Rebar.DataAccess;

namespace Rebar.Modles
{
    public class InvoiceModle
    {
        public List<OrderModle>? Orders  { get; set; }
        public int Total { get; set; }
        public InvoiceModle()
        {
            OrderAccess db = new();
            var allOrders = db.GetAllOrders().Result;
            List<OrderModle> orders = new();
            foreach (var order in allOrders)
            {
                if (order.DateOfOrder.Date == DateTime.Today)
                    orders.Add(order);
            }
            if (orders != null)
            {
                int sum = 0;
                orders.ForEach(o => sum += o.TotalPrice);
                orders.ForEach(o => sum -= o.Sale);
                Orders = orders;

                Total = sum;

            }
            else { Total = 0; }
        }
        public void ClosingTheCheckout()
        {
            var password = "2113335";
            string? passInput;
            Console.WriteLine("Enter administrator password");
            passInput = Console.ReadLine();

            while (password != passInput)
            {
                Console.WriteLine("The password is wrong!");
                passInput = Console.ReadLine();

            }
            if (Orders != null) {
                Console.WriteLine($"Today there were {Orders.Count()} orders" );
                Console.WriteLine($"The amount entered today is: {Total}");
        } 
            else Console.WriteLine("There were no orders today");
        }
        

    }
}
