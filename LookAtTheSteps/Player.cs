using System;
using System.Drawing;

namespace LookAtTheSteps
{
    public class Player
    {
        public int X;
        public int Y;
        public int DirX;
        public int DirY;
        public bool IsMoving = false;
        public Tuple<int, int> Position;
        public bool MadeMove;

        public Image Sprite;
        public int Size;

        public int Health;
        public int Moves;
        public int InventorySize;
        public MapBlocks[] Inventory;
        public bool IsInventoryPressed = false;
        public int PressedInventoryPosition = -1;

        public int PurposeX;
        public int PurposeY;


        public Player(int x, int y, Image sprite, int inventorySize, int health, int moves) // инвентарь должен быть меньше ширины карты
        {
            X = x;
            Y = y;
            Sprite = sprite;
            Size = 60;
            Position = new Tuple<int, int>(0, 0);
            InventorySize = inventorySize;
            Inventory = new MapBlocks[InventorySize];
            Health = health;
            Moves = moves;
        }

        
        public void Init()
        {
            Inventory = GetInventory();
        }

        public bool IsInventoryFull()
        {
            for (var i = 0; i < InventorySize; i++)
                if (Inventory[i] == 0)
                    return false;
            return true;

        }

        public MapBlocks[] GetInventory()
        {
            MapBlocks[] array = new MapBlocks[InventorySize];
            for (var i = 0; i < InventorySize; i++)
                array[i] = MapBlocks.Empty;
            return array;
        }
        
        public void ChangePlayerVelocity(int row, int column)
        {
            IsMoving = true;
            if (Position.Item2 - column < 0)
                DirX = 5;
            if (Position.Item2 - column > 0)
                DirX = -5;
            if (Position.Item1 - row < 0)
                DirY = 5;
            if (Position.Item1 - row > 0)
                DirY = -5;
            PurposeX = column * Map.CellSize + 100;
            PurposeY = row * Map.CellSize + 100;
            Position = new Tuple<int, int>(row, column);
        }

        public void Move()
        {
            X += DirX;
            Y += DirY;
        }
    }
}