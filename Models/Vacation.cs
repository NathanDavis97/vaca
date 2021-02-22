using vaca.Interfaces;

namespace vaca.Models
{
  public abstract class Vacation : IBookable
  {
      public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

  }
}
