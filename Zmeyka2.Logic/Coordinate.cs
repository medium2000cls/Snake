namespace Zmeyka2.Logic
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Condition ConditionSection { get; set; }

        public Coordinate(int x, int y, Condition conditionSection)
        {
            X = x;
            Y = y;
            ConditionSection = conditionSection;
        }
    }
    public enum Condition
    {
        Empty,
        Player,
        Apple,
        Obstacle
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

}