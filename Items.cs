namespace RobinMagicC;

internal class Items
{
  public List<Item> AllItemsInTheGame = [];

  public Items()
  {
    AllItemsInTheGame.Add(new Item("IT000", "Empty", ' ', true, false));
    AllItemsInTheGame.Add(new Item("IT001", "Stone", 'P', true, true));
    AllItemsInTheGame.Add(new Item("IT002", "Door", 'D', true, false));
    AllItemsInTheGame.Add(new Item("IT003", "Wood", 'O', true, false));
    AllItemsInTheGame.Add(new Item("IT004", "Tree", 'T', true, true));

    // Grass  -> "G"
    // Land   -> "L"
    // Water  -> "W"
    // Sand   -> "S"
    // Cobble -> "C"
  }
}