interface IApplicant
{
    string Name { get; set; }
    void Apply();
    void Interview();
}

abstract class Student : IApplicant
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public abstract void Apply();
    public abstract void Interview();

    public void Enroll()
    {
        Console.WriteLine("Enrolling in correspondence course...");
    }

    public void PayTuition()
    {
        Console.WriteLine("Paying tuition for correspondence course...");
    }
}

class CorrespondenceStudent : Student
{
    public string MailingAddress { get; set; }
    public bool IsInternational { get; set; }

    public override void Apply()
    {
        Console.WriteLine("Applying for correspondence course...");
    }

    public override void Interview()
    {
        Console.WriteLine("Interviewing correspondence student...");
    }

    public void SendMaterials()
    {
        Console.WriteLine("Sending materials to correspondence student...");
    }

    public void ReceiveMaterials()
    {
        Console.WriteLine("Receiving materials from correspondence student...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IApplicant> applicants = new List<IApplicant>();

        CorrespondenceStudent student1 = new CorrespondenceStudent();
        student1.Name = "John Doe";
        student1.Age = 20;
        student1.Email = "john.doe@example.com";
        student1.MailingAddress = "123 Main St, Anytown USA";
        student1.IsInternational = false;

        CorrespondenceStudent student2 = new CorrespondenceStudent();
        student2.Name = "Jane Smith";
        student2.Age = 25;
        student2.Email = "jane.smith@example.com";
        student2.MailingAddress = "456 Oak St, Anytown USA";
        student2.IsInternational = true;

        applicants.Add(student1);
        applicants.Add(student2);

        foreach (IApplicant applicant in applicants)
        {
            applicant.Apply();
            applicant.Interview();

            CorrespondenceStudent student = applicant as CorrespondenceStudent;
            if (student != null)
            {
                student.SendMaterials();
                student.ReceiveMaterials();
            }
        }

        Console.ReadKey();
    }
}