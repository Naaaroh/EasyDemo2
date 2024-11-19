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

        public Ball()
        {
            ScaleRadius = 0.5f;
        }
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(speed * deltaTime);
            if (IsTouching(typeof(Racket)))
            {
                speed = -speed;
            }

        }
    }
}
