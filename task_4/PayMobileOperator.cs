class PayMobileOperator : MobileOperator
{
    private bool hasPay;   // Наличие платы за каждое соединение

    public bool HasConnectionFee { get { return hasPay; } }

    public PayMobileOperator(string name, double callCost, double coverage, bool hasPay) : base(name, callCost, coverage)
    {
        this.hasPay = hasPay;
    }

    protected override double GetQuality()
    {
        double baseQuality = base.GetQuality(); // вызываем метод базового класса и сохраняем результат в переменной
        return hasPay ? (int)Math.Round(0.7 * baseQuality) : (int)Math.Round(1.5 * baseQuality); // Если есть плата за каждое соединение, то уменьшаем Q на 30%
                                                                                                 //Иначе увеличиваем Q на 50%
    }
}
