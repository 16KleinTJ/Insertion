using System;

namespace Insertion
{
    class SortingList
    {
        public int[] list;
        public readonly int Length;

        public SortingList(int requiredLength)
        {
            Length = requiredLength;
            list = new int[Length];
        }

        public int getListItem(int i)
        {
            return (list[i]);
        }

        public void setListItem(int i, int value)
        {
            list[i] = value;
        }

        public void Randomise()
        {
            var random = new Random();

            for (int i = 0; i < list.Length; i++)
                list[i] = random.Next(50);
        }

        public void Print()
        {
            foreach (int i in list)
                Console.Write(String.Format("{0}, ", i));
            Console.WriteLine("");
        }

        public void Insert(int value)
        {            
            /* First, find the right place for the item to go in */
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == 0)
                {
                    /* There is nothing in this place, so just take it */
                    list[i] = value;
                    break;
                }
                if (value < list[i])
                {
                    /* We need to shift everything along one, so start at 
                     * the end and copy the whole list along
                     */
                    for (int j = list.Length - 1; j > i; j--)
                        list[j] = list[j - 1];

                    list[i] = value;
                    break;
                }
            }
            this.Print();
        }

        /* Example of a docstring */
        /// <summary>
        /// Returns the first value remaining from the List.
        /// 
        /// It replaces the value with -1 to 'delete' it, so this number
        /// is special.
        /// 
        /// It's OK to do this only because we are only sorting positive
        /// numbers.  This would need a rewrite if we were to use negatives!
        /// </summary>
        /// <returns>int representing the value, or -1 if list is empty</returns>
        public int Pop()
        {
            int ret = -1;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != -1)
                {
                    ret = list[i];
                    /* 'Delete' the value */
                    list[i] = -1;
                    break;
                }
            }

            /* If no values found, ret remains as -1 */
            return (ret);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char response;
            
            Console.WriteLine("Please let me know what kinda sort you would like (i)nsertion sort, or (b)ubble sort, or (q)uit");
            for(; ; )
            {
                response = Console.ReadKey().KeyChar;
                switch (response)
                {
                    case 'i': case 'I':
                        InsertionSort();
                        break;
                    case 'b': case 'B':
                        BubbleSort();
                        break;
                    case 'q': case 'Q':
                        return;
                        /* NOTREACHED */
                    default:
                        Console.WriteLine("Um, what are you playing at?");
                        break;
                }
            }
        }

        static void BubbleSort()
        {
            var List = new SortingList(10);
            List.Randomise();
            List.Print();

            while (true) // loops forever until break is called
            {
                bool swapped = false; // init a boolean to track whether any swaps have been made
                for (int i = 0; i < List.Length - 1; i++) // for the entirety of the list, minus one (so that the final element is not compared against nothing)
                {
                    if (List.list[i] > List.list[i + 1]) // compare the current element to the element to it's right
                    {
                        swapped = true; // sets the swapped bool to true indicating that a swap has been made
                        var tempvar = List.list[i]; // store the current element in the array
                        List.list[i] = List.list[i + 1]; // overwrites the current element with the smaller value
                        List.list[i + 1] = tempvar; // move the larger value to i + 1
                    }
                }
                List.Print();
                if (!swapped) // if swapped is false (indicating that no swaps have been made) the list is sorted
                {
                    break; // break is called to end the loop
                }
            }
        }

        static void InsertionSort() {
            var unsortedList = new SortingList(10);
            var sortedList = new SortingList(unsortedList.Length);
            
            /* Let's fill the unsorted list with all sorts of junk */
            unsortedList.Randomise();
            unsortedList.Print();

            /* This is where we do the insertion sort-- doesn't
             * object oriented make this look easy? */

            for (int i = 0; i < unsortedList.Length; i++)
            {
                sortedList.Insert(unsortedList.Pop());
            }

            sortedList.Print();
        }
    }
}
