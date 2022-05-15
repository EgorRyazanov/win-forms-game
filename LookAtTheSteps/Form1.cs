using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    
    public partial class Form1 : Form
    {
        public Player Player;
        public Timer Timer;
        public Gun Arrow;
        public List<Gun> Arrows;
        public Map Map;
        public bool IsButtomPressed;
        public int IndexLevel;
        public static int WidthBorder;
        public static int HeightBorder ;
        public bool IsWin;
        public bool IsLose;
        public bool IsInstructionShow;


        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            RestartButtom.Hide();
            HealthText.Hide();
            StepsText.Hide();
            SecondLevel.Hide();
            Back.Hide();
            ZeroLevel.Hide();
            FirstLevel.Hide();
            Inventory.Hide();
            ShowMoves.Hide();
            Menu.Hide();
            Health.Hide();
            NextLevel.Hide();
            Win.Hide();
            Lose.Hide();
            CloseInstructin.Hide();
            Instruction.Hide();
            ShowInstruction.Hide();
            WidthBorder = (Screen.PrimaryScreen.Bounds.Width - Map.MapWidth * Map.CellSize)/2;
            HeightBorder = (Screen.PrimaryScreen.Bounds.Height - Map.MapHeigh * Map.CellSize)/2;
        }

        public void Init()
        {
            Map = new Map(Map.CopyMap(Level.Levels[IndexLevel].Item1.map));
            Player = new Player (Level.Levels[IndexLevel].Item2.StartX, Level.Levels[IndexLevel].Item2.StartY,  
                Level.Levels[IndexLevel].Item2.StartHealth, Level.Levels[IndexLevel].Item2.StartMoves, WidthBorder, HeightBorder);
            Timer = new Timer();
            Timer.Interval = 5;
            Timer.Tick += Update;
            MouseClick += MoveOnMouse;
            Player.Init();
            Arrows = new List<Gun>();
            Timer.Start();
            Invalidate();
        }
        
        protected override void OnPaint( PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.LightGray), 0,0, ClientSize.Width, ClientSize.Height);
            if (IsButtomPressed && !IsLose && !IsWin && !IsInstructionShow)
            {
                Drawing.DrawMap(g,WidthBorder, 
                    HeightBorder, Map.map, Map.MapHeigh, Map.MapWidth);
                g.DrawImage(Drawing.Knight, Player.X, Player.Y, 50, 50);
                Drawing.DrawInventory(g, WidthBorder, HeightBorder, Player.InventorySize, Player.Inventory, Map.MapWidth, Map.MapHeigh);
                if (Map.ArrowIsMoving)
                    foreach (var arrow in Arrows)
                        g.DrawImage(arrow.Image,  arrow.X, arrow.Y, 50, 50);

            }
        }
        
        public void Update(object sender, EventArgs e)
        {
            ShowMoves.Text = Player.Moves.ToString();
            Health.Text = Player.Health.ToString();
            if (Player.Health == 0)
                Player.IsAlive = false;
            if (Player.IsMoving)
            {
                if (Player.X == Player.PurposeX &&
                       Player.Y == Player.PurposeY)
                {
                    Player.IsMoving = false;
                    Player.DirX = 0;
                    Player.DirY = 0;
                    Player.MadeMove = true;
                    if (Map.map[Player.Position.Item1, Player.Position.Item2] == MapBlocks.Finish)
                        IsWin = true;
                }
                Player.Move();
                Invalidate();
            }
            if (Player.Moves == 0 && !Player.IsMoving) 
                Player.IsHaveSteps = false;
            if (!Player.IsAlive || !Player.IsHaveSteps)
                IsLose = true;

            if (IsWin)
            {
                Invalidate();
                if (IndexLevel < 2)
                    NextLevel.Show();
                ShowMoves.Hide();
                Health.Hide();
                Inventory.Hide();
                Win.Show();
                StepsText.Hide();
                HealthText.Hide();
                Timer.Tick -= Update;
                MouseClick -= MoveOnMouse;
            }
            else if (IsLose)
            {
                Invalidate();
                Lose.Show();
                Health.Hide();
                Inventory.Hide();
                ShowMoves.Hide();
                StepsText.Hide();
                HealthText.Hide();
                Timer.Tick -= Update;
                MouseClick -= MoveOnMouse;
            }

            if (Map.ArrowIsMoving)
            {
                for (var i = 0; i < Arrows.Count; i++)
                {
                    if (Arrows[i].X == Arrows[i].PurposeX &&
                        Arrows[i].Y == Arrows[i].PurposeY )
                    {
                        Arrows[i].DirX = 0;
                        Arrows[i].DirY = 0;
                        if (Player.Health > 0)
                            Player.Health -= 1;
                        Arrows.Remove(Arrows[i]);
                        Invalidate();
                        continue;

                    }
                    Arrows[i].Move();
                    Invalidate();
                }
                if (Arrows.Count == 0)
                    Map.ArrowIsMoving = false;
            }
            if (Player.MadeMove && Map.HaveCrossbow)
            {
                var index = 0;
                if (Map.CrossbowsRow[Player.Position.Item1].Count > 0)
                {
                    foreach (var i in Map.CrossbowsRow[Player.Position.Item1])
                        if (Map.ArrowCanShootRow(i, Player.Position.Item2, Player.Position.Item1))
                        {
                            if (Math.Abs(i - Player.Position.Item2) != 1)
                            {
                                if (i > Player.Position.Item2)
                                    Arrow = new Gun(i * Map.CellSize + WidthBorder - 25,
                                        Player.Position.Item1 * Map.CellSize + HeightBorder);

                                else
                                    Arrow = new Gun((i + 1) * Map.CellSize + WidthBorder,
                                        Player.Position.Item1 * Map.CellSize + HeightBorder);
                                Arrows.Add(Arrow);
                                ChangeArrowVelocity(Player.Position.Item1, i, index);
                                index++;
                                Invalidate();
                            }
                            else
                            {
                                if (Player.Health > 0)
                                    Player.Health -= 1;
                            }
                        }
                }
                           
                if (Map.CrossbowsColumn[Player.Position.Item2].Count > 0)
                {
                    foreach (var i in Map.CrossbowsColumn[Player.Position.Item2])
                        if (Map.ArrowCanShootColumn(i, Player.Position.Item1, Player.Position.Item2))
                        {
                            if (Math.Abs(i - Player.Position.Item1) != 1) 
                            {
                                if (i > Player.Position.Item1)        
                                    Arrow = new Gun(Player.Position.Item2 * Map.CellSize + WidthBorder, i * Map.CellSize + HeightBorder - 25);
                                else 
                                    Arrow = new Gun(Player.Position.Item2 * Map.CellSize + WidthBorder, (i + 1) * Map.CellSize + HeightBorder);
                                Arrows.Add(Arrow);
                                ChangeArrowVelocity( i, Player.Position.Item2, index);
                                Invalidate();
                            }
                            else
                            {
                                if (Player.Health > 0)
                                    Player.Health -= 1;
                            }
                        }
                }
                Player.MadeMove = false;
            }
        }

        public bool PlayerInventoryPressed(int x, int y, MouseButtons button)
        {
            return button == MouseButtons.Left &&
                   x - WidthBorder - Map.CellSize * (Map.MapWidth / 2 - 1) > 0
                   && x < WidthBorder + Map.CellSize * (Map.MapWidth / 2 - 1 + Player.InventorySize) &&
                   y - HeightBorder - Map.CellSize * (Map.MapHeigh + 1) > 0
                   && y < HeightBorder + Map.CellSize * (Map.MapHeigh + 2)
                   && !Player.IsMoving;
        }
        
        public void ChangeArrowVelocity(int row, int column, int index)
        {
            Map.ArrowIsMoving = true;
            if (Player.Position.Item2 - column < 0)
            {
                Arrows[index].DirX = -5;
                Arrows[index].PurposeX = (Player.Position.Item2 + 1) * Map.CellSize + WidthBorder - 25;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + HeightBorder;
            }

            if (Player.Position.Item2 - column > 0)
            {
                Arrows[index].DirX = 5;
                Arrows[index].PurposeX = Player.Position.Item2 * Map.CellSize + WidthBorder - 25;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + HeightBorder;
                Arrows[index].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            
            if (Player.Position.Item1 - row < 0)
            {
                Arrows[index].DirY = -5;
                Arrows[index].PurposeX = Player.Position.Item2 * Map.CellSize + WidthBorder;
                Arrows[index].PurposeY = (Player.Position.Item1 + 1) * Map.CellSize + HeightBorder - 25;
                Arrows[index].Image.RotateFlip(RotateFlipType.Rotate270FlipY);
            }
            
            if (Player.Position.Item1 - row > 0)
            {
                Arrows[index].DirY = 5;
                Arrows[index].PurposeX = Player.Position.Item2  * Map.CellSize + WidthBorder;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + HeightBorder - 25;
                Arrows[index].Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            }
        }

        public void ClickOnInventory(int x, int y)
        {
            var column = (x - WidthBorder)/ Map.CellSize;
            var row = (y - HeightBorder)/ Map.CellSize;
            Drawing.DrawRectangle(row, column, Color.Gold, CreateGraphics());
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = column - Map.MapWidth/2 + 1;
        }

        public void MoveOnMouse(object sender, MouseEventArgs e)
        {
            if (Map.MapPressed(e.X, e.Y, e.Button, Player.IsMoving) && !Player.IsInventoryPressed 
                                                                    && Player.IsHaveSteps 
                                                                    && !Map.ArrowIsMoving
                                                                    && Player.IsAlive) // пофиксить момент, когда ты можешь скрыться от стрелы 
            {
                var column = (e.X - WidthBorder)/ Map.CellSize;
                var row = (e.Y - HeightBorder)/ Map.CellSize;
                if ((Player.Position.Item1 - row == 0 || Player.Position.Item2 - column == 0) &&
                    Player.Position.Item1 - row + Player.Position.Item2 - column != 0)
                {
                    if (Map.PlayerCanMove(row, column, Player.Position.Item1, Player.Position.Item2)) // передвижение
                    {
                        if (Map.IsPressed)
                        {
                            if (Map.PressedPosition.Item1 == row &&
                                Map.PressedPosition.Item2 == column)
                            {
                                Player.ChangePlayerVelocity(row, column);
                                Player.Moves -= 1;
                            }

                            Map.PressedPosition = new Tuple<int, int>(-1, -1);
                            Map.IsPressed = false;
                            Invalidate();
                        }
                        else
                        {
                            Drawing.DrawRectangle(row, column, Color.Red, CreateGraphics());
                            Map.IsPressed = true;
                            Map.PressedPosition = new Tuple<int, int>(row, column);
                        }
                    }

                    if (Math.Abs(Player.Position.Item1 - row) +
                        Math.Abs(Player.Position.Item2 - column) == 1 &&
                        Map.map[row, column] == MapBlocks.Stone && !Player.IsInventoryFull()) //взаимодействие с предметами
                    {
                        if (Map.IsPressed)
                        {
                            Map.TakeThingInInventory(row, column, Player);
                            Player.Moves -= 1;
                            Invalidate();
                        }
                        else
                        {
                            Drawing.DrawRectangle(row, column, Color.Gold, CreateGraphics());
                            Map.IsPressed = true;
                            Map.PressedPosition = new Tuple<int, int>(row, column);
                        }
                    }
                }
            }
            

            if (Player.IsInventoryPressed && Map.MapPressed(e.X, e.Y, e.Button, Player.IsMoving)
            && Player.IsHaveSteps && Player.IsAlive)
            {
                Map.PlaceThingOnMap(e.X, e.Y, Player, WidthBorder,HeightBorder);
                Player.Moves -= 1;
                Invalidate();
            }
            
            if (Player.IsInventoryPressed && Player.IsHaveSteps && Player.IsAlive) //ситуация когда ты нечаянно нажал на инвентарь, нужно убрать свой ход
                Player.IsInventoryPressed = false;

            if (PlayerInventoryPressed(e.X, e.Y, e.Button) && !Map.IsPressed && !Map.ArrowIsMoving &&
                Player.IsHaveSteps && Player.IsAlive)
            {
                if (Player.PressedInventoryPosition != -1)
                {
                    var row = (e.Y - HeightBorder)/ Map.CellSize;
                    Drawing.DrawRectangle(row, Player.PressedInventoryPosition + Map.MapWidth/2 - 1, Color.Black, CreateGraphics());
                }
                ClickOnInventory(e.X, e.Y);
            } // берем вещь из инвентаря
        }

        private void LoadZeroLevel(object sender, EventArgs e)
        {
            Back.Hide();
            IndexLevel = 0;
            Init();
            IsButtomPressed = true;
            SecondLevel.Hide();
            ZeroLevel.Hide();
            FirstLevel.Hide();
            ExitButtom.Hide();
            Menu.Show();
            PlayButtom.Hide();
            RestartButtom.Show();
            CloseInstructin.Show();
            Instruction.Show();
            IsInstructionShow = true;
        }

        private void LoadMenu(object sender, EventArgs e)
        {
            IsLose = false;
            IsWin = false;
            IsButtomPressed = false;
            PlayButtom.Show();
            Lose.Hide();
            ExitButtom.Show();
            Menu.Hide();
            ShowMoves.Hide();
            Inventory.Hide();
            HealthText.Hide();
            StepsText.Hide();
            Health.Hide();
            Timer.Tick -= Update;
            MouseClick -= MoveOnMouse;
            Invalidate();
            RestartButtom.Hide();
            Win.Hide();
            NextLevel.Hide();
            ShowInstruction.Hide();
            Instruction.Hide();
            CloseInstructin.Hide();

        }

        private void LoadFirstLevel(object sender, EventArgs e)
        {
            Back.Hide();
            IndexLevel = 1;
            Init();
            IsButtomPressed = true;
            SecondLevel.Hide();
            ZeroLevel.Hide();
            FirstLevel.Hide();
            ExitButtom.Hide();
            Menu.Show();
            ShowMoves.Show();
            Health.Show();
            HealthText.Show();
            StepsText.Show();
            Inventory.Show();
            PlayButtom.Hide();
            RestartButtom.Show();
            ShowInstruction.Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadNextLevel(object sender, EventArgs e)
        {
            IsLose = false;
            IsWin = false;
            IndexLevel += 1;
            Init();
            Timer.Tick -= Update;
            MouseClick -= MoveOnMouse;
            IsButtomPressed = true;
            NextLevel.Hide();
            Win.Hide();
            Init();
            ShowMoves.Show();
            Health.Show();
            HealthText.Show();
            StepsText.Show();
            Inventory.Show();
        }

        private void ShowLevels(object sender, EventArgs e)
        {
            PlayButtom.Hide();
            SecondLevel.Show();
            ZeroLevel.Show();
            FirstLevel.Show();
            Back.Show();
            ExitButtom.Hide();
        }

        private void GoBack(object sender, EventArgs e)
        {
            ZeroLevel.Hide();
            FirstLevel.Hide();
            SecondLevel.Hide();
            PlayButtom.Show();
            ExitButtom.Show();
            Back.Hide();
        }

        private void LoadSecondLevel(object sender, EventArgs e)
        {
            Back.Hide();
            IndexLevel = 2;
            Init();
            IsButtomPressed = true; 
            ZeroLevel.Hide();
            FirstLevel.Hide();
            SecondLevel.Hide();
            ExitButtom.Hide();
            Menu.Show();
            ShowMoves.Show();
            Health.Show();
            HealthText.Show();
            StepsText.Show();
            Inventory.Show();
            PlayButtom.Hide();
            RestartButtom.Show();
            ShowInstruction.Show();
        }

        private void Restart(object sender, EventArgs e)
        {
            NextLevel.Hide();
            Win.Hide();
            Lose.Hide();
            IsLose = false;
            IsWin = false;
            Timer.Tick -= Update;
            MouseClick -= MoveOnMouse;
            Init();
            ShowMoves.Show();
            Health.Show();
            Inventory.Show();
            HealthText.Show();
            StepsText.Show();
            Instruction.Hide();
            ShowInstruction.Show();
            CloseInstructin.Hide();
            IsInstructionShow = false;
            Invalidate();
        }
        
        private void ShowInstructionLabel(object sender, EventArgs e)
        {
            Instruction.Show();
            Health.Hide();
            Inventory.Hide();
            HealthText.Hide();
            StepsText.Hide();
            ShowInstruction.Hide();
            CloseInstructin.Show();
            IsInstructionShow = true;
            Invalidate();
        }
        
        private void CloseInstructionLabel(object sender, EventArgs e)
        {
            Instruction.Hide();
            Health.Show();
            Inventory.Show();
            HealthText.Show();
            StepsText.Show();
            ShowMoves.Show();
            ShowInstruction.Show();
            CloseInstructin.Hide();
            IsInstructionShow = false;
            Invalidate();
            if (IsLose || IsWin)
            {
                Health.Hide();
                Inventory.Hide();
                HealthText.Hide();
                StepsText.Hide();
                ShowMoves.Hide();
            }

        }
    }
}