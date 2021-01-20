using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
//    3. *  Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.Предусмотреть методы сложения, вычитания, умножения и деления дробей.
//          Написать программу, демонстрирующую все разработанные элементы класса.
//       ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
//          Добавить упрощение дробей.
    class Program
    {
        static void Main(string[] args)
        {
            FractionNumber fractionNumber1 = new FractionNumber();
            FractionNumber fractionNumber2 = new FractionNumber();
            
            InputFractionNumbers(fractionNumber1, fractionNumber2);

            Console.WriteLine("Введите номер операции с дробями:\n1-сложение \n2-вычитание \n3-умножение \n4-деление \n5-конвертация в десятичную дробь \n6-все операции сразу ");
            int operation = int.Parse(Console.ReadLine());
            FractionNumber tempNumber = new FractionNumber();
            switch (operation)
            {
                case 1:
                    Console.Clear();
                    tempNumber = fractionNumber1 + fractionNumber2;
                    Console.WriteLine($"Сумма {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    break;
                case 2:
                    Console.Clear();
                    tempNumber = fractionNumber1 - fractionNumber2;
                    Console.WriteLine($"Разность {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    break;
                case 3:
                    Console.Clear();
                    tempNumber = fractionNumber1 * fractionNumber2;
                    Console.WriteLine($"Произведение {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    break;
                case 4:
                    Console.Clear();
                    tempNumber = fractionNumber1 / fractionNumber2;
                    Console.WriteLine($"Частное {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine($"Конвертация {fractionNumber1} и {fractionNumber2} равна {fractionNumber1.Convertation():0.00} и {fractionNumber2.Convertation():0.00} соответственно.");
                    break;
                case 6:
                    Console.Clear();
                    tempNumber = fractionNumber1 + fractionNumber2;
                    Console.WriteLine($"Сумма {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    tempNumber = fractionNumber1 - fractionNumber2;
                    Console.WriteLine($"Разность {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    tempNumber = fractionNumber1 * fractionNumber2;
                    Console.WriteLine($"Произведение {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    tempNumber = fractionNumber1 / fractionNumber2;
                    Console.WriteLine($"Частное {fractionNumber1} и {fractionNumber2} равна {tempNumber}.");
                    Console.WriteLine($"Конвертация {fractionNumber1} и {fractionNumber2} равна {fractionNumber1.Convertation():0.00} и {fractionNumber2.Convertation():0.00} соответственно.");
                    break;
                default:
                    Console.WriteLine("Данная операция отсутствует...");
                    break;
            }

            Console.ReadKey();
        }

        static public void InputFractionNumbers(FractionNumber fn1, FractionNumber fn2)
        {
            Console.WriteLine("Введите два дробных числа...");

            Console.Write("Числитель первого дробного числа: ");
            fn1.Numerator = int.Parse(Console.ReadLine());
            Console.Write("Знаменатель первого дробного числа: ");
            fn1.Denominator = int.Parse(Console.ReadLine());

            Console.Write("Числитель второго дробного числа: ");
            fn2.Numerator = int.Parse(Console.ReadLine());
            Console.Write("Знаменатель второго дробного числа: ");
            fn2.Denominator = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Первое дробное число: {fn1} . Второе дробное число: {fn2} .");
        }
    }

    class FractionNumber
    {
        private int denominator;
        private int numerator;

        public int Numerator { get => numerator; set => numerator = value; }
        public int Denominator
        {
            get => denominator;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                denominator = value;
            }
        }

        public double Convertation()
        {
            double num = (double)Numerator / denominator;
            return num;
        }

        public override string ToString()
        {
            if (numerator == 0)
            {
                return "0";
            }
            else
            {
                if (numerator < 0 || denominator < 0)
                {
                    if (numerator < 0 & denominator < 0)
                        return PositiveFractionNumber(Numerator, Denominator);
                    return NegativeFractionNumber(Numerator, Denominator);
                }
                else
                {
                    return PositiveFractionNumber(Numerator, Denominator);
                }
            }

        }


        /// <summary>
        /// ToString хелпер, вывод строки для отрицательных дробных чисел.
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="deno">Знаменатель</param>
        /// <returns></returns>
        string NegativeFractionNumber(int num, int deno)
        {
            int numerator = Math.Abs(num);
            int denominator = Math.Abs(deno);
            if ((double)numerator / denominator >= 1)
            {
                int wholeNum = numerator / denominator;
                numerator -= wholeNum * denominator;
                if (numerator == 0)
                {
                    return "-" + wholeNum;
                }
                else
                {
                    return "-" + wholeNum + "(" + numerator + "/" + denominator + ")";
                }
            }
            else
            {
                return "-" + numerator + "/" + denominator;
            }
        }

        /// <summary>
        /// ToString хелпер, вывод строки для положительных дробных чисел.
        /// </summary>
        /// <returns></returns>
        string PositiveFractionNumber(int num, int deno)
        {
            int numerator = Math.Abs(num);
            int denominator = Math.Abs(deno);
            if ((double)numerator / denominator >= 1)
            {
                int wholeNum = numerator / denominator;
                numerator -= wholeNum * denominator;
                if (numerator == 0)
                {
                    return $"{wholeNum}";
                }
                else
                {
                    return wholeNum + "(" + numerator + "/" + denominator + ")";
                }
            }
            else
            {
                return numerator + "/" + denominator;
            }
        }
        public static FractionNumber operator +(FractionNumber fn1, FractionNumber fn2)
        {
            int lcm;
            int numerator;
            int denominator;
            if (Math.Abs(fn1.Denominator) == Math.Abs(fn2.Denominator))
            {
                lcm = Math.Abs(fn1.Denominator);
            }
            else
            {
                lcm = Math.Abs(fn1.Denominator * fn2.Denominator);
            }
            numerator = fn1.Numerator * (lcm / fn1.Denominator);
            numerator += fn2.Numerator * (lcm / fn2.Denominator);
            denominator = lcm;

            return new FractionNumber() { Numerator = numerator, Denominator = denominator };
        }

        public static FractionNumber operator -(FractionNumber fn1, FractionNumber fn2)
        {
            int lcm;
            int numerator;
            int denominator;
            if (Math.Abs(fn1.Denominator) == Math.Abs(fn2.Denominator))
            {
                lcm = Math.Abs(fn1.Denominator);
            }
            else
            {
                lcm = Math.Abs(fn1.Denominator * fn2.Denominator);
            }
            numerator = fn1.Numerator * (lcm / fn1.Denominator);
            numerator -= fn2.Numerator * (lcm / fn2.Denominator);
            denominator = lcm;

            return new FractionNumber() { Numerator = numerator, Denominator = denominator };
        }

        public static FractionNumber operator *(FractionNumber fn1, FractionNumber fn2)
        {
            int numerator;
            int denomirator;
            numerator = fn1.Numerator * fn2.Numerator;
            denomirator = fn1.Denominator * fn2.Denominator;
            return new FractionNumber { Numerator = numerator, Denominator = denomirator };
        }

        public static FractionNumber operator /(FractionNumber fn1, FractionNumber fn2)
        {
            int numerator;
            int denomirator;
            if (fn2.Numerator == 0)
            {
                throw new ArgumentException("Числитель второй дроби не может быть равен 0");
            }
            else
            {
                numerator = fn1.Numerator * fn2.Denominator;
                denomirator = fn1.Denominator * fn2.Numerator;
                return new FractionNumber { Numerator = numerator, Denominator = denomirator };
            }

        }
    }
}
