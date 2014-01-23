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
    public class Explorer : IAnimatedSprite
    {
        // Fields
        private Vector2 position;
        private int speed = 2;
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private ExplorerIdle idle;
        public ExplorerWalkRight walkright;
        public ExplorerWalkLeft walkleft;
        public ExplorerWalkDown walkdown;
        public ExplorerWalkUp walkup;

        // Properties
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public IEntityState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public ExplorerIdle ExplorerIdle
        {
            get { return this.idle; }
        }
        public ExplorerWalkRight WalkRight
        {
            get { return this.walkright; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkleft; }
        }
        public ExplorerWalkDown WalkDown
        {
            get { return this.walkdown; }
        }
        public ExplorerWalkUp WalkUp
        {
            get { return this.walkup; }
        }

        // Maak de constructor
        public Explorer(PyramidPanic game, Vector2 position, int Speed)
        {
            this.position = position;
            this.game = game;
            this.texture = this.game.Content.Load<Texture2D>(@"explorer\Explorer");
            this.speed = speed;
            this.idle = new ExplorerIdle(this);
            this.walkright = new ExplorerWalkRight(this);
            this.walkleft = new ExplorerWalkLeft(this);
            this.walkdown = new ExplorerWalkDown(this);
            this.walkup = new ExplorerWalkUp(this);
            this.state = this.idle;

        }

        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
