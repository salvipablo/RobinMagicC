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
          MapSectors[x, y] = new Sector("Stone", null!);
          continue;
        }

        if (x == 0 && y == 39)
        {
          MapSectors[x, y] = new Sector("Tree", null!);
          continue;
        }

        MapSectors[x, y] = new Sector("Grass", null!);
      }
    }
  }

  public string GetCharTypeSector(int x, int y)
  {
    if (MapSectors[x, y].TypeSector == "Grass") return "H";
    if (MapSectors[x, y].TypeSector == "Land") return "T";
    if (MapSectors[x, y].TypeSector == "Water") return "A";
    if (MapSectors[x, y].TypeSector == "Stone") return "P";
    if (MapSectors[x, y].TypeSector == "Tree") return "@";
    return "/";
  }
 }
