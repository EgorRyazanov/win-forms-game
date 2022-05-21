using System;
using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    public class Player
    {
        public int X;
        public int Y;
        public int StartX;
        public int StartY;
        public int StartHealth;
        public int StartMoves;
        public int DirX;
        public int DirY;
        public bool IsMoving;
        public Tuple<int, int> Position;
        public bool MadeMove;
        

        public int Health;
        public int Moves;
        public static int InventorySize = 2;
        public MapBlocks[] Inventory;
        public bool IsInventoryPressed;
        public bool IsAlive;
        public bool IsHaveSteps;
        public int PressedInventoryPosition = -1;

        public int PurposeX;
        public int PurposeY;


        public Player(int x, int y, int health, int moves, int widthBorder, int heightBorder)
        {
            X = x;
            Y = y;
            StartX = X;
            StartY = Y;
            Position = new Tuple<int, int>((y - heightBorder)/Map.CellSize, (x - widthBorder)/Map.CellSize); 
            Inventory = new MapBlocks[InventorySize];
            Health = health;
            StartHealth = Health;
            Moves = moves;
            StartMoves = Moves;
            MadeMove = false;
            IsMoving = false;
            IsInventoryPressed = false;
            IsAlive = true;
            IsHaveSteps = true;
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
            {
                if (Form1.IsRotated)
                {
                    Form1.IsRotated = false;
                    Drawing.Knight.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                DirX = 5;
            }

            if (Position.Item2 - column > 0)
            {
                if (!Form1.IsRotated)
                {
                    Form1.IsRotated = true;
                    Drawing.Knight.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                DirX = -5;
            }
            if (Position.Item1 - row < 0)
                DirY = 5;
            if (Position.Item1 - row > 0)
                DirY = -5;
            PurposeX = column * Map.CellSize + Form1.WidthBorder;
            PurposeY = row * Map.CellSize + Form1.HeightBorder;
            Position = new Tuple<int, int>(row, column);
        }

        public void Move()
        {
            X += DirX;
            Y += DirY;
        }
    }
}