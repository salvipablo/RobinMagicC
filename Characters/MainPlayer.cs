using System.Drawing;

namespace RobinMagicC.Characters;

public class MainPlayer
{
  public Point CurrentPositionWorld;
  public Point PreviousPositionWorld;
  
  public int CurrentLevel = 1;
  private static MainPlayer? _instance;

  private MainPlayer(int x, int y)
  {
    CurrentPositionWorld = new Point(x, y);
    PreviousPositionWorld = new Point(x, y);
  }

  public static MainPlayer GetInstance(int x, int y)
  {
    if (_instance == null) return _instance = new MainPlayer(x, y);
    return _instance;
  }

  public void MovePlayer(string direction)
  {
    PreviousPositionWorld = CurrentPositionWorld;
    if (direction.Equals("left")) CurrentPositionWorld.X -= 1;
    if (direction.Equals("right")) CurrentPositionWorld.X += 1;
    if (direction.Equals("up")) CurrentPositionWorld.Y -= 1;
    if (direction.Equals("down")) CurrentPositionWorld.Y += 1;
  }
}