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
    public class Image
    {
        #region Fields
            //Fields Zijn Private en alleen maar beschikbaar binnen de class
        private Texture2D texture;
        private Rectangle rectangle;
        private PyramidPanic game;
        //We maken hier ee variable aan van het type Color waarin we het een waarde kunnen geven
        private Color color = Color.FloralWhite;
        #endregion

        #region Properties
        public Color Color
        { 
            set { this.color = value; }
        }
        #endregion

        #region Constructor
            //Constructor
            public Image(PyramidPanic game, String pathNameAsset, Vector2 position)
            {
                //Dit is de Constructor van de Image class
                this.game = game;
                this.texture = game.Content.Load<Texture2D>(pathNameAsset);
                this.rectangle = new Rectangle((int)position.X,
                                               (int)position.Y,
                                               this.texture.Width,
                                               this.texture.Height);
            }
        #endregion

        #region Update

        #endregion

        #region Draw
            public void Draw(GameTime gameTime)
            {
                this.game.SpriteBatch.Draw(this.texture, this.rectangle, this.color);
            }
        #endregion
    }
}
