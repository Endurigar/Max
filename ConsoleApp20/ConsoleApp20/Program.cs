using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string suka = Math(numbers);
            Console.ReadLine();
        }
        public static string Math(string numbers)
        {
            float[] otveti = new float[3];
            float numbers1;
            float numbers2;
            int charID;
            int startSS;
            int lastSS;
            string pupa = "";
            string skobochka;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '(')
                {
                    startSS = i;
                    while (true)
                    {
                        i++;
                        if (numbers[i] == ')')
                        {
                            lastSS = i;
                            break;
                        }
                    }
                    int lenth = lastSS - startSS;
                    skobochka = numbers.Substring(startSS + 1, lenth-1);
                    string newNumbers = numbers.Replace(numbers.Substring(startSS, lenth+1), Math(skobochka));
                    Math(newNumbers);
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == '*')
                {
                    numbers = Umnojenie(otveti, i, numbers);
                    i = 0;
                    Console.WriteLine(numbers);
                }
            }// *
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '/')
                {
                    numbers = Delenie(otveti, i, numbers);
                    i = 0;
                    Console.WriteLine(numbers);
                }
            }// /
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '+')
                {
                    numbers = Slojenie (otveti, i, numbers);
                    i = 0;
                    Console.WriteLine(numbers);
                }
            }// +
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '-')
                {
                    numbers = Vichitanie(otveti, i, numbers);
                    i = 0;
                    Console.WriteLine(numbers);
                }
            }// -

            return numbers;
        }
        public static float[] Viroshenie(int charID, string numbers)
        {
            string temp = "";
            string temp1 = "";
            float indexReplaceStart = 0;
            float indexReplaceLast = 0;
            float number1=0;
            float number2=0;
            bool check;
            for (int i = charID - 1; i >= 0; i--)
            {

                check = Char.IsNumber(numbers[i]);
                if (check == true)
                {
                    temp = Char.ToString(numbers[i]);
                    temp1 = temp + temp1;
                }
                if (check == false || i == 0)
                {
                    indexReplaceStart = i;
                    number1 = float.Parse(temp1);
                    break;
                }
            }
            temp1 = "";
            for (int i = charID + 1; i < numbers.Length; i++)
            {

                check = Char.IsNumber(numbers[i]);
                if (check == true)
                {
                    temp = Char.ToString(numbers[i]);
                    temp1 = temp + temp1;
                    indexReplaceLast = i;
                }
                if (check == false || i == numbers.Length - 1)
                {

                    char[] c = temp1.ToCharArray();
                    Array.Reverse(c);
                    temp1 = new string(c);
                    number2 = float.Parse(temp1);
                    break;
                }
            }
            float[] otveti = new float[4];
            otveti[0] = number1;
            otveti[1] = number2;
            otveti[2] = indexReplaceStart;
            otveti[3] = indexReplaceLast;
            return otveti;
        }
        public static string Umnojenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID,numbers);
            float result = otveti[0] * otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth + 1);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public static string Delenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] / otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth + 1);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public static string Slojenie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] + otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth + 1);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
        public static string Vichitanie(float[] otveti, int charID, string numbers)
        {
            otveti = Viroshenie(charID, numbers);
            float result = otveti[0] - otveti[1];
            int lenth = Convert.ToInt32(otveti[3] - otveti[2]);
            int start = Convert.ToInt32(otveti[2]);
            string tempString = numbers.Substring(start, lenth + 1);
            numbers = numbers.Replace(tempString, result.ToString());
            return numbers;
        }
    }
}
