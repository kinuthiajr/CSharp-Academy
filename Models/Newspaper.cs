using TCSA.OOP.LibraryManagementSystem.Models;
using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal class Newspaper(int id, string name, string publisher, DateTime publishdate, string location) : LibraryItem(id,name,location)
{
    internal string Publisher { get; set; } = publisher;
    internal DateTime PublishDate { get; set; } = publishdate;

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[boldBook]:[/] [cyan]{Name}[/] by [cyan]{Publisher}[/]")+
                $"\n[bold]Publish Date:[/]{PublishDate:yyyy-MM-dd}"+
                $"\n[bold]Location:[/][blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };
        AnsiConsole.Write(panel);
    }
}