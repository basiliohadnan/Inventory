namespace ElectronicStore.Utils
{
    public class StringValidatorWitExceptions : IStringValidator
    {
        public string ValidateString()
        {
            var validInput = false;
            var input = "";

            while (!validInput)
            {
                try
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                        throw new NullReferenceException();
                    validInput = true;
                    Console.WriteLine();
                }
                catch (InvalidDataException)
                {
                    ColourChanger.RedText();
                    Console.WriteLine("Invalid data input!");
                    Console.WriteLine();
                    ColourChanger.WhiteText();
                    continue;
                }
                catch (FormatException)
                {
                    ColourChanger.RedText();
                    Console.WriteLine("Invalid format!");
                    Console.WriteLine();
                    ColourChanger.WhiteText();
                    continue;
                }
                catch (NullReferenceException)
                {
                    ColourChanger.RedText();
                    Console.WriteLine("Must fill this field.");
                    Console.WriteLine();
                    ColourChanger.WhiteText();
                    continue;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return input;
        }
    }
}

