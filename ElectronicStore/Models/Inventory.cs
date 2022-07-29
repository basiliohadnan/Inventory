using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public sealed class Inventory : BaseEntity
    {
        public static StringValidatorWitExceptions stringValidatorWithExceptions = new StringValidatorWitExceptions();
        private static List<Inventory> inventoryList = new List<Inventory>();
        public int ProductCode { get; private set; }
        public int Quantity { get; private set; }
        public DateTime EntryDate { get; private set; }

        public Inventory(int productCode, int quantity)
        {
            IncrementIdentifier();
            Code = Product.Id;
            ProductCode = productCode;
            Quantity = quantity;
            EntryDate = new DateTime();
        }

        public static int ValidateQuantity(int quantity)
        {

            if (quantity <= 0)
            {
                StandardConsoleMessages.ValueCannotBeZeroOrNegative();

                Console.WriteLine();
                Console.WriteLine("Quantity:");
                quantity = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                quantity = ValidateQuantity(quantity);
            }
            return quantity;
        }

        public static void GetInventoryEntries()
        {
            Console.WriteLine($"Inventory entries: {inventoryList.Count()}");
            Console.WriteLine();

            inventoryList.ForEach(inventory => GetInventoryDetails(inventory));
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static Inventory GetInventoryEntry(int code) => inventoryList.First(inventory => inventory.Code == code);

        public static void GetInventoryDetails(Inventory inventory)
        {
            Console.WriteLine($"Inventory code: {inventory.Code}");
            Console.WriteLine($"Quantity: {inventory.Quantity}");

            var product = Product.GetProduct(inventory.ProductCode);
            Product.GetProductDetails(product);
        }
        public static int ValidateCode(int code)
        {
            try
            {
                var inventoryEntry = GetInventoryEntry(code);
                if (inventoryEntry != null)
                {
                    return code;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            catch (InvalidOperationException)
            {
                StandardConsoleMessages.InvalidCode();

                Console.WriteLine();
                Console.WriteLine("Please, inform the entry code:");
                code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                code = ValidateCode(code);
            }
            catch (Exception)
            {
                StandardConsoleMessages.UnidentifiedErrorOccurred();
            }
            return code;
        }

        public static void CreateInventoryEntry()
        {
            Console.WriteLine("Product code:");
            var productCode = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
            productCode = Product.ValidateCode(productCode);

            Console.WriteLine("Quantity:");
            var quantity = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
            quantity = ValidateQuantity(quantity);

            var inventoryEntry = new Inventory(productCode, quantity);
            inventoryList.Add(inventoryEntry);

            StandardConsoleMessages.ClearConsoleAndSkipALine();
            Console.WriteLine($"New entry of the product code '{inventoryEntry.ProductCode}' registered!");
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static void DeleteInventoryEntry()
        {
            Console.WriteLine("Please, inform the entry code:");
            int code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());

            try
            {
                var inventoryEntry = GetInventoryEntry(code);
                inventoryList.Remove(inventoryEntry);

                Console.Clear();
                Console.WriteLine($"Invetory entry code {inventoryEntry.Code} removed!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            catch (InvalidOperationException)
            {
                StandardConsoleMessages.InvalidCode();
            }
            catch (NullReferenceException)
            {
                StandardConsoleMessages.InvalidCode();
            }
            catch (Exception)
            {
                StandardConsoleMessages.UnidentifiedErrorOccurred();
            }
        }
    }
}

//public static void UpdateInventory()
//{
//    Console.WriteLine("Please, inform the Inventory Code:");
//    var code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());

//    try
//    {
//        var inventory = GetInventory(code);
//        StandardConsoleMessages.ClearConsoleAndSkipALine();

//        Console.WriteLine("PRODUCT DETAILS:");
//        GetInventoryDetails(inventory);

//        Console.WriteLine("Please, insert new values:");
//        Console.WriteLine();

//        Console.WriteLine("Description:");
//        var description = stringValidatorWithExceptions.ValidateString();
//        inventory.Description = description;

//        Console.WriteLine("Price:");
//        var price = Convert.ToDouble(stringValidatorWithExceptions.ValidateString());
//        ValidatePrice(price);
//        inventory.Price = price;

//        StandardConsoleMessages.ClearConsoleAndSkipALine();
//        Console.WriteLine($"Inventory code {inventory.Code} updated!");
//        StandardConsoleMessages.PressAnyKeyToReturn();
//    }
//    catch (InvalidOperationException)
//    {
//        StandardConsoleMessages.InvalidCode();
//    }
//    catch (Exception)
//    {
//        StandardConsoleMessages.UnidentifiedErrorOccurred();
//    }
//}
