namespace RobinMagicC;

class Program
{
  public static int screenWidth = 10;
  public static int screenHight = 7;
  public static bool exitGame = false;

  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("**** Bienvenido a Robin Magic ****");
    Console.WriteLine("F1 - Salir");

    ScreenRender();

    while(!exitGame)
    {
      
      ConsoleKeyInfo keyPressed = Console.ReadKey(true);
      
      switch (keyPressed.Key)
      {
        case ConsoleKey.F1:
          exitGame = true;
          break;

        case ConsoleKey.LeftArrow:
          break;

        case ConsoleKey.RightArrow:
          break;
      }

      //ScreenRender();
    }
  }

  private static void ScreenRender()
  {
    Console.ForegroundColor = ConsoleColor.Green;

    for (int x = 0; x < screenWidth; x++)
    {
      for (int y = 2; y < screenHight; y++)
      {
        Console.SetCursorPosition(x, y);
        Console.Write("H");
      }
    }

    Console.SetCursorPosition(2, 3);
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("1");
  }
}
