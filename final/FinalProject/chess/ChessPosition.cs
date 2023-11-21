using FinalProject.board;

namespace FinalProject.chess
{
    public class ChessPosition
    {
        public char _column { get; set; }
        public int _row { get; set; }

        public ChessPosition(char column, int row)
        {
            _column = column;
            _row = row;
        }

        // Convert squares following chess rules
        public Position toPosition() {
            return new Position(8 - _row, _column - 'a');
        }

        public override string ToString()
        {
            return "" + _column + _row;
        }
    }
}