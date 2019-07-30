using System;

namespace gameoflife
{
    class Program
    {
        public static int DEAD = 0;
        public static int LIVE = 1;
        static void Main(string[] args)
        {
            int[,] board = randomState(5,10);
            renderBoard(board);                        
        }
      
        //generate a randomized starting board
        public static int[,] randomState(int width, int height)
        {
            int[,] theBoard = new int[width, height];
            Random rand = new Random();
            for(int i=0; i< width; i++)
            {
                for (int j=0; j<height; j++)
                {
                    if (rand.NextDouble() >= 0.5)
                        theBoard[i,j]=LIVE;
                    else
                        theBoard[i,j]=DEAD;
                }

            }
            return theBoard;
        }
        //render the board so it looks nice
        public static void renderBoard(int[,] board)
        {
            for (int tL=0; tL<=board.GetLength(1)+1;tL++)
                Console.Write("_");
                Console.WriteLine();
            for (int i=0;i<board.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j=0; j<board.GetLength(1); j++)
                {
                    if (board[i,j] == LIVE)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            for (int tL=0; tL<=board.GetLength(1)+1;tL++)
                Console.Write("_");
                Console.WriteLine();
        }
        //determine the new boardstate based on the rules
        // Live Cell with 0-1 neighbors dies because of underpopulation
        // Live Cell with 2-3 neighbors stays alive because its just right
        // Live Cell with >3 neighbors dies because of overpopulation
        // Dead Cell with EXACTLY 3 neighbors is alive by reproduction
        public static void nextBoardState(int[,] currentBoard)
        {

        }
        //generate a completely dead board
          public static int[,] deadState(int width, int height)
        {
            int[,] theBoard = new int[width, height];
            for(int i=0; i< width; i++)
            {
                for (int j=0; j<height; j++)
                {
                    theBoard[i,j]=DEAD;
                }

            }
            return theBoard;
        }
    }
}
