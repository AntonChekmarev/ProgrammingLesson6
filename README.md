# Знакомство с языками программирования - ДЗ № 6

## Содержание ДЗ

* **`Program.cs`** - главное меню домашней работы. Для его работоспособности **в проекте должны присутствовать все файлы данного репозитория** (за исключением README.md).

* **`Task1.cs`** - HARD-2 - на входе размерность двумерного массива, на выходе двумерный массив случайных целых чисел, среднее арифметическое массива, минимальный и масимальный элементы с их индексами.

    _Организован контроль ввода. В качестве кол-ва строк/столбцов допустим ввод натурального числа, соответствующего типу Integer. Пробелы по обе стороны числа игнорируются._

* **`Task2.cs`** - Задача № 41 - на входе массив чисел, на выходе информация, сколь в массиве чисел больше нуля.

    _Организован контроль ввода. Допустим ввод целых/дробных положительных/отрицательных чисел, соответствующих типу Decimal. Пробелы по обе стороны числа игнорируются.Дробная часть числа вводится через точку. Перечисляются числа через запятую. Пресекается возможность предоставляемая decimal.Parse() скормить ввод пробелов внутрь числа (например "1 1" = "11"), в отлчие от создателей этой функции, я считаю это некорректным вводом._