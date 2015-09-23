namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class Snow : EnvironmentObject
    {
        private readonly char image;

        public Snow(int x, int y, int width, int height, char image)
            : base(x, y, width, height)
        {
            this.image = image;
            this.CollisionGroup = CollisionGroup.Snow;
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '.' } };
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {

        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
