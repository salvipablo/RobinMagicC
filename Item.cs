namespace RobinMagicC;

internal class Item(string id, string name, char symbol, bool isVisible, bool haveCollisionWithItem)
{
  public string Id { get; set; } = id;
  public string Name { get; set; } = name;
  public char Symbol { get; set; } = symbol;
  public bool IsVisible { get; set; } = isVisible;
  public bool HaveCollisionWithItem { get; set; } = haveCollisionWithItem;
}
