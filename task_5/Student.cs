abstract class Student : Applicant
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public abstract void Apply();
    public abstract void Interview();

    public void Enroll()    // запись на курс
    {
        Console.WriteLine("Enrolling in correspondence course...");
    }

    public void PayTuition() // оплата обучения
    {
        Console.WriteLine("Paying tuition for correspondence course...");
    }
}
