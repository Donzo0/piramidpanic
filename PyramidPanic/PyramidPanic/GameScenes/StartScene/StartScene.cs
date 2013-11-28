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
    public class StartScene
    {
        //Fields
        private PyramidPanic game;
        private Texture2D background;
        private SpriteBatch spriteBatch;

        //Constructor
        public StartScene(PyramidPanic game)
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

        }
        //Update
        public void Update(GameTime gameTime)
        { 
        }
        //Draw
        public void Draw(ContentManager Content, SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Hier word achtergrond getekent
            this.spriteBatch.Draw(Content.Load<Texture2D>(@"menu/background"), new Rectangle(0, 0, 640, 480), Color.FloralWhite);
        }
    }
}
