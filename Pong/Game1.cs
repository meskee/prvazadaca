
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using zad2;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public Paddle PaddleBottom { get; private set; }

        public Paddle PaddleTop { get; private set; }

        public Ball Ball { get; private set; }

        public Background Background { get; private set; }

        public SoundEffect HitSound { get; private set; }

        public Song Music { get; private set; }

        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500
            };
            Content.RootDirectory = "Content";
        }

        public List<Wall> Walls { get; set; }
        public List<Wall> Goals { get; set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var screenBounds = GraphicsDevice.Viewport.Bounds;

            PaddleBottom = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);

            PaddleBottom.X = 150;
            PaddleBottom.Y = 800;

            PaddleTop = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);

            PaddleTop.X = 150;
            PaddleTop.Y = 10;

            Ball = new Ball(GameConstants.DefaultBallSize,
            GameConstants.DefaultInitialBallSpeed,
            GameConstants.DefaultBallBumpSpeedIncreaseFactor)
            {
                X = 250,
                Y = 450
            };

            Background = new Background(500, 900);

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

            Walls = new List<Wall>()
            {
                new Wall ( - GameConstants . WallDefaultSize ,0 , GameConstants . WallDefaultSize , /*screenBounds . Height*/900 ) ,
            new Wall ( /*screenBounds . Right*/500 ,0 , GameConstants . WallDefaultSize , /*screenBounds . Height*/900 ) ,
            };

            Goals = new List<Wall>()
            {
                new Wall (0 , /*screenBounds . Height*/900 , /*screenBounds . Width*/500 , GameConstants . WallDefaultSize ) ,
            new Wall ( 0 , - GameConstants . WallDefaultSize ,/*screenBounds . Width*/500 , GameConstants . WallDefaultSize ) ,
            };

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            PaddleBottom.Texture = paddleTexture;
            PaddleTop.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("ball");
            Background.Texture = Content.Load<Texture2D>("background");
            // Load sounds
            // Start background music
            HitSound = Content.Load<SoundEffect>("hit");
            //Music = Content.Load<Song>("music");
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Play(Music);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).DrawSpriteOnScreen(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
