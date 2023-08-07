static bool IsValidExpression(string expression)
{
    int countOpening = 0;
    if (expression[0] == ')' || expression[0] == '}' || expression[0] == ']')
    {
        return false;
    }
    foreach (char ch in expression)
    {
        if (ch == '(')
        {
            countOpening++;
        }
        else if (ch == ')')
        {
            countOpening--;
            if (countOpening < 0)
            {
                return false;
            }
        }
    }
    if (expression[expression.Length - 1] == '(' || expression[expression.Length - 1] == '{' || expression[expression.Length - 1] == '[')
    {
        return false;
    }
    return countOpening == 0;
}
Console.WriteLine(IsValidExpression("((a+b)/5-d)"));
Console.WriteLine(IsValidExpression(" )(a+b))"));