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
            board = nextBoardState(board);
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

        //FIX CHECKING IF THE INDEX OF currentBoard[i+yc,j+xc] IS OUT OF RANGE
        public static int[,] nextBoardState(int[,] currentBoard)
        {
            int [,] nextBoard = deadState(currentBoard.GetLength(0),currentBoard.GetLength(1));
            for (int i=0; i<currentBoard.GetLength(0);i++)
            {
                for (int j=0; j<currentBoard.GetLength(1); j++)
                {
                    int neighbors = 0;
                    if (currentBoard[i,j]==LIVE)
                    {
                        for (int xc = -1; xc <= 1; xc++)
                        {
                            for (int yc = -1; yc <=1; yc++)
                            {
                                if (currentBoard[i+yc,j+xc] != null && currentBoard[i+yc,j+xc] == LIVE)
                                    neighbors++;
                            }
                        }
                        if(neighbors == 0 || neighbors == 1)
                            nextBoard[i,j]=DEAD;
                        else if (neighbors == 2 || neighbors == 3)
                            nextBoard[i,j]=LIVE;
                        else if (neighbors > 3)
                            nextBoard[i,j]=DEAD;
                    }
                    else if (currentBoard[i,j]==DEAD)
                    {
                         for (int xc = -1; xc <= 1; xc++)
                        {
                            for (int yc = -1; yc <=1; yc++)
                            {
                                if (currentBoard[i+yc,j+xc] != null && currentBoard[i+yc,j+xc] == LIVE)
                                    neighbors++;
                            }
                        }
                        if (neighbors == 3)
                            nextBoard[i,j] = LIVE;
                    }
                }
            }
            return nextBoard;
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
