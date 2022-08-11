using ElectronicStore.Models;

namespace ElectronicStore.Utils
{
    public class ValueValidator
    {
        public static StringValidator stringValidator = new StringValidator();
        public static int ValidateCode(int code, string entity)
        {
            try
            {
                switch (entity)
                {
                    case "Inventory":
                        var inventoryEntry = Inventory.GetInventoryEntry(code);
                        if (inventoryEntry != null)
                            return code;
                        else
                            throw new InvalidOperationException();
                    case "Product":
                        var product = Product.GetProduct(code);
                        if (product != null)
                            return code;
                        else
                            throw new InvalidOperationException();
                    case "Customer":

                        var customer = Customer.GetCustomer(code);
                        if (customer != null)
                            return code;
                        else
                            throw new InvalidOperationException();
                    case "Order":
                        var order = Order.GetOrder(code);
                        if (order != null)
                            return code;
                        else
                            throw new InvalidOperationException();
                    case "OrderItem":
                        var orderItem = OrderItem.GetOrderItem(code);
                        if (orderItem != null)
                            return code;
                        else
                            throw new InvalidOperationException();
                    default:
                        return code;
                }
            }
            catch (InvalidOperationException)
            {
                StandardConsoleMessages.InvalidCode();

                Console.WriteLine();
                Console.WriteLine($"Please, inform the {entity} code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            catch (NullReferenceException)
            {
                StandardConsoleMessages.InvalidCode();

                Console.WriteLine();
                Console.WriteLine($"Please, inform the {entity} code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            catch (Exception)
            {
                StandardConsoleMessages.UnidentifiedErrorOccurred();

                Console.WriteLine();
                Console.WriteLine($"Please, inform the {entity} code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            return code;
        }

        public static int ValidateQuantity(int qty)
        {
            while (true)
            {
                try
                {
                    if (qty > 0)
                        return qty;

                    StandardConsoleMessages.ValueCannotBeZeroOrNegative();

                    Console.WriteLine();
                    Console.WriteLine("Quantity:");
                    qty = Convert.ToInt32(stringValidator.ValidateString());
                    qty = ValidateQuantity(qty);
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.InvalidFormat();
                    continue;
                }
                catch (InvalidOperationException)
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

        public static double ValidatePrice(double price)
        {
            while (true)
            {
                try
                {
                    if (price > 0)
                        return price;

                    StandardConsoleMessages.ValueCannotBeZeroOrNegative();

                    Console.WriteLine();
                    Console.WriteLine("Price:");
                    price = Convert.ToDouble(stringValidator.ValidateString());
                    price = ValidatePrice(price);
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.InvalidFormat();
                    continue;
                }
                catch (InvalidOperationException)
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
}
