﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calc_LAB2_Dolganova
{
    public class Calculator
    {
        List<double> steps = [];


        public void ShowUsage() //Метод для вывода приветственного сообщения и правил пользования
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("when a first symbol on line is ‘>’ – enter operand (number)");
            Console.WriteLine("when a first symbol on line is ‘@’ – enter operation");
            Console.WriteLine("operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or ‘#’ followed with number of evaluation step and ‘q’ to exit");
        }


        public double EnterOperand()
        {
            Console.Write(">");

            double operand;

            bool isNumber = double.TryParse(Console.ReadLine(), out operand);

            // если это не удалось, то выводим сообщение об ошибке и повторяем запрос
            while (!isNumber)
            {
                Console.WriteLine("Некорректное значение. Введите число.");
                Console.Write(">");
                isNumber = double.TryParse(Console.ReadLine(), out operand);
            }

            if (steps.Count == 0)
            {
                steps.Add(operand);
                Console.WriteLine("[#" + steps.Count() + "]=" + operand);
            }


            return operand;
        }

        public string EnterAction()
        {

            string[] actions = ["+","-","*","/","q"];
            string pattern = @"^#\d+$";
            Console.Write("@");
            string userAction = Console.ReadLine();
            
            while (!(actions.Contains(userAction) | (Regex.IsMatch(userAction, pattern))))
            {
                Console.WriteLine("Некорректное значение. одно из достпуных действий");
                Console.Write("@");
                userAction = Console.ReadLine();
            }

            return userAction;
        }

        public void PlusAction(double operand)
        {
            int previousResultId = steps.Count() - 1;
            double previousResult = steps[previousResultId];
            double result = previousResult + operand;
            steps.Add(result);
            Console.WriteLine("[#" + steps.Count() + "]=" + result);
        }

        public void MinusAction(double operand) {
            int previousResultId = steps.Count() - 1;
            double previousResult = steps[previousResultId];
            double result = previousResult - operand;
            steps.Add(result);
            Console.WriteLine("[#" + steps.Count() + "]=" + result);
        }

        public void MultiplyAction(double operand) {
            int previousResultId = steps.Count() - 1;
            double previousResult = steps[previousResultId];
            double result = previousResult * operand;
            steps.Add(result);
            Console.WriteLine("[#" + steps.Count() + "]=" + result);
        }

        public void DivisionAction(double operand) {
            int previousResultId = steps.Count() - 1;
            double previousResult = steps[previousResultId];
            double result = previousResult / operand;
            steps.Add(result);
            Console.WriteLine("[#" + steps.Count() + "]=" + result);
        }

        public void ExitAction()
        {
            Console.WriteLine("Выход...");
            Environment.Exit(0);
        }

        public void GoToAction(string action)
        {

            action = action.Substring(1);
            int stepNumber = Convert.ToInt32(action);
            double result = steps[stepNumber - 1];
            steps.Add(result);
            Console.WriteLine("[#" + steps.Count() + "]=" + result);
        }

        

        
    }
}
