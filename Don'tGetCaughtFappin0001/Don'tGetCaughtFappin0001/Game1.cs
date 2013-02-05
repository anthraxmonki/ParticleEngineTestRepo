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

namespace Don_tGetCaughtFappin0001
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //create instances of the classes you'll need



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ParticleEngine oParticleEngine;



        private SpriteFont fKootenay;

        private AnimatedSprite aAnimatedSprite;


        private Texture2D tBackground;
        private Texture2D tShuttle;
        private Texture2D tEarth;
        private Texture2D tArrow;
        private Texture2D tRed;
        private Texture2D tBlue;
        private Texture2D tGreen;

        //private Texture2D tCircle;
        //private Texture2D tStar;
        //private Texture2D tDiamond;







        private int iScore = 0;

        
        private float fAngle = 0;



        private float fRedAngle    = 0;
        private float fBlueAngle   = 0;
        private float fGreenAngle  = 0;

        private float fRedSpeed   = 0.022f;
        private float fBlueSpeed  = 0.025f;
        private float fGreenSpeed = 0.017f;


        private float fDistance = 100;






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
            // TODO: use this.Content to load your game content here


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D tTextureAtlas = Content.Load<Texture2D>("SmileyWalk");
            aAnimatedSprite = new AnimatedSprite(tTextureAtlas, 4, 4);

            fKootenay = Content.Load<SpriteFont>("fKootenay");


            tBackground = Content.Load<Texture2D>("stars");
            tShuttle    = Content.Load<Texture2D>("shuttle");
            tEarth      = Content.Load<Texture2D>("earth");
            tArrow      = Content.Load<Texture2D>("arrow");

            tRed   = Content.Load<Texture2D>("red");
            tBlue  = Content.Load<Texture2D>("blue");
            tGreen = Content.Load<Texture2D>("green");


            List<Texture2D> lTextures = new List<Texture2D>();
            lTextures.Add(Content.Load<Texture2D>("circle"));
            lTextures.Add(Content.Load<Texture2D>("star"));
            lTextures.Add(Content.Load<Texture2D>("diamond"));
            oParticleEngine = new ParticleEngine(lTextures, new Vector2(400, 240));



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
        /// 
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here


            //tell the particle emitter to update itself, which will in turn update each of the particles.
            //then we need to Draw the particles, so lets go down to the Draw method ---
            oParticleEngine.vEmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            oParticleEngine.Update();






            aAnimatedSprite.Update();

            fAngle += 0.01f;

            fRedAngle   += fRedSpeed;
            fBlueAngle  += fBlueSpeed;
            fGreenAngle += fGreenSpeed;






            iScore++;




            base.Update(gameTime);
        }






        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Draw(GameTime gameTime)
        {
            //Color.White for No tint


            GraphicsDevice.Clear(Color.Black);


            oParticleEngine.Draw(spriteBatch);







            //This will move our color pngs in a circle
            Vector2 vRedPosition = new Vector2(
                (float)Math.Cos(fRedAngle) * fDistance,
                (float)Math.Sin(fRedAngle) * fDistance);

            Vector2 vBluePosition = new Vector2(
                (float)Math.Cos(fBlueAngle) * fDistance,
                (float)Math.Sin(fBlueAngle) * fDistance);

            Vector2 vGreenPosition = new Vector2(
                (float)Math.Cos(fGreenAngle) * fDistance,
                (float)Math.Sin(fGreenAngle) * fDistance);

            Vector2 vCenter = new Vector2(300, 140);



            //where to draw the sprite
            Vector2 vLocation = new Vector2(400, 240);
            //x and y coordinates based on the top-left corner 0, 0 && the width and height == to the texture w/h
            Rectangle rSourceRectangle = new Rectangle(0, 0, tArrow.Width, tArrow.Height);
            //location in the texture of the origin of the rotation
            Vector2 vOrigin = new Vector2(tArrow.Width / 2, tArrow.Height);





            //
            // TODO: Add your drawing code here
            //


            //use Additive to overlap and combine colors
            //use Opaque to see texture rectangle
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            spriteBatch.Draw(tRed, vCenter + vRedPosition, Color.White);
            spriteBatch.Draw(tBlue, vCenter + vBluePosition, Color.White);
            spriteBatch.Draw(tGreen, vCenter + vGreenPosition, Color.White);

            //spriteBatch.Draw(tArrow, vCenter + vRedPosition, Color.White);


            //fAngle == rotation angle, origin == origin   , 1.0f == scale factor we want a scale of 1to1, no sprite effects, then the depth of the sprite is 1.0
            spriteBatch.Draw(tArrow, vLocation, rSourceRectangle, Color.White, fAngle, vOrigin, 1.0f, SpriteEffects.None, 1);


            spriteBatch.End();









            //spriteBatch.Draw(tBackground, 
            //                 new Rectangle(0, 0, 800, 480), 
            //                 Color.White);

            //spriteBatch.Draw(tEarth,
            //                 new Vector2(450, 250),
            //                 Color.White);

            //spriteBatch.Draw(tShuttle, 
            //                 new Vector2(400, 240),
            //                 Color.White);


            //spriteBatch.DrawString(fKootenay, 
            //                       "Score: " + iScore, 
            //                       new Vector2(10, 10), 
            //                       Color.Red);

            







            //
            //aAnimatedSprite.Draw(spriteBatch, new Vector2(400, 200));
            //




            //spriteBatch.End();




            base.Draw(gameTime);
        }
















    }
}
