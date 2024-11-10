namespace Collections
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _stringList;

            public ListTask()
            {
                _stringList = new List<string> { "1", "2", "3" };
            }

            public void TaskLoop()
            {
                Console.WriteLine("Текущий список:");
                PrintList();

                Console.Write("Введите новую строку для добавления в список: ");
                string newItem = Console.ReadLine();
                _stringList.Add(newItem);
                PrintList();

                Console.Write("Введите строку для добавления в середину списка: ");
                string middleItem = Console.ReadLine();
                int middleIndex = _stringList.Count / 2;
                _stringList.Insert(middleIndex, middleItem);
                PrintList();

                Console.WriteLine("Введите '-exit' для выхода из задачи.");
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "-exit")
                    {
                        break;
                    }
                }
            }

            private void PrintList()
            {
                Console.WriteLine(string.Join(", ", _stringList));
            }
        }


        private class DictionaryTask
        {
            private readonly Dictionary<string, double> _studentGrades;

            public DictionaryTask()
            {
                _studentGrades = new Dictionary<string, double>();
            }

            public void TaskLoop()
            {
                while (true)
                {
                    Console.Write("Введите имя студента: ");
                    string studentName = Console.ReadLine();

                    Console.Write("Введите оценку (от 2 до 5): ");
                    if (double.TryParse(Console.ReadLine(), out double grade) && grade >= 2 && grade <= 5)
                    {
                        _studentGrades[studentName] = grade;
                    }
                    else
                    {
                        Console.WriteLine("Некорректная оценка. Попробуйте снова.");
                        continue;
                    }

                    Console.Write("Введите имя студента для проверки оценки: ");
                    string checkName = Console.ReadLine();
                    if (_studentGrades.TryGetValue(checkName, out double studentGrade))
                    {
                        Console.WriteLine($"Оценка студента {checkName}: {studentGrade}");
                    }
                    else
                    {
                        Console.WriteLine($"Студента с именем {checkName} не существует.");
                        continue;
                    }

                    Console.WriteLine("Введите '-exit' для выхода из задачи.");
                    while (true)
                    {
                        string command = Console.ReadLine();
                        if (command == "-exit")
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private class LinkedListTask
        {
            private class Node
            {
                public string Data;
                public Node Next;
                public Node Previous;


                public Node(string data)
                {
                    Data = data;
                }
            }

            private Node head;
            private Node tail;

            public void TaskLoop()
            {
                Console.WriteLine("Введите 6 элементов для двусвязного списка:");
                for (int i = 0; i < 6; i++)
                {

                    Console.Write($"Элемент {i + 1}: ");
                    string data = Console.ReadLine();
                    AddToEnd(data);
                }

                Console.WriteLine("Список в прямом порядке:");
                PrintForward();

                Console.WriteLine("Список в обратном порядке:");
                PrintBackward();

                Console.WriteLine("Введите '–exit' для выхода из задачи.");
                string exitCommand = Console.ReadLine();
                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "-exit")
                    {
                        break;
                    }
                }
            }


            private void AddToEnd(string data)
            {
                Node newNode = new Node(data);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }
            }

            private void PrintForward()
            {
                Node current = head;
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                }
                Console.WriteLine();
            }

            private void PrintBackward()
            {
                Node current = tail;
                while (current != null)
                {
                    Console.Write(current.Data + " ");
                    current = current.Previous;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, 2 или 3 для выполнения задания 1, 2 или 3:");
            if (int.TryParse(Console.ReadLine(), out int task))
            {
                switch (task)
                {
                    case 1:
                        var listTask = new ListTask();
                        listTask.TaskLoop();
                        break;
                    case 2:
                        var dictionaryTask = new DictionaryTask();
                        dictionaryTask.TaskLoop();
                        break;
                    case 3:
                        var linkedListTask = new LinkedListTask();
                        linkedListTask.TaskLoop();
                        break;
                    default:
                        Console.WriteLine("Некорректный номер задания.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}