using System.Collections.Generic;//includes ICollection, HashSet

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<Repairs>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Repairs> Engineers { get; set; }
  }
}