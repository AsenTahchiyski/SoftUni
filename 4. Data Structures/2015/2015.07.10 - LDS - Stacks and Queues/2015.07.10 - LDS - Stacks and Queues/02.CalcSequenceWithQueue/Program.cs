// Print the first 50 members of the following sequence using a Queue:
//•	S1 = N
//•	S2 = S1 + 1
//•	S3 = 2*S1 + 1
//•	S4 = S1 + 2
//•	S5 = S2 + 1
//•	S6 = 2*S2 + 1
//•	S7 = S2 + 2
namespace _02.CalcSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private const int SequenceMembersToGet = 50;

        private static void Main()
        {
            Queue<int> sequenceMembers = new Queue<int>();
            Console.Write("Start number = ");
            int startNumber = int.Parse(Console.ReadLine());
            List<int> output = new List<int>();

            sequenceMembers.Enqueue(startNumber);
            int memberCounter = 1;
            int sequenceBase = startNumber;
            for (int i = 1; i < SequenceMembersToGet; i++) // starts from 1 since the first member is already added
            {
                switch (memberCounter)
                {
                    case 1:
                        output.Add(sequenceMembers.Peek()); // add to the output list to avoid losing data
                        sequenceBase = sequenceMembers.Dequeue();
                        int member1 = sequenceBase + 1;
                        sequenceMembers.Enqueue(member1);
                        memberCounter++;
                        break;
                    case 2:
                        int member2 = sequenceBase*2 + 1;
                        sequenceMembers.Enqueue(member2);
                        memberCounter++;
                        break;
                    case 3:
                        int member3 = sequenceBase + 2;
                        sequenceMembers.Enqueue(member3);
                        memberCounter = 1;
                        break;
                    default:
                        break;
                }
            }

            while (sequenceMembers.Count > 0)
            {
                output.Add(sequenceMembers.Dequeue());
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
