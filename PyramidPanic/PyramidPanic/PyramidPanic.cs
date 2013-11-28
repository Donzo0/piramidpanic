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
    private enum GameState
    { Start, Play }

    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        // Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;

        //Keyboard voegt ie toe.
        private KeyboardState keyboardState, oldKeyboardState;
        //GameState standaard
        private GameState state = GameState.Start;
        

        //Constructor
        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Voegt title toe
            this.Window.Title = "Pyramid Panic";

            // Maak Mouse viasble
            IsMouseVisible = true;

            // Veranderd de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            // veranderd de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            // past te veranderingen toe van het canvas
            this.graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.background = Content.Load<Texture2D>(@"menu/Background");
            
        }


        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            //Kijkt iedere update of de toetsebord word gebruikt
            this.keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

            //Voor edgedecetion, zet de huidige keyboardstate in oude keyboardstate.
            this.oldKeyboardState = this.keyboardState;
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.background,new Rectangle(0,0,640,480), Color.FloralWhite);
            this.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
