using System;
using Tetris.Base;
using Tetris.Display;
using Tetris.GameObjects;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            var displaySize = new Vector2D(25, 50);
            var renderer = new ConsoleRenderer(displaySize);

            var border = new Border(displaySize);
            var block = new Block(displaySize);

            do
            {
                renderer.AddObjectToRenderer(border);
                renderer.AddObjectToRenderer(block);
                renderer.ExecuteRendering();

                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            block.Steer(Direction.Right);
                            break;
                        case ConsoleKey.LeftArrow:
                            block.Steer(Direction.Left);
                            break;
                        default:
                            break;
                    }
                }

                block.Move(1);

                System.Threading.Thread.Sleep(175);
            } while (true);
        }
    }
}
