namespace AdventOfCode2024.src
{
    public class MatrixDirection
    {
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        public static (int X, int Y) GetNextPositionByDirection((int X, int Y) position, Direction direction) => direction switch
        {
            Direction.Up => (position.X - 1, position.Y),
            Direction.Right => (position.X, position.Y + 1),
            Direction.Down => (position.X + 1, position.Y),
            Direction.Left => (position.X, position.Y - 1),
            _ => throw new ArgumentException("Invalid direction")
        };

        public static Direction ChangeDirection(Direction direction) => direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}
