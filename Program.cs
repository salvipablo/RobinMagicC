using RobinMagicC.AllGameMaps;
using RobinMagicC.Characters;
using System.Drawing;
using System.Reflection;

namespace RobinMagicC;

class Program
{
  #region Properties
  public static bool exitGame = false;
  public static bool DidCharacterMove = false;
  public static int CurrentPositionChScreenX = 8;
  public static int CurrentPositionChScreenY = 1;
  public static int PreviousPositionChScreenX;
  public static int PreviousPositionChScreenY;
  public static bool CrossAMapBorder = false;
  #endregion

  #region Methods
  static void Main()
  {
    Console.Clear();
    Console.CursorVisible = false;

    MainPlayer mainPlayer = MainPlayer.GetInstance(CurrentPositionChScreenX, CurrentPositionChScreenY);
    GameMap gameMap = GameMap.GetInstance();
    InitializeGame(mainPlayer, gameMap);
    
    while(!exitGame)
    {
      if (CrossAMapBorder)
      {
        RenderMap(gameMap, mainPlayer.CurrentPositionWorld);
      }

      if (DidCharacterMove) ScreenRender(mainPlayer, gameMap);

      DidCharacterMove = false;
      CrossAMapBorder = false;

      ConsoleKeyInfo KeyPressed = Console.ReadKey(false);

      PreviousPositionChScreenX = CurrentPositionChScreenX;
      PreviousPositionChScreenY = CurrentPositionChScreenY;

      CheckKeyPressed(KeyPressed, mainPlayer, gameMap);

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
    char symbolItem;
    if (gameMap.ItemName(mainPlayer.PreviousPositionWorld.X, mainPlayer.PreviousPositionWorld.Y).Equals("Empty"))
    {
      symbolItem = gameMap.GetCharTypeSector(mainPlayer.PreviousPositionWorld.X, mainPlayer.PreviousPositionWorld.Y);
    } else symbolItem = gameMap.GetSymbolItem(mainPlayer.PreviousPositionWorld.X, mainPlayer.PreviousPositionWorld.Y);

    SetSymbolColor(symbolItem);

    // Dibujo caracter de la posicion anterior del personaje
    Console.SetCursorPosition(PreviousPositionChScreenX, PreviousPositionChScreenY);
    Console.Write(symbolItem);

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

    char symbolItem;

    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 0; y < screenHeight; y++)
      {
        Console.SetCursorPosition(x, y);

        if (gameMap.ItemName(cameraWorldX, cameraWorldY).Equals("Empty")) symbolItem = gameMap.GetCharTypeSector(cameraWorldX, cameraWorldY);
        else symbolItem = gameMap.GetSymbolItem(cameraWorldX, cameraWorldY);

        SetSymbolColor(symbolItem);
        Console.Write(symbolItem);

        cameraWorldY++;
      }

      cameraWorldY = intialCameraWorldY;
      cameraWorldX++;
    }
  }

  private static bool CheckCollision(int currentPositionPlayerX, int currentPositionPlayerY, string direction, GameMap gameMap)
  {
    if (direction.Equals("right"))
      return gameMap.MapSectors[currentPositionPlayerX + 1, currentPositionPlayerY].ItemInSector!.HaveCollisionWithItem;
    
    if (direction.Equals("left"))
      return gameMap.MapSectors[currentPositionPlayerX - 1, currentPositionPlayerY].ItemInSector!.HaveCollisionWithItem;
    
    if (direction.Equals("up"))
      return gameMap.MapSectors[currentPositionPlayerX, currentPositionPlayerY - 1].ItemInSector!.HaveCollisionWithItem;
    
    if (direction.Equals("down"))
      return gameMap.MapSectors[currentPositionPlayerX, currentPositionPlayerY + 1].ItemInSector!.HaveCollisionWithItem;

    return false;
  }

  private static void CheckKeyPressed(ConsoleKeyInfo keyPressed, MainPlayer mainPlayer, GameMap gameMap)
  {
    switch (keyPressed.Key)
    {
      case ConsoleKey.F1:
        exitGame = true;
        break;

      case ConsoleKey.LeftArrow:
        if (mainPlayer.CurrentPositionWorld.X == 0) break;
        if (CheckCollision(mainPlayer.CurrentPositionWorld.X, mainPlayer.CurrentPositionWorld.Y, "left", gameMap)) break;
        mainPlayer.MovePlayer("left");
        CurrentPositionChScreenX -= 1;
        break;

      case ConsoleKey.RightArrow:
        if (mainPlayer.CurrentPositionWorld.X == gameMap.GameMapWidth - 1) break;
        if (CheckCollision(mainPlayer.CurrentPositionWorld.X, mainPlayer.CurrentPositionWorld.Y, "right", gameMap)) break;
        mainPlayer.MovePlayer("right");
        CurrentPositionChScreenX += 1;
        break;

      case ConsoleKey.UpArrow:
        if (mainPlayer.CurrentPositionWorld.Y == 0) break;
        if (CheckCollision(mainPlayer.CurrentPositionWorld.X, mainPlayer.CurrentPositionWorld.Y, "up", gameMap)) break;
        mainPlayer.MovePlayer("up");
        CurrentPositionChScreenY -= 1;
        break;

      case ConsoleKey.DownArrow:
        if (mainPlayer.CurrentPositionWorld.Y == gameMap.GameMapHeight - 1) break;
        if (CheckCollision(mainPlayer.CurrentPositionWorld.X, mainPlayer.CurrentPositionWorld.Y, "down", gameMap)) break;
        mainPlayer.MovePlayer("down");
        CurrentPositionChScreenY += 1;
        break;
    }
  }

  private static void SetSymbolColor(char symbolItem)
  {
    if (symbolItem == 'L') Console.ForegroundColor = ConsoleColor.DarkYellow;
    else if (symbolItem == 'W') Console.ForegroundColor = ConsoleColor.Blue;
    else if (symbolItem == 'S') Console.ForegroundColor = ConsoleColor.Yellow;
    else if (symbolItem == 'C') Console.ForegroundColor = ConsoleColor.Gray;
    else if (symbolItem == 'P') Console.ForegroundColor = ConsoleColor.Cyan;
    else if (symbolItem == 'D') Console.ForegroundColor = ConsoleColor.Red;
    else if (symbolItem == 'O') Console.ForegroundColor = ConsoleColor.Yellow;
    else if (symbolItem == 'T') Console.ForegroundColor = ConsoleColor.Magenta;
    else Console.ForegroundColor = ConsoleColor.Green;
  }
  #endregion
}
