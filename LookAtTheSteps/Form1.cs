using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    
    public partial class Form1 : Form
    {
        public Player Player;
        public Image Circle;
        public Timer Timer;
        public Arrow Arrow;

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
            Map.Init();
            Circle = new Bitmap(Path.Combine(new DirectoryInfo
                (Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Sprites\\Circle.png"));
            Player = new Player(100, 100, Circle, 2);
            Player.Init();
            Timer.Start();
        }

        public bool RowCanShoot(int arrowColumn, int playerColumn)
        {
            if (playerColumn > arrowColumn)
                arrowColumn++;
            var minColumn = Math.Min(playerColumn, arrowColumn);
            var maxColumn = Math.Max(playerColumn, arrowColumn);
            for (var x = minColumn; x < maxColumn; x++)
                if (Map.map[Player.Position.Item1, x] != MapBlocks.Empty 
                    && Map.map[Player.Position.Item1, x] != MapBlocks.Finish
                    && Map.map[Player.Position.Item1, x] != MapBlocks.ForcedLava)
                    return false;
            return true;
        }

        public bool ColumnCanShoot(int arrowRow, int playerRow)
        {
            if (playerRow > arrowRow)
                arrowRow++;
            var minRow = Math.Min(playerRow, arrowRow);
            var maxRow = Math.Max(playerRow, arrowRow);
            for (var y = minRow; y < maxRow; y++)
                if (Map.map[y, Player.Position.Item2] != MapBlocks.Empty 
                    && Map.map[y, Player.Position.Item2] != MapBlocks.Finish
                    && Map.map[y, Player.Position.Item2] != MapBlocks.ForcedLava)
                    return false;
            return true;
        }

        public void Update(object sender, EventArgs e)
        {
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
                if (Arrow.X == Arrow.PurposeX &&
                    Arrow.Y == Arrow.PurposeY )
                    {
                        Map.ArrowIsMoving = false;
                        Arrow.DirX = 0;
                        Arrow.DirY = 0;
                    }
                Arrow.Move();
                Invalidate();
            }
        }

        protected override void OnPaint( PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = e.Graphics;
            Map.DrawMap(g,100, 100);
            g.DrawImage(Player.Sprite, Player.X, Player.Y, 
                new Rectangle(new Point(0,0), new Size(Player.Size, Player.Size)),
                GraphicsUnit.Pixel);
            Player.DrawInventory(g, 100, 100);
            if (Map.ArrowIsMoving)
                g.DrawImage(Arrow.Image, Arrow.X, Arrow.Y, new Rectangle(new Point(0,0), new Size(25, 25)),
                        GraphicsUnit.Pixel);
        }

        public bool PlayerCanMove(int row, int column)
        {
            var minRow = Math.Min(Player.Position.Item1, row);
            var maxRow = Math.Max(Player.Position.Item1, row);
            for (var x = minRow; x <= maxRow; x++)
                if (Map.map[x, column] != MapBlocks.Empty 
                    && Map.map[x, column] != MapBlocks.Finish
                    && Map.map[x, column] != MapBlocks.ForcedLava)
                    return false;
            var minColumn = Math.Min(Player.Position.Item2, column);
            var maxColumn = Math.Max(Player.Position.Item2, column);
            for (var y = minColumn; y <= maxColumn; y++)
                if (Map.map[row, y] != MapBlocks.Empty 
                    && Map.map[row, y] != MapBlocks.Finish
                    && Map.map[row, y] != MapBlocks.ForcedLava)
                    return false;
            return true;
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

        public bool MapPressed(int X, int Y, MouseButtons button)
        {
            return button == MouseButtons.Left &&
                   X - 100 > 0 && X < 100 + Map.GetWidth() &&
                   Y - 100 > 0 && Y < 100 + Map.GetHeigh()
                   && !Player.IsMoving;
        }

        public void ChangePlayerVelocity(int row, int column)
        {
            Player.IsMoving = true;
            if (Player.Position.Item2 - column < 0)
                Player.DirX = 5;
            if (Player.Position.Item2 - column > 0)
                Player.DirX = -5;
            if (Player.Position.Item1 - row < 0)
                Player.DirY = 5;
            if (Player.Position.Item1 - row > 0)
                Player.DirY = -5;
            Player.PurposeX = column * Map.CellSize + 100;
            Player.PurposeY = row * Map.CellSize + 100;
            Player.Position = new Tuple<int, int>(row, column);
        }

        public void PlaceThingOnMap(int X, int Y)
        {
            var column = (X - 100)/ Map.CellSize;
            var row = (Y - 100)/ Map.CellSize;
            if (Math.Abs(Player.Position.Item1 - row) + 
                Math.Abs(Player.Position.Item2 - column) == 1
                && Map.map[row, column] == MapBlocks.Empty 
                || Map.map[row, column] == MapBlocks.Lava)
            {
                if (Map.map[row, column] == MapBlocks.Empty)
                    Map.map[row, column] = Player.Inventory[Player.PressedInventoryPosition];
                else if (Map.map[row, column] == MapBlocks.Lava)
                    Map.map[row, column] = MapBlocks.ForcedLava;
                Player.MadeMove = true;
                Player.Inventory[Player.PressedInventoryPosition] = MapBlocks.Empty;
                Player.IsInventoryPressed = false;
                Player.PressedInventoryPosition = -1;
            }
            Invalidate();
        }
        public void ChangeArrowVelocity(int row, int column)
        {
            Map.ArrowIsMoving = true;
            if (Player.Position.Item2 - column < 0)
                Arrow.DirX = -2;
            if (Player.Position.Item2 - column > 0)
                Arrow.DirX = 2;
            if (Player.Position.Item1 - row < 0)
                Arrow.DirY = -2;
            if (Player.Position.Item1 - row > 0)
                Arrow.DirY = 2;
            Arrow.PurposeX = Player.Position.Item2 * Map.CellSize + 100;
            Arrow.PurposeY = Player.Position.Item1 * Map.CellSize + 100;
        }

        public void ClickOnInventory(int X, int Y)
        {
            var column = (X - 100)/ Map.CellSize;
            var row = (Y - 100)/ Map.CellSize;
            DrawRectangle(row, column, Color.Gold);
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = column - Map.MapWidth/2 + 1;
        }

        public void TakeThingInInventory(int row, int column)
        {
            if (Map.pressedPosition.Item1 == row &&
                Map.pressedPosition.Item2 == column)
            {
                for (var i = 0; i < Player.InventorySize; i++)
                    if (Player.Inventory[i] == MapBlocks.Empty)
                    {
                        Player.Inventory[i] = Map.map[row, column];
                        Map.map[row, column] = MapBlocks.Empty;
                        Player.MadeMove = true;
                        break;
                    }
            }

            Map.pressedPosition = new Tuple<int, int>(-1, -1);
            Map.isPressed = false;
            Invalidate();
        }

        public void DrawRectangle(int row, int column, Color color)
        {
            Graphics g = CreateGraphics();
            g.DrawRectangle(new Pen(color), 100 + column * Map.CellSize,
                100 + row * Map.CellSize, Map.CellSize, Map.CellSize);
        }

        public double GetAngleX(int xPlayer, int xArrow)
        {
            if (xPlayer > xArrow)
                return 0;
            return 180;
        }
        
        public double GetAngleY(int yPlayer, int yArrow)
        {
            if (yPlayer > yArrow)
                return 90;
            return 270;
        }

        public void MoveOnMouse(object sender, MouseEventArgs e)
        {
            if (MapPressed(e.X, e.Y, e.Button) && !Player.IsInventoryPressed && !Map.ArrowIsMoving) // пофиксить момент, когда ты можешь скрыться от стрелы 
            {
                var column = (e.X - 100)/ Map.CellSize;
                var row = (e.Y - 100)/ Map.CellSize;
                if (Player.Position.Item1 - row == 0 || Player.Position.Item2 - column == 0 &&
                    Player.Position.Item1 - row + Player.Position.Item2 - column != 0)
                {
                    if (PlayerCanMove(row, column)) // передвижение
                    {
                        if (Map.isPressed)
                        {
                            if (Map.pressedPosition.Item1 == row &&
                                Map.pressedPosition.Item2 == column)
                                ChangePlayerVelocity(row, column);

                            Map.pressedPosition = new Tuple<int, int>(-1, -1);
                            Map.isPressed = false;
                            Invalidate();
                        }
                        else
                        {
                            DrawRectangle(row, column, Color.Red);
                            Map.isPressed = true;
                            Map.pressedPosition = new Tuple<int, int>(row, column);
                        }
                    }

                    if (Math.Abs(Player.Position.Item1 - row) +
                        Math.Abs(Player.Position.Item2 - column) == 1 &&
                        Map.map[row, column] == MapBlocks.Stone && !Player.IsInventoryFull()) //взаимодействие с предметами
                    {
                        if (Map.isPressed)
                            TakeThingInInventory(row, column);
                        else
                        {
                            DrawRectangle(row, column, Color.Gold);
                            Map.isPressed = true;
                            Map.pressedPosition = new Tuple<int, int>(row, column);
                        }
                    }
                }
            }

            if (Player.IsInventoryPressed && MapPressed(e.X, e.Y, e.Button))
                PlaceThingOnMap(e.X, e.Y);
            if (Player.IsInventoryPressed) //ситуация когда ты нечаянно нажал на инвентарь, нужно убрать свой ход
                Player.IsInventoryPressed = false;

            if (PlayerInventoryPressed(e.X, e.Y, e.Button) && !Map.isPressed) // берем вещь из инвентаря
                ClickOnInventory(e.X, e.Y);
            
            
            if (Player.MadeMove) // Автомат со стрелами (Есть проблема: если игрок попадает точку, где могут достать
                                 // одновременно вертикальный и горизонтальный автоматы - будет работать только вертильканый)
            {
                if (Map.HaveCrossbow)
                {
                    if (Map.CrossbowsRow[Player.Position.Item1].Count > 0)
                        foreach (var i in Map.CrossbowsRow[Player.Position.Item1])
                            if (RowCanShoot(i, Player.Position.Item2))
                                if (Math.Abs(i - Player.Position.Item2) != 1) // когда расстояние 1 - просто вычитать хп
                                {
                                    Arrow = new Arrow(i * Map.CellSize + 100, Player.Position.Item1 * Map.CellSize + 100);
                                    Arrow.Angle = GetAngleX(Player.Position.Item2, i);
                                    // if (Arrow.Angle != 0)
                                    //     Arrow.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                                    ChangeArrowVelocity( Player.Position.Item1, i);
                                    Invalidate();
                                }
                    if (Map.CrossbowsColumn[Player.Position.Item2].Count > 0)
                        foreach (var i in Map.CrossbowsColumn[Player.Position.Item2])
                            if (ColumnCanShoot(i, Player.Position.Item1))
                                if (Math.Abs(i - Player.Position.Item1) != 1) // когда расстояние 1 - просто вычитать хп
                                {
                                    Arrow = new Arrow(Player.Position.Item2 * Map.CellSize + 100, i * Map.CellSize + 100);
                                    Arrow.Angle = GetAngleY(Player.Position.Item1, i);
                                    // if (Arrow.Angle == 90)
                                    //     Arrow.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                                    // else
                                    //     Arrow.Image.RotateFlip(RotateFlipType.Rotate270FlipY);
                                    ChangeArrowVelocity( i, Player.Position.Item2);
                                    Invalidate();
                                }
                }
            
                Player.MadeMove = false;
            }
        }
    }
}