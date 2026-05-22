using RobinMagicC.Housings;

namespace RobinMagicC.AllGameMaps;

internal class GameMap
{
  #region Properties
  public static GameMap? _instance;
  public int GameMapWidth = 200;
  public int GameMapHeight = 40;
  public Sector[,] MapSectors;
  #endregion

  #region Methods
  private GameMap()
  {
    MapSectors = new Sector[GameMapWidth, GameMapHeight];
    GenerateMap();
  }

  public static GameMap GetInstance()
  {
    if (_instance == null) return _instance = new GameMap();
    return _instance;
  }

  private void GenerateMap()
  {
    for (int x = 0; x < GameMapWidth; x++)
    {
      for (int y = 0; y < GameMapHeight; y++)
      {
        if (x == 0 && y == 0) MapSectors[x, y] = new Sector("Land", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 0 && y == 19) MapSectors[x, y] = new Sector("Water", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 50 && y == 0) MapSectors[x, y] = new Sector("Water", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 50 && y == 19) MapSectors[x, y] = new Sector("Land", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 0 && y == 20) MapSectors[x, y] = new Sector("Sand", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 0 && y == 39) MapSectors[x, y] = new Sector("Cobble", new Item("IT000", "Empty", ' ', true, false));
        else if (x == 15 && y == 3) MapSectors[x, y] = new Sector("Grass", new Item("IT001", "Stone", 'P', true, true));

        else if (x == 2 && y == 2) MapSectors[x, y] = new Sector("Grass", new Item("IT004", "Tree", 'T', true, true));
        else if (x == 2 && y == 15) MapSectors[x, y] = new Sector("Grass", new Item("IT004", "Tree", 'T', true, true));
        else if (x == 9 && y == 8) MapSectors[x, y] = new Sector("Grass", new Item("IT004", "Tree", 'T', true, true));
        else if (x == 45 && y == 10) MapSectors[x, y] = new Sector("Grass", new Item("IT004", "Tree", 'T', true, true));

        else if (x == 22 && y == 11) MapSectors[x, y] = new Sector("Grass", new Item("IT003", "Wood", 'O', true, false));

        else MapSectors[x, y] = new Sector("Grass", new Item("IT000", "Empty", ' ', true, false));
      }
    }

    PlaceSimpleHouse(15, 3, new SimpleHouse());
    PlaceSimpleHouse(34, 13, new SimpleHouse());
    PlaceSimpleHouse(67, 3, new SimpleHouse());
  }

  public char GetCharTypeSector(int x, int y)
  {
    if (MapSectors[x, y].TypeSector == "Grass") return 'G';
    if (MapSectors[x, y].TypeSector == "Land") return 'L';
    if (MapSectors[x, y].TypeSector == "Water") return 'W';
    if (MapSectors[x, y].TypeSector == "Sand") return 'S';
    if (MapSectors[x, y].TypeSector == "Cobble") return 'C';
    return '/';
  }

  public string ItemName(int x, int y) => MapSectors[x, y].ItemInSector!.Name;

  public char GetSymbolItem(int x, int y) => MapSectors[x, y].ItemInSector!.Symbol;

  /*
   * Este metodo permite agregar una simple casa.
   * TODO: Es interesante la idea de agregar un metodo que permita colocar estructura (PlaceStructure)
   * Al cual se le deberia poder enviar obhetos genericos de diferentes tipos casas, castillos, choza simples
   * Ahi se podria realizar una herencia por ejemplo de edificios, y agregar todos los tipos de construcciones a este por herencia
   * Y asi poder enviar estos objetos a traves de polimorfismo, guardando estos en una variable de tipo edificio.
   */
  private void PlaceSimpleHouse(int xMap, int yMap, SimpleHouse simpleHouse)
  {
    int initiaXmap = xMap;
    int initiaYmap = yMap;

    int xWidth = simpleHouse.structure.GetLength(0);
    int yWidth = simpleHouse.structure.GetLength(1);

    for (int x = 0; x < xWidth; x++)
    {
      for (int y = 0; y < yWidth; y++)
      {
        MapSectors[initiaXmap, initiaYmap].ItemInSector = simpleHouse.structure[x, y];
        initiaYmap++;
      }

      initiaYmap = yMap;
      initiaXmap++;
    }
  }
  #endregion
}
