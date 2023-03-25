// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

Console.WriteLine("ВЫБЕРИТЕ ДЕЙСТВИЕ:");
Console.WriteLine("1 - Приемка");
Console.WriteLine("2 - Отгрузка");
Console.WriteLine("3 - Вывод на экран");
Console.WriteLine("4 - Фильтрация массива по коду");
Console.WriteLine("5 - Поиск суммарного кол-ва по заданному коду");
Console.WriteLine("6 - Поиск суммарного кол-ва по каждому из кодов детали");
Console.WriteLine("7 - Сортировка по полю Адрес ячейки");


int  LENGTH = 10;


//sklad1.Storage storage = new sklad1.Storage(2);
 

int[] code_mass = new int[LENGTH];
int[] adres_mass = new int[10] { 34, 54, 56, 29, 6, 582, 116, 34, 55, 78 };
int[] count_mass = new int[10] {34, 54, 56, 29, 6, 582, 116, 34, 55, 78};
 
for (int i = 0; i < LENGTH; i++)
    code_mass[i] = 20 + i;

//for (int i = 0; i < LENGTH; i++)
  //  adres_mass[i] = 200 + i;


Detail[] Detail1 = new Detail[LENGTH];
for (int i = 0; i < LENGTH; i++)
{
    Detail1[i] = new Detail(code_mass[i], adres_mass[i], count_mass[i]);
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
    
    Console.WriteLine("Для выхода нажмите 0");
    switch (vibor)
    {
        case 1:
            PrintMass(Priem(LENGTH, Detail1).Length, Priem(LENGTH, Detail1));
            break;
        case 2:
            PrintMass(Otgruz(LENGTH, Detail1).Length - 1, Otgruz(LENGTH, Detail1));
            break;
        case 3:
            PrintMass(LENGTH, Detail1);
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
            PrintMass(LENGTH, SortAdres(Detail1));
            break;
    }
} while (vibor != 0);

/*Detail[] SortAdres(Detail[] Detail1)
    {
    Detail[] Detail2 = new Detail[LENGTH];
    int step = Detail1.Length / 2;
        while (step > 0)
        {
            int i, j;
            for (i = step; i < Detail1.Length; i++)
            {
                int value = Detail1[i].Code;
                for (j = i - step; (j >= 0) && (Detail1[j].Code > value); j -= step)
                Detail2[j + step] = Detail1[j];
            Detail1[j + step].Code = value;
            }
            step /= 2;
        }
        return Detail2;
    }
*/
 
Detail[] SortAdres(Detail[] Detail1)
{
    Detail[] Detail2 = new Detail[Detail1.Length];//тут нужно не [LENGTH]; т.к. длина нужна такая же как и в Detail1
    //копируем исходный массив в нужный
    uint counter = 0;
    foreach (Detail detail in Detail1)
    {
        for (int j = 0; j < Detail1.Length - 1; j++)
        {
            if (Detail1[j].Adres > Detail1[j + 1].Adres)
            {
                Detail temp = new(Detail1[j].Code, Detail1[j].Adres, Detail1[j].Count);
                
                Detail1[j].Code = Detail1[j + 1].Code;
                Detail1[j].Adres = Detail1[j+1].Adres;
                Detail1[j].Count = Detail1[j+1].Count;
                Detail1[j + 1].Code = temp.Code;
                Detail1[j + 1].Adres = temp.Adres;
                Detail1[j+ 1].Count = temp.Count;
            }
        }
    }
    //Array.Sort(Detail1, Detail2);
    return Detail1;
}

void SearchCountAll()
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

}

void PrintMass(int LENGTH, Detail[] Detail1)
{
    for (int i = 0; i < LENGTH; i++)
    {
        Console.WriteLine("Код: {0}, Адрес ячейки: {1}, Количество: {2}", Detail1[i].Code, Detail1[i].Adres, Detail1[i].Count);
    }
}



Detail[] Otgruz(int LENGTH, Detail[] Detail1)
{
    Console.WriteLine("Введите код детали, которую хотите удалить:");

    int code_int = Convert.ToInt32(Console.ReadLine());

    Detail[] Detail2 = new Detail[LENGTH];

    uint count = 0;
    for (int i = 0; i < LENGTH; i++)
    {
         if (code_int != Detail1[i].Code)
            {
                Detail2[count++] = Detail1[i];
            }

         else 
            {
            continue;
            }

    }

    return Detail2;
}



Detail[] Priem(int LENGTH, Detail[] Detail1)
{
    Console.WriteLine("Введите код детали:");
    int code_int = Convert.ToInt32(Console.ReadLine()); 

    Console.WriteLine("Введите адрес ячейки:");
    int adres_int = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Введите количество:");
    int count_int = Convert.ToInt32(Console.ReadLine());

   int LENGTH2 = LENGTH+1;
    Detail[] Detail2 = new Detail[LENGTH2];

    for (int i = 0; i < LENGTH; i++)
    {
            Detail2[i] = Detail1[i];
    }
    Detail2[LENGTH2-1] = new Detail(code_int, adres_int, count_int);
    
    return Detail2;
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