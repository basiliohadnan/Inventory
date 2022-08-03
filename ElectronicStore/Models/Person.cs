using ElectronicStore.Utils;

namespace ElectronicStore.Models
{
    public abstract class Person
    {
        public static StringValidator stringValidator = new StringValidator();
        private static List<Person> people = new List<Person>();
        public string Name { get; protected set; }
        public string Phone1 { get; protected set; }
        public string Phone2 { get; protected set; }
        public string Email { get; protected set; }
        public static int Id { get; protected set; }
        public int Code { get; protected set; }

        private static void IncrementIdentifier() => Id++;

        public static string ValidateEmail()
        {
            var email = "";
            var validEmail = false;

            do
            {
                email = stringValidator.ValidateString();
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
        }
    }
}
