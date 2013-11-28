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

namespace PyramidPanic
{
    public class StartScene
    {
        //Fields
        public Texture2D background;
        public SpriteBatch spriteBatch;

        //Constructor
        public StartScene()
        { 

        }
        //Initialize
        public void Initialize()
        {
        }
        //LoadContent
        public void LoadContent()
        { 
        }
        //Update
        public void Update()
        { 
        }
        //Draw
        public void Draw(ContentManager Content, SpriteBatch spriteBatch)
        {
            //Hier word achtergrond getekent
            this.spriteBatch.Draw(Content.Load<Texture2D>(@"menu/background"), new Rectangle(0, 0, 640, 480), Color.FloralWhite);
        }
    }
}
