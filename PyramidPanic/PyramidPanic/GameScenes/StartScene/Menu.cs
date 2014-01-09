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
        //Hier word ene nieuw soort variable gedefineerd. Het is een enum.
        private enum Button { Start, Load, Help, Score, Quit }
        //Hier word de variable aangemaakt van button. deze variable kan maae 5 waardes aannemen.
        private Button buttonState = Button.Start;
        //Game variable
        private PyramidPanic game;
        //Button Fiels
        private Image startButton, loadButton, helpButton, scoreButton, quitButton;
        // int voor menu
        private int top = 433, left = 10, space = 130;
        //List object om buttons in te stoppen
        private List<Image> buttonList;
        //Color voor button
        private Color color = Color.Gold;
        //Keyboard voegt ie toe.
        private KeyboardState keyboardState, oldKeyboardState;
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
            this.loadButton = new Image(this.game, @"menu\Button_load", new Vector2(this.left +  this.space, this.top));
            this.helpButton = new Image(this.game, @"menu\Button_help", new Vector2(this.left + 2 * this.space, this.top));
            this.scoreButton = new Image(this.game, @"menu\Button_scores", new Vector2(this.left + 3 * this.space, this.top));
            this.quitButton = new Image(this.game, @"menu\Button_quit", new Vector2(this.left + 4 * this.space, this.top));
           // this.startButton
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
        public void Update(GameTime gameTime)
        {
            //MouseDetection Voor StartButton
            if (this.startButton.Rectangle.Intersects(Input.MouseRect()))
            {
                //Als de Linker muis word ingedrukt
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.PlayScene;
                }
                //Geeft aan welke button state het is
                this.buttonState = Button.Start;
                //Verwijst naar ChangeButtonColorToNormal
                this.ChangeButtonColorToNormal();
            }

            //MouseDetection Voor loadButton
            if (this.loadButton.Rectangle.Intersects(Input.MouseRect()))
            {
                //Als de Linker muis word ingedrukt
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.LoadScene;
                }
                //Geeft aan welke button state het is
                this.buttonState = Button.Load;
                //Verwijst naar ChangeButtonColorToNormal
                this.ChangeButtonColorToNormal();
            }

            //MouseDetection Voor HelpButton
            if (this.helpButton.Rectangle.Intersects(Input.MouseRect()))
            {   
                //Als de Linker muis word ingedrukt
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.HelpScene;
                }
                //Geeft aan welke button state het is
                this.buttonState = Button.Help;
                //Verwijst naar ChangeButtonColorToNormal
                this.ChangeButtonColorToNormal();
            }

            //MouseDetection Voor ScoreButton
            if (this.scoreButton.Rectangle.Intersects(Input.MouseRect()))
            {
                //Als de Linker muis word ingedrukt
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.ScoreScene;
                }
                //Geeft aan welke button state het is
                this.buttonState = Button.Score;
                //Verwijst naar ChangeButtonColorToNormal
                this.ChangeButtonColorToNormal();
            }

            //MouseDetection Voor quitButton
            if (this.quitButton.Rectangle.Intersects(Input.MouseRect()))
            {
                //Als de Linker muis word ingedrukt
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = this.game.EndScene;
                }
                //Geeft aan welke button state het is
                this.buttonState = Button.Quit;
                //Verwijst naar ChangeButtonColorToNormal
                this.ChangeButtonColorToNormal();
            }

             // Als de right knop wordt ingedrukt....
             if (Input.EdgeDetectKeyDown(Keys.Right))
                {
                    // en de buttonState is kleiner dan Button.quit
                    if (this.buttonState < Button.Quit)
                    {
                        // Zet alle knopkleuren op wit
                        foreach (Image button in this.buttonList)
                        {
                            button.Color = Color.White;
                        }
                        // Verhoog de buttonState met 1
                        this.buttonState++;
                    }
                }
            
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                // Als de buttonState groter is dan Button.Start
                if (this.buttonState > Button.Start)
                {
                    // Zet alle knopkleuren op wit
                    foreach (Image button in this.buttonList)
                    {
                        button.Color = Color.White;
                    }
                    // Verlaagd de buttonState met 1
                    this.buttonState--;
                }
            }

            // Maak een switch-case instructie voor het evalueren van de variabele this.buttonState
            switch (this.buttonState)
            {
                case Button.Start:
                    this.startButton.Color = this.color;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
                case Button.Load:
                    this.loadButton.Color = this.color;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.LoadScene;
                    }
                    break;
                case Button.Help:
                    this.helpButton.Color = this.color;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.HelpScene;
                    }
                    break;
                case Button.Score:
                    this.scoreButton.Color = this.color;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.ScoreScene;
                    }
                    break;
                case Button.Quit:
                    this.quitButton.Color = this.color;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.EndScene;
                    }
                    break;
                default:
                    break;
            }
            
        }
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

        //HelperMethod
        private void ChangeButtonColorToNormal()
        {
            foreach (Image button in this.buttonList)
            {
                button.Color = Color.White;
            }
        }
    }
}
