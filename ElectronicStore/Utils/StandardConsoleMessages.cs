namespace ElectronicStore.Utils
{
    public static class StandardConsoleMessages
    {

        //Neutral
        public static void PressAnyKeyToReturn()
        {
            Console.WriteLine();
            ColourChanger.BlueText();
            Console.WriteLine("Press any key to return.");
            ColourChanger.WhiteText();
            Console.ReadLine();
            ClearConsoleAndSkipALine();
        }

        public static void MainInfo()
        {
            ColourChanger.BlueText();
            Console.WriteLine("Please, choose an option:");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void Divider()
        {
            ColourChanger.BlueText();
            Console.WriteLine("---------------------------------");
            ColourChanger.WhiteText();
        }

        public static void ClearConsoleAndSkipALine()
        {
            Console.Clear();
            Console.WriteLine();
        }

        //Warnings
        public static void EmptyList(string type)
        {
            ClearConsoleAndSkipALine();
            ColourChanger.YellowText();
            Console.WriteLine($"There are no items in {type} list.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        //Errors

        public static void InvalidCode()
        {
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

        public static void UnidentifiedErrorOccurred()
        {
            ClearConsoleAndSkipALine();
            ColourChanger.RedText();
            Console.WriteLine("Unidentified error occured.");
            Console.WriteLine("Check the input and try again.");
            ColourChanger.WhiteText();
        }

        public static void ValueCannotBeZeroOrNegative()
        {
            ColourChanger.RedText();
            Console.WriteLine("Price can't be negative or zero.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }

        public static void MustFillField()
        {
            ColourChanger.RedText();
            Console.WriteLine("Must fill this field.");
            Console.WriteLine();
            ColourChanger.WhiteText();
        }
    }
}
