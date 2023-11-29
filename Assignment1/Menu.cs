using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Menu
    {
        private Bag _bag;

        public Menu()
        {
            _bag = new Bag();
        }

        private int GetMenuPoint()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Insert element");
            Console.WriteLine("2. Remove element");
            Console.WriteLine("3. Get frequency of element");
            Console.WriteLine("4. Get most frequent element");
            Console.WriteLine("5. Print bag");
            Console.WriteLine("6. Exit\n");
            Console.Write("Enter your choice: ");

            int v = int.Parse(Console.ReadLine());
            return v;

        }

        private void PutIn()
        {
            Console.Write("Enter element to insert: ");
            int element = int.Parse(Console.ReadLine());
            _bag.Insert(element);
            Console.WriteLine($"Inserted element {element} into bag.");
        }

        private void Erase()
        {
            Console.Write("Enter element to remove: ");
            int element = int.Parse(Console.ReadLine());
            
            try
            {

                _bag.Remove(element);
                Console.WriteLine($"Removed element {element} from the bag.");
            }

            catch(Bag.EmptyBagException)
            {
                Console.WriteLine("Error: The bag is empty");
            }

            catch (Bag.ElementNotFoundException)
            {
                Console.WriteLine("Error: The inserted element is not in the bag.");
            }
        }

        private void GetFreq()
        {
            Console.Write("Enter element to get frequency of: ");
            int element = int.Parse(Console.ReadLine());

            try
            {
                int frequency = _bag.Frequency(element);
                Console.WriteLine($"Frequency of element {element} is {frequency}.");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("Error: The bag is empty");
            }

            catch (Bag.ElementNotFoundException)
            {
                Console.WriteLine("Error: The inserted element is not in the bag.");
            }


        }

        private void GetMostFreq()
        {
            try
            {
                int mostFrequentElement = _bag.MostFrequent();
                Console.WriteLine($"Most frequent element in bag is {mostFrequentElement}.");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine($"Error: The bag is empty");
            }
            
        }

        private void GetBag()
        {
            try
            {
                _bag.Print();
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine($"Error: The bag is empty");
            }

        }

        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1: PutIn(); break;
                    case 2: Erase(); break;
                    case 3: GetFreq(); break;
                    case 4: GetMostFreq(); break;
                    case 5: GetBag(); break;
                    default: break;
                }


            } while (v != 6);

            Console.WriteLine("Bye!");
        }
    }

}

