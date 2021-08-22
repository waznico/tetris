using System.Collections.Generic;
using Tetris.Base;

namespace Tetris.GameObjects
{
    public interface IGameObject
    {
        public List<Vector2D> Elements { get; }
        public ColoredSymbol Symbol { get; }
    }
}
