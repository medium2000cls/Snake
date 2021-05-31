using System;
using System.Collections.Generic;
using System.Drawing;
using Zmeyka2.Logic;

namespace Zmeyka2
{
    
    public class Presenter
    {
        private IMainForm _view;
        private GameControler _gameControler;


        public Presenter(IMainForm view, GameControler GC) //Конструктор
        {
            _view = view;
            _gameControler = GC;
            
            _view.TimerStepEventHendler += ViewOnTimerStepEventHendler;
            _view.ClickStartEventHendler += ViewOnClickStartEventHendler;
            
            _view.KeyUpEventHandler += _view_KeyUpEventHandler;
            _view.KeyDownEventHandler += _view_KeyDownEventHandler;
            _view.KeyLeftEventHandler += _view_KeyLeftEventHandler;
            _view.KeyRightEventHandler += _view_KeyRightEventHandler;
            
            _gameControler.Start();
            List<(int, int, Color)> TL = GameControlerOnCoordInfoEventHendler(_gameControler.MapE.MapCoordinates);
            _view.NewBoxes(TL);
        }

        private void ViewOnClickStartEventHendler(object sender, EventArgs e)
        {
            if (_view.TimerIsEnabled)
            {
                _view.TimerStart();
            }
            else
            {
                _view.TimerStop();
            }
        }

        private void ViewOnTimerStepEventHendler(object sender, EventArgs e)
        {
            bool stateWorking = _gameControler.Working();
            if (!stateWorking)
            {
                _view.TimerStop();
            }
            var TL = GameControlerOnCoordInfoEventHendler(_gameControler.MapE.MapCoordinates);
            _view.UpdateBoxes(TL);
        }

        private List<ValueTuple<int,int,Color>> GameControlerOnCoordInfoEventHendler(Coordinate[,] coordinates)
        {
            List<ValueTuple<int,int,Color>> tupleList = new List<(int, int, Color)>(200);
            
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                for (int j = 0; j < coordinates.GetLength(1); j++)
                {
                    (int X, int Y, Color color) VT = ExtractingDataFromCoordinates(coordinates[i,j]);
                    tupleList.Add(VT);
                }
            }
            return tupleList;
        }
        private (int X, int Y, Color color ) ExtractingDataFromCoordinates (Coordinate coordinate)
        {
            int X = coordinate.X;
            int Y = coordinate.Y;
            Color color;
            if (coordinate.ConditionSection == Condition.Empty)
            {
                color = Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (192)))), ((int) (((byte) (255))))); 
            }
            else if (coordinate.ConditionSection == Condition.Player)
            {
                color = Color.Red;
            }
            else if (coordinate.ConditionSection == Condition.Apple)
            {
                color = Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (128)))), ((int) (((byte) (0))))); 
            }
            else if (coordinate.ConditionSection == Condition.Obstacle)
            {
                color = Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            }
            else
            {
                throw new ArgumentException("В координатах содержаться новые данные");
            }

            return (X, Y, color);
        }

        
        #region События нажатия на клавиши

        private void _view_KeyRightEventHandler(object sender, EventArgs e)
        {
            _gameControler.MovementDg = _gameControler.MoveRight;
        }

        private void _view_KeyLeftEventHandler(object sender, EventArgs e)
        {
            _gameControler.MovementDg = _gameControler.MoveLeft;
        }

        private void _view_KeyDownEventHandler(object sender, EventArgs e)
        {
            _gameControler.MovementDg = _gameControler.MoveDown;
        }

        private void _view_KeyUpEventHandler(object sender, EventArgs e)
        {
            _gameControler.MovementDg = _gameControler.MoveUp;
        }

        #endregion
    }
}