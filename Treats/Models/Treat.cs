namespace Treats.Models
{
  public class Treats
  {
    public Treats ()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<FlavorTreat> Flavors { get; set; }
  }
}