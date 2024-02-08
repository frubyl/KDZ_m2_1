namespace Methods_Library
{
    public class DataProcessing
    {
        /// <summary>
        /// Метод для формирования массива из строк, удовлетворяющих условию.
        /// </summary>
        /// <param name="nameField">По какому полю выборка.</param>
        /// <param name="fileLines">Массив для выборки.</param>
        /// <returns>true если есть такие строки, false иначе.</returns>
        public static bool Sample(string nameField, string[] fileLines, out string[] ans)
        {
            string input;
            do //Обработка пустой строки.
            {
                Console.WriteLine($"\nВведите через запятую параметры для выборки поля {nameField}:");
                input = Console.ReadLine();
                if (input == String.Empty)
                {
                    Console.WriteLine("Пустая строка, повторите попытку!");
                }
                else { break; }
            } while (true);
            string[] parametrs = input.Split(','); //Массив из элементов, которые должны быть в строке.
            int n = Array.IndexOf(fileLines[0].Split("\";\""), nameField); //Получаем индекс нужного поля.
            ans = fileLines;
            int curr = 2; //Номер текущего элемента в массиве, состоящего из отобранных строк.
            for (int i = 2; i < fileLines.Length; i++)
            {
                bool flag = true;
                foreach (string el in parametrs)
                {
                    if (!fileLines[i].Split("\";\"")[n].Contains(el.Trim()))
                    {
                        flag = false; // Если нет хотя бы одного из параметров, строка не подходит.
                        break;
                    }
                }
                if (flag) //Если все поля есть, добавляем в массив и меняем текущий элемент.
                {
                    ans[curr] = fileLines[i];
                    curr += 1;
                }
            }
            if (curr == 2)
            {
                Console.WriteLine("Нет таких строк.\n");
                return false;
            }
            Array.Resize(ref ans, curr); //Избавляемся от пустых строк.
            return true;
        }
        /// <summary>
        /// Сортировка по убыванию.
        /// </summary>
        /// <param name="fileLines">Массив для сортировки.</param>
        /// <param name="emptyStrings">Кол-во строк, где поле для сортировки пустое.</param>
        /// <param name="FormatCheck">true, если все поля нужного формата, false иначе.</param>
        /// <returns></returns>
        public static string[] SortDescending(string[] fileLines, out int emptyStrings, out bool FormatCheck)
        {
            string[] copyArr = new string[fileLines.Length];
            fileLines.CopyTo(copyArr, 0);
            emptyStrings = 0;
            FormatCheck = true;
            for (int i = 2; i < copyArr.Length; i++)
            {
                for (int j = i + 1; j < copyArr.Length; j++)
                {
                    try
                    {
                        DateTime dateI = DateTime.Parse(copyArr[i].Split("\";\"")[8]);
                        DateTime dateJ = DateTime.Parse(copyArr[j].Split("\";\"")[8]);
                        int result = DateTime.Compare(dateI, dateJ);
                        string el = copyArr[i];
                        if (copyArr[i].Split("\";\"")[8] == String.Empty)
                        {
                            emptyStrings += 1;
                            el = copyArr[i];
                            copyArr[i] = copyArr[j];
                            copyArr[j] = el;
                        }
                        else if (result < 0)
                        {
                            el = copyArr[i];
                            copyArr[i] = copyArr[j];
                            copyArr[j] = el;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат данных!");
                        FormatCheck = false;
                        return copyArr;
                    }
                }
            }
            return copyArr;
        }
        /// <summary>
        /// Сортировка по возрастанию.
        /// </summary>
        /// <param name="fileLines">Массив для сортировки.</param>
        /// <param name="emptyStrings">Кол-во строк, где поле для сортировки пустое.</param>
        /// <param name="FormatCheck">true, если все поля нужного формата, false иначе.</param>
        /// <returns></returns>
        public static string[] SortAscending(string[] fileLines, out int emptyStrings, out bool FormatCheck)
        {
            string[] copyArr = new string[fileLines.Length];
            fileLines.CopyTo(copyArr, 0);
            emptyStrings = 0;
            FormatCheck = true;
            for (int i = 2; i < copyArr.Length; i++)
            {
                for (int j = i + 1; j < copyArr.Length; j++)
                {
                    try
                    {
                        DateTime dateI = DateTime.Parse(copyArr[i].Split("\";\"")[8]);
                        DateTime dateJ = DateTime.Parse(copyArr[j].Split("\";\"")[8]);
                        int result = DateTime.Compare(dateI, dateJ);
                        string el = copyArr[i];
                        if (copyArr[i].Split("\";\"")[8] == String.Empty)
                        {
                            emptyStrings += 1;
                            el = copyArr[i];
                            copyArr[i] = copyArr[j];
                            copyArr[j] = el;
                        }
                        else if (result > 0)
                        {
                            el = copyArr[i];
                            copyArr[i] = copyArr[j];
                            copyArr[j] = el;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат данных!");
                        FormatCheck = false;
                        return copyArr;
                    }
                }
            }
            return copyArr;
        }
    }
}
