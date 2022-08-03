using ElectronicStore.Models;

namespace ElectronicStore.Utils
{
    public class CodeValidator
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
                Console.WriteLine("Please, inform the entry code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            catch (NullReferenceException)
            {
                StandardConsoleMessages.InvalidCode();

                Console.WriteLine();
                Console.WriteLine("Please, inform the entry code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            catch (Exception)
            {
                StandardConsoleMessages.UnidentifiedErrorOccurred();

                Console.WriteLine();
                Console.WriteLine("Please, inform the entry code:");
                code = Convert.ToInt32(stringValidator.ValidateString());
                code = ValidateCode(code, entity);
            }
            return code;
        }
    }
}
