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
    public interface IGameState
    {
        // Van de GameState Variable in de class pyramidpanic willen aanroepen. alleen als je het in de interface aangeeft
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}
