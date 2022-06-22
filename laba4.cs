using System;
//Створити суперклас Вантажоперевізник і підкласи Літак, Поїзд, Автомобіль, Вагон.
//Визначити час і вартість перевезення для зазначених міст і відстаней.


class Program
{
    static void Main()
    {

        Pereviznik pereviznik = new Pereviznik();
        pereviznik.inicialisation();
        int Number = pereviznik.CityChoise();
        pereviznik.GetPrice(Number);

    }//инициализция суперкласа 


}
//создаю подкласы Літак, Поїзд, Автомобіль, Вагон
//в них вписываю изн стоимость и метод с увеличением стоимости в случае увеличения времени
class Plane : Pereviznik
{
    int price = 100000;

    public int DeliveryTime(int s)
    {
        return s / Speed;
    }

    public int DeliveryPrice(int s)
    {
        int t = DeliveryTime(s);

        if (t >= 0 && t <= 10) return price;
        else if (t > 20) return price + 5000;
        else return price + 10000;
    }

    public int Speed { get; } = 500;

}
class Train : Pereviznik
{

    int price = 40000;

    public int DeliveryTime(int s)
    {
        return s / Speed;
    }

    public int DeliveryPrice(int s)
    {
        int t = DeliveryTime(s);

        if (t >= 0 && t <= 10) return price;
        else if (t > 20) return price + 5000;
        else return price + 10000;
    }
    public int Speed { get; } = 120;
}
class Car : Pereviznik
{
    int price = 20000;

    public int DeliveryTime(int s)
    {
        return s / Speed;
    }

    public int DeliveryPrice(int s)
    {
        int t = DeliveryTime(s);

        if (t >= 0 && t <= 10) return price;
        else if (t > 20) return price + 5000;
        else return price + 10000;
    }
    public int Speed { get; } = 80;
}
class Vagon : Pereviznik
{
    int price = 15000;

    public int DeliveryTime(int s)
    {
        return s / Speed;
    }

    public int DeliveryPrice(int s)
    {
        int t = DeliveryTime(s);

        if (t >= 0 && t <= 10) return price;
        else if (t > 20) return price + 5000;
        else return price + 10000;
    }
    public int Speed { get; } = 80;
}


public class Pereviznik
{
    string Text = null;
    int amount = -1;
    public void inicialisation()
    {
        Console.WriteLine(new string('*', 15) + " Инициализация значений грузоперевозчика " + new string('*', 15));// просто оформление
        Console.WriteLine();

        string Text = null;

        do
        {
            if (amount == -1) { Console.WriteLine("Введите количество городов > 0  в которые грузоперевозчик поставляет груз:"); amount = 0; }
            else
            {
                Console.WriteLine("Ошибка. Введите количество городов > 0  в которые грузоперевозчик поставляет груз:");
            }
            Text = Console.ReadLine();
        }
        while (!int.TryParse(Text, out amount) || amount <= 0); //метод где спршиваем количество городов, будет спрашивать пока количество не напишете чысло не равное 0

        this.NumberOfCitys = amount;

        for (int i = 0; i < amount; i++)
        {
            Console.WriteLine("Укажите наименование города под #{0}: ", i);
            this.City[i] = Console.ReadLine();

            int Distance = -1;
            do
            {
                if (Distance == -1) { Console.WriteLine("Укажите расстояние(число) до города {0}: ", this.City[i]); Distance = 0; }

                else
                {
                    Console.WriteLine("Ошибка ввода! Укажите расстояние(число) до города {0}: ", this.City[i]);
                }
                Text = Console.ReadLine();
            }
            while (!int.TryParse(Text, out Distance));

            this.Distance[i] = Distance;
        } //методы где узнаем название города и растояние до него

        Console.WriteLine(new string('*', 15) + " Завершение инициализации значений для грузоперевозчика " + new string('*', 15));// просто оформление
        Console.WriteLine();
    }

    public int CityChoise() //узнаем номер города куда нужно доставить
    {
        int NumberOfCity = -1;
        do
        {
            if (NumberOfCity == -1)
            {
                Console.WriteLine("Введите номер города куда нужно доставить:");

                NumberOfCity = 0;
            }

            else
            {
                Console.WriteLine("Ошибка ввода! Введите номер города куда нужно доставить:");
            }

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("#{0} - название {1}", i, this.City[i]); //выводит номер города и его название 
            }

            Text = Console.ReadLine();
        }
        while (!int.TryParse(Text, out NumberOfCity) || NumberOfCity > amount - 1);

        return NumberOfCity;
    }
    public void GetPrice(int NumberOfCity) // вывод цен и длительности доставкы
    {
        string City = this.City[NumberOfCity];
        int s = this.Distance[NumberOfCity];
        Console.WriteLine("{0} Прайс лист на грузоперевозку в город {1} {0}", new string('*', 8), City);
        Console.WriteLine();

        Console.WriteLine("Доставка самолётом в город {0}, расстояние до города {1}: ", City, s);
        Console.WriteLine("Цена : {0}  Длительность поставки : {1}"
            , this.PriceByPlane(s),
           this.TimeByPlane(s));
        Console.WriteLine();

        Console.WriteLine("Доставка поездом в город {0}, расстояние до города {1}: ", City, s);
        Console.WriteLine("Цена : {0}  Длительность поставки : {1}"
            , this.PriceByTrain(s),
           this.TimeByTrain(s));
        Console.WriteLine();

        Console.WriteLine("Доставка автомобилем в город {0}, расстояние до города {1}: ", City, s);
        Console.WriteLine("Цена : {0}  Длительность поставки : {1}"
            , this.PriceByCar(s),
           this.TimeByCar(s));
        Console.WriteLine();

        Console.WriteLine("Доставка вагоном в город {0}, расстояние до города {1}: ", City, s);
        Console.WriteLine("Цена : {0}  Длительность поставки : {1}"
            , this.PriceByVagon(s),
           this.TimeByVagon(s));
        Console.WriteLine();
    }


    //конструкотры которые возвращают время доставкы для каждого тыпа перевозки
    public int TimeByPlane(int s)
    {
        return new Plane().DeliveryTime(s);
    }
    public int TimeByTrain(int s)
    {
        return new Train().DeliveryTime(s);
    }
    public int TimeByCar(int s)
    {
        return new Car().DeliveryTime(s);
    }
    public int TimeByVagon(int s)
    {
        return new Car().DeliveryTime(s);
    }

    //конструкотры которые возвращают цену доставкы для каждого тыпа перевозки
    public int PriceByPlane(int s)
    {
        return new Plane().DeliveryPrice(s);
    }

    public int PriceByTrain(int s)
    {
        return new Train().DeliveryPrice(s);
    }
    public int PriceByCar(int s)
    {
        return new Car().DeliveryPrice(s);
    }
    public int PriceByVagon(int s)
    {
        return new Plane().DeliveryPrice(s);
    }

    static int AmountOfCitys;
    public int Price { get; set; }
    static Pereviznik()
    {

    }

    public int NumberOfCitys //кол городов
    {
        get { return AmountOfCitys; }
        set { AmountOfCitys = value; }
    }


    string[] city;

    public string[] City 
    {
        get { if (city == null) city = new string[AmountOfCitys]; return city; }
        set { city = value; }
    }

    int[] distance;

    public int[] Distance //відстань до міст
    {
        get { if (distance == null) distance = new int[AmountOfCitys]; return distance; }
        set { distance = value; }
    }

}

