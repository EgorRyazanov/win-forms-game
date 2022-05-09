using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    public enum MapBlocks
    {
        Empty,
        Wall,
        Stone,
        Finish,
        Lava,
        ForcedLava,
        Crossbow,
    }

    public class Map
    {
        public bool isPressed;
        public static Tuple<int, int> pressedPosition;

        public int MapHeigh = 12;
        public int MapWidth = 14;
        public MapBlocks[,] map;
        public static int CellSize = 50;


        public Dictionary<int, List<int>> CrossbowsColumn;
        public Dictionary<int, List<int>> CrossbowsRow;
        public bool HaveCrossbow;
        public static bool ArrowIsMoving; // эта статическая переменная может нарушать работу карты при ее создании

        public Map(int mapHeigh, int mapWidth, MapBlocks[,] mapCopy)
        {
            MapHeigh = mapHeigh;
            MapWidth = mapWidth;
            pressedPosition = new Tuple<int, int>(-1, -1);
            CrossbowsColumn = new Dictionary<int, List<int>>();
            CrossbowsRow = new Dictionary<int, List<int>>();
            ArrowIsMoving = false;
            map = new MapBlocks[MapHeigh, MapWidth];
            for (var row = 0; row < mapHeigh; row++)
                for (var column = 0; column < mapHeigh; column++)
                    map[row, column] = mapCopy[row, column];
            GetCrossbows();
        }
        
        public void GetCrossbows()
        {
            for (var x = 0; x < MapWidth; x++)
                CrossbowsColumn[x] = new List<int>();
            for (var y = 0; y < MapWidth; y++)
                CrossbowsRow[y] = new List<int>();

            for (var x = 0; x < MapWidth; x++)
            for (var y = 0; y < MapHeigh; y++)
                if (map[y, x] == MapBlocks.Crossbow)
                {
                    CrossbowsRow[y].Add(x);
                    CrossbowsColumn[x].Add(y);
                    HaveCrossbow = true;
                }
        }
        public int GetWidth()
        {
            return CellSize * MapWidth;
        }

        public int GetHeigh()
        {
            return CellSize * MapHeigh;
        }

        public bool ArrowCanShootRow(int arrowColumn, int playerColumn, int playerRow)
        {
            if (playerColumn > arrowColumn)
                arrowColumn++;
            var minColumn = Math.Min(playerColumn, arrowColumn);
            var maxColumn = Math.Max(playerColumn, arrowColumn);
            for (var x = minColumn; x < maxColumn; x++)
                if (map[playerRow, x] != MapBlocks.Empty
                    && map[playerRow, x] != MapBlocks.Finish
                    && map[playerRow, x] != MapBlocks.ForcedLava)
                    return false;
            return true;
        }

        public bool ArrowCanShootColumn(int arrowRow, int playerRow, int playerColumn)
        {
            if (playerRow > arrowRow)
                arrowRow++;
            var minRow = Math.Min(playerRow, arrowRow);
            var maxRow = Math.Max(playerRow, arrowRow);
            for (var y = minRow; y < maxRow; y++)
                if (map[y, playerColumn] != MapBlocks.Empty
                    && map[y, playerColumn] != MapBlocks.Finish
                    && map[y, playerColumn] != MapBlocks.ForcedLava)
                    return false;
            return true;
        }

        public bool PlayerCanMove(int row, int column, int playerRow, int playerColumn)
        {
            var minRow = Math.Min(playerRow, row);
            var maxRow = Math.Max(playerRow, row);
            for (var x = minRow; x <= maxRow; x++)
                if (map[x, column] != MapBlocks.Empty
                    && map[x, column] != MapBlocks.Finish
                    && map[x, column] != MapBlocks.ForcedLava)
                    return false;
            var minColumn = Math.Min(playerColumn, column);
            var maxColumn = Math.Max(playerColumn, column);
            for (var y = minColumn; y <= maxColumn; y++)
                if (map[row, y] != MapBlocks.Empty
                    && map[row, y] != MapBlocks.Finish
                    && map[row, y] != MapBlocks.ForcedLava)
                    return false;
            return true;
        }

        public bool MapPressed(int X, int Y, MouseButtons button, bool isMoving)
        {
            return button == MouseButtons.Left &&
                   X - 100 > 0 && X < 100 + GetWidth() &&
                   Y - 100 > 0 && Y < 100 + GetHeigh()
                   && !isMoving;
        }


        public void PlaceThingOnMap(int X, int Y, Player player) //переношу Player - возможна потеря 
        {
            var column = (X - 100) / CellSize;
            var row = (Y - 100) / CellSize;
            if (Math.Abs(player.Position.Item1 - row) +
                Math.Abs(player.Position.Item2 - column) == 1
                && map[row, column] == MapBlocks.Empty
                || map[row, column] == MapBlocks.Lava)
            {
                if (map[row, column] == MapBlocks.Empty)
                    map[row, column] = player.Inventory[player.PressedInventoryPosition];
                else
                    map[row, column] = MapBlocks.ForcedLava;
                player.MadeMove = true;
                player.Inventory[player.PressedInventoryPosition] = MapBlocks.Empty;
                player.IsInventoryPressed = false;
                player.PressedInventoryPosition = -1;
            }
        }

        public  void TakeThingInInventory(int row, int column, Player player) // та же проблема
        {
            if (pressedPosition.Item1 == row &&
                pressedPosition.Item2 == column)
            {
                for (var i = 0; i < player.InventorySize; i++)
                    if (player.Inventory[i] == MapBlocks.Empty)
                    {
                        player.Inventory[i] = map[row, column];
                        map[row, column] = MapBlocks.Empty;
                        player.MadeMove = true;
                        break;
                    }
            }

            pressedPosition = new Tuple<int, int>(-1, -1);
            isPressed = false;
        }
    }
}