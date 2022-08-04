using System.Collections.Generic;

namespace Mob.Models
{
  public class Criminal
  {
    public Criminal()
    {
      this.Jobs = new HashSet<CriminalJob>(); // navigation property. This is simply a property on Criminal class that includes a reference to Job class.
      //this.Jobs = this.JoinEntities
    }

    public int CriminalId { get; set; }//two columns in our Criminal table
    public string Name { get; set; }//
    public virtual ICollection<CriminalJob> Jobs { get; set; }
  }
}