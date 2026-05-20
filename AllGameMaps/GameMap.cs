using RobinMagicC.Housings;

namespace RobinMagicC.AllGameMaps;

internal class GameMap
{
  public static GameMap? _instance;
  public int GameMapWidth = 200;
  public int GameMapHight = 56;
  public Sector[,] MapSectors;

  private GameMap()
  {
    MapSectors = new Sector[GameMapWidth, GameMapHight];
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
      for (int y = 0; y < GameMapHight; y++)
      {
        if (x == 0 && y == 0)
        {
          MapSectors[x, y] = new Sector("Land", null!);
          continue;
        }

        if (x == 0 && y == 19)
        {
          MapSectors[x, y] = new Sector("Water", null!);
          continue;
        }

        if (x == 50 && y == 0)
        {
          MapSectors[x, y] = new Sector("Water", null!);
          continue;
        }

        if (x == 50 && y == 19)
        {
          MapSectors[x, y] = new Sector("Land", null!);
          continue;
        }

        if (x == 0 && y == 20)
        {
          MapSectors[x, y] = new Sector("Sand", null!);
          continue;
        }

        if (x == 0 && y == 39)
        {
          MapSectors[x, y] = new Sector("Cobble", null!);
          continue;
        }

        if (x == 15 && y == 3)
        {
          MapSectors[x, y] = new Sector("Grass", new Item("IT001", "Stone", 'P', true));
          continue;
        }

        MapSectors[x, y] = new Sector("Grass", null!);
      }
    }

    PlaceSimpleHouse(15, 3, new SimpleHouse());
    PlaceSimpleHouse(34, 13, new SimpleHouse());
    PlaceSimpleHouse(67, 3, new SimpleHouse());
  }

  public string GetCharTypeSector(int x, int y)
  {
    if (MapSectors[x, y].TypeSector == "Grass") return "G";
    if (MapSectors[x, y].TypeSector == "Land") return "L";
    if (MapSectors[x, y].TypeSector == "Water") return "W";
    if (MapSectors[x, y].TypeSector == "Sand") return "S";
    if (MapSectors[x, y].TypeSector == "Cobble") return "C";
    return "/";
  }

  public bool ItemExists(int x, int y) => MapSectors[x, y].ItemInSector != null;

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
}
