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
    public static class Input
    {
        //Fields
        
        //Keyboard voegt ie toe.
        private static KeyboardState keyboardState, oldKeyboardState;
        //Mouse toevoegen
        private static MouseState ms, oms;
        //Gamepad toevoegen
        private static GamePadState gps, ogps;

        // Maak een rectengle aan voor de Mouse 
        private static Rectangle mouseRect;

        //Constructor van een static class mag geen excesmodifier (private, public, protected)
        //krijgen.
        static Input()
        {
            keyboardState = Keyboard.GetState();
            ms = Mouse.GetState();
        }

        public static void Update()
        {
            oldKeyboardState = keyboardState;
            oms = ms;
            keyboardState = Keyboard.GetState();
            ms = Mouse.GetState();
        }


        // Dit is de edgedetector voor een willekeurige toets op het toetsenbord
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (keyboardState.IsKeyDown(key) && oldKeyboardState.IsKeyUp(key));
        }

    }
}

