﻿using System;
using System.Collections.Generic;
using Tetris.Base;

namespace Tetris.GameObjects
{
    public class Border : IGameObject
    {
        public Vector2D MapSize { get; private set; }
        public List<Vector2D> Elements { get; private set; }
        public ColoredSymbol Symbol { get; private set; }

        public Border(Vector2D mapSize)
        {
            if(mapSize.Equals(Vector2D.Zero))
            {
                throw new ArgumentException($"{nameof(mapSize)} can not be Vector2D zero");
            }

            MapSize = mapSize;
            Elements = new List<Vector2D>();
            Symbol = new ColoredSymbol('#', ConsoleColor.DarkGray);
            DefinePositions();
        }

        /// <summary>
        /// Creates border positions for later rendering.
        /// </summary>
        private void DefinePositions()
        {
            var firstCol = new List<Vector2D>();
            var lastRow = new List<Vector2D>();
            var lastCol = new List<Vector2D>();

            for (int x = 0; x < MapSize.X; x++)
            {
                lastRow.Add(new Vector2D(x, MapSize.Y - 1));
            }

            for (int y = 0; y < MapSize.Y; y++)
            {
                firstCol.Add(new Vector2D(0, y));
                lastCol.Add(new Vector2D(MapSize.X - 1, y));
            }

            Elements.AddRange(firstCol);
            Elements.AddRange(lastRow);
            Elements.AddRange(lastCol);
        }
    }
}
