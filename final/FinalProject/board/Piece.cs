namespace FinalProject.board
{
    // Polymorphism example
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color color { get; protected set; }
        public int movements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            this.board = board;
            this.color = color;
            movements = 0;
        }
        public void incrementMovements()
        {
            movements++;
        }

        public void decrementMovements()
        {
            movements--;
        }

        public bool existPossibleMovements()
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos._row, pos._column];
        }


        // Demonstrate polymorphism applying this method in all pieaces
        public abstract bool[,] possibleMovements();
    }
}