namespace RobinMagicC;

internal class Item
{
  public string Id { get; set; }
  public string Name { get; set; }
  public char Symbol { get; set; }
  public bool IsVisible { get; set; }

  public Item(string id, string name, char symbol, bool isVisible)
  {
    Id = id;
    Name = name;
    IsVisible = isVisible;
    Symbol = symbol;
  }
}
