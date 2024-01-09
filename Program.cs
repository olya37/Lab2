using Lab2;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.ShowUsage();
        string pattern = @"^#\d+$";
        double operand = calculator.EnterOperand();

        while (true)
        {
            string useraction = calculator.EnterAction();
            if (Regex.IsMatch(useraction, pattern))
            {
                calculator.GoToAction(useraction);
            }
            else
            {
                switch (useraction)
                {
                    case "+":
                        operand = calculator.EnterOperand();
                        calculator.PlusAction(operand);
                        break;
                    case "-":
                        operand = calculator.EnterOperand();
                        calculator.MinusAction(operand);
                        break;
                    case "*":
                        operand = calculator.EnterOperand();
                        calculator.MultiplyAction(operand);
                        break;
                    case "/":
                        operand = calculator.EnterOperand();
                        calculator.DivisionAction(operand);
                        break;
                    case "q":
                        calculator.ExitAction();
                        break;
                }
            }
        }   
    }
}
