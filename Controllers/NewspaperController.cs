using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class NewspaperController: IBaseController
{
    public void ViewItems()
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Published[/]");

        var newsPaper = MockDatabase.items.OfType<Newspaper>();
        foreach (var np in newsPaper)
        {
            table.AddRow(
                np.Id.ToString(),
                $"[cyan]{np.Name}[/]",
                $"[cyan]{np.Location}[/]",
                $"[cyan]{np.Publisher}[/]",
                $"[cyan]{np.PublishDate:yyyy-MM-dd}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to Newspaper:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the Newspaper:");
        var published = AnsiConsole.Ask<string>("Enter the [green]published[/] of the book to Newspaper (yyyy-MM-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book to Newspaper:");
        if (DateOnly.TryParse(published, out DateOnly publishedDate))
        {
             // Successfully parsed, you can now use publishedDate
        var panel = new Panel(new Markup($"[boldBook]:[/] [cyan]{title}[/] by [cyan]{publisher}[/]") +
                $"\n[bold]Publish Date:[/] {publishedDate:yyyy-MM-dd}" + 
                $"\n[bold]Location:[/][blue]{location}[/]")
        {
            Border = BoxBorder.Rounded
        };
        AnsiConsole.Write(panel);
    
        }
        

        if (MockDatabase.items.OfType<Newspaper>().Any(n => n.Name.Equals(title,StringComparison.Ordinal)))
        {
            AnsiConsole.MarkupLine("[red]This Newspaper already exists.[/]");
        }
        else
        {
            var newsPaper = new Newspaper(MockDatabase.items.Count+1,title, publisher,published,location);
            MockDatabase.items.Add(newsPaper);
            AnsiConsole.MarkupLine("[green]Book added successfully![/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void DeleteItem()
    {
        if (MockDatabase.items.OfType<Newspaper>().Count() == 0)
        {
        AnsiConsole.MarkupLine("[red]No Newspaper available to delete.[/]");
        Console.ReadKey();
        return;
        }
        
        var paperToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Newspaper>()
        .Title("Select a [red]Newspaper[/] to delete:")
        .UseConverter(n => $"{n.Name} (Published on {n.PublishDate:yyyy-MM-dd})")
        .AddChoices(MockDatabase.items.OfType<Newspaper>()));

        if (MockDatabase.items.Remove(paperToDelete))
         {
            AnsiConsole.MarkupLine("[red]Newspaper deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Newspaper not found.[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}