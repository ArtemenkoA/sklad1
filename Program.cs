// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;

int vibor = PrintMenu("ВЫБЕРИТЕ ДЕЙСТВИЕ");

Random random = new Random();

int  LENGTH = 10;


//sklad1.Storage storage = new sklad1.Storage(2);


int[] code_mass = new int[LENGTH];
int[] adres_mass = new int[LENGTH];
int[] count_mass = new int[10] {34, 54, 56, 29, 6, 582, 116, 34, 55, 78};

for (int i = 0; i < LENGTH; i++)
    code_mass[i] = 20 + i;

for (int i = 0; i < LENGTH; i++)
    adres_mass[i] = 200 + i;


Detail[] Detail1 = new Detail[LENGTH];
for (int i = 0; i < LENGTH; i++)
{
    Detail1[i] = new Detail(code_mass[i], adres_mass[i], count_mass[i]);
}



/*
int code1 = 20; int adres1 = 200;
int code2 = 21; int adres2 = 201;
int code3 = 20; int adres3 = 202;
int code4 = 21; int adres4 = 203;
int code5 = 20; int adres5 = 204;
int code6 = 21; int adres6 = 205;
int code7 = 20; int adres7 = 206;
int code8 = 21; int adres8 = 207;
int code9 = 20; int adres9 = 208;
int code10 = 21; int adres10 = 209;*/




int PrintMenu(string name)
{
    Console.WriteLine("ВЫБЕРИТЕ ДЕЙСТВИЕ:");
    Console.WriteLine("1 - Приемка");
    Console.WriteLine("2 - Отгрузка");
    Console.WriteLine("3 - Вывод на экран");
    Console.WriteLine("4 - Фильтрация массива по коду");
    Console.WriteLine("5 - Поиск суммарного кол-ва по заданному коду");
    Console.WriteLine("6 - Поиск суммарного кол-ва по каждому из кодов детали");
    Console.WriteLine("7 - Сортировка по полю Адрес ячейки");
    string str;
    int result;
    bool success;

    do
    {
        str = Console.ReadLine();

        success = int.TryParse(str, out result);

        if (!success && result > 8)
        {
            Console.WriteLine("Не удалось распознать команду, введите еще раз", str);
        }
    }
    while (!success);

    return result;
}

Console.WriteLine(vibor);//отладочная печать

switch (vibor)
{
    case 1:
        PrintMass(Priem(LENGTH, Detail1).Length, Priem(LENGTH, Detail1));
        break;
    case 2: 
        PrintMass(Otgruz(LENGTH, Detail1).Length-1, Otgruz(LENGTH, Detail1));
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
       // SearchCountAll();
        break;
    case 7:
        SortAdres();
        break;
}

void SortAdres()
{

}

/*void SearchCountAll()
{
    string[] code = new string[10];
    int[] code_int = new int[10];
    bool success;

    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Введите код детали:");
        do
        {

            code = Console.ReadLine();


            success = int.TryParse(code[i], out code_int[i]);

            if (!success)
            {
                Console.WriteLine("Не удалось распознать, введите еще раз", code);
            }
        }
        while (!success);
    }

    for (int i = 0; i < Detail1.Length; i++)
    {
        for (int j = 0; j < code_int.Length; j++)
        {

            if (code_int[j] == Detail1[i].Code)
            {
                Console.WriteLine(" Количество деталей c кодом {1} на складе: {0}", Detail1[i].Count, Detail1[i].Code);
            }
        }
    }
}*/

void SearchCountCode()
{
    string? code = "";
    int code_int = 0;
    bool success;
    Console.WriteLine("Введите код детали:");

    do
    {
        code = Console.ReadLine();

        success = int.TryParse(code, out code_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз", code);
        }
    }
    while (!success);

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
    string? code = "";
    int code_int = 0;
    bool success;
    Console.WriteLine("Введите код детали:");

    do
    {
        code = Console.ReadLine();

        success = int.TryParse(code, out code_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз", code);
        }
    }
    while (!success);

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
    string? code;
    int code_int;
    bool success;
    Console.WriteLine("Введите код детали, которую хотите удалить:");

    do
    {
        code = Console.ReadLine();

        success = int.TryParse(code, out code_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз");
        }
    }
    while (!success);

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
    string? code = "", adres = "", count = "";
    int code_int = 0, adres_int = 0, count_int = 0;

    bool success;

    Console.WriteLine("Введите код детали:");

    do
    {
        code = Console.ReadLine();

        success = int.TryParse(code, out code_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз");
        }
    }
    while (!success);

    Console.WriteLine("Введите адрес ячейки:");

    do
    {
         adres = Console.ReadLine();

        success = int.TryParse(adres, out adres_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз");
        }
    }
    while (!success);

    Console.WriteLine("Введите количество:");

    do
    {
        count = Console.ReadLine();

        success = int.TryParse(count, out count_int);

        if (!success)
        {
            Console.WriteLine("Не удалось распознать, введите еще раз");
        }
    }
    while (!success);

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