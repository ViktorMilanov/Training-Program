using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете аритметичен израз със скоби:");
        string expression = Console.ReadLine();

        bool isValid = CheckBrackets(expression);
        Console.WriteLine("Скобите са " + (isValid ? "коректно поставени." : "некоректно поставени."));
    }

    static bool CheckBrackets(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
