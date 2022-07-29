namespace ElectronicStore.Utils
{
    public static class StandardConsoleMessages
    {
        public static void PressAnyKeyToReturn()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void InvalidCode()
        {
            Console.Clear();
            ColourChanger.RedText();
            Console.WriteLine("Invalid code, please try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void InvalidFormat()
        {
            Console.Clear();
            ColourChanger.RedText();
            Console.WriteLine("Invalid format, please try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void InvalidOption()
        {
            Console.Clear();
            ColourChanger.RedText();
            Console.WriteLine("Invalid option, try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void UnidentifiedErrorOccurred()
        {
            Console.Clear();
            ColourChanger.RedText();
            Console.WriteLine("Unidentified error occured.");
            Console.WriteLine("Check the input and try again.");
            ColourChanger.WhiteText();
        }

        public static void ClearConsoleAndSkipALine()
        {
            Console.Clear();
            Console.WriteLine();
        }

        public static void ValueCannotBeZeroOrNegative()
        {
            Console.Clear();
            ColourChanger.RedText();
            Console.WriteLine("Price can't be negative or zero.");
            ColourChanger.WhiteText();
        }
    
        public static void MainInfo()
        {
            ColourChanger.GreenText();
            Console.WriteLine("Please, choose an option:");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }
    }
}
