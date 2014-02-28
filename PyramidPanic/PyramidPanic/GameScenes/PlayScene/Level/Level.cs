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
        private Block[,] blocks;
        private Explorer explorer;
        // In deze list worden de scorpion opgeslagen
        private List<Scorpion> scorpions;
        // In deze list worden de beetles opgeslagen
        private List<Beetle> beetles;
        // In deze list worden de Treasure opgeslagen
        private List<Image> treasures;

        //Propeties
        public int LevelIndex
        {
            get { return this.levelIndex; }
            set { this.levelIndex = value; }
        }

        public List<Scorpion> Scorpions
        {
            get { return this.scorpions; }
        }
        public Block[,] Blocks
        {
            get { return this.blocks; }
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
        public void Update(GameTime gameTime)
        { 
            // we roepen de Update-method aan van de Scorpion-object
            foreach (Scorpion scorpions in this.scorpions)
            {
                scorpions.Update(gameTime);
            }

            // We roepen de Update-method aan van de Beetle-class
            foreach (Beetle beetle in this.beetles)
            {
                beetle.Update(gameTime);
            }


            // we roepen de Update method aan van de explorer zodat hij gaat bewegen
            this.explorer.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {

            // we roepen de draw-method aan van de Scorpion-object
            foreach (Scorpion scorpions in this.scorpions)
            {
                scorpions.Draw(gameTime);
            }

            // we roepen de draw-method aan van de Scorpion-object
            foreach (Beetle beetle in this.beetles)
            {
                beetle.Draw(gameTime);
            }

            // We roepen deDraw-method aan van de treasure-class
            foreach (Image treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

            // Het blocks-array wordt getekend
            for (int row = 0; row < this.blocks.GetLength(1); row++)
            {
                for (int column = 0; column < this.blocks.GetLength(0); column++)
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }

            // de explorer wordt getekend
            this.explorer.Draw(gameTime);
        }

        private void LoadAssets()
        {
            // List voor Scorpion
            this.scorpions = new List<Scorpion>();


            // Maak een list<Beetle> waarin we beetle-objecten in kunnen opslaan
            this.beetles = new List<Beetle>();

            // Maak een list<Image> waarin we de treasures in op kunnen slaan.
            this.treasures = new List<Image>();

            //Deze list van strings slaat elke regel van 0.txt
            this.lines = new List<string>();
            //StreamReader kan lezen wat er in het textobject staat
            StreamReader reader = new StreamReader(this.stream);
            //  lees de eerste regel uit het tekstbestand in
            String line = reader.ReadLine();
            // bepaal hoeveel tekens een regel is(blijkt 20 te zijn)
            int lineWidth = line.Length;
            
            // de while lus leest alle regels uit het tekstbestand en zet deze in de list<String> this.lines
            while (line != null)
            {
                // stop de uitgelezen regel in de List<String> tgis.lines
                this.lines.Add(line);
                // Lees de volgende regel uit het tekstbestand met reader.ReadLine()
                line = reader.ReadLine();

            }
            
            // bepaal uit hoeveel regels het bestand bestaat
            int amountOfLines = this.lines.Count;

            // vernietigt reader object
            reader.Close();

            // vernietigt stream object
            this.stream.Close();

            // dit tweedimensionale array bevat block-object
            this.blocks = new Block[lineWidth, amountOfLines];

            for (int row = 0; row < amountOfLines; row++)
            { 
                for (int column = 0;column < lineWidth; column++)
                {
                    //we lezen iedere letter uit de lines-list uit in een char variable
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] = this.LoadBlock(blockElement, column * 32, row * 32);
                }
            }

            //Manager.level
            
        }

        public Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case 'E':
                    this.explorer = new Explorer(this.game, new Vector2(x + 16, y + 16), 0);
                    return new Block(this.game, @"level\Transparant", new Vector2(x, y), true);
                case 's':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x + 16, y + 16), 1));
                    return new Block(this.game, @"level\Transparant", new Vector2(x, y), true);
                
                case 'b':
                    this.beetles.Add(new Beetle(this.game, new Vector2(x + 16f, y + 16f), 1));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);   
                case 'x':
                    return new Block(this.game, @"level\Block", new Vector2(x, y), true);
                case '.':
                    return new Block(this.game, @"Level\Transparant", new Vector2(x, y), true);
                case 'a':
                    return new Block(this.game, @"Level\Block_vert", new Vector2(x, y), true);
                case 'B':
                    return new Block(this.game, @"Level\Block_hor", new Vector2(x, y), true);
                case 'd':
                    return new Block(this.game, @"Level\Door", new Vector2(x, y), true);
                case 't':
                    return new Block(this.game, @"Level\Treasure1", new Vector2(x, y), true);
                case 'T':
                    return new Block(this.game, @"Level\Treasure2", new Vector2(x, y), true);
                case 'w':
                    return new Block(this.game, @"Level\Wall1", new Vector2(x, y), true);
                case 'W':
                    return new Block(this.game, @"Level\Wall2", new Vector2(x, y), true);
                case 'c':
                    this.treasures.Add(new Image(this.game, @"Treasures\Cat", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);
                case 'A':
                    this.treasures.Add(new Image(this.game, @"Treasures\Ankh", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);
                case 'S':
                    this.treasures.Add(new Image(this.game, @"Treasures\Scarab", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);
                case 'p':
                    this.treasures.Add(new Image(this.game, @"Treasures\potion", new Vector2(x, y)));
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);
                default:
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y), true);
            }
        }
    }
}
