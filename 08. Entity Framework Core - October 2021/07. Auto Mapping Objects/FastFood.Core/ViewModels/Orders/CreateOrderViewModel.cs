namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public Dictionary<int, string> Items { get; set; }

        public Dictionary<int, string> Employees { get; set; }
    }
}
