using System;

using static UserOutputService;

public class ConsoleUserOutputService : IUserOutputService
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
