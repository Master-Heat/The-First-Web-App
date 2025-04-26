using Microsoft.EntityFrameworkCore;
using webAPP_1.Models;
namespace webAPP_1.Data;

public class WebAPP_1Contaxt :DbContext
{
    //this class contain main properties and method in order for the context to do its work 
    //the main bridge to connect our project with Database
    // query data from database and so on
    public WebAPP_1Contaxt(DbContextOptions<WebAPP_1Contaxt> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                Id=4 ,Name="Microphone" ,Price=14,SerialNumberId = 10}
            );      
        modelBuilder.Entity<SerialNumber>().HasData(
            new SerialNumber
            {
                Id=10,Name="MIX150" ,ItemId= 4}
            );
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category{Id = 2, Name = "Books" }
        );
    }
    public DbSet<Item>Items { get; set; }
    public DbSet<SerialNumber> SerialNumbers { get; set; }
    public DbSet<Category> Categories { get; set; }
}


