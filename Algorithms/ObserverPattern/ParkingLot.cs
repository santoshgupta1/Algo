using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class ParkingLot
    {
        public class Floor
        {
            int totalFloor = 100;
            int floorIndex;
            public Floor(int index)
            {
                this.floorIndex = index;
            }

            public ParkingUpdates parkingUpdates = new ParkingUpdates();
            public int ParkedSlotsValue { get; set; }
            public delegate void UpdateParkingInfo(int parkingReader, int parkedSpaceCount);
            public event UpdateParkingInfo notify;

            public void Run()
            {
                (new Task(UpdateParkingReaders)).Start();
            }

            public void UpdateParkingReaders()
            {
                foreach(Tuple<int, int> parkingUpate in parkingUpdates)
                {
                    if(parkingUpate.Item1 == this.floorIndex)
                    {
                        this.ParkedSlotsValue = parkingUpate.Item2;
                        Console.WriteLine("Floor " + this.floorIndex + " ;ParkingSpaceCount= " + this.ParkedSlotsValue);
                        notify(parkingUpate.Item1, parkingUpate.Item2);
                        Thread.Sleep(200);
                    }
                }
            }
        }

        interface IParkingReader
        {
            void Update(int floor, int emptySlots);
        }

        public class ParkingReader : IParkingReader
        {
            int id;
            int totalFloorCount = 10;
            List<Floor> floors;
            public ParkingReader(int parkingReaderId, List<Floor> floorsList)
            {
                this.id = parkingReaderId;
                this.floors = floorsList;
                foreach(Floor floor in floorsList)
                {
                    floor.notify += Update;               
                }
            }

            public void Update(int floor, int emptySlots)
            {
                Console.WriteLine("ParkingReader: " + id + " ; Floor =" + floor + " ;EmptySlots = " + emptySlots);
            }
        }
        public class ParkingUpdates : IEnumerable<Tuple<int, int>>
        {
            List<Tuple<int, int>> parkingValues = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 10),
                new Tuple<int, int>(2, 50),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(1, 15),
                new Tuple<int, int>(6, 10),
                new Tuple<int, int>(5, 13),
                new Tuple<int, int>(6, 70),
                new Tuple<int, int>(6, 12),
                new Tuple<int, int>(6, 45),
            };
            public IEnumerator<Tuple<int, int>> GetEnumerator()
            {
                foreach(var parkingValue in parkingValues)
                {
                    yield return parkingValue;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            List<Floor> parkingFloors = new List<Floor>();
            for(int i=0; i< 10;i++)
            {
                parkingFloors.Add(new Floor(i));
            }

            ParkingReader parkingReader1 = new ParkingReader(1, parkingFloors);
            ParkingReader parkingReader2 = new ParkingReader(2, parkingFloors);
            foreach(Floor parkingFloor in parkingFloors)
            {
                parkingFloor.Run();
            }

            Console.ReadLine();
        }
    }
}
