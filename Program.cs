using RobinMagicC.AllGameMaps;
using RobinMagicC.Characters;
using System.Reflection;

namespace RobinMagicC;

class Program
{
  public static bool exitGame = false;
  
  static void Main(string[] args)
  {
    Console.Clear();

    Version? versionEstandar = Assembly.GetEntryAssembly()?.GetName().Version;

    MainPlayer mainPlayer = MainPlayer.GetInstance();
    GameMap gameMap = GameMap.GetInstance();

    Console.WriteLine($"**** Bienvenido a Robin Magic - Versión: {versionEstandar} ****");
    Console.WriteLine("F1 - Salir");
    
    while(!exitGame)
    {
      // Muestro la pantalla
      ScreenRender(mainPlayer, gameMap);

      ConsoleKeyInfo keyPressed = Console.ReadKey(false);
      
      switch (keyPressed.Key)
      {
        case ConsoleKey.F1:
          exitGame = true;
          break;

        case ConsoleKey.LeftArrow:
          if (mainPlayer.CurrentPosition.X > 0) mainPlayer.MovePlayer("left");
          break;

        case ConsoleKey.RightArrow:
          if (mainPlayer.CurrentPosition.X < gameMap.screenWidth - 1) mainPlayer.MovePlayer("right");
          break;

        case ConsoleKey.UpArrow:
          if (mainPlayer.CurrentPosition.Y > 2)  mainPlayer.MovePlayer("up");
          break;

        case ConsoleKey.DownArrow:
          if (mainPlayer.CurrentPosition.Y < gameMap.screenHight - 1) mainPlayer.MovePlayer("down");
          break;
      }
    }
  }

  private static void ScreenRender(MainPlayer mainPlayer, GameMap gameMap)
  {
    Console.ForegroundColor = ConsoleColor.Green;

    // Dibujo el mapa del juego.
    for (int x = 0; x < gameMap.screenWidth; x++)
    {
      for (int y = 2; y < gameMap.screenHight; y++)
      {
        Console.SetCursorPosition(x, y);
        if (gameMap.MapSectors[x, y].TypeSector.Equals("Grass")) Console.Write(gameMap.getCharTypeSector(x, y));
      }
    }

    // Tomo la posicion del personaje en variable, para usarla mas facil en adelante.
    int xPlayer = mainPlayer.CurrentPosition.X;
    int yPlayer = mainPlayer.CurrentPosition.Y;

    Console.ForegroundColor = ConsoleColor.Gray;
    
    // Dibujo al personaje.
    Console.SetCursorPosition(xPlayer, yPlayer);
    Console.Write(mainPlayer.CurrentLevel.ToString());

    // Muestro la posicion del personaje.
    Console.SetCursorPosition(gameMap.screenWidth + 3, 2);
    Console.Write($"X: {xPlayer}. -- Y: {yPlayer}");
  }
}
