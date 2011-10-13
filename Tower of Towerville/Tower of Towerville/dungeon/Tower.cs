using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Tower_of_Towerville.entities.components;
using Tower_of_Towerville.entities.actions;
using Microsoft.Xna.Framework.Graphics;

namespace Tower_of_Towerville.dungeon
{
    class Tower
    {
        public int currentFloor;
        public int[][] Floorplan;
        public List<int[][]> Floors = new List<int[][]>();
        public List<Entity> torchList = new List<Entity>();
        private ContentManager Content;
        Dictionary<string, Texture2D> Sprites;
        List<string> planLines = new List<string>();

        public Tower(ContentManager content, Dictionary<string, Texture2D> spriteDict) 
        {
            Content = content;
            Sprites = spriteDict;
            Floorplan = getFloorPlanFromFile();
            addTorches();

            currentFloor = 0;
            addNextFloor();
        }

        public int[][] getCurrentFloor()
        {
            return Floors[currentFloor];
        }

        public void addNextFloor()
        {
            int[][] nextfloor = Floorplan;
            //TODO: add mobs here
            Floors.Add(nextfloor);
        }

        private void addTorches()
        {
            Entity wallTorch = new Entity();
            wallTorch.AddComponent(new Animation(Sprites["wall_torch"], 2, true, SpriteEffects.None));
            wallTorch.AddAction(new NextFrameOfAnimation());
            wallTorch.AddComponent(new Position(4, 2));
            torchList.Add(wallTorch);

            Entity wallTorch2 = new Entity();
            wallTorch2.AddComponent(new Animation(Sprites["wall_torch"], 2, true, SpriteEffects.None));
            wallTorch2.AddAction(new NextFrameOfAnimation());
            wallTorch2.AddComponent(new Position(12, 2));
            torchList.Add(wallTorch2);
        }

        private int[][] getFloorPlanFromFile()
        {
            int[][] floor = new int[17][];
            initFloorArray(floor);

            try
            {
                Stream stream = TitleContainer.OpenStream("dungeon/floor.dat");
                StreamReader sreader = new StreamReader(stream);
                int lineNum = 0;
                while (sreader.Peek() >= 0)
                {
                    fillFloorRow(floor, sreader.ReadLine(), lineNum);
                    lineNum++;
                }
                stream.Close();
            }
            catch (System.IO.FileNotFoundException) {}

            return floor;
        }

        private void fillFloorRow(int[][] floor, string line, int num)
        {
            for (int a = 0; a < line.Length; a++)
                floor[a][num] = (int)Char.GetNumericValue(line[a]);
        }

        private void initFloorArray(int[][] floorplan)
        {
            for (int a = 0; a < floorplan.Length; a++)
            {
                floorplan[a] = new int[17];
            }

            for (int x = 0; x < floorplan.Length; x++)
            {
                for (int y = 0; y < floorplan[x].Length; y++)
                {
                    floorplan[x][y] = 0;
                }
            }
        }
    }
}
