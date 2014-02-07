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
    public class Block : Image
    {
        //Fields

        //Properties

        //Constructor
        public Block(PyramidPanic game, string pathNameAsset, Vector2 position)
            : base(game, pathNameAsset, position)
        {

        }

        //Update

        //Draw
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}