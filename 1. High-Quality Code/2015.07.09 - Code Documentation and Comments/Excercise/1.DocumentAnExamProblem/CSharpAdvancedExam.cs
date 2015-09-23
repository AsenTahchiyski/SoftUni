namespace _1.DocumentAnExamProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class is a problem from SoftUni.BG's "C# Advanced Topic" course 31 May 2015 exam.
    /// Its purpose is to receive an array of elements from the console and manipulate it in one or more of the following 4 ways:
    /// - Reverse a portion of the provided array using start index and count of elements after it.
    /// - Same as above, but instead of reversing the elements - sorts them.
    /// - Rolls all array elements N times to the right. Each roll each of the array elements is moved to the right, and the first element becomes last.
    /// - Same as above, but to the left. Each roll the last array element becomes first.
    /// </summary>
    public class ArrayManipulator
    {
        /// <summary>
        /// This is just the Main method to demonstrate how the class works and cover the test cases for the exam.
        /// </summary>
        public static void Main()
        {
            // Collect input arrayElements
            string inputArray = Console.ReadLine();
            string[] arrayElements = Regex.Split(inputArray, @"\s+");

            // Process commands
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParameters = Regex.Split(command, @"\s+");
                switch (commandParameters[0])
                {
                    case "reverse": 
                        arrayElements = ReversePortion(arrayElements, command); 
                        break;
                    case "sort": 
                        arrayElements = SortPortion(arrayElements, command); 
                        break;
                    case "rollLeft": 
                        arrayElements = RollLeft(arrayElements, command); 
                        break;
                    case "rollRight": 
                        arrayElements = RollRight(arrayElements, command); 
                        break;
                    default: 
                        break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", arrayElements) + "]");
        }

        /// <summary>
        /// This method reverses a portion of an array. Starts from "startIndex" and takes "elementCount" arrayElements for he portion to be reversed.
        /// </summary>
        /// <param name="arrayElements">Array on which to perform the action.</param>
        /// <param name="commandInput">Parameters on the action.</param>
        /// <returns>
        /// The method returns the original array with the respective action performed in a part of it as per the command provided.
        /// </returns>
        public static string[] ReversePortion(string[] arrayElements, string commandInput)
        {
            string[] commandParameters = Regex.Split(commandInput, @"\s+");
            if (commandParameters.Length != 5)
            {
                Console.WriteLine("Invalid input parameters.");
            }

            int startIndex = int.Parse(commandParameters[2]);
            int elementCount = int.Parse(commandParameters[4]);
            
            // Check whether the index and element count provided are valid.
            if (startIndex < 0 || startIndex > arrayElements.Length - 1 ||
                elementCount < 0 || elementCount > arrayElements.Length ||
                (startIndex + elementCount - 1) > arrayElements.Length)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            // Copy the given array to a new one and reverse its arrayElements according to the command parameters.
            string[] reversedSubArray = arrayElements.ToArray();
            int reversedElementsCounter = 0;

            for (int currentElementIndex = startIndex; currentElementIndex <= startIndex + elementCount - 1; currentElementIndex++)
            {
                int reversedElementIndex = startIndex + (elementCount - 1) - reversedElementsCounter;
                reversedSubArray[currentElementIndex] = arrayElements[reversedElementIndex];
                reversedElementsCounter++;
            }

            return reversedSubArray;
        }
       
        /// <summary>
        /// This method sorts a portion of an array. Starts from "startIndex" and takes "elementCount" arrayElements for the portion to be sorted.
        /// </summary>
        /// <param name="arrayElements">Array on which to perform the action.</param>
        /// <param name="commandInput">Parameters on the action.</param>
        /// <returns>
        /// The method returns the original array with the respective action performed in a part of it as per the command provided.
        /// </returns>
        public static string[] SortPortion(string[] arrayElements, string commandInput)
        {
            string[] commandParameters = Regex.Split(commandInput, @"\s+");

            if (commandParameters.Length != 5)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            int startIndex = int.Parse(commandParameters[2]);
            int elementCount = int.Parse(commandParameters[4]);

            // Check whether the index and element count provided are valid.
            if (startIndex < 0 || startIndex > arrayElements.Length - 1 ||
                elementCount < 0 || elementCount > arrayElements.Length ||
                (startIndex + elementCount - 1) > (arrayElements.Length - 1))
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            // Create a list with all arrayElements to be sorted, sort them and add them back to a copy of the original array.
            List<string> elementsToSort = new List<string>();

            for (int currentIndex = startIndex; currentIndex < startIndex + elementCount; currentIndex++)
            {
                elementsToSort.Add(arrayElements[currentIndex]);
            }

            elementsToSort.Sort();
            int sortIndex = 0;
            string[] arrayWithSortedElements = arrayElements.ToArray();

            for (int elementIndex = startIndex; elementIndex < startIndex + elementCount; elementIndex++)
            {
                arrayWithSortedElements[elementIndex] = elementsToSort[sortIndex];
                sortIndex++;
            }

            return arrayWithSortedElements;
        }

        /// <summary>
        /// This method moves all elements in the array to the right "rollCount" times. On each roll, the last element is placed at the beginning of the array.
        /// </summary>
        /// <param name="arrayElements">Array on which to perform the action.</param>
        /// <param name="commandInput">Parameters on the action.</param>
        /// <returns>
        /// The method returns the original array modified as per the command.
        /// </returns>
        public static string[] RollRight(string[] arrayElements, string commandInput)
        {
            string[] commandParameters = Regex.Split(commandInput, @"\s+");

            if (commandParameters.Length < 2)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            int rollCount = int.Parse(commandParameters[1]);

            if (rollCount < 0 || rollCount > int.MaxValue)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            // Remove excess rolls since if you roll the array "n" times where n = the length of the array, array is left unchanged.
            rollCount = rollCount % arrayElements.Length;

            string[] output = arrayElements.ToArray(); // <-- result should not be initialized empty
            string[] temp = arrayElements.ToArray();

            for (int i = 0; i < rollCount; i++)
            {
                for (int j = 1; j < temp.Length; j++)
                {
                    output[j] = temp[j - 1];
                }

                output[0] = temp[temp.Length - 1];
                temp = output.ToArray();
            }

            return output;
        }

        /// <summary>
        /// This method moves all elements in the array to the left "elementCount" times. On each roll, the first element is placed at the end of the array.
        /// </summary>
        /// <param name="arrayElements">Array on which to perform the action.</param>
        /// <param name="commandInput">Parameters on the action.</param>
        /// <returns>
        /// The method returns the original array modified as per the command.
        /// </returns>
        public static string[] RollLeft(string[] arrayElements, string commandInput)
        {
            string[] command = Regex.Split(commandInput, @"\s+");

            if (command.Length < 2)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            int count = int.Parse(command[1]);

            if (count < 0 || count > int.MaxValue)
            {
                Console.WriteLine("Invalid input parameters.");
                return arrayElements;
            }

            // Remove excess rolls since if you roll the array "n" times where n = the length of the array, array is left unchanged.
            count = count % arrayElements.Length;
            string[] output = arrayElements.ToArray(); // <-- result should not be initialized empty
            string[] temp = arrayElements.ToArray();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < temp.Length - 1; j++)
                {
                    output[j] = temp[j + 1];
                }

                output[temp.Length - 1] = temp[0];
                temp = output.ToArray();
            }

            return output;
        }
    }
}
