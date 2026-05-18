using System.Drawing;

namespace RobinMagicC.Characters;

public class MainPlayer
{
  public Point CurrentPosition = new Point(1, 3);
  public int CurrentLevel = 1;
  public static MainPlayer _instance;

  private MainPlayer() { }

  public static MainPlayer GetInstance()
  {
    if (_instance == null) return _instance = new MainPlayer();
    return _instance;
  }

  public void MovePlayer(string direction)
  {
    if (direction.Equals("left")) CurrentPosition.X -= 1;
    if (direction.Equals("right")) CurrentPosition.X += 1;
    if (direction.Equals("up")) CurrentPosition.Y -= 1;
    if (direction.Equals("down")) CurrentPosition.Y += 1;
  }
}