using Methods_Library;
class Program
{
    static void Main(string[] args)
    {
        do
        {
            string[] fileData;
            do //Получаем путь к файлу.
            {
                Console.WriteLine("Введите абсолютный путь к файлу:");
                try
                {
                    CsvProcessing.FPath = Console.ReadLine();
                    fileData = CsvProcessing.Read();
                    Console.WriteLine("Файл прочитан!");
                    break;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch
                {
                    Console.WriteLine("Возникла непредвиденная ошибка");
                }
            } while (true);
            Methods.Menu(out int n);
            try
            {
                switch (n)
                {
                    case 1:
                        if (DataProcessing.Sample("District", fileData, out string[] ans1))
                        {
                            Methods.PrintLines(ans1);
                            Methods.SaveFile(ans1);
                        }
                        break;
                    case 2:
                        if (DataProcessing.Sample("Owner", fileData, out string[] ans2))
                        {
                            Methods.PrintLines(ans2);
                            Methods.SaveFile(ans2);
                        }
                        break;
                    case 3:
                        if (DataProcessing.Sample("AdmArea", fileData, out string[] arrDistrict) && DataProcessing.Sample("Owner", fileData, out string[] arrOwner))
                        {
                            string[] ans3 = new string[arrDistrict.Length];
                            int curr = 0;
                            for (int i = 0; i < arrDistrict.Length; i++)
                            {
                                if (arrOwner.Contains(arrDistrict[i]))
                                {
                                    ans3[curr] = arrDistrict[i];
                                    curr += 1;
                                }
                            }
                            Array.Resize(ref ans3, curr);
                            Methods.PrintLines(ans3);
                            Methods.SaveFile(ans3);
                        }
                        break;
                    case 4:
                        string[] ans4 = DataProcessing.SortAscending(fileData, out int emptyStrings, out bool Check1);
                        if (Check1)
                        {
                            Methods.PrintLines(ans4, emptyStrings);
                            Methods.SaveFile(ans4);
                        }
                        break;
                    case 5:
                        string[] ans5 = DataProcessing.SortDescending(fileData, out int emptyStrings2, out bool Check2);
                        if (Check2)
                        {
                            Methods.PrintLines(ans5, emptyStrings2);
                            Methods.SaveFile(ans5);
                        }
                        break;
                    case 6: return;
                };
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка, повторите попытку");
                continue;
            }
        } while (true);
    }
}