namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    class Tail : MovingObject
    {
        private int counter = 0;

        public Tail(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Tail;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '*' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground)
            {
                this.Exists = false;
            }
        }

        public override void Update()
        {
            if (counter < 2)
            {
                counter++;
            }
            else
            {
                this.Bounds.TopLeft.X += this.Direction.X;
                this.Bounds.TopLeft.Y += this.Direction.Y;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
