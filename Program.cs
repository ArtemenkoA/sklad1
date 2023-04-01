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
        Console.WriteLine("1 - Приемка");
        Console.WriteLine("2 - Отгрузка");
        Console.WriteLine("3 - Вывод на экран");
        Console.WriteLine("4 - Фильтрация массива по коду");
        Console.WriteLine("5 - Поиск суммарного кол-ва по заданному коду");
        Console.WriteLine("6 - Поиск суммарного кол-ва по каждому из кодов детали");
        Console.WriteLine("7 - Сортировка по полю Адрес ячейки");


     

        string path = @"C:\Users\79152\source\repos\sklad1\Details.bat";

        /* using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
         {
             //Detail[] Detail1 = new Detail[20];

             foreach (Detail Detail_bin in Detail1)
             {
                 writer.Write(Detail_bin.Code);
                 writer.Write(Detail_bin.Adres);
                 writer.Write(Detail_bin.Count);
             }
         }
        */
      /* List<Detail> Details_bin = new List<Detail>();

        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.PeekChar() > -1)
            {
                int code = reader.ReadInt32();
                int adres = reader.ReadInt32();
                int count = reader.ReadInt32();
                Details_bin.Add(new Detail(code, adres, count));
            }
            
        }*/



        int Answer()
        {
            int result = Convert.ToInt32(Console.ReadLine());
            return result;
        }

        int vibor;

        do
        {
            vibor = Answer();

            Console.WriteLine("Для выхода нажмите 0");
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
                   // SortCode();
                    break;
                case 5:
                   // SearchCountCode();
                    break;
                case 6:
                   // SearchCountAll();
                    break;
                case 7:
                    PrintMass();
                   // SortAdres(Detail1);
                    break;
            }
        } while (vibor != 0);


        Detail[] SortAdres(Detail[] Detail1)
        {
            Detail[] Detail2 = new Detail[Detail1.Length];
                                                          //копируем исходный массив в нужный
            uint counter = 0;
            foreach (Detail detail in Detail1)
            {
                Detail2[counter++] = detail;
            }
            //обрабатываем скопированный массив, чтобы вернуть отсортированную копию, но не трогаем оригинал 
            for (int i = 0; i < Detail2.Length - 1; i++)
            {
                for (int j = i + 1; j < Detail2.Length; j++)
                {
                    if (Detail2[i].Adres > Detail2[j].Adres)
                    {
                        //используем самописный swap
                        swapDetail(ref Detail2[i], ref Detail2[j]);
                    }
                }
            }

            return Detail2;
        }

        void swapDetail(ref Detail detail1, ref Detail detail2)
        {
            Detail temp = detail1;
            detail1 = detail2;
            detail2 = temp;
        }

      /*  void SearchCountAll()
        {
            Console.WriteLine("Введите код детали:");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < Detail1.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {

                    if (arr[j] == Detail1[i].Code)
                    {
                        Console.WriteLine(" Количество деталей c кодом {1} на складе: {0}", Detail1[i].Count, Detail1[i].Code);
                    }
                }
            }
        }

        void SearchCountCode()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Detail1.Length; i++)
            {

                if (code_int == Detail1[i].Code)
                {
                    Console.WriteLine(" Количество деталей на складе: {0}", Detail1[i].Count);
                }
            }
        }


        void SortCode()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Detail1.Length; i++)
            {

                if (code_int == Detail1[i].Code)
                {
                    Console.WriteLine("{0}, {1}, {2}", Detail1[i].Code, Detail1[i].Adres, Detail1[i].Count);
                }
            }

        }*/

        void PrintMass()
        {
            List<Detail> Details_Print = new List<Detail>();

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int code = reader.ReadInt32();
                    int adres = reader.ReadInt32();
                    int count = reader.ReadInt32();
                    Details_Print.Add(new Detail(code, adres, count));

                }
            }

            Detail[] Detail = new Detail[50];
            Detail = Details_Print.ToArray();

            for (int i = 0; i < Details_Print.Count; i++)
            {
                Console.WriteLine("Код: {0}, Адрес ячейки: {1}, Количество: {2}", Detail[i].Code, Detail[i].Adres, Detail[i].Count);
            }
            Details_Print.Clear();
        }



        void Otgruz()
        {
            Console.WriteLine("Введите код детали, которую хотите удалить:");

            int code_int = Convert.ToInt32(Console.ReadLine());
            List<Detail> Details_Otgruz = new List<Detail>();


            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int code = reader.ReadInt32();
                    int adres = reader.ReadInt32();
                    int count = reader.ReadInt32();
                    Details_Otgruz.Add(new Detail(code, adres, count));
                }
                
            }
            Detail[] Detail1 = new Detail[20];
            Detail1 = Details_Otgruz.ToArray();

            Detail[] Detail2 = new Detail[20];

            uint count1 = 0;
            for (int i = 0; i < Detail1.Length; i++)
            {
                if (code_int != Detail1[i].Code)
                {
                    Detail2[count1++] = Detail1[i];
                }

                else
                {
                    continue;
                }

            }
            Details_Otgruz.Clear();

            //for (int i = 0;i < Detail2.Length;i++)
            Details_Otgruz.AddRange(Detail2);

            Detail[] Detail_otgruz = Details_Otgruz.ToArray();

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {

                foreach (Detail Detail in Detail_otgruz)
                {
                    writer.Write(Detail.Code);
                    writer.Write(Detail.Adres);
                    writer.Write(Detail.Count);
                }
            }

            Details_Otgruz.Clear();

        }



        void Priem()
        {
            Console.WriteLine("Введите код детали:");
            int code_int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите адрес ячейки:");
            int adres_int = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество:");
            int count_int = Convert.ToInt32(Console.ReadLine());

            List<Detail> Details_Priem = new List<Detail>();

            Detail Detail2_new = new Detail(code_int, adres_int, count_int);

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {

                while (reader.PeekChar() > -1)
                {
                    int code = reader.ReadInt32();
                    int adres = reader.ReadInt32();
                    int count = reader.ReadInt32();
                    Details_Priem.Add(new Detail(code, adres, count));
                }
            }
            Details_Priem.Add(Detail2_new);
            Detail[] Detail_priem = Details_Priem.ToArray();


                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {

                    foreach (Detail Detail in Detail_priem)
                    {
                        writer.Write(Detail.Code);
                        writer.Write(Detail.Adres);
                        writer.Write(Detail.Count);
                    }
                }

            Details_Priem.Clear();
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