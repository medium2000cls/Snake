using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Zmeyka2
{
    public interface IMainForm
    {
        event EventHandler KeyUpEventHandler;
        event EventHandler KeyDownEventHandler;
        event EventHandler KeyLeftEventHandler;
        event EventHandler KeyRightEventHandler;
        event EventHandler TimerStepEventHendler;
        event EventHandler ClickStartEventHendler;
        public bool TimerIsEnabled { get; set; }
        public void NewBoxes(List<ValueTuple<int, int, Color>> tupleList);
        public void UpdateBoxes(List<ValueTuple<int, int, Color>> tupleList);

        // public void UpdateBoxes( List<ValueTuple<int,int,Color>> tupleList);
        public void TimerStart();
        public void TimerStop();


    }

    public partial class MainForm : Form, IMainForm
    {
        public event EventHandler KeyUpEventHandler;
        public event EventHandler KeyDownEventHandler;
        public event EventHandler KeyLeftEventHandler;
        public event EventHandler KeyRightEventHandler;
        public event EventHandler TimerStepEventHendler;
        public event EventHandler ClickStartEventHendler;

        private Timer _timer = new Timer(100);
        
        public bool TimerIsEnabled
        {
            get => _timer.Enabled;
            set => _timer.Enabled = value;
        }

        private List<PictureBox> _pictureBoxes = new List<PictureBox>(200);
        private int ScaleK = 12;
        
        public MainForm()
        {
            InitializeComponent();
            
            buttonStart.PreviewKeyDown += OnPreviewKeyDown;
            this.KeyDown += OnKeyDown;

            _timer.AutoReset = true;
            _timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            TimerStepEventHendler(this, EventArgs.Empty);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            TimerStart();
            if (ClickStartEventHendler != null) ClickStartEventHendler(this, EventArgs.Empty);
        }

        private void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
                e.IsInputKey = true;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                KeyUpEventHandler(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Down)
            {
                KeyDownEventHandler(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Left)
            {
                KeyLeftEventHandler(this, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Right)
            {
                KeyRightEventHandler(this, EventArgs.Empty);
            }
        }

        public void TimerStart()
        {
            _timer.Start();
        }

        public void TimerStop()
        {
            _timer.Stop();
        }

        public void NewBoxes(List<ValueTuple<int,int,Color>> tupleList)
        {
            foreach (var el in tupleList)
            {
                AddBoxes(el.Item1, el.Item2, el.Item3);
            }
        }

        public void UpdateBoxes (List<ValueTuple<int,int,Color>> tupleList)
        {                
            int i = 0;

            foreach (var el in tupleList)
            {
                ChangeBoxes(_pictureBoxes[i], el.Item3);
                i++;
            }
        }


        private void ChangeBoxes(PictureBox pictureBox, Color color)
        {
            pictureBox.BackColor = color;
            
        }

        private void AddBoxes(int X, int Y, Color color)
        {
            PictureBox box = CreateOneBox(X, Y, color);
            _pictureBoxes.Add(box);
            Controls.Add(box);
        }

        private PictureBox CreateOneBox(int X, int Y, Color color)
        {
            var originCoord = (X: 20, Y:20);
            PictureBox pb = new PictureBox();
            pb.Location = new System.Drawing.Point(originCoord.X + X * ScaleK, originCoord.Y + Y * ScaleK);
            pb.BackColor = color;
            pb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pb.Size = new System.Drawing.Size(ScaleK-1, ScaleK-1);
            pb.TabIndex = 0;
            pb.Name = $"Box {X} {Y}";
            return pb;
        }
    }
}
