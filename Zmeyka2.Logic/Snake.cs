using System.Collections.Generic;

namespace Zmeyka2.Logic
{
    public interface ISnake
    {
        public Coordinate NextStep { get; set; }
        //public Coordinate LastStep { get; set; }
        public List<Coordinate> Body { get; set; }

        public void AppearanceOnMap(Coordinate coordinate); // Появление на карте
        public void Movement(); // Движение вперед
        public void IncreaseBody(); // Увеличение тела

    }

    public class Snake : ISnake
    {
        public Coordinate NextStep { get; set; }
        //public Coordinate LastStep { get; set; }
        public List<Coordinate> Body { get; set; }

        public Snake()
        {
            Body = new List<Coordinate>(20);
        }
        public void AppearanceOnMap(Coordinate coordinate)
        {
            coordinate.ConditionSection = Condition.Player;
            Body.Insert(0,coordinate);
        }
        public void Movement()
        {
            NextStep.ConditionSection = Condition.Player;
            Body.Insert(0,NextStep);
            Body.RemoveAt(Body.Count-1);
        }
        public void IncreaseBody()
        {
            NextStep.ConditionSection = Condition.Player;
            Body.Insert(0, NextStep);
        }
    }
}