using System.ComponentModel.DataAnnotations.Schema;

namespace webAPP_1.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int? SerialNumberId {get; set;}
    public SerialNumber? SerialNumber { get; set; } 
    //One item to one serial number 
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    //one category to many Items
    
}
