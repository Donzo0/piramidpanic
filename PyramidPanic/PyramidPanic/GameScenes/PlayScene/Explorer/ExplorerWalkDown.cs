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
    public class ExplorerWalkDown : AnimatedSprite, IEntityState
    {
        // Fields
        private Explorer explorer;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Explorer als argument
        public ExplorerWalkDown(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.velocity = new Vector2(0f, this.explorer.Speed);
            // Hier word een sprite effect waarmee je de spritebatch kan spiegelen
            this.effect = SpriteEffects.None;
            //Hier geef je rotarion een waarde in contructor
            this.rotation = (float)Math.PI / 2;
        }

        public void Initialize()
        {
            // Met deze methode synchroniseren we de positie van de explorer zodat deze op de juiste positie start nadat hij van toestand gewisselt is.
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            //ifstate voor keydetectUp voor toets down
            if (Input.LevelDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                //hier word de Initialize van ExplorerIdle opgehaald
                this.explorer.ExplorerIdle.Initialize();
                // Hier word een sprite effect waarmee je de spritebatch kan spiegelen
                this.explorer.ExplorerIdle.Effect = SpriteEffects.None;
                //Hier word de rotatie waar gemaakt
                this.explorer.ExplorerIdle.Rotation = (float)Math.PI / 2;
            }
            // Hier word er mogelijk gemaakt dat je naar beneden kan lopen
            this.explorer.Position += this.velocity;
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
