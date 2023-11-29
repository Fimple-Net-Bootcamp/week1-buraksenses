namespace LibraryManagementSystemApp;

public class Book : Writing,IPrintable
{
    public BookStatus Status { get; set; }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Name : {Name}  Author : {Author}  Publishing Date : {PublishingDate} Status : {(Status == BookStatus.Available ? "Available":"Loaned")}");
    }
}