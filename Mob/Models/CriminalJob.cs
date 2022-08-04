namespace Mob.Models
{
  public class CriminalJob //join table
  {
    // no constructor because this class is just about storing data for the table

    public int CriminalJobId { get; set; } // each of these are column in the CriminalJob table
    public int JobId { get; set; }
    public int CriminalId { get; set; }
    public virtual Job Job { get; set; }
    public virtual Criminal Criminal { get; set; }
  }
}