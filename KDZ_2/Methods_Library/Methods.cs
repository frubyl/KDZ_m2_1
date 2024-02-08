namespace Methods_Library
{
    public class Methods
    {
        /// <summary>
        /// Вывод меню.
        /// </summary>
        /// <param name="n">Номер пункта меню.</param>
        public static void Menu(out int n)
        {
            do
            {
                Console.WriteLine("\nУкажите номер пункта меню без знаков препинания для запуска действия:\nПример ввода: 1");
                Console.WriteLine("1. Произвести выборку по значению District");
                Console.WriteLine("2. Произвести выборку по значению Owner");
                Console.WriteLine("3. Произвести выборку по значению AdmArea и Owner");
                Console.WriteLine("4. Отсортировать по значению TestDate (по возрастанию даты)");
                Console.WriteLine("5. Отсортировать по значению TestDate (по убыванию даты)");
                Console.WriteLine("6. Выход из программы");
                if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 6)
                {
                    Console.WriteLine("Указан неверный пункт меню, повторите попытку");
                }
                else { break; }
            } while (true);
        }
        /// <summary>
        /// Вывод массива.
        /// </summary>
        /// <param name="lines">Массив для вывода.</param>
        public static void PrintLines(string[] lines)
        {
            Console.WriteLine("Результат: ");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i].Replace("\";\"", "\" \"") + '\n');
            }
        }
        /// <summary>
        /// Вывод массива после сортировки без строк, где поле для сортировки было пустым.
        /// </summary>
        /// <param name="lines">Массив для вывода.</param>
        /// <param name="emptyLines">Кол-во строк, которые не надо выводить.</param>
        public static void PrintLines(string[] lines, int emptyLines)
        {
            Console.WriteLine("Результат: ");
            for (int i = 0; i < lines.Length - emptyLines; i++)
            {
                Console.WriteLine(lines[i].Replace("\";\"", "\" \"") + '\n');

            }
        }
        /// <summary>
        /// Сохраняет файл.
        /// </summary>
        /// <param name="ans">Массив для записи в файл.</param>
        public static void SaveFile(string[] ans)
        {
            Console.WriteLine("\nЕсли хотите сохранить данные введите \"Да\", иначе любой ввод:");
            if (Console.ReadLine()?.ToLower().Trim() == "да")
            {
                Console.WriteLine("\nВведите полностью директорию, где хотите сохранить файл.\nПример для Windows: C:\\Users\\frubyl\\Desktop\\folder");
                do
                {
                    if (ans.Length == 3) //Если в файле одна строка, т.е. 2 строки шапки + сама строкаю.
                    {
                        if (CsvProcessing.Write(Console.ReadLine(), ans[2])) //Перегрузка для записи строки.
                        {
                            Console.WriteLine("Файл записан!");
                            break;
                        }
                        else { continue; }
                    }
                    else
                    {
                        if (CsvProcessing.Write(Console.ReadLine(), ans)) //Перегрузка для записи массива.
                        {
                            Console.WriteLine("Файл записан!");
                            break;
                        }
                        else { continue; }
                    }
                } while (true);
            }
        }
    }
}
