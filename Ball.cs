using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMonoGame;

namespace EasyDemo2
{
    internal class Ball : Actor
    {
        private float speed = 500;
        private int score_Left;
        private int score_Right;
        private float pause_time = 0.5f;

        public Ball()
        {
            ScaleRadius = 0.5f;
        }
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            pause_time -= deltaTime;
            if (pause_time > 0 )
            {
                return;
            }
            Move(speed * deltaTime);
            if (IsTouching(typeof(Racket)))
            {
                Racket racket = (Racket)GetOneIntersectingActor(typeof(Racket));
                //racket.Y = 0;
                //Turn(3);
                //Om bollen träffar nedre delen på racket åk nedåt, om den träffar övre åk uppåt
                float angle = (this.Y - racket.Y);
                if (this.X > 400)
                {
                    Rotation = -angle;
                    this.X = 750;
                }    
                else
                {
                    Rotation = angle;
                    this.X = 50;
                }
                    
                speed = -speed;
            }
            if (this.Y < 0) 
            {
                //180 - 30 --> 180 + 30
                //150 --> 210
                // (180 - 150) * 2 rotera
                Turn((180 - Rotation) * 2);
            }
            if (this.Y > 600)
            {
                Turn((180 - Rotation) * 2);
            }
            if (this.X < 0) 
            {
                score_Left += 1;

                // move ball to middle
                this.X = 400;
                this.Y = 300;
                pause_time = 0.5f;

            }
            if (this.X > 800) 
            {
                score_Right += 1;
                // move ball to middle
                this.X = 400;
                this.Y = 300;
                pause_time = 0.5f;
            }
            World.ShowText(" " + score_Left, 700, 100);
            World.ShowText(" " + score_Right, 100, 100);
        }
    }
}
