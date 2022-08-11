using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class OrderItem
    {
        public static StringValidator stringValidator = new StringValidator();
        
        private static List<OrderItem> orderItemList = new List<OrderItem>();
        public static int Id { get; private set; }
        public int Code { get; private set; }
        public int Quantity { get; private set; }
        public int ProductCode { get; private set; }
        public double ProductPrice { get; private set; }
        public int OrderId { get; private set; }

        private static void IncrementIdentifier() => Id++;
        public OrderItem(int quantity, int productCode, int orderId)
        {
            IncrementIdentifier();
            Code = Id;
            Quantity = quantity;
            ProductCode = productCode;
            OrderId = orderId;
            ProductPrice = Product.GetProduct(productCode).Price;
            orderItemList.Add(this);
        }

        public static void GetOrderItemDetails()
        {
            Console.WriteLine($"Order items: {orderItemList.Count()}");
            Console.WriteLine();

            orderItemList.ForEach(orderItem => GetOrderItemDetails(orderItem));
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static OrderItem GetOrderItem(int code) => orderItemList.First(orderItem => orderItem.Code == code);
        public static void GetOrderItemDetails(OrderItem orderItem)
        {
            Console.WriteLine($"Ordem item code: {orderItem.Code}");
            Console.WriteLine($"Product code: {orderItem.ProductCode}. {Product.GetProduct(orderItem.ProductCode).Description}");
            Console.WriteLine($"Product price: {orderItem.ProductPrice}");
            Console.WriteLine($"Quantity: {orderItem.Quantity}");
            Console.WriteLine();
        }

        public static void DeleteOrderItem()
        {
            if (orderItemList.Count > 0)
            {
                Console.WriteLine("Order item code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValueValidator.ValidateCode(code, "Order Item");

                var orderItem = GetOrderItem(code);
                orderItemList.Remove(orderItem);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Order item code {orderItem.Code} removed!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Ordem Item");
        }
    }
}