using System.Drawing;

namespace RobinMagicC.Characters;

public class MainPlayer
{
  public Point CurrentPosition;
  public Point PreviousPosition;
  public int CurrentLevel = 1;
  public static MainPlayer _instance;

  private MainPlayer(int x, int y)
  {
    CurrentPosition = new Point(x, y);
    PreviousPosition = new Point(x, y);
  }

  public static MainPlayer GetInstance(int x, int y)
  {
    if (_instance == null) return _instance = new MainPlayer(x, y);
    return _instance;
  }

  public void MovePlayer(string direction)
  {
    PreviousPosition = CurrentPosition;
    if (direction.Equals("left")) CurrentPosition.X -= 1;
    if (direction.Equals("right")) CurrentPosition.X += 1;
    if (direction.Equals("up")) CurrentPosition.Y -= 1;
    if (direction.Equals("down")) CurrentPosition.Y += 1;
  }
}