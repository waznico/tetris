using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Base;
using Tetris.Display;
using Tetris.GameObjects;
using Tetris.GameObjects.Blocks;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = false;
            var displaySize = new Vector2D(25, 50);
            var renderer = new ConsoleRenderer(displaySize);

            var border = new Border(displaySize);
            var block = new Block(displaySize);
            var stack = new List<Block>();

            do
            {
                renderer.AddObjectToRenderer(border);
                foreach (var item in stack)
                {
                    renderer.AddObjectToRenderer(item);
                }
                renderer.AddObjectToRenderer(block);
                renderer.ExecuteRendering();

                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();

                    var modifier = 1;
                    if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                    {
                        modifier *= -1;
                    }
                    var collidedWithBorder = block.Elements.Where(el => el.X + modifier < 2 || el.X + modifier > displaySize.X - 2).Any();

                    if (!collidedWithBorder)
                    {
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
                }

                var hitTheGround = block.Elements.Where(bl => bl.Y == displaySize.Y - 2).Any();
                
                if (!hitTheGround)
                {
                    block.Move(1);
                }
                else
                {
                    stack.Add(block);
                    block = new Block(displaySize);
                }

                System.Threading.Thread.Sleep(175);
            } while (true);
        }
    }
}
