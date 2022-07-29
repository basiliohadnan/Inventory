using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public sealed class Product : BaseEntity
    {
        public static StringValidatorWitExceptions stringValidatorWithExceptions = new StringValidatorWitExceptions();
        private static List<Product> products = new List<Product>();
        public string Description { get; private set; }
        public double Price { get; private set; }

        public Product(string description, double price)
        {
            IncrementIdentifier();
            Code = Id;
            Description = description;
            Price = price;
        }

        public static void InvalidCode(int code)
        {
            StandardConsoleMessages.InvalidCode();

            Console.WriteLine();
            Console.WriteLine("Product code:");
            code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
            code = ValidateCode(code);
        }

        public static double ValidatePrice(double price)
        {
            if (price <= 0)
            {
                StandardConsoleMessages.ValueCannotBeZeroOrNegative();

                Console.WriteLine();
                Console.WriteLine("Price:");
                price = Convert.ToDouble(stringValidatorWithExceptions.ValidateString());
                price = ValidatePrice(price);
            }
            return price;
        }

        public static int ValidateCode(int code)
        {
            try
            {
                var product = GetProduct(code);
                if (product != null)
                {
                    return code;
                }
                else
                {
                    InvalidCode(code);
                }
            }
            catch (FormatException)
            {
                InvalidCode(code);
            }
            catch (InvalidOperationException)
            {
                InvalidCode(code);
            }
            catch (NullReferenceException)
            {
                InvalidCode(code);
            }
            catch (Exception)
            {
                StandardConsoleMessages.UnidentifiedErrorOccurred();
            }
            return code;
        }

        public static void CreateProduct()
        {
            Console.WriteLine("Please, register a product.");
            Console.WriteLine();

            Console.WriteLine("Description:");
            var description = stringValidatorWithExceptions.ValidateString();

            Console.WriteLine("Price:");
            var price = Convert.ToDouble(stringValidatorWithExceptions.ValidateString());
            price = ValidatePrice(price);

            var product = new Product(description, price);
            products.Add(product);

            StandardConsoleMessages.ClearConsoleAndSkipALine();
            Console.WriteLine($"Product '{product.Description}' registered!");
            StandardConsoleMessages.PressAnyKeyToReturn();
        }

        public static void GetProducts()
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
            Console.WriteLine("Please, inform the Product Code:");
            int code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
            code = ValidateCode(code);

            var product = GetProduct(code);
            products.Remove(product);

            Console.Clear();
            Console.WriteLine($"Product code {product.Code} removed!");
        }

        public static void UpdateProduct()
        {
            Console.WriteLine("Please, inform the Product Code:");
            int code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
            code = ValidateCode(code);

            var product = GetProduct(code);

            Console.WriteLine("PRODUCT DETAILS:");
            GetProductDetails(product);

            Console.WriteLine("Please, insert new values:");
            Console.WriteLine();

            Console.WriteLine("Description:");
            var description = stringValidatorWithExceptions.ValidateString();
            product.Description = description;

            Console.WriteLine("Price:");
            var price = Convert.ToDouble(stringValidatorWithExceptions.ValidateString());
            ValidatePrice(price);
            product.Price = price;

            StandardConsoleMessages.ClearConsoleAndSkipALine();
            Console.WriteLine($"Product code {product.Code} updated!");
            StandardConsoleMessages.PressAnyKeyToReturn();
        }
    }
}