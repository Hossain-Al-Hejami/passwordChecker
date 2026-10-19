using System.Data;
using System.Text.RegularExpressions;

namespace passwordChecker;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Password Security Checker ===\n");

        Console.WriteLine("Enter password:");
        string passwordInput = ReadPassword();

        Console.WriteLine();

        PasswordStrength(passwordInput);
    }

    static string ReadPassword()
    {
        string password = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        }
        return password;
    }

    public static int PasswordStrength(string password)
    {
        int score = 0;

        bool uppercase = Regex.IsMatch(password, @"[A-Z]");
        bool lowercase = Regex.IsMatch(password, @"[a-z]");
        bool numbers = Regex.IsMatch(password, @"\d");
        bool specialChars = Regex.IsMatch(password, @"[^\w\s]");

        if (password.Length >= 16)
        {
            score++;
        }
        if (lowercase)
        {
            score++;
        }
        if (uppercase)
        {
            score++;
        }
        if (numbers)
        {
            score++;
        }
        if (specialChars)
        {
            score++;
        }

        string[] commonPasswords =
        {
            "password",
            "password123",
            "123456",
            "12345678",
            "123456789",
            "qwerty",
            "abc123",
            "admin",
            "letmein"
        };

        bool commonPassword = commonPasswords.Contains(password.ToLower());

        int poolSize = 0;

        if (lowercase)
        {
            poolSize += 26;
        }

        if (uppercase)
        {
            poolSize += 26;
        }
        if (numbers)
        {
            poolSize += 10;
        }
        if (specialChars)
        {
            poolSize += 32;
        }

        double entropy = 0;

        if (poolSize > 0)
        {
            entropy = password.Length * Math.Log2(poolSize);
        }

        Console.WriteLine($"Length: {password.Length}");
        Console.WriteLine($"Uppercase: {(uppercase ? "yes" : "No")}");
        Console.WriteLine($"Lowercase: {(lowercase ? "yes" : "No")}");
        Console.WriteLine($"Numbers: {(numbers ? "yes" : "No")}");
        Console.WriteLine($"Special chars: {(specialChars ? "yes" : "No")}");
        Console.WriteLine($"Common password: {(commonPassword ? "yes" : "No")}");
        Console.WriteLine($"Estimated entropy: {Math.Round(entropy)} bits\n");

        Console.WriteLine($"Score; {score}/5");

        if (commonPassword || score <= 2)
        {
            Console.WriteLine("Result: WEAK");
        }
        else if (score <= 4)
        {
            Console.WriteLine("Result: MEDIUM");
        }
        else
        {
            Console.WriteLine("Result: STRONG");
        }

        return score;
    }
}