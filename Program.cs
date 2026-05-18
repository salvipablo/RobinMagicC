using RobinMagicC.Characters;

namespace RobinMagicC;

class Program
{
  public static int screenWidth = 10;
  public static int screenHight = 7;
  public static bool exitGame = false;
  
  static void Main(string[] args)
  {
    MainPlayer mainPlayer = MainPlayer.GetInstance();

    Console.Clear();
    Console.WriteLine("**** Bienvenido a Robin Magic ****");
    Console.WriteLine("F1 - Salir");
    
    while(!exitGame)
    {
      // Muestro la pantalla
      ScreenRender(mainPlayer);

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
    }
  }

  private static void ScreenRender(MainPlayer mainPlayer)
  {
    Console.ForegroundColor = ConsoleColor.Green;

    // Dibujo el mapa del juego.
    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 2; y < screenHight; y++)
      {
        Console.SetCursorPosition(x, y);
        Console.Write("H");
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
    Console.SetCursorPosition(20, 2);
    Console.Write($"X: {xPlayer}. -- Y: {yPlayer}");
  }
}
