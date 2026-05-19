using RobinMagicC.AllGameMaps;
using RobinMagicC.Characters;
using System.Reflection;

namespace RobinMagicC;

class Program
{
  public static bool exitGame = false;
  public static bool DidCharacterMove = false;
  public static int CameraX = 0;
  public static int CameraY = 0;

  static void Main(string[] args)
  {
    Console.Clear();
    Console.CursorVisible = false;

    MainPlayer mainPlayer = MainPlayer.GetInstance(20, 5);
    GameMap gameMap = GameMap.GetInstance();
    InitializeGame(mainPlayer, gameMap);
    
    while(!exitGame)
    {
      if (DidCharacterMove) ScreenRender(mainPlayer, gameMap);

      DidCharacterMove = false;
      ConsoleKeyInfo keyPressed = Console.ReadKey(false);
      
      switch (keyPressed.Key)
      {
        case ConsoleKey.F1:
          exitGame = true;
          break;

        case ConsoleKey.LeftArrow:
          mainPlayer.MovePlayer("left");
          break;

        case ConsoleKey.RightArrow:
          mainPlayer.MovePlayer("right");
          break;

        case ConsoleKey.UpArrow:
          mainPlayer.MovePlayer("up");
          break;

        case ConsoleKey.DownArrow:
          mainPlayer.MovePlayer("down");
          break;
      }

      if (mainPlayer.CurrentPositionWorld != mainPlayer.PreviousPositionWorld) DidCharacterMove = true;
    }
  }

  private static void ScreenRender(MainPlayer mainPlayer, GameMap gameMap)
  {
    // Tomo la posicion del personaje en variable, para usarla mas facil en adelante.
    int xCurrentPlayerMap = mainPlayer.CurrentPositionWorld.X - CameraX;
    int yCurrentPlayerMap = mainPlayer.CurrentPositionWorld.Y - CameraY;

    int xPreviousPlayerMap = mainPlayer.PreviousPositionWorld.X - CameraX;
    int yPreviousPlayerMap = mainPlayer.PreviousPositionWorld.Y - CameraY;

    // Dibujo al personaje.
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(xCurrentPlayerMap, yCurrentPlayerMap);
    Console.Write(mainPlayer.CurrentLevel.ToString());

    // Dibujo caracter de la posicion anterior del personaje
    Console.ForegroundColor = ConsoleColor.Green;
    string charPreviousPlayer = gameMap.getCharTypeSector(mainPlayer.PreviousPositionWorld.X, mainPlayer.PreviousPositionWorld.Y);
    Console.SetCursorPosition(xPreviousPlayerMap, yPreviousPlayerMap);
    Console.Write(charPreviousPlayer);

    // Muestro la posicion del personaje.
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(55, 2);
    Console.Write($"X: {mainPlayer.CurrentPositionWorld.X}. -- Y: {mainPlayer.CurrentPositionWorld.Y}");
  }

  private static void InitializeGame(MainPlayer mainPlayer, GameMap gameMap)
  {
    Version? versionEstandar = Assembly.GetEntryAssembly()?.GetName().Version;

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"**** Bienvenido a Robin Magic - Versión: {versionEstandar} ****");
    Console.WriteLine("F1 - Salir");

    RenderMap(CameraX, CameraY, gameMap);

    // Tomo la posicion del personaje en variable, para usarla mas facil en adelante.
    int screenPlayerX = mainPlayer.CurrentPositionWorld.X - CameraX;
    int screenPlayerY = mainPlayer.CurrentPositionWorld.Y - CameraY;

    Console.ForegroundColor = ConsoleColor.Gray;

    // Dibujo al personaje.
    Console.SetCursorPosition(screenPlayerX, screenPlayerY);
    Console.Write(mainPlayer.CurrentLevel.ToString());

    // Muestro la posicion del personaje.
    Console.SetCursorPosition(55, 2);
    Console.Write($"X: {mainPlayer.CurrentPositionWorld.X}. -- Y: {mainPlayer.CurrentPositionWorld.Y}");
  }

  private static void RenderMap(int cameraX, int cameraY, GameMap gameMap)
  {
    int screenWidth = 50;
    int screenHight = 22;

    int cameraWorldX = cameraX;
    int cameraWorldY = cameraY;

    // Dibujo el mapa del juego.
    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 2; y < screenHight + 2; y++)
      {
        Console.SetCursorPosition(x, y);
        
        if (gameMap.getCharTypeSector(cameraWorldX, cameraWorldY) == "T") Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (gameMap.getCharTypeSector(cameraWorldX, cameraWorldY) == "A") Console.ForegroundColor = ConsoleColor.Blue;
        else Console.ForegroundColor = ConsoleColor.Green;

        Console.Write(gameMap.getCharTypeSector(cameraWorldX, cameraWorldY));
        cameraWorldY++;
      }

      cameraWorldY = cameraY;
      cameraWorldX++;
    }
  }
}
