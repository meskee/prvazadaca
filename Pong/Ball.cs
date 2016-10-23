using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Ball : Sprite
    {
        public float Speed { get; set; }

        public float BumpSpeedIncreaseFactor { get; set; }

        public Vector2 Direction { get; set; }

        public Ball(int size, float speed, float defaultBallBumpSpeedIncreaseFactor) : base(size, size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBallBumpSpeedIncreaseFactor;
            Direction = new Vector2(1, 1);
        }

        public void SetDirection (float x, float y)
        {
            Direction = new Vector2(x, y);
        }

        public void SpeedSet (float x)
        {
            if (x > 1) Speed = 1;
            else Speed = x;
        }
    }

}
