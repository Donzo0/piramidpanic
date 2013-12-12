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
    public class Menu
    {
        #region Fiels
        private PyramidPanic game;
        //Button Fiels
        private Image startButton, loadButton, helpButton, scoreButton, quitButton;
        // int voor menu
        private int top = 433, left = 10, space = 130;
        //List object om buttons in te stoppen
        private List<Image> buttonList;
        #endregion

        #region Properties
        
        #endregion

        #region Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }
        #endregion

        #region Initialize
        public void Initialize()
        {
            this.LoadContent();
        }
        #endregion

        #region LoadContent
        public void LoadContent()
        {

            //Button worden hier aangemaakt
            this.startButton = new Image(this.game, @"menu\Button_start", new Vector2(this.left, this.top));
            this.loadButton = new Image(this.game, @"menu\Button_load", new Vector2(this.left + this.space, this.top));
            this.helpButton = new Image(this.game, @"menu\Button_help", new Vector2(this.left + 2 * this.space, this.top));
            this.scoreButton = new Image(this.game, @"menu\Button_scores", new Vector2(this.left + 3 * this.space, this.top));
            this.quitButton = new Image(this.game, @"menu\Button_quit", new Vector2(this.left + 4 * this.space, this.top));

            //Maak een nieuw object van he ttype List <Image>
            this.buttonList = new List<Image>();
            // Voeg een Image object toe aan de List<Image> Genaamd this.buttonList
            this.buttonList.Add(this.startButton);
            this.buttonList.Add(this.loadButton);
            this.buttonList.Add(this.helpButton);
            this.buttonList.Add(this.scoreButton);
            this.buttonList.Add(this.quitButton);
        }
        #endregion

        #region Update

        #endregion

        #region Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image button in this.buttonList)
            {
                button.Draw(gameTime);
            }
        }
        #endregion
    }
}
