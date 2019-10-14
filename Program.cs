using System;
using System.Threading;

namespace gameoflife
{   
    class Program
    {
        // declare static variables for DEAD and LIVE because it looks cooler
        public static int DEAD = 0;
        public static int LIVE = 1;
        static void Main(string[] args)
        {
            //set initial boardstate and bool then continue rendering board until new boards are identical
            bool keepGoing = true;
            int[,] board = randomState(5,10);
            renderBoard(board);
			//continue to run until the board becomes stale
            while(keepGoing)
            {
                int[,] nextBoard = nextBoardState(board);
                board = nextBoard;
                renderBoard(board);
                Thread.Sleep(1000);
            }
        }
      
        //generate a randomized starting board
        public static int[,] randomState(int width, int height)
        {
            //create array for board
            int[,] theBoard = new int[width, height];
            Random rand = new Random();
            //fill the Board with 1 and 0 in a random first state.
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
            //create board border
            for (int tL=0; tL<=board.GetLength(1)+1;tL++)
                Console.Write("_");
            Console.WriteLine();
            for (int i=0;i<board.GetLength(0); i++)
            {
                Console.Write("|");
                //convert 1 and 0 into * and blank spaces
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
        public static int[,] nextBoardState(int[,] currentBoard)
        {
            //generate the next board state following rules above
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
                                bool validCol = (i+yc >=0 && i+yc < currentBoard.GetLength(0));
                                bool validRow = (j+xc >=0 && j+xc < currentBoard.GetLength(1));
                                bool notCurrent = (yc != 0 && xc !=0);
                                bool validNeighbor = (validCol && validRow && notCurrent);
                                if (validNeighbor && currentBoard[i+yc,j+xc] == LIVE)
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
                                bool validCol = (i+yc >=0 && i+yc < currentBoard.GetLength(0));
                                bool validRow = (j+xc >=0 && j+xc < currentBoard.GetLength(1));
                                bool notCurrent = (yc != 0 && xc !=0);
                                bool validNeighbor = (validCol && validRow && notCurrent);
                                if ( validNeighbor && currentBoard[i+yc,j+xc] == LIVE)
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
