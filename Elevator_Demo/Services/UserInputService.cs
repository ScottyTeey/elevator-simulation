using System;

public class UserInputService
{
    // Method to read an integer from the user with a provided prompt.
    public interface IUserInputService
    {
        int ReadInteger(string prompt);
    }

}
