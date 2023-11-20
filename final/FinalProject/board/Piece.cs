namespace FinalProject.board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color color { get; protected set; }
        public int movements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color) {
            Position = null;
            this.board = board;
            this.color = color;
            movements = 0;
        }
    }
}