using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        // Объявляем объект класса Random для генерации рандомных чисел
        public static Random rand = new Random();

        // Массив с числами для проверки
        public static int[] numberArr = new int[10];

        // Коллекция для хранения уникальных значений
        public static List<int> uniqueList = new List<int>();

        // Переменная для записи проверяемого числа
        public static int num = 0;

        // Счетчик вхождений проверяемого числа в массив
        public static int count = 0;

        static void Main(string[] args)
        {
            // Генерируем рандомные значения в массиве numberArr
            for (int i = 0; i < numberArr.Length; i++)
                numberArr[i] = rand.Next(0, 10);

            /* Вызываем функцию getUniqueNumbers передавая numberArr как параметр
            и ожидая возвращения значения в uniqueList*/
            uniqueList = getUniqueNumbers(numberArr);

            // Выводим все значения из массива numberArr
            for (int i = 0; i < numberArr.Length; i++)
                Console.WriteLine($"numberArr - {numberArr[i]}");

            // Пробел между выводами значений массива и коллекции, чтобы все не смешалось в кучу
            Console.WriteLine("\n");

            /* Если в коллекции uniqueList есть хотя бы одна цифра,
            то выводим коллекцию, иначе выводим сообщение о том, что коллекция пустая */
            if (uniqueList.Count > 0)
                // Выводим все значения из коллекции uniqueList
                for (int i = 0; i < uniqueList.Count; i++)
                    Console.WriteLine($"uniqueList - {uniqueList[i]}");
            else
                Console.WriteLine("Уникальных чисел не найдено!");

            // Пауза чтобы посмотреть результат, иначе консоль быстро закроется
            Console.WriteLine("Чтобы закончить нажмите любую клавишу...");
            Console.ReadLine();
        }

        public static List<int> getUniqueNumbers(int[] sortableArr)
        {
            // Локальная коллекция для хранения уникальных значений функции
            List<int> resultList = new List<int>();

            // Проверка, что массив не пустой
            if (sortableArr.Length > 0)
            {
                for (int i = 0; i < sortableArr.Length; i++)
                {
                    // Если данное число не находится в локальной коллекции, то обнуляем count и записываем его в num
                    if (resultList.IndexOf(sortableArr[i]) == -1)
                    {
                        num = sortableArr[i];
                        count = 0;
                    }

                    // "Пробегаем" массив считая количество вхождений проверяемого числа в массив
                    for (int j = 0; j < sortableArr.Length; j++)
                        if (sortableArr[j] == num)
                            count++;

                    // Если число встречено лишь один раз в массиве, то сохраняем его
                    if (count == 1)
                        resultList.Add(num);
                }
            }

            /* Возвращаем коллекцию уникальных чисел, если переданный в функцию массив был пустой,
            то и коллекция будет пустой*/
            return resultList;
        }
    }
}
