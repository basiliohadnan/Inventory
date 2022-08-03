using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Inventory
    {
        public static StringValidator stringValidator = new StringValidator();
        private static List<Inventory> inventoryList = new List<Inventory>();
        public int ProductCode { get; private set; }
        public int Quantity { get; private set; }
        public DateTime EntryDate { get; private set; }
        public static int Id { get; private set; }
        public int Code { get; private set; }

        private static void IncrementIdentifier() => Id++;

        public Inventory(int productCode, int quantity)
        {
            IncrementIdentifier();
            Code = Id;
            ProductCode = productCode;
            Quantity = quantity;
            EntryDate = DateTime.Now;
        }

        public static int ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                StandardConsoleMessages.ValueCannotBeZeroOrNegative();

                Console.WriteLine("Quantity:");
                quantity = Convert.ToInt32(stringValidator.ValidateString());
                quantity = ValidateQuantity(quantity);
            }
            return quantity;
        }

        public static void CreateInventoryEntry()
        {
            if (Product.GetProducts().Count > 0)
            {
                Console.WriteLine("Product code:");
                var productCode = Convert.ToInt32(stringValidator.ValidateString());
                var product = Product.GetProduct(productCode);
                productCode = product.Code;

                Console.WriteLine("Quantity:");
                var quantity = Convert.ToInt32(stringValidator.ValidateString());
                quantity = ValidateQuantity(quantity);

                var inventoryEntry = new Inventory(productCode, quantity);
                inventoryList.Add(inventoryEntry);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"New entry of the product code '{inventoryEntry.ProductCode}' registered!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Products");
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
            Console.WriteLine($"Entry date: {inventory.EntryDate}");
            Console.WriteLine($"Quantity: {inventory.Quantity}");
            var product = Product.GetProduct(inventory.ProductCode);
            Product.GetProductDetails(product);
        }

        public static void DeleteInventoryEntry()
        {
            if (inventoryList.Count() > 0)
            {
                Console.WriteLine("Please, inform the entry code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = CodeValidator.ValidateCode(code, "Inventory");
                var inventoryEntry = GetInventoryEntry(code);

                inventoryList.Remove(inventoryEntry);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Invetory entry code {inventoryEntry.Code} removed!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Inventory");
        }

        public static int GetInventoryCount() => inventoryList.Count();

        public static List<Inventory> GetInventoryList() => inventoryList;
    }
}