using System.Collections.Generic;//includes ICollection, HashSet

namespace Mob.Models
{
  public class Job
  {
    public Job()
    {
      this.Criminals = new HashSet<CriminalJob>();
    }

    public int JobId { get; set; }
    public string Description { get; set; }
    public virtual ICollection<CriminalJob> Criminals { get; set; } //ICollection includes built in methods that help us manipulate our data. Entity needs it.
    // Criminals named after this.Criminals
  }
}