using ElectronicStore.Utils;

namespace ElectronicStore.Models

{
    public sealed class Customer : Person

    {
        private static List<Customer> customers = new List<Customer>();
        public string Cpf { get; private set; }
        public bool Subscriber { get; private set; }

        public Customer(string name, string cpf, bool subscriber, string phone1, string phone2, string email) : base(name, phone1, phone2, email)
        {
            Cpf = cpf;
            Subscriber = subscriber;
            Code = Id;
        }

        public Customer(string name, string cpf, bool subscriber, string phone1, string email) : base(name, phone1, email)
        {
            Cpf = cpf;
            Subscriber = subscriber;
            Code = Id;
        }

        public static bool SaveAsBoolean(int input)
        {
            if (input == 1)
                return true;
            return false;
        }

        public static string SubscriberBooleanToString(Customer customer)
        {
            var subscriber = "";

            if (customer.Subscriber)
            {
                subscriber = "Yes";
            }
            else
            {
                subscriber = "No";
            }
            return subscriber;
        }

        public static void CreateCustomer()
        {
            Console.WriteLine("Please, register a customer.");
            Console.WriteLine();

            Console.WriteLine("Name:");
            var name = stringValidatorWithExceptions.ValidateString();

            Console.WriteLine("CPF:");
            var cpf = stringValidatorWithExceptions.ValidateString();

            Console.WriteLine("Subscriber:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var subscriber = SaveAsBoolean(Convert.ToInt32(stringValidatorWithExceptions.ValidateString()));

            Console.WriteLine("Phone 1:");
            var phone1 = stringValidatorWithExceptions.ValidateString();

            Console.WriteLine("Phone 2:");
            var phone2 = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("E-mail:");
            var email = ValidateEmail();

            if (phone2 is null)
            {
                var customer = new Customer(name, cpf, subscriber, phone1, email);
                customers.Add(customer);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Customer '{customer.Name}' registered!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
            else
            {
                var customer = new Customer(name, cpf, subscriber, phone1, phone2, email);
                customers.Add(customer);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Customer '{customer.Name}' registered!");
                StandardConsoleMessages.PressAnyKeyToReturn();
            }
        }

        public static void GetCustomers()
        {
            Console.WriteLine($"Customers: {customers.Count()}");
            Console.WriteLine();

            customers.ForEach(customer => GetCustomerDetails(customer));

            Console.WriteLine();
            Console.WriteLine("Press any key to return.");
            Console.ReadLine();
            Console.Clear();
        }

        public static Customer GetCustomer(int code) => (customers.First(customer => customer.Code == code));

        public static void GetCustomerDetails(Customer customer)
        {
            Console.WriteLine($"Code: {customer.Code}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"CPF: {customer.Cpf}");
            Console.WriteLine($"Subscriber: {SubscriberBooleanToString(customer)}");
            Console.WriteLine($"Phone 1: {customer.Phone1}");
            if (customer.Phone2 is not null)
            {
                Console.WriteLine($"Phone 2: {customer.Phone2}");
            }
            Console.WriteLine($"E-mail: {customer.Email}");
            Console.WriteLine();
        }

        public static void DeleteCustomer()
        {
            Console.WriteLine("Please, inform the Customer Code:");
            int code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());

            try
            {
                var customer = GetCustomer(code);
                customers.Remove(customer);

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Customer code {customer.Code} removed!");
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

        public static void UpdateCustomer()
        {
            Console.WriteLine("Please, inform the Customer Code:");
            var code = Convert.ToInt32(stringValidatorWithExceptions.ValidateString());

            try
            {
                var customer = GetCustomer(code);
                Console.Clear();

                Console.WriteLine("CUSTOMER DETAILS:");
                GetCustomerDetails(customer);

                Console.WriteLine("Please, insert new values:");
                Console.WriteLine();

                Console.WriteLine("Name:");
                var name = stringValidatorWithExceptions.ValidateString();
                customer.Name = name;

                Console.WriteLine("CPF:");
                var cpf = stringValidatorWithExceptions.ValidateString();
                customer.Cpf = cpf;

                Console.WriteLine("Subscriber:");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                var subscriber = SaveAsBoolean(Convert.ToInt32(stringValidatorWithExceptions.ValidateString()));
                customer.Subscriber = subscriber;

                Console.WriteLine("Phone 1:");
                var phone1 = stringValidatorWithExceptions.ValidateString();
                customer.Phone1 = phone1;

                Console.WriteLine("Phone 2:");
                var phone2 = Console.ReadLine();
                customer.Phone2 = phone2;

                Console.WriteLine("E-mail:");
                customer.Email = ValidateEmail();

                StandardConsoleMessages.ClearConsoleAndSkipALine();
                Console.WriteLine($"Customer code {customer.Code} updated!");
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