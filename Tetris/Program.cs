using Tetris.Base;
using Tetris.Display;
using Tetris.GameObjects;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            var block = new Block();
            var renderer = new ConsoleRenderer(new Vector2D(100, 100));

            renderer.AddObjectToRenderer(block);
            renderer.ExecuteRendering();
        }
    }
}
