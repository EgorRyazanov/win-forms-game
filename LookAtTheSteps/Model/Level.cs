using System;
using System.Collections.Generic;

namespace LookAtTheSteps
{
    public static class Level
    {

        private static Tuple<Map, Player> FirstLevel  = new Tuple<Map, Player>(
            new Map(new[,]
            {
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, 
                    MapBlocks.Gun, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Gun,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Finish, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },}), new Player(Form1.WidthBorder + Map.CellSize * 7, Form1.HeightBorder + (Map.MapHeigh - 1) * Map.CellSize,  4, 14,Form1.WidthBorder, Form1.HeightBorder));

        private static Tuple<Map, Player> SecondLevel = new Tuple<Map, Player>(
            new Map(new[,]
            {
                {
                    MapBlocks.Finish, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Lava
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Empty,
                    MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Stone,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Lava
                },
                {
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Empty,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Stone,
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Stone,
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Lava,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Empty
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Stone,
                    MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Stone
                },
            }), new Player(Form1.WidthBorder + Map.CellSize * 7, Form1.HeightBorder + (Map.MapHeigh - 1) * Map.CellSize, 1, 17, 
                Form1.WidthBorder, Form1.HeightBorder));
        
        private static Tuple<Map, Player> ThirdLevel = new Tuple<Map, Player>(
            new Map(new[,]
            {
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Gun, MapBlocks.Wall, MapBlocks.Gun, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Gun, MapBlocks.Lava, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Gun, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall
                },
                {
                    MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Stone, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Lava, MapBlocks.Lava,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Lava
                },
                {
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Lava,
                    MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Lava, MapBlocks.Wall, MapBlocks.Empty,
                    MapBlocks.Wall, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Empty
                },
                {
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Wall, MapBlocks.Empty,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Stone, MapBlocks.Wall,
                    MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Empty, MapBlocks.Finish
                },
                {
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall,
                    MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall, MapBlocks.Wall
                },
            }), new Player(Form1.WidthBorder, Form1.HeightBorder + Map.CellSize * 5, 11, 22,Form1.WidthBorder, Form1.HeightBorder));
        
        
        public static List<Tuple<Map, Player>> Levels = new List<Tuple<Map, Player>>( ){FirstLevel, SecondLevel, ThirdLevel};
        
    }
}