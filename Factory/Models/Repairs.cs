namespace Factory.Models
{
  public class Repairs //join table
  {
    // no constructor because this class is just about storing data for the table

    public int RepairsId { get; set; } // each of these are column in the Repairs table
    public int MachineId { get; set; }
    public int EngineerId { get; set; }
    public virtual Machine Machine { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}