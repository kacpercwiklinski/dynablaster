using DynaBlaster.Class.Screen;
using DynaBlaster.Class.UiScripts;
using DynaBlaster.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static DynaBlaster.Class.Screen.MenuScreen;

namespace DynaBlaster
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static TextureManager textureManager;
        public static AudioManager audioManager;

        public static bool debugMode = false;

        SplashScreen mSplashScreen;
        Screen mCurrentScreen;
        MenuScreen mMenuScreen;
        GameScreen mGameScreen;
        GameOverScreen mGameOverScreen;

        public const int HEIGHT = 720;
        public const int WIDTH = 1280;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            LineBatch.Init(GraphicsDevice);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textureManager = new TextureManager(this.Content);
            audioManager = new AudioManager(this.Content);

            mSplashScreen = new SplashScreen(this.Content, new EventHandler(ControllerDetectScreenEvent));
            mMenuScreen = new MenuScreen(this.Content, new EventHandler(MenuScreenEvent));
            mGameScreen = new GameScreen(this.Content, new EventHandler(GameScreenEvent));
            mGameOverScreen = new GameOverScreen(this.Content, new EventHandler(GameOverScreenEvent));

            mCurrentScreen = mMenuScreen;
        }

        private void GameOverScreenEvent(object sender, EventArgs e){
            mCurrentScreen = mMenuScreen;
        }

        private void GameScreenEvent(object sender, EventArgs e){
            // Game Over
            mCurrentScreen = mGameOverScreen;
        }

        private void MenuScreenEvent(object sender, EventArgs e){

            Option chosenOption = mMenuScreen.options.Find((option) => option.active);
            if (chosenOption.label.Equals("Play singleplayer")){
                mCurrentScreen = mGameScreen;
                LivesComponent.lives = 3;
                ScoreComponent.score = 0;
                mGameScreen.StartGame();
            } else if (chosenOption.label.Equals("Exit")){
                Exit();
            }
        }

        public void ControllerDetectScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = mMenuScreen;
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
            mCurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
