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
                            Console.WriteLine("Thanks, see you!");
                            break;
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
                            Product.CreateProduct();
                            break;
                        case 2:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Product.GetProductsDetails();
                            break;
                        case 3:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Product.DeleteProduct();
                            break;
                        case 4:
                            StandardConsoleMessages.ClearConsoleAndSkipALine();
                            Product.UpdateProduct();
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
                            Customer.CreateCustomer();
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
