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

    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        // Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;

        //Scene's
        // Maak een variable aan van het type StartScene
        private StartScene startScene; //Camelcase notatie
        // Maak een variable aan van het type PlayScene
        private PlayScene playScene; //Camelcase notatie
        // Maak een variable aan van het type HelpScene
        private HelpScene helpScene; //Camelcase notatie
        // Maak een variable aan van het type GameOverScene
        private GameOverScene gameOverScene; //Camelcase notatie
        // Maak een variable aan van het type EndScene
        private EndScene endScene; //Camelcase notatie

        //Keyboard voegt ie toe.
        private KeyboardState keyboardState, oldKeyboardState;
      

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

            //Scene's
            // Maakt een instantie aan van StartScene
            this.startScene = new StartScene(this);
            // Maakt een instantie aan van playScene
            this.playScene = new PlayScene(this);
            // Maakt een instantie aan van HelpScene
            this.helpScene = new HelpScene(this);
            // Maakt een instantie aan van GameOverScene
            this.gameOverScene = new GameOverScene(this);
            // Maakt een instantie aan van EndScene
            this.endScene = new EndScene(this);

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

            //Scene's
            //Roept de update method aan van startScene
            this.startScene.Update(gameTime);
            //Roept de update method aan van PlayScene
            this.playScene.Update(gameTime);
            //Roept de update method aan van HelpScene
            this.helpScene.Update(gameTime);
            //Roept de update method aan van GameOverScene
            this.gameOverScene.Update(gameTime);
            //Roept de update method aan van EndScene
            this.endScene.Update(gameTime);

            //Voor edgedecetion, zet de huidige keyboardstate in oude keyboardstate.
            this.oldKeyboardState = this.keyboardState;
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //hier roep je begin() method aan
            this.spriteBatch.Begin();

            //Scene's
            //roep de Draw(gameTime) aan van StartScene
            this.startScene.Draw(gameTime);
            //roep de Draw(gameTime) aan van pPlayScene
            this.playScene.Draw(gameTime);
            //roep de Draw(gameTime) aan van StartScene
            this.helpScene.Draw(gameTime);
            //roep de Draw(gameTime) aan van pPlayScene
            this.gameOverScene.Draw(gameTime);
            //roep de Draw(gameTime) aan van StartScene
            this.endScene.Draw(gameTime);

            // hier roep je end() method aan
            this.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
