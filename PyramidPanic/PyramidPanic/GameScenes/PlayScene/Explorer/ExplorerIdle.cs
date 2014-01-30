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
    // Dit is de toestands class van de Beetle    
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        // Fields
        private Explorer explorer;
        private Vector2 velocity;

        //propety Hier kan je waardes veranderen en mee geven
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }

        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Explorer als argument
        public ExplorerIdle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            this.effect = SpriteEffects.None;
            this.imageNumber = 1;
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            // Hier worden state gegeven aan een bepaalde key als De key Down is, ook de Initialize van de WalkClasses van expolorer worden geimplemeerd
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
                this.explorer.WalkRight.Initialize();
            }
            if (Input.LevelDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
                this.explorer.WalkLeft.Initialize();
            }
            if (Input.LevelDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.WalkDown;
                this.explorer.WalkDown.Initialize();
            }
            if (Input.EdgeDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.WalkUp;
                this.explorer.WalkUp.Initialize();
            }

        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
