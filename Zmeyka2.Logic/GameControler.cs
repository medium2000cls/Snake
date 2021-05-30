using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Zmeyka2.Logic
{
    public delegate void MoveDg();
    

    public class GameControler
    {
        public IMap MapE { get; private set; }
        public ISnake SnakeE { get; private set; }
        public MoveDg MovementDg { private get; set; }
        // public EventWaitHandle ewh;
        
        //public event EventHandler<Coordinate [,]> CoordInfoEventHendler;

        public GameControler()
        {
            MapE = new Map();
            SnakeE = new Snake();
            // ewh = new EventWaitHandle(false, EventResetMode.ManualReset);
            MovementDg = MoveLeft;
        }

        public void Start()                //TODO Метод старт
        {
            MapE.SetMapSize(20, 30);
            MapE.ObstacleDensityPercent = 0;
            MapE.AppleCount = 3;
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

        // public void StartWorking()
        // {
        //     ewh.Set();
        // }
        // public void StopWorking()
        // {
        //     ewh.Reset();
        // }

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
        
        // Событие срабатывания внутреннего таймера
        // protected virtual void OnCoordInfoEventHendler(Coordinate [,] e)
        // {
        //     CoordInfoEventHendler.Invoke(this, e);
        // }
    }
}