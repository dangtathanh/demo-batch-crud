using System;

namespace NetCore.BatchCRUD.Infrastructures.Helpers
{
    public static class InputHelper
    {
        //Returns null if ESC key pressed during input.
        public static string ReadLineWithCancel(out bool exit)
        {
            exit = false;

            string result = Console.ReadLine(); // Get string from user
            if (result.Equals("B", StringComparison.OrdinalIgnoreCase)) // Check string
            {
                exit = true;
                return string.Empty;
            }

            return result;
        }
    }
}
