using System.Collections.Generic;
using petshop.Models;

namespace petshop.db
{
  public class FAKEDB
  {
    public static List<Cat> Cats { get; set; } = new List<Cat>();
    public static List<Dog> Dogs { get; set; } = new List<Dog>();
  }
}