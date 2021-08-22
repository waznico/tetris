using System;
using System.Collections.Generic;
using Tetris.Base;

namespace Tetris.GameObjects
{
    public class Block : IGameObject
    {
        public List<Vector2D> Elements { get; private set; }

        public ColoredSymbol Symbol { get; private set; }

        public Block()
        {
            Symbol = new ColoredSymbol('X', ConsoleColor.Yellow);

            Elements = new List<Vector2D>();
            Elements.Add(new Vector2D(50, 0));
            Elements.Add(new Vector2D(50, 1));
            Elements.Add(new Vector2D(51, 1));
        }


    }
}
