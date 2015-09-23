namespace EnvironmentSystem.Models.Objects
{
    class Explosion : EnvironmentObject
    {
        private int counter = 0;

        public Explosion(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
            
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '*' } };
        }

        public override void Update()
        {
            this.counter++;
            if (this.counter == 10)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.counter = 0;
            }
        }
        
        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup ;
            if (hitObjectGroup == CollisionGroup.Ground)
            {
                // to do
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
