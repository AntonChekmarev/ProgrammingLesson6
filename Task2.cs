namespace Task2
{
    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("41", "на входе массив чисел, на выходе информация, сколь в массиве чисел больше нуля.", "дробная часть числа вводится через точку. Перечисляются числа через запятую.");

            decimal[] array = InputDecimalArray();

            Console.WriteLine("");
            Console.WriteLine("Кол-во чисел больше нуля: " + PNZCount(array, true));


            PrintFinishTask();
        } // === FINISH ===



        // Функция ввода и проверки данных.
        static decimal[] InputDecimalArray()
        {
            Console.WriteLine("");

        NewInput:

            Console.ResetColor();

            Console.Write("Введите числа: ");

            string str = Console.ReadLine()!;

            string[] str_ = str.Split(','); // разбив на элементы

            decimal[] rezult = new decimal[str_.Length];

            for (int i = 0; i < str_.Length; i++) // цикл по элементам
            {
                string tempStr = str_[i].Replace(".", ",").Trim(); // колдунство с точками и проблеами :D



                if (tempStr.IndexOf(" ") > -1) // пресекается возможность предоставляемая decimal.Parse() скормить ввод пробелов внутрь числа (например "1 1" = "11").
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"err: некорректный ввод {i + 1}-го элемента!");

                    goto NewInput;
                }

                if (decimal.TryParse(tempStr, out decimal tempInt)) // если элемент - число типа decimal
                {
                    rezult[i] = tempInt; // запись элемента
                }
                else // если элемент - НЕ число типа decimal
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"err: некорректный ввод {i + 1}-го элемента!");

                    goto NewInput; // поехали сначала
                }
            }
            return rezult;
        }


        //функция подсчета кол-ва положительных/отрицательных/нулей в массиве чисел
        //pisitiveValue = true (для положительных)
        //pisitiveValue = false (для отрицательных)
        //pisitiveValue = null (для нулей)
        static int PNZCount(decimal[] arrayNumbers, bool? positiveValue)
        {
            int rezult = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                switch (positiveValue)
                {
                    case true:
                        if (arrayNumbers[i] > 0) rezult++; // положительные
                        break;
                    case false:
                        if (arrayNumbers[i] < 0) rezult++; // отрицательные
                        break;
                    default:
                        if (arrayNumbers[i] == 0) rezult++; // нули
                        break;
                }
            }
            return rezult;
        }


        // отрисовка заголовка задачи
        static void PrintStartTask(string taskNumber, string taskText, string infoText = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ЗАДАЧА {taskNumber}: " + taskText);
            if (infoText != "")
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("info: " + infoText);
            }

            Console.ResetColor();
        }

        // отрисовка завершения задачи
        static void PrintFinishTask()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }







    //На случай запуска как самостоятельно проекта, не из под Главного Меню
    class Program
    {
        static void Main()
        {
            Task task = new();
            task.Start();
        }
    }
}