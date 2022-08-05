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
    public string Description { get; set; }
    public virtual ICollection<Repairs> Engineers { get; set; } //ICollection includes built in methods that help us manipulate our data. Entity needs it.
    // Engineers named after this.Engineers
  }
}