using System.ComponentModel.DataAnnotations;
using System;

namespace petshop.Models
{
  public class Dog
  {
    public Dog(string name, string description)
    {
      Name = name;
      Description = description;
    }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}