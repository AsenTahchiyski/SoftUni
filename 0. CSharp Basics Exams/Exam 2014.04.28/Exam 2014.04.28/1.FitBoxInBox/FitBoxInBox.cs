using System;
class FitBoxInBox
{
    static void Main()
    {
        // box define
        int[] box1 = new int[3];
        int[] box2 = new int[3];
        for (int i = 0; i < 3; i++)
        {
            box1[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 3; i++)
        {
            box2[i] = int.Parse(Console.ReadLine());
        }
        bool box1IsSmaller = false;
        // find smaller
        if (box1[0] > box2[0] && box1[1] > box2[1] && box1[2] > box2[2] ||
            box1[0] > box2[0] && box1[1] > box2[2] && box1[2] > box2[1] ||
            box1[0] > box2[1] && box1[1] > box2[0] && box1[2] > box2[2] ||
            box1[0] > box2[2] && box1[1] > box2[0] && box1[2] > box2[1] ||
            box1[0] > box2[1] && box1[1] > box2[2] && box1[2] > box2[0] ||
            box1[0] > box2[2] && box1[1] > box2[1] && box1[2] > box2[0])
        {
            box1IsSmaller = false;
        }
        else if (box1[0] < box2[0] && box1[1] < box2[1] && box1[2] < box2[2] ||
                 box1[0] < box2[0] && box1[1] < box2[2] && box1[2] < box2[1] ||
                 box1[0] < box2[1] && box1[1] < box2[0] && box1[2] < box2[2] ||
                 box1[0] < box2[2] && box1[1] < box2[0] && box1[2] < box2[1] ||
                 box1[0] < box2[1] && box1[1] < box2[2] && box1[2] < box2[0] ||
                 box1[0] < box2[2] && box1[1] < box2[1] && box1[2] < box2[0])
        {
            box1IsSmaller = true;
        }
        else
        {
            return;
        }
        // check fit
        int[] smallerBox = new int[3];
        int[] biggerBox = new int[3];
        if (box1IsSmaller)
        {
            for (int i = 0; i < 3; i++)
            {
                smallerBox[i] = box1[i];
                biggerBox[i] = box2[i];
            }   
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                smallerBox[i] = box2[i];
                biggerBox[i] = box1[i];
            }   
        }
        if (smallerBox[0] < biggerBox[0] && smallerBox[1] < biggerBox[1] && smallerBox[2] < biggerBox[2])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[0], biggerBox[1], biggerBox[2]);
        }
        if (smallerBox[0] < biggerBox[0] && smallerBox[1] < biggerBox[2] && smallerBox[2] < biggerBox[1])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[0], biggerBox[2], biggerBox[1]);
        }
        if (smallerBox[0] < biggerBox[1] && smallerBox[1] < biggerBox[0] && smallerBox[2] < biggerBox[2])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[1], biggerBox[0], biggerBox[2]);
        }
        if (smallerBox[0] < biggerBox[2] && smallerBox[1] < biggerBox[0] && smallerBox[2] < biggerBox[1])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[2], biggerBox[0], biggerBox[1]);
        }
        if (smallerBox[0] < biggerBox[1] && smallerBox[1] < biggerBox[2] && smallerBox[2] < biggerBox[0])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[1], biggerBox[2], biggerBox[0]);
        }
        if (smallerBox[0] < biggerBox[2] && smallerBox[1] < biggerBox[1] && smallerBox[2] < biggerBox[0])
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", smallerBox[0], smallerBox[1], smallerBox[2], biggerBox[2], biggerBox[1], biggerBox[0]);
        }
    }
}
