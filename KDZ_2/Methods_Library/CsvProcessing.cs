namespace Methods_Library
{
    public class CsvProcessing
    {
        static string fPath; //Путь к файлу.
        static string firstRow = "\"ID\";\"FullName\";\"global_id\";\"ShortName\";\"AdmArea\";\"District\";\"Address\";\"Owner\";\"TestDate\";\"geodata_center\";\"geoarea\";";
        static string secondRow = "\"Код\";\"Полное официальное наименование\";\"global_id\";\"Сокращенное наименование\";\"Административный округ\";\"Район\";\"Адрес\";\"Наименование компании\";\"Дата проверки\";\"geodata_center\";\"geoarea\";";
        public static string FPath { get { return fPath; } set { fPath = value; } }
        /// <summary>
        /// Чтение файла.
        /// </summary>
        /// <returns>Массив строк файла.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывает ошибку, если неверный путь.</exception>
        /// <exception cref="FormatException">Выбрасывает ошибку, если неправильная шапка, либо неправильное кол-во полей в строке.</exception>
        public static string[] Read()
        {
            char[] invalidPathChars = Path.GetInvalidPathChars();
            string[] rowData = null;
            if (File.Exists(fPath)) //Проверка на существование файла.
            {
                rowData = File.ReadAllLines(fPath);
            }
            else { throw new ArgumentNullException("Неверный путь"); }
            if (rowData.Length < 2 || rowData[0] != firstRow || rowData[1] != secondRow) { throw new FormatException("Неверная структура файла"); } //Проверка кол-ва строк и правильности шапки таблицы.
            for (int i = 0; i < rowData.Length; i++)
            {
                if (rowData[i].Split("\";\"").Length != 11) //Проверка на кол-во полей в каждой строке.
                {
                    throw new FormatException("Неверная структура файла");
                }

            }
            return rowData;
        }
        /// <summary>
        /// Запись в файл для строки.
        /// </summary>
        /// <param name="nPath">Директория, где будет лежать файл.</param>
        /// <param name="newLine">Строка для записи.</param>
        /// <returns>true, если удалось записать файл, false иначе.</returns>
        public static bool Write(string nPath, string newLine)
        {
            var directory = new DirectoryInfo(nPath);
            char sep = Path.DirectorySeparatorChar;
            if (!directory.Exists) //Проверка на существование директории.
            {
                Console.WriteLine("Такой директории не существует, повторите ввод!");
                return false;
            }
            else
            {
                Console.WriteLine("Введите имя файла:");
                string fileName = Console.ReadLine();
                string path = nPath + sep + fileName;
                if (!File.Exists(path))
                { //Если файла не существует, то создаем и записываем шапку таблицы.
                    File.AppendAllText(path, firstRow + '\n');
                    File.AppendAllText(path, secondRow + '\n');
                    File.AppendAllText(path, newLine);
                }
                else
                {
                    string[] fileData = File.ReadAllLines(path);
                    if (fileData.Length < 2 || fileData[0] != firstRow || fileData[1] != secondRow)
                    {
                        Console.WriteLine("Неверная структура файла!\nВведите полностью директорию, где хотите сохранить файл.");
                        return false;
                    }
                    for (int i = 0; i < fileData.Length; i++)
                    {
                        if (fileData[i].Split("\";\"").Length != 11) //Проверка на кол-во полей в каждой строке.
                        {
                            Console.WriteLine("Неверная структура файла!\nВведите полностью директорию, где хотите сохранить файл.");
                            return false;
                        }
                    }
                    File.AppendAllText(path, '\n' + newLine);
                }
            }
            return true;

        }
        /// <summary>
        /// Запись для массива, файл всегда пересоздается.
        /// </summary>
        /// <param name="nPath">Директория, где будет лежать файл.</param>
        /// <param name="newLines">Массив строк для завписи.</param>
        /// <returns>true, если удалось записать файл, false иначе.</returns>            
        public static bool Write(string nPath, string[] newLines)
        {
            var directory = new DirectoryInfo(nPath);
            char sep = Path.DirectorySeparatorChar;
            if (!directory.Exists) //Проверка на существование директории.
            {
                Console.WriteLine("Такой директории не существует, повторите ввод!");
                return false;
            }
            else
            {
                Console.WriteLine("Введите имя файла:");
                string fileName = Console.ReadLine();
                string path = nPath + sep + fileName;
                File.WriteAllLines(path, newLines);
            }
            return true;
        }
    }
}
