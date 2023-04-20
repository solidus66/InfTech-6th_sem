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

    protected virtual double GetQuality()
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
