namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    class Star : EnvironmentObject
    {
        private static readonly Random randomGenerator = new Random();
        private int counter = 0;

        public Star(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
            
        }

        protected virtual char[,] GenerateImageProfile()
        {
            char[] symbols = { 'O', '0', '@' };
            int currentSymbol = randomGenerator.Next(0, 3);
            return new char[,] { { symbols[currentSymbol] } };
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
