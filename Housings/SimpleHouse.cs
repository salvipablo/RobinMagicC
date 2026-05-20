namespace RobinMagicC.Housings;

internal class SimpleHouse
{
  public Item[,] structure = new Item[5, 5];

  public SimpleHouse()
  {
    structure[0, 0] = new Item("IT001", "Stone", 'P', true);
    structure[0, 1] = new Item("IT001", "Stone", 'P', true);
    structure[0, 2] = new Item("IT002", "Door", 'D', true);
    structure[0, 3] = new Item("IT001", "Stone", 'P', true);
    structure[0, 4] = new Item("IT001", "Stone", 'P', true);

    structure[1, 0] = new Item("IT001", "Stone", 'P', true);
    structure[1, 1] = new Item("IT000", "Empty", ' ', true);
    structure[1, 2] = new Item("IT000", "Empty", ' ', true);
    structure[1, 3] = new Item("IT000", "Empty", ' ', true);
    structure[1, 4] = new Item("IT001", "Stone", 'P', true);

    structure[2, 0] = new Item("IT001", "Stone", 'P', true);
    structure[2, 1] = new Item("IT000", "Empty", ' ', true);
    structure[2, 2] = new Item("IT000", "Empty", ' ', true);
    structure[2, 3] = new Item("IT000", "Empty", ' ', true);
    structure[2, 4] = new Item("IT001", "Stone", 'P', true);

    structure[3, 0] = new Item("IT001", "Stone", 'P', true);
    structure[3, 1] = new Item("IT000", "Empty", ' ', true);
    structure[3, 2] = new Item("IT000", "Empty", ' ', true);
    structure[3, 3] = new Item("IT000", "Empty", ' ', true);
    structure[3, 4] = new Item("IT001", "Stone", 'P', true);

    structure[4, 0] = new Item("IT001", "Stone", 'P', true);
    structure[4, 1] = new Item("IT001", "Stone", 'P', true);
    structure[4, 2] = new Item("IT001", "Stone", 'P', true);
    structure[4, 3] = new Item("IT001", "Stone", 'P', true);
    structure[4, 4] = new Item("IT001", "Stone", 'P', true);
  }
}
