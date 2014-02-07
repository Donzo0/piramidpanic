using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PlayScene : IGameState
    {
        //Fields
        private PyramidPanic game;
        private Beetle beetle, beetle1;
        private Scorpion scorpion, scorpion1;
        private Level level;
        private Image bg;

        //Constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }


        //LoadContent
        public void LoadContent()
        {
            this.beetle = new Beetle(this.game, new Vector2(200f, 300f), 2);
            this.beetle1 = new Beetle(this.game, new Vector2(50f, 200f), 2);
            this.scorpion = new Scorpion(this.game, new Vector2(100f, 300f), 2);
            this.scorpion1 = new Scorpion(this.game, new Vector2(200f, 250f), 2);
            this.level = new Level(this.game, 0);
            this.bg = new Image(this.game, @"level\Background2", new Vector2(0f, 0f));
        }


        //Update
        public void Update(GameTime gameTime)
        {
            //Hiermee kan je terug naar het startScherm
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.GameState = this.game.StartScene;
            }
            //Hier worden het upgedate anders doen ze niks
            this.beetle.Update(gameTime);
            this.beetle1.Update(gameTime);
            this.scorpion.Update(gameTime);
            this.scorpion1.Update(gameTime);
            this.level.Update(gameTime);
        }
        
        //Draw
        public void Draw(GameTime gameTime)
        {
            //Achtergrond kleur kan je hier aanpassen
            this.game.GraphicsDevice.Clear(Color.Gainsboro);

            //Hier word alles gedrawt
            this.bg.Draw(gameTime);
            this.beetle.Draw(gameTime);
            this.beetle1.Draw(gameTime);
            this.scorpion.Draw(gameTime);
            this.scorpion1.Draw(gameTime);
            this.level.Draw(gameTime);

        }

    }
}
