using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public class Menu
    {
        public static StringValidatorWithExceptions stringValidatorWithExceptions = new StringValidatorWithExceptions();

        public static void ShowMainMenuOptions()
        {
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Inventory");
            Console.WriteLine("9. Quit");
        }
        public static void ShowMainMenu()
        {
            var keepAsking = true;

            while (keepAsking)
            {
                try
                {
                    StandardConsoleMessages.MainInfo();
                    ShowMainMenuOptions();

                    var keyPressed = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            Console.Clear();
                            ShowProductMenu();
                            break;
                        case 2:
                            Console.Clear();
                            ShowCustomersMenu();
                            break;
                        case 3:
                            Console.Clear();
                            ShowInventoryMenu();
                            break;
                        case 9:
                            keepAsking = false;
                            Console.Clear();
                            Console.WriteLine("Thanks, see you!");
                            Console.ReadLine();
                            StandardConsoleMessages.PressAnyKeyToReturn();
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

        public static void ShowProductMenu()
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

                    var keyPressed = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            Console.Clear();
                            Product.CreateProduct();
                            break;
                        case 2:
                            Console.Clear();
                            Product.GetProducts();
                            break;
                        case 3:
                            Console.Clear();
                            Product.DeleteProduct();
                            break;
                        case 4:
                            Console.Clear();
                            Product.UpdateProduct();
                            break;
                        case 9:
                            keepAsking = false;
                            Console.Clear();
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

        public static void ShowCustomersMenu()
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

                    var keyPressed = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            Console.Clear();
                            Customer.CreateCustomer();
                            break;
                        case 2:
                            Console.Clear();
                            Customer.GetCustomers();
                            break;
                        case 3:
                            Console.Clear();
                            Customer.DeleteCustomer();
                            break;
                        case 4:
                            Console.Clear();
                            Customer.UpdateCustomer();
                            break;
                        case 9:
                            keepAsking = false;
                            Console.Clear();
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
        public static void ShowInventoryMenu()
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

                    var keyPressed = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());
                    Console.WriteLine();

                    switch (keyPressed)
                    {
                        case 1:
                            Console.Clear();
                            Inventory.CreateInventoryEntry();
                            break;
                        case 2:
                            Console.Clear();
                            Inventory.GetInventoryEntries();
                            break;
                        case 3:
                            Console.Clear();
                            Inventory.DeleteInventoryEntry();
                            break;
                        case 9:
                            keepAsking = false;
                            Console.Clear();
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
