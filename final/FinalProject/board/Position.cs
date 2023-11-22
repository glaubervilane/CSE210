using System.Data;

namespace FinalProject.board
{
  public class Position
  {
    public int _row { get; set; }
    public int _column { get; set; }

    public Position(int row, int column)
    {
      _row = row;
      _column = column;
    }

    public void getValues(int row, int column)
    {
      _row = row;
      _column = column;
    }

    public override string ToString()
    {
      return _row
        + ", "
        + _column;
    }
  }
}