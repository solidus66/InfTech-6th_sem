class Car
{
    private string brand;
    private Wheel[] wheels;
    private Engine engine;

    public Car(string brand, Wheel[] wheels, Engine engine)
    {
        this.brand = brand;
        this.wheels = wheels;
        this.engine = engine;
    }

    public void Drive()
    {
        Console.WriteLine("The car is driving.");
    }

    public void Refuel()
    {
        Console.WriteLine("The car is being refueled.");
    }

    public void ChangeWheel(int wheelIndex, Wheel newWheel)
    {
        if (wheelIndex >= 0 && wheelIndex < wheels.Length)
        {
            wheels[wheelIndex] = newWheel;
            Console.WriteLine("Wheel {0} has been changed.", wheelIndex + 1);
        }
        else
        {
            Console.WriteLine("Invalid wheel index.");
        }
    }

    public void DisplayBrand()
    {
        Console.WriteLine("Car brand: {0}", brand);
    }
}
