namespace RobinMagicC;

internal class Sector
{
  #region Properties
  public string TypeSector { get; set; }
  public Item? ItemInSector { get; set; }
  #endregion

  #region Methods
  public Sector(string typeSector, Item itemInSector)
  {
    TypeSector = typeSector;
    ItemInSector = itemInSector;
  }
  #endregion
}
