using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Themes;

namespace pis_pr3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string themes1 = "\"Статус работы\" \"Казарез Полина Андреевна\" \"Практическая работа\" 2023.10.02 \"В процессе\"";
            string themes2 = "\"Тема работы\" \"Спепанова Лидия Ивановна\" \"Практическая работа\" 2024.09.09";
            string themes3 = "\"Работа с наставником\" \"Казарез Полина Андреевна\" \"Курсовая работа\" 2024.10.02 \"Иванов Михаил Ильич\"";
            string[] provera = new string[] { themes1, themes2, themes3 };


            Console.WriteLine("---------------------------------------------Вывод из строк------------------------------------");
            foreach (string linestr in provera)
            {
                var workObject = StringManipulation.ObjectOutput(linestr);
                Console.WriteLine(StringManipulation.ToStringDependingOnType(workObject));
            }

            Console.WriteLine("---------------------------------------------Вывод из файла------------------------------------");
            foreach (string linefile in StringManipulation.StrFromFiles("2.txt"))
            {
                var workObject = StringManipulation.ObjectOutput(linefile);
                Console.WriteLine(StringManipulation.ToStringDependingOnType(workObject));
            }
            Console.ReadKey();
        }
    }
    
}
