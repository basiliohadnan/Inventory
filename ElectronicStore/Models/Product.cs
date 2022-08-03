using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Product
    {
        public static StringValidator stringValidator = new StringValidator();
        private static List<Product> products = new List<Product>();
        public string Description { get; private set; }
        public double Price { get; private set; }
        public static int Id { get; private set; }
        public int Code { get; private set; }

        private static void IncrementIdentifier() => Id++;
        public Product(string description, double price)
        {
            IncrementIdentifier();
            Code = Id;
            Description = description;
            Price = price;
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

        public static void CreateProduct()
        {
            Console.WriteLine("Description:");
            var description = stringValidator.ValidateString();

            Console.WriteLine("Price:");
            var price = Convert.ToDouble(stringValidator.ValidateString());
            price = ValidatePrice(price);

            var product = new Product(description, price);
            products.Add(product);

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

        public static void DeleteProduct()
        {
            if (products.Count > 0)
            {
                Console.WriteLine("Please, inform the Product Code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = CodeValidator.ValidateCode(code, "Product");
                var product = GetProduct(code);
               
                products.Remove(product);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Product code {product.Code} removed!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Products");
        }

        public static void UpdateProduct()
        {
            if (products.Count > 0)
            {
                Console.WriteLine("Product code:");
                int code = Convert.ToInt32(stringValidator.ValidateString());
                code = CodeValidator.ValidateCode(code, "Product");
                var product = GetProduct(code);

                Console.WriteLine("PRODUCT DETAILS:");
                GetProductDetails(product);

                Console.WriteLine("Please, insert new values:");
                Console.WriteLine("Description:");
                var description = stringValidator.ValidateString();
                product.Description = description;

                Console.WriteLine("Price:");
                var price = Convert.ToDouble(stringValidator.ValidateString());
                ValidatePrice(price);
                product.Price = price;

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Product code {product.Code} updated!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
                StandardConsoleMessages.EmptyList("Products");
        }
    }
}