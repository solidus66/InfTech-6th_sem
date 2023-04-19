class MobileOperator
{
    private string name;        // Название оператора
    private double callCost;    // Стоимость 1 минуты разговора
    private double coverage;    // Площадь покрытия

    public string Name { get { return name; } }
    public double PricePerMinute { get { return callCost; } }
    public double CoverageArea { get { return coverage; } }

    public MobileOperator(string name, double callCost, double coverage)
    {
        this.name = name;
        this.callCost = callCost;
        this.coverage = coverage;
    }

    public double GetQuality()
    {
        return 100 * coverage / callCost;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Название оператора: " + name);
        Console.WriteLine("Стоимость 1 минуты разговора: " + callCost + " руб.");
        Console.WriteLine("Площадь покрытия: " + coverage + " км^2");
        Console.WriteLine("Качество связи: " + GetQuality().ToString("F0") + "(округлено до целого)");
    }
}

class PayMobileOperator : MobileOperator
{
    private bool hasPay;   // Наличие платы за каждое соединение

    public bool HasConnectionFee { get { return hasPay; } }

    public PayMobileOperator(string name, double callCost, double coverage, bool hasPay) : base(name, callCost, coverage)
    {
        this.hasPay = hasPay;
    }

    public new int GetQuality()
    {
        double q = base.GetQuality();
        return hasPay ? (int)Math.Round(0.7 * q) : (int)Math.Round(1.5 * q); // Если есть плата за каждое соединение, то уменьшаем Q на 30%
                                                                             // Иначе увеличиваем Q на 50%
    }
}
class Program
{
    static void Main(string[] args)
    {
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

        foreach (MobileOperator op in operators)
        {
            Console.WriteLine();
            Console.WriteLine("Информация об операторах: ");
            op.PrintInfo();
            Console.WriteLine();
        }
    }
}