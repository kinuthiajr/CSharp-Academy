using TCSA.OOP.LibraryManagementSystem.Models;
using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;


internal class Magazine(int id, string name, string location,string publisher, DateTime publishdate,int issuenum): LibraryItem(id,name,location)
{
    public string Publisher {get; set;} = publisher;
    public DateTime PublishDate {get; set;} = publishdate;
    public int IssueNumber {get; set;} = issuenum;

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[boldBook]:[/] [cyan]{Name}[/] by [cyan]{Publisher}[/]")+
                $"\n[bold]Publish Date:[/]{PublishDate:G}"+
                $"\n[bold]Issue number:[/][green]{IssueNumber}[/]"+
                $"\n[bold]Location:[/][blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };
        AnsiConsole.Write(panel);
    }
    
}