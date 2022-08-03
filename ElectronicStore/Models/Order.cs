using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Order
    {
        public static StringValidator stringValidator = new StringValidator();
        private static List<Order> orders = new List<Order>();
        public List<OrderItem> OrderItems { get; private set; }
        public static int Id { get; private set; }
        public int Code { get; private set; }
        public DateTime EntryDate { get; private set; }
        public int CustomerId { get; private set; }
        public double OrderTotal { get; private set; }

        private static void IncrementIdentifier() => Id++;
        public Order(int customerId, List<OrderItem> orderItems)
        {
            IncrementIdentifier();
            Code = Id;
            EntryDate = DateTime.Now;
            CustomerId = customerId;
            OrderItems = orderItems;
        }

        public static double CalculateTotal(List<OrderItem> OrderItems)
        {
            double total = 0;
            OrderItems.ForEach(orderItem => total += orderItem.Quantity * orderItem.ProductPrice);
            return total;
        }

        public static int GetOrdersCount() => orders.Count();

        public static List<Order> GetOrders() => orders;

        public static Order GetOrder(int code) => orders.First(order => order.Code == code);

        public static void GetOrderDetails(Order order)
        {
            Console.WriteLine($"Order code: {order.Code}");
            Console.WriteLine($"Create date: {order.EntryDate}");
            Console.WriteLine($"Customer code: {order.CustomerId}");
            Console.WriteLine();

            Console.WriteLine($"PRODUCTS:");
            order.OrderItems.ForEach(orderItem => OrderItem.GetOrderItemDetails(orderItem));

            Console.WriteLine($"TOTAL: R${order.OrderTotal.ToString("0.00")}");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }

        public static void CreateOrder()
        {
            if (Product.GetProductsCount() < 1)
                StandardConsoleMessages.EmptyList("Products");
            else if (Customer.GetCustomersCount() < 1)
                StandardConsoleMessages.EmptyList("Customers");
            else if (Inventory.GetInventoryCount() < 1)
                StandardConsoleMessages.EmptyList("Inventory");
            else
            {
                Console.WriteLine("Customer code:");
                int customerCode = Convert.ToInt32(stringValidator.ValidateString());
                customerCode = CodeValidator.ValidateCode(customerCode, "Customer");

                var orderItems = new List<OrderItem>();
                var order = new Order(customerCode, orderItems);
                var keepAsking = true;

                while (keepAsking)
                {
                    try
                    {
                        Console.WriteLine("1. Insert product");
                        Console.WriteLine("2. Finish order");

                        var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                        Console.WriteLine();

                        switch (keyPressed)
                        {
                            case 1:
                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine("Product code:");
                                int productCode = Convert.ToInt32(stringValidator.ValidateString());
                                productCode = CodeValidator.ValidateCode(productCode, "Product");

                                Console.WriteLine("Quantity:");
                                int quantity = Convert.ToInt32(stringValidator.ValidateString());
                                var orderItem = new OrderItem(quantity, productCode, Id);
                                orderItems.Add(orderItem);
                                order.OrderTotal = CalculateTotal(orderItems);

                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine($"{quantity}x product code '{productCode}' added to the order!");
                                StandardConsoleMessages.PressAnyKeyToReturn();
                                break;
                            case 2:
                                if (order.OrderItems.Count() > 0)
                                {
                                    orders.Add(order);
                                    StandardConsoleMessages.ClearConsoleAndSkipALine();
                                    Console.WriteLine($"Order code {order.Code} created!");
                                    StandardConsoleMessages.PressAnyKeyToReturn();
                                    keepAsking = false;
                                    break;
                                }
                                else
                                {
                                    StandardConsoleMessages.ClearConsoleAndSkipALine();
                                    Console.WriteLine($"You can't create an empty order!");
                                    StandardConsoleMessages.PressAnyKeyToReturn();
                                    break;
                                }
                            default:
                                StandardConsoleMessages.InvalidOption();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        StandardConsoleMessages.InvalidFormat();
                        continue;
                    }
                    catch (NullReferenceException)
                    {
                        StandardConsoleMessages.InvalidOption();
                        continue;
                    }
                    catch (Exception)
                    {
                        StandardConsoleMessages.UnidentifiedErrorOccurred();
                        continue;
                    }
                }

            }

        }

        public static void GetOrdersDetails()
        {
            Console.WriteLine($"Orders: {orders.Count()}");
            Console.WriteLine();

            orders.ForEach(order => GetOrderDetails(order));
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static void DeleteOrder()
        {
            if (orders.Count > 0)
            {
                Console.WriteLine("Order code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = CodeValidator.ValidateCode(code, "Order");
                var order = GetOrder(code);
                orders.Remove(order);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Order code {order.Code} removed!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Orders");
        }

        public static void UpdateOrder()
        {
            if (orders.Count > 0)
            {
                Console.WriteLine("Order code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = CodeValidator.ValidateCode(code, "Order");
                var order = GetOrder(code);

                Console.WriteLine("ORDER DETAILS:");
                GetOrderDetails(order);

                var orderItems = order.OrderItems;
                var keepAsking = true;

                while (keepAsking)
                {
                    try
                    {
                        Console.WriteLine("1. Insert product");
                        Console.WriteLine("2. Remove product");
                        Console.WriteLine("3. Finish order");

                        var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                        Console.WriteLine();

                        switch (keyPressed)
                        {
                            case 1:
                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine("Product code:");
                                int productCode = Convert.ToInt32(stringValidator.ValidateString());
                                productCode = CodeValidator.ValidateCode(productCode, "Product");

                                Console.WriteLine("Quantity:");
                                int quantity = Convert.ToInt32(stringValidator.ValidateString());
                                var orderItem = new OrderItem(quantity, productCode, Id);
                                orderItems.Add(orderItem);
                                order.OrderTotal = CalculateTotal(orderItems);

                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine($"{quantity}x product code '{productCode}' added to the order!");
                                StandardConsoleMessages.PressAnyKeyToReturn();
                                break;
                            case 2:
                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine("Order item code:");
                                int orderItemCode = Convert.ToInt32(stringValidator.ValidateString());
                                orderItemCode = CodeValidator.ValidateCode(orderItemCode, "OrderItem");

                                var orderItemToBeRemoved = OrderItem.GetOrderItem(orderItemCode);
                                order.OrderItems.Remove(orderItemToBeRemoved);
                                order.OrderTotal = CalculateTotal(orderItems);

                                //OrderItem.orderItemList.Remove(orderItem);

                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine($"Order item code '{orderItemCode}' removed from the order!");
                                StandardConsoleMessages.PressAnyKeyToReturn();
                                break;
                            case 3:
                                if (order.OrderItems.Count() > 0)
                                {
                                    StandardConsoleMessages.ClearConsoleAndSkipALine();
                                    Console.WriteLine($"Order code {order.Code} updated!");
                                    StandardConsoleMessages.PressAnyKeyToReturn();
                                    keepAsking = false;
                                    break;
                                }
                                else
                                {
                                    StandardConsoleMessages.ClearConsoleAndSkipALine();
                                    Console.WriteLine($"You can't create an empty order!");
                                    StandardConsoleMessages.PressAnyKeyToReturn();
                                    break;
                                }
                            default:
                                StandardConsoleMessages.InvalidOption();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        StandardConsoleMessages.InvalidFormat();
                        continue;
                    }
                    catch (NullReferenceException)
                    {
                        StandardConsoleMessages.InvalidOption();
                        continue;
                    }
                    catch (Exception)
                    {
                        StandardConsoleMessages.UnidentifiedErrorOccurred();
                        continue;
                    }
                }
            }
            else
                StandardConsoleMessages.EmptyList("Order");
        }
    }
}