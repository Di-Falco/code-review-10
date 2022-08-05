using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HashSet<Repairs>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Repairs> Machines { get; set; }
  }
}