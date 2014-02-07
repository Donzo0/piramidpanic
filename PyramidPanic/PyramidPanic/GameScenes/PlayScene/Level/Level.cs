using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level
    {
        //Fields
        private int levelIndex;
        private PyramidPanic game;
        private Stream stream;
        private List<String> lines;

        //Propeties
        public int LevelIndex
        {
            get { return this.levelIndex; }
            set { this.levelIndex = value; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        //constuctor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex = levelIndex;

            //Laad het textbestand met behulp van stream object
            this.stream = TitleContainer.OpenStream(@"Content\LevelE\0.txt");
            this.LoadAssets();
        }
        //Update

        //Draw

        private void LoadAssets()
        {
            //Deze list van strings slaat elke regel van 0.txt
            this.lines = new List<string>();
            //StreamReader kan lezen wat er in het textobject staat
            StreamReader reader = new StreamReader(this.stream);
            //  lees de eerste regel uit het tekstbestand in
            String line = reader.ReadLine();
            // bepaal hoeveel tekens een regel is(blijkt 20 te zijn)
            int lineWidth = line.Length;

            // de while lus leest alle regels uit het tekstbestand en zet deze in de list<String> this.lines
            while (lines != null)
            {
                // stop de uitgelezen regel in de List<String> tgis.lines
                this.lines.Add(line);
                // Lees de volgende regel uit het tekstbestand met reader.ReadLine()
                line = reader.ReadLine();

            }

            // bepaal uit hoeveel regels het bestand bestaat
            int amountOfLines = this.lines.Count;

            foreach (String lineInText in this.lines)
            {
                Console.WriteLine(amountOfLines);
            }
            Console.WriteLine(amountOfLines);

        }
    }
}
