namespace ElectronicStore.Utils
{
    public class StringValidator
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
                    StandardConsoleMessages.InvalidFormat();
                    continue;
                }
                catch (FormatException)
                {
                    StandardConsoleMessages.InvalidFormat();
                    continue;
                }
                catch (NullReferenceException)
                {
                    StandardConsoleMessages.MustFillField();
                    continue;
                }
                catch (Exception)
                {
                    StandardConsoleMessages.UnidentifiedErrorOccurred();
                    throw;
                }
            }
            return input;
        }
    }
}

