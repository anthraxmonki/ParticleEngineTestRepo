using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Don_tGetCaughtFappin0001
{

    class AnimatedSprite
    {
        //tTextureAtlas stores our TextureAtlas data for animation
        //iRows is the number or Rows in the TextureAtlas
        //icolumns is the number of columns in the TextureAtlas

        public Texture2D tTextureAtlas { get; set; }
        public int iRows         { get; set; }
        public int iColumns      { get; set; }

        
        private int iCurrentAtlasFrame;
        private int iTotalAtlasFrames;




        public AnimatedSprite(Texture2D textureAtlas, int irows, int icolumns) {

            tTextureAtlas = textureAtlas;
            iRows = irows;
            iColumns = icolumns;

            iCurrentAtlasFrame = 0;
            iTotalAtlasFrames = iRows * iColumns;
 
        }




        public void Update(){

            iCurrentAtlasFrame++;
            if (iCurrentAtlasFrame == iTotalAtlasFrames)
            {
                iCurrentAtlasFrame = 0;
            }
        }



        public void Draw(SpriteBatch spriteBatch, Vector2 location){


            int iWidth  = tTextureAtlas.Width / iColumns;
            int iHeight = tTextureAtlas.Height / iRows;
            int iRow = (int)(float)(iCurrentAtlasFrame / (float)iColumns);
            int iColumn = iCurrentAtlasFrame % iColumns;


            Rectangle rSourceRectangle = new Rectangle(iWidth * iColumn, iHeight * iRow, iWidth, iHeight);
            Rectangle rDestinationRectangle = new Rectangle((int)location.X, (int)location.Y, iWidth, iHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(tTextureAtlas, rDestinationRectangle, rSourceRectangle, Color.White);
            spriteBatch.End();



        }





    }
















}
