namespace RobinMagicC.AllGameMaps;

internal class GameMap
{
  public static GameMap _instance;
  public int screenWidth = 30;
  public int screenHight = 22;
  public Sector[,] MapSectors;

  private GameMap()
  {
    MapSectors = new Sector[screenWidth, screenHight];
    GenerateMap();
  }

  public static GameMap GetInstance()
  {
    if (_instance == null) return _instance = new GameMap();
    return _instance;
  }

  private void GenerateMap()
  {
    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 2; y < screenHight; y++) MapSectors[x, y] = new Sector("Grass", null);
    }
  }

  public string getCharTypeSector(int x, int y)
  {
    if (MapSectors[x, y].TypeSector == "Grass") return "H";
    return "T";
  }
 }
