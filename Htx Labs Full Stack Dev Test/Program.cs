using System;

namespace HTX_Labs_Full_Stack_Developer_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Most relevant files: Program.cs, Boids.js, Game_particle_System.cs (and its interface)");

            Console.WriteLine("Task one: Determine if a 3D point is within a 2D sphere.");
            PointInSphere();
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Task two: Calculate the number of unique squares given N");
            CountUniqueSquares(2);
            CountUniqueSquares(3);
            CountUniqueSquares(15);
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Task Three: See Game_Particle_System.cs and IGame_Particle_System.cs");
            Console.WriteLine("Task Four: Unit tests for the particle system.\n" +
                "  1) Particle system should appear as a cloud, flames, confetti, etc.\n" +
                "  2) Particle system intensity should ramp up as another object moves around.\n" +
                "  3) Particle system should follow object as it moves around\n" +
                "  4) Particle system should block screen space (viewport).\n" +
                "  5) Particle system should scale up as object moves around.\n" +
                "  6) If one particle system enters another, they should scale down until they don't touch anymore (no overlap).\n" +
                "  7) If object is interacted with, it should enable multiple particle effects.\n" +
                "  8) (Perhaps obviously) If a particle effect's type is changed, it should reflect that other type.\n" +
                "  9) Depending on the type, particle system should only appear for a brief duration (similar to an explosion).");
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Task Five: See the web browser that opened up with the start button.\n" +
                "Unfortunately I didn't get it complete, as it kind of follows a more 'Game of Life' kind of movement system, but does swarm the mouse cursor");
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Task Six: E-Commerce system \n" +
                "Assume everything has an appropriate ID attached\n" +
                "\n" +
                "We would need to create a listing/product.\n" +
                "  Product: name, price, description, miscellaneous descriptions (size, height, etc), and a list of basic descriptors (electronic, iphone, etc).\n" +
                "           Variations in products are different products (ie 6ft vs 12ft cable)\n" +
                "A review of a product is an account's username, rating, date, and a description. Maybe a summary of the review if we're feeling cheeky.\n" +
                "Next we need a cart.\n" +
                "  Cart: list of products (duplicates allowed), calculated total price, expiration date (amazon doesn't do this to my knowledge)\n" +
                "A web page should reflect all of the above, but it should get a list of reviews, similar products.\n" +
                "We need to use the data of the account\n" +
                "  Account: Username, password, attached cart, attached list of payment system\n" +
                "A payment system is either a class for card information, or paypal.\n" +
                "Discount codes are applied to a cart that iterates over the items in the cart and checks the basic descriptors.\n" +
                "Targeted marketing tracks the products that an account interacts with, adds to their cart, search queries, etc.\n"
            );
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Task Seven: Database overload");
            Console.WriteLine("Assuming we're using an azure environment, we should have access to Azure Insights, a very useful tool for seeing how long it takes to execute a given query or stored proc.");
            Console.WriteLine("If we don't have Azure Insights, I would regression test to see where the problem is, then optimize the code.\n");
            Console.WriteLine("Another solution is that we could look into load balancing our existing servers, or simply adding more servers.");
            Console.WriteLine("Yet another system could be implementing a queue system for requests, FIFO.");



        }

        // Note: Could have used vector3, would have gotten the same result with less steps.
        public class Point
        {
            public Point()
            {

            }
            public int pointX { get; set; }
            public int pointY { get; set; }
            public int pointZ { get; set; }
        }

        // One: Create the points for the circle's center point and the sample point. Set a distance for the circle
        // Two: Calculate the distance between the center's point and the sample point.
        // Three: Check if the point's distance is less than the radius of the sphere.
        public static bool PointInSphere()
        {
            Random random = new Random();
            Point samplePoint = new Point();
            Point centerPoint = new Point();

            centerPoint.pointX = 0;
            centerPoint.pointY = 0;
            centerPoint.pointZ = 0;

            samplePoint.pointX = random.Next(-25, 25);
            samplePoint.pointY = random.Next(-25, 25);
            samplePoint.pointZ = random.Next(-25, 25);

            //Wanted to give it a chance of being in the circle. Having it at zero was too unlikely.
            var SphereRadius = random.Next(1, 50);
            var TotalDistance = ComputeDistanceBetweenTwoPoints(centerPoint, samplePoint);

            Console.WriteLine("Testing Point                          : " + "{0}, {1}, {2}", samplePoint.pointX, samplePoint.pointY, samplePoint.pointZ);
            Console.WriteLine("Sphere Radius                          : " + SphereRadius);
            Console.WriteLine("Total Distance between center and point: " + TotalDistance);

            var returnVal = TotalDistance <= SphereRadius;
            string temp = TotalDistance <= SphereRadius ? "is" : "is not";
            Console.WriteLine("Point {0} in the 3D sphere.", temp);

            return returnVal;
        }

        public static double ComputeDistanceBetweenTwoPoints(Point centerPoint, Point examplePoint)
        {
            var distanceX = Math.Pow(examplePoint.pointX - centerPoint.pointX, 2);
            var distanceY = Math.Pow(examplePoint.pointY - centerPoint.pointY, 2);
            var distanceZ = Math.Pow(examplePoint.pointZ - centerPoint.pointZ, 2);
            var totalDistance = Math.Abs(Math.Sqrt(distanceX + distanceY + distanceZ));
            return totalDistance;
        }

        // One: Take an example (3) and count the unique squares by hand
        // Two: Figure out the rule, make a mathematical function
        // Three: Make a programmatic function
        // Four: ...
        // Five: Profit?
        public static double CountUniqueSquares(int N)
        {
            if (N == 0)
            {
                return 0;
            }
            N = Math.Abs(N);
            double TotalSquares = 0;
            for (int sizeOfSquare = N; sizeOfSquare > 0; sizeOfSquare--)
            {
                TotalSquares += Math.Pow((N - (N - sizeOfSquare)), 2);
            }
            Console.WriteLine("N value: " + N);
            Console.WriteLine("Number of unique Squares: " + TotalSquares);
            return TotalSquares;
        }

    }
}
