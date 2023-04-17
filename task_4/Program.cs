using System;

class MobileOperator
{
    // Поля класса
    private string name;        // Название оператора
    private double callCost;    // Стоимость 1 минуты разговора
    private double coverage;    // Площадь покрытия

    // Свойства для доступа к полям класса
    public string Name { get { return name; } }
    public double PricePerMinute { get { return callCost; } }
    public double CoverageArea { get { return coverage; } }

    // Конструктор класса
    public MobileOperator(string name, double callCost, double coverage)
    {
        this.name = name;
        this.callCost = callCost;
        this.coverage = coverage;
    }

    // Функция, которая определяет «качество» объекта – Q по заданной формуле
    public double GetQuality()
    {
        return 100 * coverage / callCost;
    }

    // Функция вывода информации об объекте
    public void PrintInfo()
    {
        Console.WriteLine("Название оператора: " + name);
        Console.WriteLine("Стоимость 1 минуты разговора: " + callCost + " руб.");
        Console.WriteLine("Площадь покрытия: " + coverage + " км^2");
        Console.WriteLine("Качество связи: " + GetQuality().ToString("F0") + "(округлено до целого)");
    }
}

// Определение класса 2-го уровня "Оператор мобильной связи с платой за каждое соединение"
class PayMobileOperator : MobileOperator
{
    // Дополнительное поле класса
    private bool hasPay;        // Наличие платы за каждое соединение

    // Свойство для доступа к полю hasPay
    public bool HasConnectionFee { get { return hasPay; } }

    // Конструктор класса
    public PayMobileOperator(string name, double callCost, double coverage, bool hasPay) : base(name, callCost, coverage)
    {
        this.hasPay = hasPay;
    }

    // Функция, которая определяет «качество» объекта класса 2-го уровня – Qp,
    // которая перекрывает функцию качества класса 1-го уровня (Q), 
    // выполняя вычисление по новой формуле
    //public new double GetQuality()
    //{
    //    double q = base.GetQuality();  // Вычисляем качество связи Q

    //    // Если есть плата за каждое соединение, то уменьшаем Q на 30%
    //    // Иначе увеличиваем Q на 50%
    //    return hasPay ? 0.7 * q : 1.5 * q;
    //}
    public new int GetQuality()
    {
        double q = base.GetQuality();
        return hasPay ? (int)Math.Round(0.7 * q) : (int)Math.Round(1.5 * q);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем список операторов
        List<MobileOperator> operators = new List<MobileOperator>();

        while (true)
        {
            Console.WriteLine("Введите название оператора или \"0\" для завершения ввода:");
            string name = Console.ReadLine();
            if (name == "0") break;

            double callCost = 0;
            while (callCost <= 0)
            {
                Console.WriteLine("Введите стоимость 1 минуты разговора:");
                if (!double.TryParse(Console.ReadLine(), out callCost) || callCost <= 0)
                {
                    Console.WriteLine("Некорректный ввод, стоимость должна быть числом больше 0.");
                }
            }

            double coverage = 0;
            while (coverage <= 0)
            {
                Console.WriteLine("Введите площадь покрытия в км^2:");
                if (!double.TryParse(Console.ReadLine(), out coverage) || coverage <= 0)
                {
                    Console.WriteLine("Некорректный ввод, площадь покрытия должна быть числом больше 0.");
                }
            }

            Console.WriteLine("Есть ли плата за каждое соединение? (да/нет):");
            bool hasPay = Console.ReadLine().ToLower() == "да";

            // Создаем новый объект оператора и добавляем его в список
            MobileOperator newOperator = new PayMobileOperator(name, callCost, coverage, hasPay);
            operators.Add(newOperator);
        }

        // Выводим информацию обо всех операторах
        foreach (MobileOperator op in operators)
        {
            Console.WriteLine();
            Console.WriteLine("Информация об операторах: ");
            op.PrintInfo();
            Console.WriteLine();
        }
    }
}