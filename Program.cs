using Calc_LAB2_Dolganova;
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
    



        //Добавляем первое действие

        //Парсим число, проверяем на q

        //Парсим действие, проверяем само действие
        
        //Switchcase действий 

        //Вывод результата

        //Возврат к парсингу ввода числа (рекурсия?)






}





