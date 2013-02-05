using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Don_tGetCaughtFappin0001
{

    //class to be used int he aprticle engine
    public class Particle
    {
        public Texture2D tTexture     { get; set; }

        public Vector2 vPosition      { get; set; }
        public Vector2 vVelocity      { get; set; }

        public Color cColor           { get; set; }

        public float fAngle           { get; set; }
        public float fAngularVelocity { get; set; }
        public float fSize            { get; set; }

        public int iTTL               { get; set; }




        public Particle(Texture2D texture, 
                        Vector2 position, Vector2 velocity,
                        float angle, float angularvelocity,
                        Color color,
                        float size,
                        int TTL){
            tTexture = texture;
            vPosition = position;
            vVelocity = velocity;
            fAngle = angle;
            fAngularVelocity = angularvelocity;
            cColor = color;
            fSize = size;
            iTTL = TTL;

        }



        //we need to update our particles here
        public void Update(){

            iTTL--;
            vPosition += vVelocity;
            fAngle += fAngularVelocity;

        }




        //draw particle texture
        //Notice we don't call spriteBatch.Begin() or spriteBatch.End() here, 
        //    because we are going to be drawing a Lot of these all at one time.
        public void Draw(SpriteBatch spriteBatch){

            Rectangle rSourceRectangle = new Rectangle(0, 0, tTexture.Width, tTexture.Height);
            Vector2 vOrigin = new Vector2(tTexture.Width / 2, tTexture.Height / 2);

            spriteBatch.Draw(tTexture, vPosition, 
                rSourceRectangle, cColor, 
                fAngle, vOrigin, fSize, 
                SpriteEffects.None, 0f);






        }












    //class bracket
    }
//namespace bracket
}
