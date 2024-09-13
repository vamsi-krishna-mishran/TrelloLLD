

public class LoggerService
{


    public void Info(string message)
    {
        message = "[Info]: " + message;
        message = message.ToUpper();
        ConsoleColor cur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ForegroundColor = cur;
    }
    public void Warning(string message)
    {
        message = "[Waring]: " + message;
        message = message.ToUpper();
        ConsoleColor cur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ForegroundColor = cur;
    }
    public void Error(string message)
    {
        message = "[Error]: " + message;
        message = message.ToUpper();
        ConsoleColor cur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = cur;
    }
    public void Success(string message)
    {
        message = "[Success]: " + message;
        message = message.ToUpper();
        ConsoleColor cur = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = cur;
    }
}