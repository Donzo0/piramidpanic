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
    // Dit is de toestands class van de Beetle    
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        // Fields
        private Explorer explorer;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Explorer als argument
        public ExplorerWalkLeft(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (Input.LevelDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerIdle.Initialize();
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.ExplorerIdle.Rotation = 0f;
            }
            this.explorer.Position -= this.velocity;
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            //zorgt voor animatie
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
