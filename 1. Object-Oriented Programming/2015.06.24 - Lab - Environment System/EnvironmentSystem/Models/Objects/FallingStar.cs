namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    class FallingStar : MovingObject
    {
        private bool isFalling = false;
        private int counter = 0;
        
        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.FallingStar;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'O' } };
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
            if (counter < 10)
            {
                counter++;
            }
            else
            {
                this.Bounds.TopLeft.X += this.Direction.X;
                this.Bounds.TopLeft.Y += this.Direction.Y;
                this.isFalling = true;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.isFalling && this.Exists)
            {
                return new[] { new Tail(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Height, this.Bounds.Width, this.Direction) }; 
            }
            return new EnvironmentObject[0];
        }
    }
}
