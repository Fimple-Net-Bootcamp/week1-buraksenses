namespace LibraryManagementSystemApp;

public class Member : IPrintable
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; } 

    public List<Book> LoanedBooks { get; set; }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Name : {Name}  Surname : {Surname}");
        Console.WriteLine("Loaned Books :");
        foreach (var loanedBook in LoanedBooks)
        {
            loanedBook.PrintInfo();
        }
    }
}