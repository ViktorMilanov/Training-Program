using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    private static Dictionary<string, int> precedence = new Dictionary<string, int>
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 },
        { "^", 3 },
        { "lg", 3 },
        { "(", 4 },
        { ")", 4 },
    };

    public static Queue<string> InfixToPostfix(string infix)
    {
        Stack<string> operatorStack = new Stack<string>();
        Queue<string> valueQueue = new Queue<string>();

        for (int i = 0; i < infix.Length; i++)
        {
            if (Char.IsLetter(infix[i]) && (i == 0 || !Char.IsLetter(infix[i - 1])))
            {
                string toOperation = infix[i].ToString();
                for (int j = i + 1; j < infix.Length; j++)
                {
                    if (!Char.IsLetter(infix[j])){
                        break;
                    }
                    toOperation += infix[j];
                }
                if (operatorStack.Count == 0)
                {
                    operatorStack.Push(toOperation);
                    continue;
                }
                string lastOperator = operatorStack.Peek();
                if (lastOperator == "(" || lastOperator == ")")
                {
                    operatorStack.Push(infix[i].ToString());
                }
                else
                {
                    if (precedence[toOperation] >= precedence[lastOperator])
                    {
                        operatorStack.Push(toOperation);
                    }
                    else
                    {
                        valueQueue.Enqueue(operatorStack.Pop());
                        operatorStack.Push(toOperation);
                    }
                }
            }
            else if (precedence.ContainsKey(infix[i].ToString()))
            {
                if(operatorStack.Count == 0)
                {
                    operatorStack.Push(infix[i].ToString());
                    continue;
                }
                string lastOperator = operatorStack.Peek();
                if (infix[i] == ')')
                {
                    while (operatorStack.Peek() != "(")
                    {
                        valueQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                    continue;
                }
                if (lastOperator == "(" || lastOperator == ")")
                {
                    operatorStack.Push(infix[i].ToString());
                }
                else
                {
                    if (precedence[infix[i].ToString()] >= precedence[lastOperator])
                    {
                        operatorStack.Push(infix[i].ToString());
                    }
                    else
                    {
                        valueQueue.Enqueue(operatorStack.Pop());
                        operatorStack.Push(infix[i].ToString());
                    }
                }
            }
            else if(Char.IsDigit(infix[i]))
            {
                valueQueue.Enqueue(infix[i].ToString());
            }
        }
        while (operatorStack.Count > 0)
        {
            valueQueue.Enqueue(operatorStack.Pop());
        }
        return valueQueue;
    }

    public static double PostfixEvaluate(Queue<string> postfix)
    {
        Stack<double> valuesStack = new Stack<double>();

        foreach (var token in postfix)
        {
            if (Regex.IsMatch(token, @"^[a-zA-Z]+$"))
            {
                double number1 = valuesStack.Pop();
                valuesStack.Push(EvaluateComplexOperation(number1, token));
            }
            else if (precedence.ContainsKey(token))
            {
                double number2 = valuesStack.Pop();
                double number1 = valuesStack.Pop();
                valuesStack.Push(Evaluate(number1, number2, token[0]));
            }
            else if (Char.IsDigit(token[0]))
            {
                double.TryParse(token, out double operand);
                valuesStack.Push(operand);
            }
        }
        return valuesStack.Pop();
    }

    private static double EvaluateComplexOperation(double number1, string currentElement)
    {
        switch (currentElement)
        {
            case "lg": return Math.Log10(number1);
            default:
                throw new ArgumentException("The operator is not supported or valid");
        }
    }

    private static double Evaluate(double number1, double number2, char token)
    {
        switch (token)
        {
            case '+': return number1 + number2;
            case '-': return number1 - number2;
            case '*': return number1 * number2;
            case '/': return number1 / number2;
            case '^': return Math.Pow(number1,number2);
            default:
                throw new ArgumentException("The operator is not valid");
        }
    }

    static void Main()
    {
        string infix = "lg3+4*(2-1)";
        Queue<string> postfix = InfixToPostfix(infix);
        Console.WriteLine(PostfixEvaluate(postfix)); // Output: Result: 7
    }

}
