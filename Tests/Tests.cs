using System;
using LookAtTheSteps;
using NUnit.Framework;

namespace Tests
{
    public enum MouseClicks
    {
        Left,
        Right
    }

    [TestFixture]
    public class Tests
    {
        private int WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
        private int HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
        private Map Map;
        private Player Player;
        private bool IsWin;
        private bool IsLose;
        
        
        [Test]
        public void MoveHorizontallyWithoutObstacles()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(11, 6);
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(new Tuple<int, int>(11, 6), Player.Position);
        }
        
        
        [Test]
        public void MoveVerticallyWithoutObstacles()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[0].Item2.StartHealth, Level.Levels[0].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            MoveOnMouse(990, 750, MouseClicks.Left);
            Assert.AreEqual(new Tuple<int, int>(10, 7), Player.Position);
        }
        
        [Test]
        public void DontMoveOnWall()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[0].Item2.StartHealth, Level.Levels[0].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            Map.map[10, 7] = MapBlocks.Wall; 
            MoveOnMouse(990, 750, MouseClicks.Left);
            Assert.AreEqual(new Tuple<int, int>(11, 7), Player.Position);
        }
        
        [Test]
        public void DontMoveOnLava()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(11, 6);
            Map.map[11, 6] = MapBlocks.Lava; 
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(new Tuple<int, int>(11, 7), Player.Position);
        }
        
        [Test]
        public void DontMoveDiagonally()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 6);
            MoveOnMouse(920, 750, MouseClicks.Left);
            Assert.AreEqual(new Tuple<int, int>(11, 7), Player.Position);
        }
        
        [Test]
        public void DontInteractWithTheFieldOutsideTheMap()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            MoveOnMouse(1, 1, MouseClicks.Left);
            Assert.AreEqual(false, Map.IsPressed);
        }
        
        [Test]
        public void TakeStoneInInventory()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(11, 6);
            Map.map[11, 6] = MapBlocks.Stone;
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(MapBlocks.Stone, Player.Inventory[0]);
        }
        
        
        [Test]
        public void PlaceStoneOnLava()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.map[11, 6] = MapBlocks.Lava;
            Player.Inventory[0] = MapBlocks.Stone;
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = 0;
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(MapBlocks.ForcedLava, Map.map[11, 6]);
        }
        
        [Test]
        public void PlayerTakeDamage()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[0].Item2.StartHealth, Level.Levels[0].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            Map.map[8, 7] = MapBlocks.Gun;
            Map.GetGuns();
            MoveOnMouse(990, 750, MouseClicks.Left);
            DamagePlayer();
            Assert.AreEqual(Level.Levels[0].Item2.StartHealth - 1, Player.Health);
        }
        
        [Test]
        public void StepsDecreaseWhenPlayerMadeMove()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[0].Item2.StartHealth, Level.Levels[0].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            MoveOnMouse(990, 750, MouseClicks.Left);
            Assert.AreEqual(Level.Levels[0].Item2.StartMoves - 1, Player.Moves);
        }
        
        [Test]
        public void StepsDecreaseWhenPlayerTookInInventory()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(11, 6);
            Map.map[11, 6] = MapBlocks.Stone;
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(Level.Levels[1].Item2.StartMoves -1 , Player.Moves);
        }
        
        [Test]
        public void StepsDecreaseWhenPlayerPlacedStone()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.map[11, 6] = MapBlocks.Lava;
            Player.Inventory[0] = MapBlocks.Stone;
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = 0;
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(Level.Levels[1].Item2.StartMoves - 1, Player.Moves);
        }
        
        [Test]
        public void PlayerWinWhenComesToFinish()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[1].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[1].Item2.StartHealth, Level.Levels[1].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(11, 6);
            Map.map[11, 6] = MapBlocks.Finish;
            MoveOnMouse(920, 800, MouseClicks.Left);
            Assert.AreEqual(true, IsWin);
        }
        
        [Test]
        public void PlayerLoseWhenStepsOver()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                Level.Levels[0].Item2.StartHealth, 1, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            MoveOnMouse(990, 750, MouseClicks.Left);
            Assert.AreEqual(true, IsLose);
        }
        
        [Test]
        public void PlayerLoseWhenTakesDamage()
        {
            WidthBorder = (1920 - Map.CellSize * Map.MapWidth) / 2;
            HeightBorder = (1080 - Map.CellSize * Map.MapHeigh) / 2;
            Map = new Map(Map.CopyMap(Level.Levels[0].Item1.map));
            Player = new Player (7 * Map.CellSize + WidthBorder, HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  
                1, Level.Levels[0].Item2.StartMoves, WidthBorder, HeightBorder);
            Map.IsPressed = true;
            Map.PressedPosition = new Tuple<int, int>(10, 7);
            Map.map[8, 7] = MapBlocks.Gun;
            Map.GetGuns();
            MoveOnMouse(990, 750, MouseClicks.Left);
            DamagePlayer();
            Assert.AreEqual(true, IsLose);
        }

        public void ClickOnInventory(int x)
        {
            var column = (x - WidthBorder)/ Map.CellSize;
            Player.IsInventoryPressed = true;
            Player.PressedInventoryPosition = column - Map.MapWidth/2 + 1;
        }
        
        public bool PlayerInventoryPressed(int x, int y, MouseClicks button)
        {
            return button == MouseClicks.Left &&
                   x - WidthBorder - Map.CellSize * (Map.MapWidth / 2 - 1) > 0
                   && x < WidthBorder + Map.CellSize * (Map.MapWidth / 2 - 1 + Player.InventorySize) &&
                   y - HeightBorder - Map.CellSize * (Map.MapHeigh + 1) > 0
                   && y < HeightBorder + Map.CellSize * (Map.MapHeigh + 2)
                   && !Player.IsMoving;
        }
        
        public bool MapPressed(int x, int y, MouseClicks button, bool isMoving)
        {
            return button == MouseClicks.Left &&
                   x - WidthBorder > 0 && x < WidthBorder + Map.GetWidth() &&
                   y - HeightBorder > 0 && y < HeightBorder + Map.GetHeigh()
                   && !isMoving;
        }
        
        public void MoveOnMouse(int x, int y, MouseClicks button)
        {
            if (MapPressed(x, y, button, Player.IsMoving) && !Player.IsInventoryPressed 
                                                                    && Player.IsHaveSteps
                                                                    && Player.IsAlive) // пофиксить момент, когда ты можешь скрыться от стрелы 
            {
                var column = (x - WidthBorder)/ Map.CellSize;
                var row = (y - HeightBorder)/ Map.CellSize;
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
                                Player.Position = new Tuple<int, int>(row, column);
                                Player.IsMoving = false;
                                Player.MadeMove = true;
                                Player.Moves -= 1;
                                if (Map.map[Player.Position.Item1, Player.Position.Item2] == MapBlocks.Finish)
                                    IsWin = true;
                                if (Player.Moves == 0 && !Player.IsMoving) 
                                    Player.IsHaveSteps = false;
                            }

                            Map.PressedPosition = new Tuple<int, int>(-1, -1);
                            Map.IsPressed = false;
                        }
                        else
                        {
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
                        }
                        else
                        {
                            Map.IsPressed = true;
                            Map.PressedPosition = new Tuple<int, int>(row, column);
                        }
                    }

                    if (!Player.IsHaveSteps)
                        IsLose = true;
                }
            }
            

            if (Player.IsInventoryPressed && MapPressed(x, y, button, Player.IsMoving)
            && Player.IsHaveSteps && Player.IsAlive)
            {
                Map.PlaceThingOnMap(x, y, Player, WidthBorder, HeightBorder);
            }
            
            if (Player.IsInventoryPressed && Player.IsHaveSteps && Player.IsAlive) //ситуация когда ты нечаянно нажал на инвентарь, нужно убрать свой ход
                Player.IsInventoryPressed = false;

            if (PlayerInventoryPressed(x, y, button) && !Map.IsPressed && !Map.IsProejectileFlying &&
                Player.IsHaveSteps && Player.IsAlive)
            {
                ClickOnInventory(x);
            } // берем вещь из инвентаря
        }

        public void DamagePlayer()
        {
            if (Player.MadeMove && Map.HaveGuns)
            { 
                if (Map.GunsRow[Player.Position.Item1].Count > 0)
                {
                    foreach (var i in Map.GunsRow[Player.Position.Item1])
                        if (Map.ArrowCanShootRow(i, Player.Position.Item2, Player.Position.Item1))
                        {
                            if (Player.Health > 0)
                                Player.Health -= 1;
                        }
                }
                           
                if (Map.GunsColumn[Player.Position.Item2].Count > 0)
                {
                    foreach (var i in Map.GunsColumn[Player.Position.Item2])
                        if (Map.ArrowCanShootColumn(i, Player.Position.Item1, Player.Position.Item2))
                        {
                            if (Player.Health > 0)
                                Player.Health -= 1;
                        }
                }
                Player.MadeMove = false;
                if (Player.Health == 0)
                    Player.IsAlive = false;
                if (!Player.IsAlive)
                    IsLose = true;
            }
        }
    }
}