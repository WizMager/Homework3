using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    //2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел.
    //      Сами числа и сумму вывести на экран, используя tryParse;
    //   б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.При возникновении ошибки вывести сообщение.
    //      Напишите соответствующую функцию;
    class Program
    {
        static void Main(string[] args)
        {
            string allNumbers = "";
            string curNumber;
            
            bool isValidTryParse;
            
            double resultSum = 0;
            int counter = 0;
            
            //Для проверки 2-ой части задания(именно работы функции) нужно закомментить регион Task2.1 и раскомментить вызов функции.
            //Не очень понял зачем использовать TryParse именно в конце, к итоговым значениям, если всё-равно нужно хранить отдельно все числа и сумму нужных чисел.
            //Потому проверка и ввод сделаны в while, а вывод уже отдельно суммы и самих чисел.
            do
            {
                Console.WriteLine($"Enter any number except 0. Zero is stop input. You entered {counter} numbers: ");
                curNumber = Console.ReadLine();
                #region Task2.1
                isValidTryParse = double.TryParse(curNumber,out double resultTryparse);
                if (isValidTryParse)
                {
                    if (resultTryparse != 0)
                    {
                        allNumbers += $"{curNumber} ";
                        if (resultTryparse > 0 & resultTryparse % 2 == 0)
                        {
                            resultSum += resultTryparse;
                        }
                        counter++;
                    }
                } else { 
                    Console.WriteLine($"You entered not a number - {curNumber}. Press any key to continue enter.");
                    Console.ReadKey();
                }
                #endregion
                //ParseFunction(curNumber,ref allNumbers,ref counter,ref resultSum);
                Console.Clear();
            } while (curNumber != "0");

            Console.Clear();
            Console.WriteLine("Input numbers is:");
            Console.WriteLine(allNumbers);
            Console.WriteLine($"Sum of odd and positive numbers is: {resultSum}.");
            Console.ReadKey();
        }

        #region Task2.2
        /// <summary>
        /// Method for check correct input with TryParse.
        /// </summary>
        /// <param name="curNum">Current input string number</param>
        /// <param name="allNum">Reference string to all numbers</param>
        /// <param name="counter">Reference count of correct input numbers</param>
        /// <param name="resSum">Reference of sum numbers</param>
        static void ParseFunction(string curNum, ref string allNum, ref int counter, ref double resSum)
        {
            bool isValidTryParse = double.TryParse(curNum, out double resultTryparse);
            if (isValidTryParse)
            {
                if (resultTryparse != 0)
                {
                    allNum += $"{curNum} ";
                    if (resultTryparse > 0 & resultTryparse % 2 == 0)
                    {
                        resSum += resultTryparse;
                    }
                    counter++;
                }
            }
            else
            {
                Console.WriteLine($"You entered not a number - {curNum}. Press any key to continue enter.");
                Console.ReadKey();
            }
        }
        #endregion
    }
}
