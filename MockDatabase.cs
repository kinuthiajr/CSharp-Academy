using TCSA.OOP.LibraryManagementSystem.Models;
namespace TCSA.OOP.LibraryManagementSystem;

internal static class MockDatabase
{
    internal static List<LibraryItem> items = 
    [
        new Book(1,"The Great Gatsby","A1","F Fitzgerald","Fiction",180),
        new Book(2,"To Kill a Mockingbird","A2","Harper Lee","Fiction",281),
        new Book(3,"1984","A3","Newton Key","Sci-Fi",328),

        new Magazine(1,"Great earth Catalogue","M1","Stewart Brant",new DateTime(2024,8,2),41),
        new Magazine(2, "The Catcher in the Rye","M2","Stewart Brant",new DateTime(2024,8,2),301),
        new Magazine(3,"The Hobbit","M3","Stewart Brant",new DateTime(2024,8,2),975),

        new Newspaper(1,"The Nation","Nation Media",new DateTime(2024,8,2),"p1"),
        new Newspaper(2,"People Daily","K-24",new DateTime(2024,8,2),"p3"),
        new Newspaper(1,"The Standard","KTN",new DateTime(2024,8,2),"p4"),
    ];
}