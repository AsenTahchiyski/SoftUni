namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class Snowflake : MovingObject
    {
        public Snowflake(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snowflake;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '*' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup ;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Snow)
            {
                this.Exists = false; // added to stop snowflakes passing through the ground (1)
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists == false) // generate snow particle
            {
                return new[] { new Snow(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Height, this.Bounds.Width, '.') }; 
            }
            else return new EnvironmentObject[0];
            
        }
    }
}
