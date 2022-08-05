namespace Factory.Models
{
  public class Repairs
  {
    public int RepairsId { get; set; }
    public int MachineId { get; set; }
    public int EngineerId { get; set; }
    public virtual Machine Machine { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}