using RobinMagicC.AllGameMaps;
using RobinMagicC.Characters;
using System.Drawing;
using System.Reflection;

namespace RobinMagicC;

class Program
{
  public static bool exitGame = false;
  public static bool DidCharacterMove = false;
  public static int CurrentPositionChScreenX = 20;
  public static int CurrentPositionChScreenY = 5;
  public static int PreviousPositionChScreenX = 20;
  public static int PreviousPositionChScreenY = 5;
  public static bool CrossAMapBorder = false;

  static void Main()
  {
    Console.Clear();
    Console.CursorVisible = false;

    MainPlayer mainPlayer = MainPlayer.GetInstance(CurrentPositionChScreenX, CurrentPositionChScreenY);
    GameMap gameMap = GameMap.GetInstance();
    InitializeGame(mainPlayer, gameMap);
    
    while(!exitGame)
    {
      if (CrossAMapBorder) RenderMap(gameMap, mainPlayer.CurrentPositionWorld);
      if (DidCharacterMove) ScreenRender(mainPlayer, gameMap);

      DidCharacterMove = false;
      CrossAMapBorder = false;
      ConsoleKeyInfo keyPressed = Console.ReadKey(false);

      PreviousPositionChScreenX = CurrentPositionChScreenX;
      PreviousPositionChScreenY = CurrentPositionChScreenY;

      switch (keyPressed.Key)
      {
        case ConsoleKey.F1:
          exitGame = true;
          break;

        case ConsoleKey.LeftArrow:
          mainPlayer.MovePlayer("left");
          CurrentPositionChScreenX -= 1;
          break;

        case ConsoleKey.RightArrow:
          mainPlayer.MovePlayer("right");
          CurrentPositionChScreenX += 1;
          break;

        case ConsoleKey.UpArrow:
          mainPlayer.MovePlayer("up");
          CurrentPositionChScreenY -= 1;
          break;

        case ConsoleKey.DownArrow:
          mainPlayer.MovePlayer("down");
          CurrentPositionChScreenY += 1;
          break;
      }

      if (CurrentPositionChScreenX > 49 || CurrentPositionChScreenX < 0 || CurrentPositionChScreenY > 19 || CurrentPositionChScreenY < 0) CrossAMapBorder = true;

      if (CurrentPositionChScreenX > 49) CurrentPositionChScreenX = 0;
      if (CurrentPositionChScreenX < 0) CurrentPositionChScreenX = 49;
      if (CurrentPositionChScreenY > 19) CurrentPositionChScreenY = 0;
      if (CurrentPositionChScreenY < 0) CurrentPositionChScreenY = 19;

      if (mainPlayer.CurrentPositionWorld != mainPlayer.PreviousPositionWorld) DidCharacterMove = true;
    }
  }

  private static void ScreenRender(MainPlayer mainPlayer, GameMap gameMap)
  {
    // Dibujo caracter de la posicion anterior del personaje
    Console.ForegroundColor = ConsoleColor.Green;
    string charPreviousPlayer = gameMap.GetCharTypeSector(mainPlayer.PreviousPositionWorld.X, mainPlayer.PreviousPositionWorld.Y);
    Console.SetCursorPosition(PreviousPositionChScreenX, PreviousPositionChScreenY);
    Console.Write(charPreviousPlayer);

    // Dibujo al personaje.
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(CurrentPositionChScreenX, CurrentPositionChScreenY);
    Console.Write(mainPlayer.CurrentLevel.ToString());

    // Muestro la posicion del personaje.
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(55, 2);
    Console.Write($"X: {mainPlayer.CurrentPositionWorld.X}. -- Y: {mainPlayer.CurrentPositionWorld.Y}");
  }

  private static void InitializeGame(MainPlayer mainPlayer, GameMap gameMap)
  {
    Version? versionEstandar = Assembly.GetEntryAssembly()?.GetName().Version;

    RenderMap(gameMap, mainPlayer.CurrentPositionWorld);

    Console.ForegroundColor = ConsoleColor.Gray;

    // Dibujo al personaje.
    Console.SetCursorPosition(CurrentPositionChScreenX, CurrentPositionChScreenY);
    Console.Write(mainPlayer.CurrentLevel.ToString());

    // Muestro info del juego.
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(55, 0);
    Console.WriteLine($"**** Bienvenido a Robin Magic - Versión: {versionEstandar} ****");
    Console.SetCursorPosition(55, 1);
    Console.WriteLine("F1 - Salir");
    Console.SetCursorPosition(55, 2);
    Console.Write($"X: {mainPlayer.CurrentPositionWorld.X}. -- Y: {mainPlayer.CurrentPositionWorld.Y}");
  }

  private static void RenderMap(GameMap gameMap, Point playerPositionWorld)
  {
    int screenWidth = 50;
    int screenHeight = 20;

    int cameraWorldX = (playerPositionWorld.X / screenWidth) * screenWidth;
    int cameraWorldY = (playerPositionWorld.Y / screenHeight) * screenHeight;
    
    int intialCameraWorldY = cameraWorldY;

    // Dibujo el mapa del juego.
    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 0; y < screenHeight; y++)
      {
        Console.SetCursorPosition(x, y);
        
        if (gameMap.GetCharTypeSector(cameraWorldX, cameraWorldY) == "T") Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (gameMap.GetCharTypeSector(cameraWorldX, cameraWorldY) == "A") Console.ForegroundColor = ConsoleColor.Blue;
        else if (gameMap.GetCharTypeSector(cameraWorldX, cameraWorldY) == "P") Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Green;

        Console.Write(gameMap.GetCharTypeSector(cameraWorldX, cameraWorldY));
        cameraWorldY++;
      }

      cameraWorldY = intialCameraWorldY;
      cameraWorldX++;
    }
  }
}
