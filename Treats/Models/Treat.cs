using System.Collections.Generic;

namespace Treats.Models
{
  public class Treat
  {
    public Treat ()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public ICollection<FlavorTreat> Flavors { get; set; }
  }
}