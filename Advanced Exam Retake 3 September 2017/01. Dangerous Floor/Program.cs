using System;
using System.Linq;

namespace _01._Dangerous_Floor
{
    class Program
    {
        static char[][] data;
        static void Main(string[] args)
        {
            ReadMatrix();
            ReadCommands();
            
        }

        private static void ReadCommands()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                char[] command = input.ToCharArray();
             
                if (command.Length == 6)
                {
                    char piece = command[0];
                    int currentR = int.Parse(command[1].ToString());
                    int currentC = int.Parse(command[2].ToString());
                    int finalR = int.Parse(command[4].ToString());
                    int finalC = int.Parse(command[5].ToString());

                    if (data[currentR][currentC] != piece)
                    {
                        Console.WriteLine("There is no such a piece!");
                        continue;
                    }
                    else if (!HasMove(piece, currentR, currentC, finalR, finalC))
                    {
                        Console.WriteLine("Invalid move!");
                        continue;
                    }
                    else if (!CheckRC(finalR, finalC))
                    {
                        Console.WriteLine("Move go out of board!");
                        continue;
                    }
                    else
                    {
                        data[currentR][currentC] = 'x';
                        data[finalR][finalC] = piece;
                    }
                }
                

            }

        }

        private static bool HasMove(char piece, int currentR, int currentC, int finalR, int finalC)
        {
            bool isMove = false;
            switch (piece)
            {
                case 'K':
                    isMove = King(currentR, currentC, finalR, finalC);
                        break;
                case 'R':
                    isMove = Rook(currentR, currentC, finalR, finalC);
                    break;
                case 'B':
                    isMove = Bishop(currentR, currentC, finalR, finalC);
                    break;
                case 'Q':
                    isMove = Queen(currentR, currentC, finalR, finalC);
                    break;
                case 'P':
                    isMove = Pawn(currentR, currentC, finalR, finalC);
                    break;
                default:
                    break;
            }
            return isMove;
        }

        private static bool Pawn(int currentR, int currentC, int finalR, int finalC)
        {
            if ((currentC == finalC) && (currentR == finalR +1))
            {
                return true;
            }
            return false;
        }

        private static bool Queen(int currentR, int currentC, int finalR, int finalC)
        {
            int r = Math.Abs(currentR - finalR);
            int c = Math.Abs(currentC - finalC);
            if (((currentR == finalR) || (currentC == finalC)) || r == c)
            {
                return true;
            }
            return false;
        }

        private static bool Bishop(int currentR, int currentC, int finalR, int finalC)
        {
            int r = Math.Abs(currentR - finalR);
            int c = Math.Abs(currentC - finalC);
            if (r == c)
            {
                return true;
            }
            return false;
        }

        private static bool Rook(int currentR, int currentC, int finalR, int finalC)
        {
            if ((currentR == finalR) || (currentC == finalC))
            {
                return true;
            }
            return false;
        }

        private static bool King(int currentR, int currentC, int finalR, int finalC)
        {
            int r = Math.Abs(currentR - finalR);
            int c = Math.Abs(currentC - finalC);

            if ((r == 0 || r == 1) && (c == 0 || c == 1))
            {
                return true;
            }
            return false;
        }

        private static bool CheckRC(int currentR, int currentC)
        {
            if (currentR >= 0 && currentR < 8 && currentC >= 0 && currentC < 8)
            {
                return true;
            }
            return false;
        }

        private static void ReadMatrix()
        {
            data = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                char[] tokens = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                data[i] = new char[tokens.Length];
                for (int j = 0; j < tokens.Length; j++)
                {
                    data[i][j] = tokens[j];
                }
            }
        }
    }
}
