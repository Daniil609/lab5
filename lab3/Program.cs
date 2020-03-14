using System;
using System.Text;

namespace lab3
{
    class rom
    {
        private int size;
        public int Namber { get; set; }
        private int numbersOfPeople;

        public rom() : this (0, 0,0)
        { }
        public rom(int numberof): this (numberof, 0, 0)
        { }
        public rom (int numberof,int size): this(numberof,size, 0) 
        { }
        public rom (int numberof,int size,int number)
        {
            Namber = number;
            Size = size;
            numbersOfPeople = numberof;

        }

        public int Size
        {
            set
            {
                if (value > 0)
                    size = value;
                else
                    size = 0;
            }
            get { return size; }
        }
        public int numberof
        {
            set
            {
                if (value > 0)
                    numbersOfPeople = value;
                else
                    numbersOfPeople = 0;
            }
            get { return numbersOfPeople; }
        }
        public void NewRom(int new_number, int new_size, int new_NamberOfPeople)
        {
            Namber = new_number;
            Size = new_size;
            numbersOfPeople = new_NamberOfPeople;
        }
        public void Show()
        {
            Console.WriteLine($"Namber: {Namber}\nSizee: {size}\nNumber of people: {numbersOfPeople}");
        }

        internal void NewRom(string v1, int v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
    class House<T>
    {
        T[] rom;

        public int Length { get; private set; }

        public House(int amount)
        {
            rom = new T[amount];
            Length = amount;
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                    return rom[index];
                else
                    return rom[0];
            }
            set
            {
                if (index >= 0 && index <= Length)
                    rom[index] = value;
                else
                    Console.WriteLine("incorrect input");
            }
        }

        static Random rnd = new Random();

        static House()
        {
            Console.WriteLine($"Rom's unique id - {rnd.Next(1000, 10000).ToString()}");
        }
    }
    class Program
    {
        public static int Input()
        {
            string number = Console.ReadLine();

           if (!int.TryParse(number, out int x))
            {
                Console.WriteLine("Incorrect input. Please enter number");
                return Input();
            }
            else
            {
                return x;
            }
            
        }
        public static House<rom> CreateHouse()
        {
            Console.WriteLine("Enter amount of room: ");

            int amount = Input();

            House<rom> house = new House<rom>(amount);

            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Enter info about {(i + 1).ToString()} rom:(namber, size, Nambers Of people)");
                house[i] = new rom (Convert.ToInt32(Console.ReadLine()), Input(), Convert.ToInt32(Console.ReadLine()));
                Console.Clear();
            }

            Console.Clear();

            return house;
        }
        public static void GetInfo(House<rom> house)
        {
            Console.WriteLine("Info about all: \n");

            for (int i = 0; i < house.Length; i++)
            {
                Console.WriteLine($"Rom {(i + 1).ToString()}: {house[i].Namber}, {house[i].Size}, {house[i].numberof}\n");
            }
        }

        public static House<rom> ChangeInfo(House<rom> house)
        {
            Console.WriteLine("Enter number of roms: ");
            int x = Input() - 1;

            Console.WriteLine("Enter new info(namber, size, number of rooms): ");
            house[x].NewRom(Convert.ToInt32(Console.ReadLine()), Input(), Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            Console.WriteLine("New info is: ");
            house[x].Show();

            return house;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                House<rom> house = CreateHouse();

                GetInfo(house);

                Console.WriteLine("If you want change info about some rom, enter yes:");

                if (Console.ReadLine() == "yes")
                {
                    Console.Clear();
                    house = ChangeInfo(house);
                }
                else
                    Console.WriteLine("Ok");

                GetInfo(house);

                Console.WriteLine("Continue?");

                if (Console.ReadLine() == "yes")
                {
                    Console.Clear();
                    continue;
                }
                else
                    break;
            }

            Console.ReadKey();
        }





    }
}
