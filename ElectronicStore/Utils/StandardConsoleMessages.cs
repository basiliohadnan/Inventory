namespace ElectronicStore.Utils
{
    public static class StandardConsoleMessages
    {
        public static void PressAnyKeyToReturn()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return.");
            Console.ReadLine();
            ClearConsoleAndSkipALine();
        }

        public static void InvalidCode()
        {
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Invalid code, please try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void InvalidFormat()
        {
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Invalid format, please try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void InvalidOption()
        {
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Invalid option, try again.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void EmptyList(string type)
        {
            ClearConsoleAndSkipALine();
            ColourChanger.YellowText();
            Console.WriteLine($"There are no items in {type} list.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void UnidentifiedErrorOccurred()
        {
            StandardConsoleMessages.ClearConsoleAndSkipALine();
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
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Price can't be negative or zero.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void MustFillField()
        {
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Must fill this field.");
            Console.WriteLine();
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
