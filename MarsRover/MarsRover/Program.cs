using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Command[] commandList = new Command[] { Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.L, Command.M, Command.M };
            Go(1, 2, (int)Direction.N, commandList);

            commandList = new Command[] { Command.M, Command.M, Command.R, Command.M, Command.M, Command.R, Command.M, Command.R, Command.R, Command.M };
            Go(3, 3, (int)Direction.E, commandList);

            Console.ReadKey();
        }

        public enum Command { L, M, R }

        public enum Direction
        {
            [EnumMember]
            N = 1,
            [EnumMember]
            W = 2,
            [EnumMember]
            S = 3,
            [EnumMember]
            E = 4,
        }
        public static void Go(int x, int y, int direction, Command[] commandList)
        {
            foreach (Command command in commandList)
            {
                switch (command)
                {
                    case Command.L:
                        direction++;
                        if (direction == 5) direction = 1;
                        break;
                    case Command.M:
                        switch (direction)
                        {
                            case 1:
                                y++;
                                break;
                            case 2:
                                x--;
                                break;
                            case 3:
                                y--;
                                break;
                            case 4:
                                x++;
                                break;
                            default:
                                break;
                        }
                        break;
                    case Command.R:
                        direction--;
                        if (direction == 0) direction = 4;
                        break;
                    default:
                        break;
                }
            }
            Direction position = (Direction)direction;

            Console.WriteLine(x.ToString() + " " + y.ToString() + " " + position.ToString().Substring(0, 1));
        }




    }
}
