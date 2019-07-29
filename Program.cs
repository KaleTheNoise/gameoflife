using System;

namespace gameoflife
{
    class Program
    {
        public static int DEAD = 0;
        public static int LIVE = 1;
        static void Main(string[] args)
        {
            //test print dead board
            int[,] board = deadState(4,4);
            for (int i=0;i<board.GetLength(0); i++)
            {
                for (int j=0; j<board.GetLength(1); j++)
                {
                    Console.Write(board[i,j] +"\t");
                }
                Console.WriteLine();
            }
            
        }
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
