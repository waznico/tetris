using System;
using System.Collections.Generic;
using Tetris.Base;

namespace Tetris.GameObjects
{
    public class Block : IGameObject
    {
        public List<Vector2D> Elements { get; private set; }

        public ColoredSymbol Symbol { get; private set; }

        public Block(Vector2D displaySize)
        {
            Symbol = new ColoredSymbol('X', ConsoleColor.Yellow);

            Elements = new List<Vector2D>();
            Elements.Add(new Vector2D(displaySize.X / 2, 0));
            Elements.Add(new Vector2D(displaySize.X / 2, 1));
            Elements.Add(new Vector2D(displaySize.X / 2 + 1, 1));
        }

        public void Turn()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                int x = Elements[i].X * -1;
                int y = Elements[i].Y;
                Elements[i].X = y;
                Elements[i].Y = x;
            }
        }

        public void Move(int speed)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                var movement = Vector2D.Down;
                movement.Y *= speed;
                Elements[i].Add(movement);
            }
        }

        public void Steer(Direction direction)
        {
            var directionVector = Vector2D.Zero;
            switch (direction)
            {
                case Direction.Left:
                    directionVector = Vector2D.Left;
                    break;
                case Direction.Right:
                    directionVector = Vector2D.Right;
                    break;
            }

            if (!directionVector.Equals(Vector2D.Zero))
            {
                for (int i = 0; i < Elements.Count; i++)
                {
                    Elements[i].Add(directionVector);
                }
            }
        }
    }
}
