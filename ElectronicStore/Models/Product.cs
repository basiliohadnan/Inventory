using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Product
    {
        public static StringValidator stringValidator = new StringValidator();
        private static List<Product> products = new List<Product>();
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new InvalidDataException("Description must be filled.");
                else
                    _description = value;
            }
        }
        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (value <= 0)
                    throw new InvalidDataException("Value cannot be zero or negative.");
                else
                    _price = value;
            }
        }
        public static int Id { get; private set; }
        public int Code { get; private set; }

        private static void IncrementIdentifier() => Id++;
        public Product(string description, double price)
        {
            IncrementIdentifier();
            Code = Id;
            Description = description;
            Price = price;
            products.Add(this);
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

        public static void CreateProduct(string description, double price)
        {
            var product = new Product(description, price);

            StandardConsoleMessages.ClearConsoleAndSkipALine();
            Console.WriteLine($"Product '{product.Description}' registered!");
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static int GetProductsCount() => products.Count();

        public static List<Product> GetProducts() => products;

        public static void GetProductsDetails()
        {
            Console.WriteLine($"Products: {products.Count()}");
            Console.WriteLine();

            products.ForEach(product => GetProductDetails(product));
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static Product GetProduct(int code) => products.First(product => product.Code == code);
        public static void GetProductDetails(Product product)
        {
            Console.WriteLine($"Product code: {product.Code}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: R${product.Price.ToString("0.00")}");
            Console.WriteLine();
        }

        public static bool DeleteProduct(int code)
        {
            if (products.Count > 0)
            {
                var product = GetProduct(code);
                products.Remove(product);

                //StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Product code {product.Code} removed!");
                //StandardConsoleMessages.PressAnyKeyToReturn();
                return true;
            }
            else
            {
                StandardConsoleMessages.EmptyList("Products");
                return false;
            }

        }

        public static bool UpdateProduct(int code, string description, double price)
        {
            if (products.Count > 0)
            {
                var product = GetProduct(code);
                product.Description = description;
                product.Price = price;

                //StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Product code {product.Code} updated!");
                //StandardConsoleMessages.PressAnyKeyToReturn();
                return true;
            }
            else
            {
                StandardConsoleMessages.EmptyList("Products");
                return false;
            }
        }
    }
}