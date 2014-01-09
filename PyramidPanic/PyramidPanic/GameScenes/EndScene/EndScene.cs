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
    public class EndScene : IGameState
    {
        //Fields
        private PyramidPanic game;
        private int timer = 0;

        //Constructor
        public EndScene(PyramidPanic game)
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
            if (timer >= 50)
            {
                this.game.Exit();
            }
             timer++;
        }
        //Draw
        public void Draw(GameTime gameTime)
        {
            //Hier word achtergrond getekent
            this.game.GraphicsDevice.Clear(Color.PapayaWhip);
        }
    }

}