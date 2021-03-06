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
            // Hier word een sprite effect waarmee je de spritebatch kan spiegelen
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            // Hier word er mogelijk gemaakt dat je naar left kan lopen
            this.explorer.Position -= this.velocity;
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;

            // hier word mogelijk gemaakt dat hij niet door de rand heen kan lopen en niet naar de verkeerde kant kijkt
            if (this.explorer.Position.X < 16)
            {
                this.explorer.Position += this.velocity;
                this.explorer.State = this.explorer.IdleWalk;
                this.explorer.IdleWalk.Initialize();
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.IdleWalk.Rotation = 0f;
            }

            //ifstate voor keydetectUp voor toets left
            if (Input.LevelDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                //hier word de Initialize van ExplorerIdle opgehaald
                this.explorer.ExplorerIdle.Initialize();
                // Hier word een sprite effect waarmee je de spritebatch kan spiegelen
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                //Hier word de rotatie waar gemaakt maar hier word er geen gebruik van gemaakt
                this.explorer.ExplorerIdle.Rotation = 0f;
            }
            //zorgt voor animatie
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
