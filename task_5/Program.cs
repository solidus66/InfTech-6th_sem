class Program
{
    static void Main(string[] args)
    {
        List<Applicant> applicants = new List<Applicant>();

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

        foreach (Applicant applicant in applicants)
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