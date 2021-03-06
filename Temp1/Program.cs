using System;

namespace CircularQ
{
    class QueueCircular
    {
        private int[] _qArray;
        private int _front;
        private int _rear;
        private int _max;
        private int _size;




        //Size of queue passed as argument
        //Init queue to empty
        public QueueCircular(int qSize)
        {
            _max = qSize;
            _qArray = new int[_max];
            _front = 0;
            _rear = -1;
            _size = 0;
        }

        // Function to add an item to the queue. 
        // Changes _rear and _size
        // Returns: 
        //   true: successful
        //   false: unsuccessful
        public bool enqueue(int item)
        {
            bool rv;

            //Are we at the end of the Array?
            if (_rear == _max - 1)
            {
                _rear = -1;  //Move to beginning
            }

            //Are we full?
            if (_size == _max)
            {
                rv = false;  //Yes
            }
            else
            {
                _rear++;
                _qArray[_rear] = item;
                _size++;
                rv = true;
            }

            return rv;
        }

        // Function to remove an item from queue. 
        // Changes _front and _size 
        // Returns: 
        //   true: successful   
        //         p holds value
        //   false: unsuccessful
        //         p holds -1
        public bool dequeue(ref int p)
        {
            bool rv = true;

            //Are we empty?
            if (_size == 0)
            {
                p = -1;
                rv = false;
            }
            else
            {
                p = _qArray[_front];
                _front++;
                if (_front == _max)
                {
                    _front = 0;
                }
                _size--;
            }
            return rv;
        }



        // Function to print queue. 
        public void printQueue()
        {
            //Are we empty?
            if (_size == 0)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                int i;
                i = _front;
                do
                {
                    Console.WriteLine(_qArray[i]);
                    if (i == _rear) break;    //Done
                    i++;
                    if (i == _max) //We at end of array?
                    {
                        i = 0;
                    }
                } while (true);
            }
        }

        public int Size()
        {
            return _size;
        }

        public bool isEmpty()
        {
            if (_qArray == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool peek(ref int item)
        {
            if (_size == 0)
            {
                item = -1;
                return false;
            }
            else
            {
                item = _qArray[_front];
            }

            return true;
        }

        public void clear()
        {
            Array.Clear(_qArray, 1, _qArray.Length - 1);
        }



    }

    // Test code 
    class Program
    {
        static void Main()
        {
            QueueCircular Q = new QueueCircular(5);

            int item = 0;

            
              Console.WriteLine("\nPrintout of queue\n--------------------");
                       Q.printQueue();
                       Console.WriteLine();

                       for (int i = 0; i < 4; i++)
                       {
                           Console.Write("Enqueue of {0} ", i * 10);
                           if (Q.enqueue(i * 10))
                           {
                               Console.WriteLine("Successful");
                           }
                           else
                           {
                               Console.WriteLine("Unsuccessful");
                           }
                       }

                       Console.WriteLine("\nPrintout of queue\n--------------------");
                       Q.printQueue();
                       Console.WriteLine();

                       for (int i = 0; i < 2; i++)
                       {
                           if (Q.dequeue(ref item))
                           {
                               Console.WriteLine("{0} removed from queue", item);
                           }
                           else
                           {
                               Console.WriteLine("Dequeue Error");
                           }
                       }
                       for (int i = 10; i < 14; i++)
                       {
                           Console.Write("Enqueue of {0} ", i * 10);
                           if (Q.enqueue(i * 10))
                           {
                               Console.WriteLine("Successful");
                           }
                           else
                           {
                               Console.WriteLine("Unsuccessful");
                           }
                       }

                       Console.WriteLine("\nPrintout of queue\n--------------------");
                       Q.printQueue();
                       Console.WriteLine();

                       for (int i = 0; i < 6; i++)
                       {
                           if (Q.dequeue(ref item))
                           {
                               Console.WriteLine("{0} removed from queue", item);
                           }
                           else
                           {
                               Console.WriteLine("Dequeue Error");
                           }
                       }

                       Console.WriteLine("\nPrintout of queue\n--------------------");
                       Q.printQueue();


               
            
            for(int i = 0; i < 4; i++){
                Console.WriteLine("Size =" + Q.Size());
                Q.enqueue(i);
                Console.WriteLine("Is Empty? " + Q.isEmpty());
                Console.WriteLine("Peek" + Q.peek(ref item));
                Console.WriteLine("All Clear");
                Q.clear();
                             
            }
           



            Console.WriteLine("Hello World");




            Console.ReadKey();
        }
    }
}

