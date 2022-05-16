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
        Gun,
    }

    public class Map
    {
        public bool IsPressed;
        public static Tuple<int, int> PressedPosition;

        public static readonly int MapHeigh = 12;
        public static readonly int MapWidth = 14;
        public MapBlocks[,] map;
        public static int CellSize = 50;


        public Dictionary<int, List<int>> GunsColumn;
        public Dictionary<int, List<int>> GunsRow;
        public bool HaveGuns;
        public static bool IsProejectileFlying;

        public Map(MapBlocks[,] mapCopy)
        {
            PressedPosition = new Tuple<int, int>(-1, -1);
            GunsColumn = new Dictionary<int, List<int>>();
            GunsRow = new Dictionary<int, List<int>>();
            IsProejectileFlying = false;
            map = new MapBlocks[MapHeigh, MapWidth];
            IsPressed = false;
            for (var row = 0; row < MapHeigh; row++)
                for (var column = 0; column < MapWidth; column++)
                    map[row, column] = mapCopy[row, column];
            GetGuns();
        }
        
        public void GetGuns()
        {
            for (var x = 0; x < MapWidth; x++)
                GunsColumn[x] = new List<int>();
            for (var y = 0; y < MapWidth; y++)
                GunsRow[y] = new List<int>();

            for (var x = 0; x < MapWidth; x++)
                for (var y = 0; y < MapHeigh; y++)
                    if (map[y, x] == MapBlocks.Gun)
                    {
                        GunsRow[y].Add(x);
                        GunsColumn[x].Add(y);
                        HaveGuns = true;
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

        public static MapBlocks[,] CopyMap(MapBlocks[,] map)
        {
            var newMap = new MapBlocks[MapHeigh, MapWidth];
            for (var y = 0; y < MapHeigh; y++)
                for (var x = 0; x < MapWidth; x++)
                    newMap[y, x] = map[y, x];
            return newMap;
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
                    && map[playerRow, x] != MapBlocks.ForcedLava
                    && map[playerRow, x] != MapBlocks.Lava)
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
                    && map[y, playerColumn] != MapBlocks.ForcedLava
                    && map[y, playerColumn] != MapBlocks.Lava)
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

        public bool MapPressed(int x, int y, MouseButtons button, bool isMoving)
        {
            return button == MouseButtons.Left &&
                   x - Form1.WidthBorder > 0 && x < Form1.WidthBorder + GetWidth() &&
                   y - Form1.HeightBorder > 0 && y < Form1.HeightBorder + GetHeigh()
                   && !isMoving;
        }


        public void PlaceThingOnMap(int x, int y, Player player, int widthBorder, int heightBorder)  
        {
            var column = (x - widthBorder) / CellSize;
            var row = (y - heightBorder) / CellSize;
            if (Math.Abs(player.Position.Item1 - row) +
                Math.Abs(player.Position.Item2 - column) == 1
                && map[row, column] == MapBlocks.Empty
                || map[row, column] == MapBlocks.Lava)
            {
                if (map[row, column] == MapBlocks.Empty)
                    map[row, column] = player.Inventory[player.PressedInventoryPosition];
                else
                    map[row, column] = MapBlocks.ForcedLava;
                player.Moves -= 1;
                player.MadeMove = true;
                player.Inventory[player.PressedInventoryPosition] = MapBlocks.Empty;
                player.IsInventoryPressed = false;
                player.PressedInventoryPosition = -1;
            }
        }

        public  void TakeThingInInventory(int row, int column, Player player) 
        {
            if (PressedPosition.Item1 == row &&
                PressedPosition.Item2 == column)
            {
                for (var i = 0; i < Player.InventorySize; i++)
                    if (player.Inventory[i] == MapBlocks.Empty)
                    {
                        player.Inventory[i] = map[row, column];
                        map[row, column] = MapBlocks.Empty;
                        player.MadeMove = true;
                        break;
                    }
            }

            PressedPosition = new Tuple<int, int>(-1, -1);
            IsPressed = false;
        }
    }
}