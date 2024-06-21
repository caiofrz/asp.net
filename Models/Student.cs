using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc.Models;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime RegisterDate { get; set; }

    public bool IsRegistered { get; set; }
}