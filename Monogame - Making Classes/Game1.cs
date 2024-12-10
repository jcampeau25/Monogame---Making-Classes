using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame___Making_Classes
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Random generator;

        List<Tribble>tribbles;
        List<Texture2D>tribbleTextures;

        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleOrangeTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = window.Height;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            tribbles = new List<Tribble>();
            tribbleTextures = new List<Texture2D>();
            generator = new Random();

            base.Initialize();
            for (int i = 0; i < 100; i++)
            {
                tribbles.Add(new Tribble(tribbleTextures[generator.Next(tribbleTextures.Count)], new Rectangle(generator.Next(window.Width - 120), generator.Next(window.Height - 120), generator.Next(50, 120), generator.Next(50, 120)), new Vector2(generator.Next(-3, 3), generator.Next(-3, 3))));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleGrey"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleBrown"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleCream"));
            tribbleTextures.Add(Content.Load<Texture2D>("tribbleOrange"));


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < tribbles.Count; i++)
                tribbles[i].Move(window);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            for (int i = 0; i < tribbles.Count; i++)
                tribbles[i].Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}