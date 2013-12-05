﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic.GameScenes.HelpScene
{
    public class HelpScene
    {
        //Fields
        private PyramidPanic game;

        //Constructor
        public HelpScene(PyramidPanic game)
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
        public void Draw(GameTime gameTime)
        {
            //Hier word achtergrond getekent
            this.game.GraphicsDevice.Clear(Color.Black);
        }
    }
    
}