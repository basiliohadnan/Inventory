namespace ElectronicStore.Utils
{
    public class StringValidatorWithExceptions : IStringValidator
    {
        public string ValidateString()
        {
            var validInput = false;
            var input = "";

            while (!validInput)
            {
                try
                {
                    input = Console.ReadLine() ?? string.Empty;
                    validInput = true;
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

