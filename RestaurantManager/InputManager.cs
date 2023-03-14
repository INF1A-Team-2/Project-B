namespace RestaurantManager;

static class InputManager
{
    public static string GetString(string prefix = "", Func<string, bool>? isValid = null, bool allowEmpty = true)
    {
        while (true)
        {
            Console.Write(prefix + " ");
            string input = Console.ReadLine() ?? "";

            if ((input.Length == 0 && !allowEmpty) || (isValid != null && !isValid(input)))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            return input;
        }
    }
    
    public static int GetInt(string prefix = "", Func<int, bool>? isValid = null)
    {
        while (true)
        {
            Console.Write(prefix + " ");
            string input = Console.ReadLine() ?? "";
            
            bool valid = int.TryParse(input, out int result);

            if (!valid || (isValid != null && !isValid(result)))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            return result;
        }
    }

    public static DateTime GetDate(string prefix = "")
    {
        while (true)
        {
            Console.Write(prefix + " ");
            string input = Console.ReadLine() ?? "";

            string[] parts = input.Split("-");

            bool valid = parts.Length == 3;
            
            DateTime date = new DateTime();
            try
            {
                date = new DateTime(
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    int.Parse(parts[2]));
            }
            catch
            {
                valid = false;
            }

            if (!valid)
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            return date;
        }
    }

    public static int GetSelection(List<string> options, string secretCode = "")
    {
        secretCode = secretCode.ToUpper();
        
        int currentSelection = 0;

        string currentSecretInput = "";
        
        while (true)
        {
            for (int i = 0; i < options.Count; i++)
            {
                string output = i == currentSelection ? $"• {options[i]}" : $" {options[i]}";
                Console.WriteLine(output);
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    currentSelection = currentSelection == options.Count - 1 ? 0 : currentSelection + 1;
                    break;
                case ConsoleKey.UpArrow:
                    currentSelection = currentSelection == 0 ? options.Count - 1 : currentSelection - 1;
                    break;
                case ConsoleKey.Enter:
                    return currentSelection;
            }

            if (secretCode.Length > 0)
            {
                if ((char)key == secretCode[currentSecretInput.Length])
                    currentSecretInput += secretCode[currentSecretInput.Length];

                else
                    currentSecretInput = "";

                if (currentSecretInput == secretCode)
                    return -1;
            }

            ClearLines(options.Count);
        }
    }

    public static void ClearLines(int amount)
    {
        if (amount < 0)
            return;
        
        for (int i = 0; i < amount; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentLine();
        }
    }
    
    private static void ClearCurrentLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }
}