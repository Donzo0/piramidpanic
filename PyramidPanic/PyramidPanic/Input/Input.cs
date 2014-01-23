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
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
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

        // Dit is de edgeDetector voor de linker muisknop.
        public static bool EdgeDetectMousePressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed) && (oms.LeftButton == ButtonState.Released);
        }

        // Dit is een leveldetector voor een willerkeurige toets op het toetsenbord word ingedrukt
        public static bool LevelDetectKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }
        // Dit is een leveldetector voor een willerkeurige toets op het toetsenbord word losgelaten
        public static bool LevelDetectKeyUp(Keys key)
        {
            return keyboardState.IsKeyUp(key);
        }


        public static Rectangle MouseRect()
        {
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            return mouseRect;
        }

    }
}

