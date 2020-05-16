using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();
            int userChoice = default(int);
            string inpStr = string.Empty;
            int index = default(int);

            while (true)
            {
                Console.WriteLine("**************************************************");
                Console.WriteLine("\t\tМеню пользователя\n");

                Console.WriteLine("{0} - добавить элемент в конец списка;", (int)Menu.Add);
                Console.WriteLine("{0} - добавить элемент в список по индексу;", (int)Menu.Insert);
                Console.WriteLine("{0} - удалить элемент из списка по индексу;", (int)Menu.RemoveAt);
                Console.WriteLine("{0} - получить элемент списка по индексу;", (int)Menu.GetElement);
                Console.WriteLine("{0} - получить количество элементов в списке;", (int)Menu.GetCount);
                Console.WriteLine("{0} - показать весь список;", (int)Menu.ShowList);
                Console.WriteLine("{0} - выход.\n", (int)Menu.Exit);

                Console.Write("Введите номер опции: ");
                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                switch (userChoice)
                {
                    case (int)Menu.Exit:
                        return;

                    case (int)Menu.Add:
                        Console.Write("Введите строку: ");
                        inpStr = Console.ReadLine();
                        list.Add(inpStr);
                        Console.WriteLine("Операция выполнена.");
                        break;

                    case (int)Menu.Insert:
                        Console.Write("Введите строку: ");
                        inpStr = Console.ReadLine();
                        index = GetIndexFromUser();

                        try
                        {
                            if (index < 0 || index > list.Count)
                            {
                                throw new IndexOutOfRangeException("Индекс вышел за пределы диапазона.");
                            }
                            list.Insert(inpStr, index);
                            Console.WriteLine("Операция выполнена.");
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case (int)Menu.RemoveAt:
                        index = GetIndexFromUser();

                        try
                        {
                            if (index < 0 || index > list.Count - 1 || list.Count == 0)
                            {
                                throw new IndexOutOfRangeException("Индекс вышел за пределы диапазона.");
                            }
                            list.RemoveAt(index);
                            Console.WriteLine("Операция выполнена.");
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case (int)Menu.GetElement:
                        index = GetIndexFromUser();

                        try
                        {
                            if (index < 0 || index > list.Count - 1 || list.Count == 0)
                            {
                                throw new IndexOutOfRangeException("Индекс вышел за пределы диапазона.");
                            }
                            Console.WriteLine(list.GetElement(index));
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case (int)Menu.GetCount:
                        Console.WriteLine($"Количество элементов в списке: {list.Count}");
                        break;

                    case (int)Menu.ShowList:
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
            }
        }

        enum Menu
        {
            Exit, Add, Insert, RemoveAt, GetElement, GetCount, ShowList
        };

        static int GetIndexFromUser()
        {
            int index = default(int);

            while (true)
            {
                Console.Write("Введите индекс: ");

                try
                {
                    index = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                break;
            }

            return index;
        }
    }
}
