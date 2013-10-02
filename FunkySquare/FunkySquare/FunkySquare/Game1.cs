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

namespace FunkySquare
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Rectangle[] magicstuff = new Rectangle[100];
        int CurrentScreen = 1;
        Color[] colors = new Color[3] { Color.Black, Color.Gray, Color.White };
        
    
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            square = Content.Load<Texture2D>("square");
            Random random = new Random();
            
            for (int i = 0; i < 100; i++)
            {
                int RandX = random.Next(0, 700);
                int RandY = random.Next(0, 400);
               magicstuff[i] = new Rectangle(RandX, RandY, i + 1, i + 1);              
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.D1))
            {
                CurrentScreen = 1;
            }
            else if (kb.IsKeyDown(Keys.D2))
            {
                CurrentScreen = 2;
            }
            else if (kb.IsKeyDown(Keys.D3))
            {
                CurrentScreen = 3;
            }
            else if (kb.IsKeyDown(Keys.D4))
            {
                CurrentScreen = 4;
            }
            else if (kb.IsKeyDown(Keys.D5))
            {
                CurrentScreen = 5;
            }
            base.Update(gameTime);
        }

        public void DrawCheckerboard()
        {
            for (int x = 0; x < this.Window.ClientBounds.Width/25; x++)
            {
                for (int y = 0; y < this.Window.ClientBounds.Height/25; y++)
                {
                    if((x + y) % 2 == 0)
                    {
                    spriteBatch.Draw(square, new Vector2(x*25, y*25), Color.Red);
                    }
                    else
                    {
                    spriteBatch.Draw(square, new Vector2(x * 25, y * 25), Color.White);
                    }
                }
            }
        }

        public void DrawRainbow()
        {
            int i;
            int x = 0;
            int y = 0;
            Rectangle Rainbow = new Rectangle(x, y, 115, 800);
            for (i = 0; i <= 6; i++)  
            {   
            if (i == 0)
                spriteBatch.Draw(square, Rainbow, Color.Red);
            else if (i == 1)
                spriteBatch.Draw(square, Rainbow, Color.Orange);
            else if (i == 2)
                spriteBatch.Draw(square, Rainbow, Color.Yellow);
            else if (i == 3)
                spriteBatch.Draw(square, Rainbow, Color.Green);
            else if (i == 4)
                spriteBatch.Draw(square, Rainbow, Color.Blue);
            else if (i == 5)
                spriteBatch.Draw(square, Rainbow, Color.Indigo);
            else if (i == 6)
                spriteBatch.Draw(square, Rainbow, Color.Violet);          
            Rainbow.X += 115;   
            }

        }

        public void DrawSquares()
        {

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {               
                spriteBatch.Draw(square, magicstuff[i], Color.Yellow);
            }
        }
         public void DrawBlankScreen()
        {
            {
                for (int x = 0; x < this.Window.ClientBounds.Width / 25; x++)
                {
                    for (int y = 0; y < this.Window.ClientBounds.Height / 25; y++)
                    {
                        spriteBatch.Draw(square, new Vector2(x * 25, y * 25), Color.Teal);
                    }
                }
            }
        }

         public void DrawStatic()
         {
             Random rand = new Random();
                for (int i = 0; i < 100000; i++)
            {
                int RandX = rand.Next(0, 800);
                int RandY = rand.Next(0, 500);
                Rectangle tv = new Rectangle(RandX, RandY, 5, 5);
                    spriteBatch.Draw(square, tv, colors[i % 3]);
                
                }
         }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            switch (CurrentScreen)
            {
                case 1: DrawBlankScreen(); break;
                case 2: DrawCheckerboard(); break;
                case 3: DrawRainbow(); break;
                case 4: DrawSquares(); break;
                case 5: DrawStatic(); break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
