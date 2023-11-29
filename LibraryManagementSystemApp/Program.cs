using LibraryManagementSystemApp;

var library = new Library
{
    Books = new List<Book>(),
    Members = new List<Member>()
};

bool running = true;
while (running)
{
    Console.WriteLine("\nLibrary Management System");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Delete Book");
    Console.WriteLine("3. Add Member");
    Console.WriteLine("4. Loan Book");
    Console.WriteLine("5. Return Book");
    Console.WriteLine("6. Print Library Information");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            AddBook();
            break;
        case 2:
            DeleteBook();
            break;
        case 3:
            AddMember();
            break;
        case 4:
            LoanBook();
            break;
        case 5:
            ReturnBook();
            break;
        case 6:
            PrintLibraryInfo();
            break;
        case 7:
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

void AddBook()
{
    Console.Write("Enter book name: ");
    string name = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter author name: ");
    string author = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter publishing date: ");
    string publishingDate = Console.ReadLine() ?? string.Empty;

    Book book = new Book
    {
        Id = Guid.NewGuid(),
        Name = name,
        Author = author,
        PublishingDate = publishingDate,
        Status = BookStatus.Available
    };

    library.AddBook(book);
    Thread.Sleep(1000);
}

void DeleteBook()
{
    Console.Write("Enter book name to delete: ");
    string name = Console.ReadLine() ?? string.Empty;
    
    library.DeleteBook(name);
    
    Thread.Sleep(1000);
}

void AddMember()
{
    Console.Write("Enter member name: ");
    string name = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter member surname: ");
    string surname = Console.ReadLine() ?? string.Empty;
   
    Member member = new Member
    {
        Id = Guid.NewGuid(),
        Name = name,
        Surname = surname,
        LoanedBooks = new List<Book>()
    };

    library.Members.Add(member);
    Thread.Sleep(1000);
}

void LoanBook()
{
    Console.Write("Enter book name to loan: ");
    string bookName = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter member Name: ");
    var memberName = Console.ReadLine() ?? string.Empty;

    library.LoanBook(bookName, memberName);
    
    Thread.Sleep(1000);
}

void ReturnBook()
{
    Console.Write("Enter book name to return: ");
    string bookName = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter member name: ");
    string memberName = Console.ReadLine() ?? string.Empty;
    
    library.ReturnBook(bookName, memberName);
    
    Thread.Sleep(1000);
}

void PrintLibraryInfo()
{
    Console.WriteLine("\nBooks in Library:");
    foreach (var book in library.Books)
    {
        book.PrintInfo();
    }

    Console.WriteLine("\nMembers in Library:");
    foreach (var member in library.Members)
    {
        member.PrintInfo();
    }
    Thread.Sleep(1000);
}
