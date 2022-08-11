using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Menu
    {
        public static StringValidator stringValidator = new StringValidator();

        public static void MainMenuOptions()
        {
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("4. Orders");
            Console.WriteLine("9. Quit");
        }

        public static void MainMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();
                    MainMenuOptions();

                    var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            ProductsMenu();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            CustomersMenu();
                            break;
                        case 3:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            InventoryMenu();
                            break;
                        case 4:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            OrdersMenu();
                            break;
                        case 9:
                            keepAsking = false;
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            ColourChanger.BlueText();
                            Console.WriteLine("Thanks, see you!");
                            ColourChanger.WhiteText();
                            break;
                        default:
                            StandardConsoleMessages.InvalidOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.ClearConsoleAndSkipALine();
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

        public static void ProductsMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();

                    Console.WriteLine("1. Register a product");
                    Console.WriteLine("2. See product list");
                    Console.WriteLine("3. Delete a product");
                    Console.WriteLine("4. Alter a product");
                    Console.WriteLine("9. Return the main menu");

                    var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Console.WriteLine("Description:");
                            var description = stringValidator.ValidateString();
                            Console.WriteLine("Price:");
                            var price = Convert.ToDouble(stringValidator.ValidateString());
                            price = ValueValidator.ValidatePrice(price);

                            Product.CreateProduct(description, price);
                            StandardConsoleMessages.PressAnyKeyToReturn();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Product.GetProductsDetails();
                            break;
                        case 3:
                            if (Product.GetProductsCount() > 0)
                            {
                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine("Product code:");
                                var code = Convert.ToInt32(stringValidator.ValidateString());
                                code = ValueValidator.ValidateCode(code, "Product");

                                Product.DeleteProduct(code);
                                StandardConsoleMessages.PressAnyKeyToReturn();
                            }
                            else
                                StandardConsoleMessages.EmptyList("Products");
                            break;
                        case 4:
                            if (Product.GetProductsCount() > 0)
                            {
                                StandardConsoleMessages.ClearConsoleAndSkipALine();
                                Console.WriteLine("Product code:");
                                var code = Convert.ToInt32(stringValidator.ValidateString());
                                code = ValueValidator.ValidateCode(code, "Product");

                                Console.Clear();
                                ColourChanger.BlueText();
                                Console.WriteLine("PRODUCT DETAILS");
                                ColourChanger.WhiteText();

                                var product = Product.GetProduct(code);
                                Product.GetProductDetails(product);

                                ColourChanger.BlueText();
                                Console.WriteLine("Please, insert new values:");
                                ColourChanger.WhiteText();
                                Console.WriteLine("Description:");
                                description = stringValidator.ValidateString();

                                Console.WriteLine("Price:");
                                price = Convert.ToDouble(stringValidator.ValidateString());
                                ValueValidator.ValidatePrice(price);

                                Product.UpdateProduct(product, description, price);
                                StandardConsoleMessages.PressAnyKeyToReturn();
                            }
                            else
                                StandardConsoleMessages.EmptyList("Products");
                            break;
                        case 9:
                            keepAsking = false;
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            break;
                        default:
                            StandardConsoleMessages.InvalidOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.ClearConsoleAndSkipALine();
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

        public static void CustomersMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();

                    Console.WriteLine("1. Register a customer");
                    Console.WriteLine("2. See customer list");
                    Console.WriteLine("3. Delete a customer");
                    Console.WriteLine("4. Alter a customer");
                    Console.WriteLine("9. Return the main menu");

                    var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Console.WriteLine("Name:");
                            var name = stringValidator.ValidateString();

                            Console.WriteLine("CPF:");
                            var cpf = stringValidator.ValidateString();

                            Console.WriteLine("Subscriber:");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            var subscriber = Customer.SaveAsBoolean(Convert.ToInt32(stringValidator.ValidateString()));

                            Console.WriteLine("Phone 1:");
                            var phone1 = stringValidator.ValidateString();

                            Console.WriteLine("Phone 2:");
                            var phone2 = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("E-mail:");
                            var email = Person.ValidateEmail();

                            Customer.CreateCustomer(name, cpf, subscriber, phone1, phone2, email);
                            StandardConsoleMessages.PressAnyKeyToReturn();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Customer.GetCustomersDetails();
                            break;
                        case 3:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Customer.DeleteCustomer();
                            break;
                        case 4:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Customer.UpdateCustomer();
                            break;
                        case 9:
                            keepAsking = false;
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            break;
                        default:
                            StandardConsoleMessages.InvalidOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.ClearConsoleAndSkipALine();
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

        public static void InventoryMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();

                    Console.WriteLine("1. Register an entry");
                    Console.WriteLine("2. See inventory list");
                    Console.WriteLine("3. Delete an entry");
                    Console.WriteLine("9. Return the main menu");

                    var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Inventory.CreateInventoryEntry();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Inventory.GetInventoryEntries();
                            break;
                        case 3:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Inventory.DeleteInventoryEntry();
                            break;
                        case 9:
                            keepAsking = false;
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            break;
                        default:
                            StandardConsoleMessages.InvalidOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.ClearConsoleAndSkipALine();
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

        public static void OrdersMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();

                    Console.WriteLine("1. Register an order");
                    Console.WriteLine("2. See order list");
                    Console.WriteLine("3. Delete an order");
                    Console.WriteLine("4. Update an order");
                    Console.WriteLine("9. Return the main menu");

                    var keyPressed = Convert.ToInt32(stringValidator.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Order.CreateOrder();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Order.GetOrdersDetails();
                            break;
                        case 3:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Order.DeleteOrder();
                            break;
                        case 4:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Order.UpdateOrder();
                            break;
                        case 9:
                            keepAsking = false;
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            break;
                        default:
                            StandardConsoleMessages.InvalidOption();
                            break;
                    }
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.ClearConsoleAndSkipALine();
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
}
