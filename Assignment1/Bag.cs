using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    public class Bag
    {
        public struct Item
        {
            public int element;
            public int frequency;

            public Item()
            {
                element = 0;
                frequency = 0;
            }

            public Item(int element, int frequency)
            {
                this.element = element;
                this.frequency = frequency;
            }
        }

        public class ElementNotFoundException : Exception { }
        public class EmptyBagException : Exception { }

        public List<Item> _seq;
        private int mostFrequentElement;

        
        public Bag()
        {
            _seq = new List<Item>();
            mostFrequentElement = 0;
        }
        
        
        public void Insert(int element)
        {
            //adding new element to the empty bag
            if(_seq.Count == 0)
            {
                _seq.Add(new Item(element, 1));
                mostFrequentElement = 0;
            }
            else
            {
                for(int i = 0; i < _seq.Count; i++)
                {
                    if (_seq[i].element == element)
                    {
                        _seq[i] = new Item(element, _seq[i].frequency + 1);

                        //SearchMostFrequency();

                        
                        if (_seq[i].frequency > _seq[mostFrequentElement].frequency)
                        {
                            mostFrequentElement = i;
                        }

                        break; 

                    }
                    //adding new element into a not empty bag
                    //traverse till the end
                    
                    else if (i == _seq.Count - 1)
                    {
                        _seq.Add(new Item(element, 1));
                        break;
                    }

                }
            }

           

        }

        public void Remove(int element)
        {
            if (_seq.Count == 0)
            {
                throw new EmptyBagException();
            }
            else
            {
                bool found = false;
                for (int i = 0; i < _seq.Count; i++)
                {
                    if (_seq[i].element == element)
                    {
                        _seq[i] = new Item(element, _seq[i].frequency - 1);

                        //update the mostfrequent after doing anything insertion or removing
                        SearchMostFrequency();

                        if(_seq[i].frequency == 0)
                        {
                            _seq.RemoveAt(i);

                        }
                        /*
                        else if (_seq[i].frequency > _seq[mostFrequentElement].frequency)
                        {
                            mostFrequentElement = i;
                        }
                        */
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new ElementNotFoundException();
                }
            }
        }

        public int Frequency(int element)
        {
            if (_seq.Count == 0)
            {
                throw new EmptyBagException();
            }
            bool found = false;
            int freq = 0;
            for (int i = 0; i < _seq.Count; i++)
            {
                if (_seq[i].element == element)
                {
                    freq = _seq[i].frequency;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                throw new ElementNotFoundException();
            }
            return freq;
        }

        public int MostFrequent()
        {
            if (_seq.Count == 0) throw new EmptyBagException();
            else if (_seq.Count == 1)
            {
                return _seq[0].element;
            }
            else
            {
                return _seq[mostFrequentElement].element;
            }
            
        }

        public void Print()
        {
            if (_seq.Count == 0)
            {
                throw new EmptyBagException();
            }
            Console.WriteLine("The items in the bag are as follows: ");
            foreach(var item in _seq)
            {
                Console.WriteLine($"({item.element}, {item.frequency})");
            }
        }


        private void SearchMostFrequency()
        {
            int max = 0;
            for (int i = 0; i < _seq.Count; i++)
            {
                if (_seq[i].frequency > max)
                {
                    max = _seq[i].frequency;
                    mostFrequentElement = i;
                }
            }
        }




    }


}



