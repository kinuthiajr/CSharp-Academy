using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class BooksController: IBaseController
{

    public void ViewItems()
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDatabase.items.OfType<Book>();
        foreach (var book in books)
        {
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Name}[/]",
                $"[cyan]{book.Location}[/]",
                $"[cyan]{book.Author}[/]",
                $"[cyan]{book.Category}[/]",
                book.Pages.ToString()
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book to add:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book to add:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book to add:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]pages[/] of the book to add:");
                        
        if(MockDatabase.items.OfType<Book>().Any(b => b.Name.Equals(title,StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine("[red]This book already exists.[/]");
        }
        else
        {
            var newBook = new Book(MockDatabase.items.Count+1,title,location,author,category,pages);
            MockDatabase.items.Add(newBook);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        var books = MockDatabase.items.OfType<Book>().ToList();

        if (books.Count==0)
        {
        AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
        Console.ReadKey();
        return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
        .Title("Select a [red]book[/] to delete:")
        .AddChoices(books));

        if(MockDatabase.items.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found![/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}