// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using System.IO;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("ВЫБЕРИТЕ ДЕЙСТВИЕ:");
        PrintMenu();

        void PrintMenu()
        {
            Console.WriteLine("1 - Приемка");
            Console.WriteLine("2 - Отгрузка");
            Console.WriteLine("3 - Вывод на экран");
            Console.WriteLine("4 - Фильтрация массива по коду");
            Console.WriteLine("5 - Поиск суммарного кол-ва по заданному коду");
            Console.WriteLine("6 - Поиск суммарного кол-ва по каждому из кодов детали");
            Console.WriteLine("7 - Сортировка по полю Адрес ячейки");
        }

     

        string path = @"C:\Users\79152\source\repos\sklad1\Details.bat";

        List<Detail> ReadFile()
        {
            List<Detail> list = new List<Detail>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int code = reader.ReadInt32();
                    int adres = reader.ReadInt32();
                    int count = reader.ReadInt32();
                    list.Add(new Detail(code, adres, count));

                }
            }
            return list;
        }

        void WriteToFile(Detail[] detail)
        {
            File.Delete(path);

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Detail Detail in detail)
                {
                    writer.Write(Detail.Code);
                    writer.Write(Detail.Adres);
                    writer.Write(Detail.Count);
                }
            }

        }


        int Answer()
        {
            int result = Convert.ToInt32(Console.ReadLine());
            return result;
        }

        int vibor;

        do
        {
            vibor = Answer();

            switch (vibor)
            {
                case 1:
                    Priem();
                    PrintMass();
                    break;
                case 2:
                    Otgruz();
                    PrintMass();
                    break;
                case 3:
                    PrintMass();
                    break;
                case 4:
                    SortCode();
                    break;
                case 5:
                    SearchCountCode();
                    break;
                case 6:
                    SearchCountAll();
                    break;
                case 7:
                    SortAdres();
                    break;
                case 8:
                    PrintMenu();
                    break;
            }
            Console.WriteLine("\n\nДля выхода нажмите 0, для вызова меню - 8\n\n");

        } while (vibor != 0);


        void SortAdres()
        {
            List<Detail> Details_SearchCountAll = ReadFile();

            Detail[] Detail = Details_SearchCountAll.ToArray();

            for (int i = 0; i < Detail.Length - 1; i++)
            {
                for (int j = i + 1; j < Detail.Length; j++)
                {
                    if (Detail[i].Adres > Detail[j].Adres)
                    {
                        swapDetail(ref Detail[i], ref Detail[j]);
                    }
                }
            }
            for (int i = 0; i < Detail.Length; i++)
            {
                Console.WriteLine("Код: {0}, Адрес ячейки: {1}, Количество: {2}", Detail[i].Code, Detail[i].Adres, Detail[i].Count);
            }
        }

        void swapDetail(ref Detail detail1, ref Detail detail2)
        {
            Detail temp = detail1;
            detail1 = detail2;
            detail2 = temp;
        }

        void SearchCountAll()
        {
            Console.WriteLine("Введите код детали:");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Detail> Details_SearchCountAll = ReadFile();

            Detail[] Detail = Details_SearchCountAll.ToArray();

            int error = 0;

            for (int i = 0; i < Detail.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {

                    if (arr[j] == Detail[i].Code)
                    {
                        Console.WriteLine(" Количество деталей c кодом {1} на складе: {0}", Detail[i].Count, Detail[i].Code);
                        error++;
                    }
                }
            }
            if (error == 0)
            {
                Console.WriteLine("Деталей с заданными кодами не найдено");
            }
        }
      

        void SearchCountCode()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            List<Detail> Details_SearchCountCode = ReadFile();

            Detail[] Detail = Details_SearchCountCode.ToArray();

            int error = 0;

            for (int i = 0; i < Detail.Length; i++)
            {

                if (code_int == Detail[i].Code)
                {
                    Console.WriteLine(" Количество деталей на складе: {0}", Detail[i].Count);
                    error++;
                }
                
            }
                if (error == 0)
                {
                    Console.WriteLine("Деталей с заданным кодом не найдено");
                }
        }

      
        void SortCode()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            List<Detail> Details_SortCode = ReadFile();

            Detail[] Detail = Details_SortCode.ToArray();

            for (int i = 0; i < Detail.Length; i++)
            {

                if (code_int == Detail[i].Code)
                {
                    Console.WriteLine("Код: {0}, Адрес ячейки: {1}, Количество: {2}", Detail[i].Code, Detail[i].Adres, Detail[i].Count);
                }
            }

        }

        void PrintMass()
        {
            List<Detail> Details_Print = ReadFile();

            Detail[] Detail = Details_Print.ToArray();

            for (int i = 0; i < Detail.Length; i++)
            {
                Console.WriteLine("Код: {0}, Адрес ячейки: {1}, Количество: {2}", Detail[i].Code, Detail[i].Adres, Detail[i].Count);
            } 
        }



        void Otgruz()
        {
            Console.WriteLine("Введите код детали, которую хотите удалить:");

            int code_int = Convert.ToInt32(Console.ReadLine());
            List<Detail> Details_Otgruz = ReadFile();

            Detail[] Detail = Details_Otgruz.ToArray();

            List<Detail> DetailsOtgruzNew = new List<Detail>();

            for (int i = 0; i < Details_Otgruz.Count; i++)
            {
                if (code_int != Detail[i].Code)
                {
                    DetailsOtgruzNew.Add(Detail[i]);
                }

                else
                {
                    continue;
                }

            }

            Detail[] Detail2 = DetailsOtgruzNew.ToArray();

            WriteToFile(Detail2);
        }



        void Priem()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите адрес ячейки:");
            int adres_int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество:");
            int count_int = Convert.ToInt32(Console.ReadLine());

            List<Detail> Details_Priem = ReadFile();

            Detail Detail2_new = new Detail(code_int, adres_int, count_int);
            Details_Priem.Add(Detail2_new);

            Detail[] Detail_priem = Details_Priem.ToArray();

            WriteToFile(Detail_priem);
        } 
    }
}

class Detail
{
    private int code, adres, count;

    public Detail(int code, int adres, int count)
    {
        this.code = code;
        this.adres = adres;
        this.count = count;
    }
    public int Code
    {
        get { return code; }
        set { value = Code; }
    }
    public int Adres
    {
        get { return adres; }
        set { value = Adres; }
    }

    public int Count
    {
        get { return count; }
        set { value = Count; }
    }
}