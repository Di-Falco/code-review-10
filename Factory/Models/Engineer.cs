using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HashSet<Repairs>(); // navigation property. This is simply a property on Engineer class that includes a reference to Machine class.
      //this.Machines = this.JoinEntities
    }

    public int EngineerId { get; set; }//two columns in our Engineer table
    public string Name { get; set; }//
    public virtual ICollection<Repairs> Machines { get; set; }
  }
}