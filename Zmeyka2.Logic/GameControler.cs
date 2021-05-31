using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace Zmeyka2.Logic
{
    public delegate void MoveDg();
    

    public class GameControler
    {
        public IMap MapE { get; private set; }
        public ISnake SnakeE { get; private set; }
        public MoveDg MovementDg { private get; set; }

        public GameControler()
        {
            MapE = new Map();
            SnakeE = new Snake();
            MovementDg = MoveLeft;
        }

        public void Start()                //TODO Метод старт
        {
            MapE.SetMapSize(40, 50);
            MapE.ObstacleDensityPercent = 0;
            MapE.AppleCount = 2;
            MapE.MakeAMap();

            SetLvl();
        }

        public void SetLvl()
        {
            MapE.AddObstacle();
            MapE.AddApple();
            SnakeE.AppearanceOnMap(MapE.RandomEmptyCoord());
        }

        public bool Working()
        {
            // ewh.WaitOne();
            MovementDg();
            bool isLvlWorking = CheckCoordinat();
            return isLvlWorking;
        }

        #region Методы движения

        public void MoveUp()
        {
            Coordinate head = SnakeE.Body[0];
            int sizeY = MapE.MapCoordinates.GetLength(1) - 1;
            if (head.Y == 0)
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X, sizeY];
            }
            else
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X, head.Y - 1];
            }

            if (SnakeE.Body.Count > 1 && SnakeE.NextStep == SnakeE.Body[1])
            {
                MoveDown();
            }   

            
        }

        public void MoveDown()
        {
            Coordinate head = SnakeE.Body[0];
            int sizeY = MapE.MapCoordinates.GetLength(1) - 1;
            if (head.Y == sizeY)
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X, 0];
            }
            else
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X, head.Y + 1];
            }
            if (SnakeE.Body.Count > 1 && SnakeE.NextStep == SnakeE.Body[1])
            {
                MoveUp();
            }

        }

        public void MoveLeft()
        {
            Coordinate head = SnakeE.Body[0];
            int sizeX = MapE.MapCoordinates.GetLength(0) - 1;
            if (head.X == 0)
            {
                SnakeE.NextStep = MapE.MapCoordinates[sizeX, head.Y];
            }
            else
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X-1, head.Y];
            }
            if (SnakeE.Body.Count > 1 && SnakeE.NextStep == SnakeE.Body[1])
            {
                MoveRight();
            }

        }

        public void MoveRight()
        {
            Coordinate head = SnakeE.Body[0];
            int sizeX = MapE.MapCoordinates.GetLength(0) - 1;
            if (head.X == sizeX)
            {
                SnakeE.NextStep = MapE.MapCoordinates[0, head.Y];
            }
            else
            {
                SnakeE.NextStep = MapE.MapCoordinates[head.X+1, head.Y];
            }
            if (SnakeE.Body.Count > 1 && SnakeE.NextStep == SnakeE.Body[1])
            {
                MoveLeft();
            }

        }

        #endregion

        // Методы проверки клеток
        private bool CheckCoordinat()
        {
            if (SnakeE.NextStep.ConditionSection == Condition.Empty)
            {
                MapE.ChangeTheMap(SnakeE.Body,Condition.Empty);
                SnakeE.Movement();
                MapE.ChangeTheMap(SnakeE.Body,Condition.Player);
                return true;
            }
            else if (SnakeE.NextStep.ConditionSection == Condition.Apple)
            {
                MapE.ChangeTheMap(SnakeE.Body, Condition.Empty);
                SnakeE.IncreaseBody();
                MapE.ChangeTheMap(SnakeE.Body, Condition.Player);
                MapE.AddApple(25);
                return true;
            }
            else if (SnakeE.NextStep.ConditionSection == Condition.Obstacle)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        
    }
}