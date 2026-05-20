namespace RobinMagicC;

internal class Items
{
  public List<Item> AllItemsInTheGame = new List<Item>();

  public Items()
  {
    AllItemsInTheGame.Add(new Item("IT000", "Empty", ' ', true));
    AllItemsInTheGame.Add(new Item("IT001", "Stone", 'P', true));
    AllItemsInTheGame.Add(new Item("IT002", "Door", 'D', true));
    AllItemsInTheGame.Add(new Item("IT003", "Wood", 'O', true));

    // Grass  -> "G"
    // Land   -> "L"
    // Water  -> "W"
    // Sand   -> "S"
    // Cobble -> "C"
  }
}
