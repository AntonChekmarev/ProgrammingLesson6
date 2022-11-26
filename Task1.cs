namespace Task1
{

    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("HARD-2", "на входе размерность двумерного массива, на выходе двумерный массив случайных целых чисел, среднее арифметическое массива, минимальный и масимальный элементы с их индексами.");

            int rowsCount = InputInt("Введите кол-во строк");
            int columnsCount = InputInt("Введите кол-во столбцов");

            int[,] array = TwoDimensionalArrayRandom(rowsCount, columnsCount, 0, 99);


            Console.WriteLine();
            Console.WriteLine("Сформирована таблица:");
            TwoDimensionalArrayPrint(array);

            decimal[][] finishArray = MinMaxValuesWithIndexsAndArithmeticMeanInTwoDimensionalArray(array);

            Console.WriteLine("");
            Console.WriteLine("Минимальный элемент: " + finishArray[0][0]);
            Console.WriteLine($"Индексы расположения: [{IndesMinAndMaxInTwoDimensionalArrayToString(finishArray[1])}]");

            Console.WriteLine("");
            Console.WriteLine("Максимальный элемент: " + finishArray[2][0]);
            Console.WriteLine($"Индексы расположения: [{IndesMinAndMaxInTwoDimensionalArrayToString(finishArray[3])}]");

            Console.WriteLine("");
            Console.WriteLine("Среднее арифметическое двумерного массива: " + finishArray[4][0].ToString("0.##").Replace(",", "."));

            PrintFinishTask();
        } // === FINISH ===


        // Функция ввода и проверки данных числа int.
        static int InputInt(string inputText)
        {
            int rezult;

            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write(inputText + ": ");

                string str = Console.ReadLine()!.Trim();

                if (int.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: неcоответствие типу Integer!");

                    continue;
                }

                if (rezult <= 0) // доп проверка
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: количество должно быть натуральным числом!");

                    continue;
                }

                break;
            } while (true);

            return rezult;
        }

        //функция формирования двумерного массива со случайными элеменатми в задаваемом дипазоне
        static int[,] TwoDimensionalArrayRandom(int rowsCount, int columnsCount, int min = 0, int max = 1)
        {
            int[,] rezult = new int[rowsCount, columnsCount];

            Random rnd = new();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    rezult[i,j] = rnd.Next(min, max + 1);
                }
            }

            return rezult;
        }

        void TwoDimensionalArrayPrint(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                if (i!=0) Console.WriteLine();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    string str = array[i, j].ToString();    
                    Console.Write(" "+ str + ((str.Length < 2) ? "   " : "  "));
                }
            }
            Console.WriteLine();
        }

        // функция возвращает зубчатый массив.
        // Массив 0: мин значение массива
        // Массив 1: индексы мин значений (парами)
        // Массив 2: макс значение массива
        // Массив 3: индексы макс значений (парами)
        // Массив 4: среднее арифметическое массива    
        static decimal[][] MinMaxValuesWithIndexsAndArithmeticMeanInTwoDimensionalArray(int[,] array)
        {
            decimal minValue = array[0,0]; // мин значение в массиве
            int minCount = 0; // кол-во мин значений в массиве
            decimal maxValue = array[0,0]; // макс значение в массиве
            int maxCount = 0; // кол-во макс значений в массиве            

            // поиск мин и макс значений и их кол-ва в массиве
            for (int i = 0; i < array.GetLength(0); i++)
            {      
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    var value = array[i, j];
                    if (value == minValue) minCount++;
                    if (value == maxValue) maxCount++;

                    if (value < minValue) { minValue = value; minCount = 1; }
                    if (value > maxValue) { maxValue = value; maxCount = 1; }
                }
            }


            decimal[] minIndexs = new decimal[minCount*2]; // массив индексов для мин значения
            int minI = 0; // текущий индекс в массиве индексов для мин значения
            decimal[] maxIndexs = new decimal[maxCount*2];// массив индексов для макс значения
            int maxI = 0; // текущий индекс в массиве индексов для мин значения

            // формируются массивы с индексами мин и макс значений
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == minValue) { minIndexs[minI] = i; minI++; minIndexs[minI] = j; minI++; }
                    if (array[i,j] == maxValue) { maxIndexs[maxI] = i; maxI++; maxIndexs[maxI] = j; maxI++; }
                }
            }

            // результат
            decimal[][] rezult = {
                                new decimal[1], // мин значение
                                new decimal[minCount], // индексы мин значения 
                                new decimal[1], // макс значение
                                new decimal[maxCount], // индексы макс значения 
                                new decimal[1] // среднее арифметическое
                               };


            rezult[0][0] = minValue;
            rezult[1] = minIndexs;
            rezult[2][0] = maxValue;
            rezult[3] = maxIndexs;
            rezult[4][0] = ArithmeticMeanInTwoDimensionalArray(array);

            return rezult;
        }

        // функция получения среднего арифметического числа из двумерного массива чисел
        static decimal ArithmeticMeanInTwoDimensionalArray(int[,] array)
        {
            decimal rezult = 0;
            decimal sum = 0;

            foreach (decimal value in array)
            {
                sum += value;
            }
            rezult = sum / array.Length;

            return rezult;
        }

        //функция преобразования массива чисел в строку
        static string IndesMinAndMaxInTwoDimensionalArrayToString(decimal[] array, string split = ",")
        {
            string rezult = "";

            for (int i = 0; i < array.Length; i++)
            {            
                
                rezult += array[i];
                if (i < array.Length - 1)
                {
                    if (i % 2 != 0) rezult += "; ";
                    else rezult += ",";
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
                Console.WriteLine();
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
}