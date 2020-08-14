namespace Treats.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<FlavorTreat>();
    }

    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<FlavorTreat> Treats { get; set; }
  }
}