using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public abstract class Person : BaseEntity
    {
        public static StringValidatorWitExceptions stringValidatorWithExceptions = new StringValidatorWitExceptions();
        private static List<Person> people = new List<Person>();
        public string Name { get; protected set; }
        private string _phone1;
        public string Phone1
        {
            get
            {
                return _phone1;
            }
            protected set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                        Console.WriteLine("Phone 1 must be filled.");
                    else
                        _phone1 = value;
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.InvalidFormat();
                }
                catch (Exception)
                {
                    StandardConsoleMessages.UnidentifiedErrorOccurred();
                }
            }
        }
        public string Phone2 { get; protected set; }
        public string Email { get; protected set; }

        public static string ValidateEmail()
        {
            var email = "";
            var validEmail = false;

            do
            {
                email = stringValidatorWithExceptions.ValidateString();
                validEmail = RegexUtilities.IsValidEmail(email);
                if (!validEmail)
                {
                    StandardConsoleMessages.InvalidFormat();
                    Console.WriteLine("E-mail:");
                }
            } while (!validEmail);
            return email;
        }

        public Person(string name, string phone1, string email)
        {
            IncrementIdentifier();
            Code = Id;
            Name = name;
            Phone1 = phone1;
            Email = email;
            people.Add(this);
            Console.Clear();
            Console.WriteLine("New person registered!");
            Console.WriteLine();
        }

        public Person(string name, string phone1, string phone2, string email)
        {
            IncrementIdentifier();
            Code = Id;
            Name = name;
            Phone1 = phone1;
            Phone2 = phone2;
            Email = email;
            people.Add(this);
            Console.Clear();
            Console.WriteLine("New person registered!");
            Console.WriteLine();
        }
    }
}
