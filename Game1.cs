using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Topic_7_keyboard_and_mouse_events
{
    public class Game1 : Game
    {


        Texture2D pacTexture, pacLeft, pacDown, pacUp, pacRight, pacSleep;

        Rectangle pacLocation;

        KeyboardState keyboardState, prevKeyboardState;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Vector2 pacSpeed;

        Random generator = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pacLocation = new Rectangle(10, 10, 100, 100);
            pacSpeed = Vector2.Zero;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pacTexture = Content.Load<Texture2D>("pacSleep");
            pacSleep = Content.Load<Texture2D>("pacSleep");
            pacLeft = Content.Load<Texture2D>("pacLeft");
            pacDown = Content.Load<Texture2D>("pacDown");
            pacUp = Content.Load<Texture2D>("pacUp");
            pacRight = Content.Load<Texture2D>("pacRight");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            pacSpeed = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                pacSpeed.Y -= 2;
                pacTexture = pacUp;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                pacSpeed.Y += 2;
                pacTexture = pacDown;
            }
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                pacSpeed.X -= 2;
                pacTexture = pacLeft;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                pacSpeed.X += 2;
                pacTexture = pacRight;
            }
            if (keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
            {
                int width = generator.Next(0, 800);
                int height = generator.Next(0, 500);
                pacLocation = new Rectangle(width, height, 100, 100);

            }

            if (pacSpeed == Vector2.Zero)
                pacTexture = pacSleep;

            pacLocation.Offset(pacSpeed);


            if (pacLocation.Right > _graphics.PreferredBackBufferWidth || pacLocation.Left < 0)
            {
                if (pacLocation.Right > _graphics.PreferredBackBufferWidth)
                {
                    pacLocation.X = _graphics.PreferredBackBufferWidth - pacLocation.Width;
                }
                else
                {
                    pacLocation.X = 0;
                }

            }
            if (pacLocation.Bottom> _graphics.PreferredBackBufferHeight || pacLocation.Top < 0)
            {
                if (pacLocation.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    pacLocation.Y = _graphics.PreferredBackBufferHeight - pacLocation.Height;
                }
                else
                {
                    pacLocation.Y = 0;
                }

            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                
            }
            else if (keyboardState.IsKeyDown (Keys.Down))
            {
                
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
            }
            else 
            {
                pacTexture = pacSleep;
            }
            


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}