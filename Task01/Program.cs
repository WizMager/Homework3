using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры;
    //   б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;

    #region Task1.1
    struct ComplexSruct
    {
        public double im;
        public double re;

        public ComplexSruct Plus(ComplexSruct inpCompl)
        {
            ComplexSruct outCompl;
            outCompl.im = im + inpCompl.im;
            outCompl.re = re + inpCompl.re;
            return outCompl;
        }

        public ComplexSruct Minus(ComplexSruct inpCompl)
        {
            ComplexSruct outCompl;
            outCompl.im = im - inpCompl.im;
            outCompl.re = re - inpCompl.re;
            return outCompl;
        }

        public override string ToString()
        {
            if (im < 0)
            {
                return $"{re}{im}i";
            } else
            {
                return $"{re}+{im}i";
            }
        }
    }
    #endregion

    #region Task1.2
    class ComplexClass
    {
        double re;
        double im;

        public ComplexClass()
        {
            re = 0;
            im = 0;
        }

        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        //Plus with method
        public ComplexClass Plus(ComplexClass inpCompl)
        {
            ComplexClass outCompl = new ComplexClass();
            outCompl.im = im + inpCompl.im;
            outCompl.re = re + inpCompl.re;
            return outCompl;
        }

        //Minus with method
        public ComplexClass Minus(ComplexClass inpCompl)
        {
            ComplexClass outCompl = new ComplexClass();
            outCompl.im = im - inpCompl.im;
            outCompl.re = re - inpCompl.re;
            return outCompl;
        }

        //Multiplication with method
        public ComplexClass Multi(ComplexClass inpCompl)
        {
            ComplexClass outCompl = new ComplexClass();
            outCompl.im = im * inpCompl.im;
            outCompl.re = re * inpCompl.re;
            return outCompl;
        }

        //Plus with override operator "+"
        public static ComplexClass operator + (ComplexClass cc1, ComplexClass cc2)
        {
            ComplexClass result = new ComplexClass();
            result.im = cc1.im + cc2.im;
            result.re = cc1.re + cc2.re;

            return result;
        }

        //Minus with override operator "-"
        public static ComplexClass operator - (ComplexClass cc1, ComplexClass cc2)
        {
            ComplexClass result = new ComplexClass();
            result.im = cc1.im - cc2.im;
            result.re = cc1.re - cc2.re;

            return result;
        }

        //Multipli with override operator "*"
        public static ComplexClass operator *(ComplexClass cc1, ComplexClass cc2)
        {
            ComplexClass result = new ComplexClass();
            result.im = cc1.im * cc2.im;
            result.re = cc1.re * cc2.re;

            return result;
        }

        public override string ToString()
        {
            if (im < 0)
            {
                return $"{re}{im}i";
            }
            else
            {
                return $"{re}+{im}i";
            }
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {

            #region Task1.1
            Console.WriteLine("Work of structures...");
            ComplexSruct complex1;
            complex1.im = 5;
            complex1.re = 10;
            Console.WriteLine($"First number: {complex1}");

            ComplexSruct complex2;
            complex2.im = -7;
            complex2.re = -5;
            Console.WriteLine($"Second number: {complex2}");

            ComplexSruct result = complex1.Plus(complex2);
            Console.WriteLine($"Result of summ: {result}");

            result = complex1.Minus(complex2);
            Console.WriteLine($"Result of minus: {result}");

            Console.ReadKey();
            Console.Clear();
            #endregion


            #region Task1.2
            Console.WriteLine("Work of classes...");
            ComplexClass complexClassDefault = new ComplexClass();
            Console.WriteLine($"Craeted default ComplexClass: {complexClassDefault}");

            ComplexClass complexClass1 = new ComplexClass(8, -5);
            Console.WriteLine($"First number: {complexClass1}");

            ComplexClass complexClass2 = new ComplexClass(-3, 4);
            Console.WriteLine($"First number: {complexClass2}");

            Console.WriteLine($"Result of summ: {complexClass1 + complexClass2}");
            Console.WriteLine($"Result of minus: {complexClass1 - complexClass2}");
            Console.WriteLine($"Result of multiplication: {complexClass1 * complexClass2}");

            Console.ReadKey();
            #endregion

        }
    }
}
