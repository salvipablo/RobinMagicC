namespace RobinMagicC;

internal class Sector
{
  public string TypeSector { get; set; }
  public Item? ItemInSector { get; set; }

  public Sector(string typeSector, Item itemInSector)
  {
    TypeSector = typeSector;
    ItemInSector = itemInSector;
  }
}
