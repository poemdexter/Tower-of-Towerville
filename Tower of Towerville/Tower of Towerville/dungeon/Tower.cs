using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tower_of_Towerville.framework;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Tower_of_Towerville.dungeon
{
    class Tower
    {
        public int[][] floorplan { get; set; }
        //public List<Entity> torchlist;
        private ContentManager Content;
        List<string> planLines = new List<string>();

        public Tower(ContentManager content) 
        {
            Content = content;
            getFloorPlanFromFile();
        }

        public void getFloorPlanFromFile()
        {
            initFloorArray();

            try
            {
                Stream stream = TitleContainer.OpenStream("dungeon/floor.dat");
                StreamReader sreader = new StreamReader(stream);
                int lineNum = 0;
                while (sreader.Peek() >= 0)
                {
                    fillFloorRow(sreader.ReadLine(), lineNum);
                    lineNum++;
                }
                stream.Close();
            }
            catch (System.IO.FileNotFoundException) {}
        }

        private void fillFloorRow(string line, int num)
        {
            for (int a = 0; a < line.Length; a++)
                floorplan[a][num] = (int)Char.GetNumericValue(line[a]);
        }

        private void initFloorArray()
        {
            floorplan = new int[17][];
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
