using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Don_tGetCaughtFappin0001
{
    public class ParticleEngine
    {

        private Random oRandom;

        //allows user to change the location the particles are originating at
        public Vector2 vEmitterLocation { get; set; }

        //list of Partcile class objects -- parameters are pass using the GenerateNewParticle method below
        private List<Particle>  lParticles;
        private List<Texture2D> lTextures;




        public ParticleEngine(List<Texture2D> textures, Vector2 location){

            vEmitterLocation = location;
            lTextures = textures;
            lParticles = new List<Particle>();
            oRandom = new Random();

        }



        private Particle GenerateNewParticle(){

            Texture2D tTexture  = lTextures[oRandom.Next(lTextures.Count)];
            Vector2   vPosition = vEmitterLocation;

            Vector2 vVelocity = new Vector2(
                1f * (float)(oRandom.NextDouble() * 2 - 1),
                1f * (float)(oRandom.NextDouble() * 2 - 1));


            float fAngle = 0;
            float fAngularVelocity = 0.1f * (float)(oRandom.NextDouble() * 2 - 1);

            Color cColor = new Color(
                (float)oRandom.NextDouble(),
                (float)oRandom.NextDouble(),
                (float)oRandom.NextDouble()
                );

            float fSize = (float)oRandom.NextDouble();
            int iTTL = 20+ oRandom.Next(40);

            //call our Particle class consturctor
            return new Particle(tTexture, vPosition, vVelocity, fAngle, fAngularVelocity, cColor, fSize, iTTL);
        }





        //Add new particles as needed, allow each of the particles to update themselves, and remove dead particles.
        public void Update(){

            int iTotal = 10;

            for (int i = 0; i < iTotal; i++){
                lParticles.Add(GenerateNewParticle());
            }


            for (int iParticle = 0; iParticle < lParticles.Count; iParticle++){

                lParticles[iParticle].Update();

                if (lParticles[iParticle].iTTL <= 0){
                    lParticles.RemoveAt(iParticle);
                    iParticle--;
                }
            }
        //end Update override
        }






        public void Draw(SpriteBatch spriteBatch){


            spriteBatch.Begin();

            //loop through and draw each sprite object in the list
            for (int iIndex = 0; iIndex < lParticles.Count; iIndex++){

                lParticles[iIndex].Draw(spriteBatch);
            }


            spriteBatch.End();






        }





















    //class end bracket
    }
//namespace bracket
}
