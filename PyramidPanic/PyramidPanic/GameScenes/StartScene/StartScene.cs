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
    public class StartScene : IGameState
    {
        //Fields
        private PyramidPanic game;

        // Fields voor de startScene
        private Image background,backTitle;

        //Constructor
        public StartScene(PyramidPanic game)
        {

            this.game = game;
            this.Initialize();
        }
        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }
        //LoadContent
        public void LoadContent()
        {
            this.background = new Image(this.game,@"menu\Background", new Vector2(0f, 0f));
            this.backTitle = new Image(this.game, @"menu\Title", new Vector2(100f, 30f));
        }
        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.game.GameState = this.game.PlayScene;
            }
        }
        //Draw
        public void Draw(GameTime gameTime)
        {
            //Hier word achtergrond getekent
            this.game.GraphicsDevice.Clear(Color.Black);
            this.background.Draw(gameTime);
            this.backTitle.Draw(gameTime);
        }
    }
}
