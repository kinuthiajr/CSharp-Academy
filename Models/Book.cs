using TCSA.OOP.LibraryManagementSystem.Models;
using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal class Book(int id, string name, string location ,string author,string category,int pages): LibraryItem(id,name,location)
{

    internal string Author {get; set;} = author;
    internal string Category{get; set;} = category;
    public int Pages {get; set;} = pages;

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[boldBook]:[/] [cyan]{Name}[/] by [cyan]{Author}[/]")+
                $"\n[bold]Pages:[/]{Pages}"+
                $"\n[bold]Category:[/][green]{Category}[/]"+
                $"\n[bold]Location:[/][blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };
        AnsiConsole.Write(panel);
    }
}