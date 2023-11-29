namespace LibraryManagementSystemApp;

public class Library
{
    public List<Book> Books { get; set; }

    public List<Member> Members { get; set; }
    
    public void AddBook(Book book)
    {
        if (IsBookExist(book))
            return;
        Books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

    public void DeleteBook(string bookName)
    {
        if (!IsBookExist(bookName))
            return;
        var book = FindBookByName(bookName);
        if (book == null || book.Status == BookStatus.Loaned)
        {
            Console.WriteLine("Book could not be found!");
            return;
        }
        Books.Remove(book);
        Console.WriteLine("Book deleted successfully!");
    }
    
    //LoanBook() Override Methods

    public void LoanBook(Book book, Guid memberId)
    {
        if (!IsBookExist(book))
            return;
        if (!IsBookAvailable(book))
            return;
        var member = FindMemberById(memberId);
        if (member == null)
            return;
        
        member.LoanedBooks.Add(book);
        book.Status = BookStatus.Loaned;
        Console.WriteLine($"{book.Name} has been loaned to {member.Name} {member.Surname} successfully!");
    }
    
    public void LoanBook(string bookName, string memberName)
    {
        if (!IsBookExist(bookName))
            return;
        if (!IsBookAvailable(bookName))
            return;
        var member = FindMemberByName(memberName);
        var book = FindBookByName(bookName);

        if (member == null || book == null)
        {
            Console.WriteLine("Member or book could not be found!");
            return;
        }
        
        member.LoanedBooks.Add(book);
        book.Status = BookStatus.Loaned;
        Console.WriteLine($"{book.Name} has been loaned to {member.Name} {member.Surname} successfully!");
    }
    
    public void LoanBook(Book book, Guid memberId,int days)
    {
        if (!IsBookExist(book))
            return;
        if (!IsBookAvailable(book))
            return;
        var member = FindMemberById(memberId);
        if (member == null)
            return;
        
        member.LoanedBooks.Add(book);
        book.Status = BookStatus.Loaned;
        Console.WriteLine($"{book.Name} has been loaned to {member.Name} {member.Surname} for {days} days successfully!");
    }

    //Return Book Methods
    public void ReturnBook(Book book, Guid memberId)
    {
        var member = FindMemberById(memberId);
        member?.LoanedBooks.Remove(book);
        book.Status = BookStatus.Available;
    }

    public void ReturnBook(string bookName, string memberName)
    {
        var member = FindMemberByName(memberName);
        var book = FindBookByName(bookName);
        if (member == null || book == null)
        {
            Console.WriteLine("Member or book could not be found!");
            return;
        }
        member.LoanedBooks.Remove(book);
        book.Status = BookStatus.Available;
        Console.WriteLine($"{memberName} has successfully returned the book {book.Name}!");
    }
    
    
    //FIND METHODS
    
    public Book? FindBookByName(string name)
    {
        return Books.FirstOrDefault(x => x.Name == name);
    }

    private Member? FindMemberById(Guid memberId)
    {
        return Members.FirstOrDefault(x => x.Id == memberId);
    }

    public Member? FindMemberByName(string memberName)
    {
        return Members.FirstOrDefault(x => x.Name == memberName);
    }

    public Member? FindMemberByNameAndSurname(string name, string surname)
    {
        return Members.FirstOrDefault(x => x.Name == name && x.Surname == surname);
    }
    
    //BOOK AVAILABLE METHODS & Overrides

    private static bool IsBookAvailable(Book book)
    {
        if (book.Status == BookStatus.Available) 
            return true;
        Console.WriteLine("Book was loaned to another member!");
        return false;
    }

    private bool IsBookAvailable(string bookName)
    {
        var book = FindBookByName(bookName);
        if (book == null)
            return false;
        if (book.Status == BookStatus.Available) 
            return true;
        Console.WriteLine("Book was loaned to another member!");
        return false;
    }
    
    //IsExist Methods & Overrides
    private bool IsBookExist(Book book)
    {
        if (Books.FirstOrDefault(x => x.Name == book.Name) != null) 
            return true;
        Console.WriteLine("Book does not exist!");
        return false;
    }

    private bool IsBookExist(string name)
    {
        if (Books.FirstOrDefault(x => x.Name == name) != null) 
            return true;
        Console.WriteLine("Book does not exist!");
        return false;
    }
}