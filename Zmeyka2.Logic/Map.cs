
using System;
using System.Collections.Generic;

namespace Zmeyka2.Logic
{
    public interface IMap
    {
        public Coordinate[,] MapCoordinates { get; set; } 
        public int ObstacleDensityPercent { get; set; }
        public int AppleCount { get; set; }

        public void SetMapSize(int a, int b); //Установить рамер карты
        public void MakeAMap(); //Составить карту
        public void ChangeTheMap(List<Coordinate> coordinates, Condition condition); //Изменить карту
        public Coordinate RandomEmptyCoord();
        public void AddApple(); //Добавить яблоко на карту
        public void AddObstacle(); //Добавить препятствие на карту
        public void RemoveApple(); //Удалить яблоко с карты
        
        
    }


    public class Map : IMap
    {
        public Coordinate[,] MapCoordinates { get; set; }
        public int ObstacleDensityPercent { get; set; }
        public int AppleCount { get; set; }

        public void SetMapSize(int a, int b)
        {
            MapCoordinates = new Coordinate[a, b];
        }
        public void MakeAMap()
        {
            for (int i = 0; i < MapCoordinates.GetLength(0); i++)
            {
                for (int j = 0; j < MapCoordinates.GetLength(1); j++)
                {
                    MapCoordinates[i, j] = new Coordinate(i, j, Condition.Empty);
                }
            }
        }
        public void ChangeTheMap(List<Coordinate> coordinates, Condition condition)
        {
            foreach (Coordinate Coord in coordinates)
            {
                Coord.ConditionSection = condition;
            }
        }
        public Coordinate RandomEmptyCoord()
        {
            List<Coordinate> coordinatesCondition = CoordinatesCondition(Condition.Empty);
            Random rnd = new Random();

            Coordinate coordinate = coordinatesCondition[rnd.Next(0, coordinatesCondition.Count - 1)];
            return coordinate;

        }
        public void AddApple()
        {
            int elMap = AppleCount;
            AddObjectOnMap(elMap, Condition.Apple, Condition.Empty);
        }
        public void AddObstacle()
        {
            int elMap = MapCoordinates.GetLength(0) * MapCoordinates.GetLength(1) * ObstacleDensityPercent / 100;
            AddObjectOnMap(elMap, Condition.Obstacle, Condition.Empty);
        }
        public void RemoveApple()
        {
            for (int i = 0; i < MapCoordinates.GetLength(0); i++)
            {
                for (int j = 0; j < MapCoordinates.GetLength(1); j++)
                {
                    if (MapCoordinates[i, j].ConditionSection == Condition.Apple)
                    {
                        MapCoordinates[i, j].ConditionSection = Condition.Empty;
                    }
                }
            }
        }

        //Приватный метод изменяет на карте состояние случайных координат с заданным состоянием, на другое заданное состояние
        private void AddObjectOnMap(int elMap, Condition conditionForSet, Condition conditionForFind)
        {
            List<Coordinate> coordinatesCondition = CoordinatesCondition(conditionForFind);
            Coordinate coordinate;
            Random rnd = new Random();
            
            for (int i = 0; i < elMap && coordinatesCondition.Count > 1; i++)
            {
                int countK = coordinatesCondition.Count;
                if (countK > 1)
                {
                    coordinate = coordinatesCondition[rnd.Next(0, countK - 1)];
                    coordinate.ConditionSection = conditionForSet;
                    coordinatesCondition.Remove(coordinate);
                }
            }
        }

        //Приватный метод групирует координаты с одинаковым состоянием
        private List<Coordinate> CoordinatesCondition(Condition conditionForFind) 
        {
            List<Coordinate> coordinatesCondition = new List<Coordinate>(12);
            for (int i = 0; i < MapCoordinates.GetLength(0); i++)
            {
                for (int j = 0; j < MapCoordinates.GetLength(1); j++)
                {
                    if (MapCoordinates[i, j].ConditionSection == conditionForFind)
                    {
                        coordinatesCondition.Add(MapCoordinates[i, j]);
                    }
                }
            }

            return coordinatesCondition;
        }
    }
}