using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public static class AppDbContext
    {
        static List<Hotel> Hotels = new List<Hotel>();
        static List<Room> Rooms = new List<Room>();

        public static void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public static void AddHotel(Hotel hotel)
        {
            bool condition = true;
            for (int i = 0; i < Hotels.Count; i++)
            {
                if (hotel.Name == Hotels[i].Name)
                {
                    condition = false;
                    break;
                }
            }
            if (condition)
            {
                Hotels.Add(hotel);
                Console.WriteLine("Otel ugurla yaradildi.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eyni adli otel movcuddur!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                //bu bilmirem nedi prosta maragli seye oxsayir
            }
        }

        public static bool SelectHotel(string name)
        {
            bool condition = false;
            for (int i = 0; i < Hotels.Count; i++)
            {
                if (name == Hotels[i].Name)
                {
                    condition = true;
                    break;
                }
            }
            return condition;
        }

        public static void ShowAllHotels()
        {
            if (Hotels.Count > 0)
            {
                for (int i = 0; i < Hotels.Count; i++)
                {
                    Console.WriteLine($"Id: {Hotels[i].Id}, Name: {Hotels[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("Otel yaratmamisiniz.");
            }
        }

        public static void ShowAllRooms()
        {
            if (Rooms.Count > 0)
            {
                for (int i = 0; i < Rooms.Count; i++)
                {
                    Rooms[i].ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Ilk once otaq yaradin.");
            }
        }

        public static void RemoveRoom(Room room)
        {
            Rooms.Remove(room);
        }

        public static void MakeReservation(int roomId, int customers)
        {
            if (Rooms.Count == 0)
            {
                Console.WriteLine("Ilk once otaq yaradin.");
                return;
            }

            Room foundedRoom = Rooms.Find(x => x.Id == roomId);
            if (foundedRoom != null)
            {
                if (customers < foundedRoom.PersonCapacity && foundedRoom.IsAvailable)
                {
                    foundedRoom.IsAvailable = false;
                    Console.WriteLine("Otaq rezervasiya olundu.");
                }
                else if (customers > foundedRoom.PersonCapacity && foundedRoom.IsAvailable)
                {
                    Console.WriteLine($"Otagin tutumu {foundedRoom.PersonCapacity}-dir. Sizin musteri sayiniz bunu asir.");
                }
                else
                {
                    Console.WriteLine("Otaq rezervasiya olunub.");
                }
            }
            else
            {
                throw new NullReferenceException("Otaq tapilmadi.");
            }
        }
    }
}
