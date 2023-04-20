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
