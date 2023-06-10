class Program
{
    static void Main(string[] args)
    {
        Wheel[] wheels = new Wheel[4];
        wheels[0] = new Wheel("Front Left");
        wheels[1] = new Wheel("Front Right");
        wheels[2] = new Wheel("Rear Left");
        wheels[3] = new Wheel("Rear Right");

        Engine engine = new Engine("V6");

        Car car = new Car("Example Car", wheels, engine);

        car.DisplayBrand();
        car.Drive();
        car.Refuel();

        car.ChangeWheel(2, new Wheel("New Rear Left"));

        Console.ReadLine();
    }
}