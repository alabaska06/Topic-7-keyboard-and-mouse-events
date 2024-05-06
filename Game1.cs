using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_7_keyboard_and_mouse_events
{
    public class Game1 : Game
    {
        Texture2D pacTexture, pacLeft, pacDown, pacUp, pacRight;

        Rectangle pacLocation;

        KeyboardState keyboardState;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pacTexture = Content.Load<Texture2D>("pacSleep");
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

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacLocation.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacLocation.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacLocation.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacLocation.X += 2;
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
                pacTexture = pacUp;
            }
            if (keyboardState.IsKeyDown (Keys.Down))
            {
                pacTexture = pacDown;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacTexture = pacLeft;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacTexture = pacRight;
            }

                _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}