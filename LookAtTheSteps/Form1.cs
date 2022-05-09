using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    
    public partial class Form1 : Form
    {
        public Player Player;
        public Image Knight;
        public Timer Timer;
        public Arrow Arrow;
        public List<Arrow> Arrows = new List<Arrow>();
        public Map Map;
        public List<Level> Levels;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Timer = new Timer();
            Timer.Interval = 5;
            Timer.Tick += Update;
            Init();
            MouseClick += MoveOnMouse;
        }

        public void Init()
        {
            Levels = new List<Level>();
            Map = new Map(12, 14, new[,]
            {
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, 
                    MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Crossbow, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Crossbow, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Crossbow,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Crossbow
                },
                {
                    MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Crossbow, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Empty
                },
                {
                    MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Crossbow, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },});
            Knight = new Bitmap(Path.Combine(new DirectoryInfo
                (Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\knight.png"));
            Player = new Player(100, 100, Knight, 2, 2, 14);
            Player.Init();
            Timer.Start();
        }
        
        protected override void OnPaint( PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = e.Graphics;
            Drawing.DrawMap(g,100, 100, Map.map, Map.MapHeigh, Map.MapWidth);
            // g.DrawImage(Player.Sprite, Player.X, Player.Y, 
            //     new Rectangle(new Point(0,0), new Size(Player.Size, Player.Size)),
            //     GraphicsUnit.Pixel);
            g.DrawImage(Player.Sprite, Player.X, Player.Y, 50, 50);
            Drawing.DrawInventory(g, 100, 100, Player.InventorySize, Player.Inventory, Map.MapWidth, Map.MapHeigh);
            if (Map.ArrowIsMoving)
                foreach (var arrow in Arrows)
                    g.DrawImage(arrow.Image,  arrow.X, arrow.Y, 50, 50);

        }
        
        public void Update(object sender, EventArgs e)
        {
            ShowMoves.Text = Player.Moves.ToString();
            if (Player.IsMoving)
            {
                if (Player.X == Player.PurposeX &&
                       Player.Y == Player.PurposeY)
                {
                    Player.IsMoving = false;
                    Player.DirX = 0;
                    Player.DirY = 0;
                    Player.MadeMove = true;
                }
                Player.Move();
                Invalidate();
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
                                        Arrow = new Arrow(i * Map.CellSize + 76,
                                            Player.Position.Item1 * Map.CellSize + 100);

                                    else
                                        Arrow = new Arrow((i + 1) * Map.CellSize + 100,
                                            Player.Position.Item1 * Map.CellSize + 100);
                                    Arrows.Add(Arrow);
                                    ChangeArrowVelocity(Player.Position.Item1, i, index);
                                    index++;
                                    Invalidate();
                                }
                                else
                                    Player.Health -= 1;
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
                                        Arrow = new Arrow(Player.Position.Item2 * Map.CellSize + 100, i * Map.CellSize + 76);
                                    else 
                                        Arrow = new Arrow(Player.Position.Item2 * Map.CellSize + 100, (i + 1) * Map.CellSize + 100);
                                    Arrows.Add(Arrow);
                                    ChangeArrowVelocity( i, Player.Position.Item2, index);
                                    Invalidate();
                                }
                                else
                                    Player.Health -= 1;
                            }
                    }
                Player.MadeMove = false;
            }
        }

        public bool PlayerInventoryPressed(int X, int Y, MouseButtons button)
        {
            return button == MouseButtons.Left &&
                   X - 100 - Map.CellSize * (Map.MapWidth / 2 - 1) > 0
                   && X < 100 + Map.CellSize * (Map.MapWidth / 2 - 1 + Player.InventorySize) &&
                   Y - 100 - Map.CellSize * (Map.MapHeigh + 1) > 0
                   && Y < 100 + Map.CellSize * (Map.MapHeigh + 2)
                   && !Player.IsMoving;
        }
        
        public void ChangeArrowVelocity(int row, int column, int index)
        {
            Map.ArrowIsMoving = true;
            if (Player.Position.Item2 - column < 0)
            {
                Arrows[index].DirX = -2;
                Arrows[index].PurposeX = (Player.Position.Item2 + 1) * Map.CellSize + 100;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + 100;
            }

            if (Player.Position.Item2 - column > 0)
            {
                Arrows[index].DirX = 2;
                Arrows[index].PurposeX = Player.Position.Item2 * Map.CellSize + 76;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + 100;
            }
            
            if (Player.Position.Item1 - row < 0)
            {
                Arrows[index].DirY = -2;
                Arrows[index].PurposeX = Player.Position.Item2 * Map.CellSize + 100;
                Arrows[index].PurposeY = (Player.Position.Item1 + 1) * Map.CellSize + 100;
            }
            
            if (Player.Position.Item1 - row > 0)
            {
                Arrows[index].DirY = 2;
                Arrows[index].PurposeX = Player.Position.Item2  * Map.CellSize + 100;
                Arrows[index].PurposeY = Player.Position.Item1 * Map.CellSize + 76;
            }
        }

        public void ClickOnInventory(int X, int Y)
        {
            var column = (X - 100)/ Map.CellSize;
            var row = (Y - 100)/ Map.CellSize;
            Drawing.DrawRectangle(row, column, Color.Gold, CreateGraphics());;
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = column - Map.MapWidth/2 + 1;
        }

        public void MoveOnMouse(object sender, MouseEventArgs e)
        {
            if (Player.Health <= 0)
                Player.IsAlive = false;
            if (Map.MapPressed(e.X, e.Y, e.Button, Player.IsMoving) && !Player.IsInventoryPressed 
                                                                    && Player.IsHaveSteps 
                                                                    && !Map.ArrowIsMoving
                                                                    && Player.IsAlive) // пофиксить момент, когда ты можешь скрыться от стрелы 
            {
                var column = (e.X - 100)/ Map.CellSize;
                var row = (e.Y - 100)/ Map.CellSize;
                if ((Player.Position.Item1 - row == 0 || Player.Position.Item2 - column == 0) &&
                    Player.Position.Item1 - row + Player.Position.Item2 - column != 0)
                {
                    if (Map.PlayerCanMove(row, column, Player.Position.Item1, Player.Position.Item2)) // передвижение
                    {
                        if (Map.isPressed)
                        {
                            if (Map.pressedPosition.Item1 == row &&
                                Map.pressedPosition.Item2 == column)
                            {
                                Player.ChangePlayerVelocity(row, column);
                                Player.Moves -= 1;
                            }

                            Map.pressedPosition = new Tuple<int, int>(-1, -1);
                            Map.isPressed = false;
                            Invalidate();
                        }
                        else
                        {
                            Drawing.DrawRectangle(row, column, Color.Red, CreateGraphics());
                            Map.isPressed = true;
                            Map.pressedPosition = new Tuple<int, int>(row, column);
                        }
                    }

                    if (Math.Abs(Player.Position.Item1 - row) +
                        Math.Abs(Player.Position.Item2 - column) == 1 &&
                        Map.map[row, column] == MapBlocks.Stone && !Player.IsInventoryFull()) //взаимодействие с предметами
                    {
                        if (Map.isPressed)
                        {
                            Map.TakeThingInInventory(row, column, Player);
                            Invalidate();
                        }
                        else
                        {
                            Drawing.DrawRectangle(row, column, Color.Gold, CreateGraphics());;
                            Map.isPressed = true;
                            Map.pressedPosition = new Tuple<int, int>(row, column);
                        }
                    }
                }
            }

            if (Player.Moves == 0)
                Player.IsHaveSteps = false;

            if (Player.IsInventoryPressed && Map.MapPressed(e.X, e.Y, e.Button, Player.IsMoving)
            && Player.IsHaveSteps && Player.IsAlive)
            {
                Map.PlaceThingOnMap(e.X, e.Y, Player);
                Player.Moves -= 1;
                Invalidate();
            }
            if (Player.IsInventoryPressed && Player.IsHaveSteps && Player.IsAlive) //ситуация когда ты нечаянно нажал на инвентарь, нужно убрать свой ход
                Player.IsInventoryPressed = false;

            if (PlayerInventoryPressed(e.X, e.Y, e.Button) && !Map.isPressed && !Map.ArrowIsMoving && Player.IsHaveSteps && Player.IsAlive) // берем вещь из инвентаря
                ClickOnInventory(e.X, e.Y);
            
        }
    }
}