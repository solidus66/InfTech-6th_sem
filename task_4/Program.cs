class Program
{
    static void Main(string[] args)
    {
        List<MobileOperator> operators = new List<MobileOperator>();

        while (true)
        {
            Console.WriteLine();
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

            MobileOperator newOperator = new PayMobileOperator(name, callCost, coverage, hasPay);
            operators.Add(newOperator);
        }

        foreach (MobileOperator op in operators)
        {
            Console.WriteLine();
            Console.WriteLine("Информация об операторе: ");
            op.PrintInfo();
            Console.WriteLine();
        }
    }
}