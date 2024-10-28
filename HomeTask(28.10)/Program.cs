using Core.Data;
using Core.Models;
namespace HomeTask_28._10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condition = false;
            string choice;

            List<Hotel> hotels = new List<Hotel>();
            List<Room> rooms = new List<Room>();

            do
            {
                Console.WriteLine("1. Sisteme giris");
                Console.WriteLine("0. Cixis");
                Console.WriteLine(" ");
                Console.Write("Zehmet olmasa secim edin:");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("1. Hotel yarat.");
                        Console.WriteLine("2. Butun otelleri gor.");
                        Console.WriteLine("3. Hotel sec.");
                        Console.WriteLine("0. Cixis");
                        Console.WriteLine(" ");
                        Console.Write("Zehmet olmasa secim edin:");
                        string choice2 = Console.ReadLine();
                        bool condition2 = false;

                        do
                        {
                            switch (choice2)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.Write("Hotel adi daxil edin:");
                                    string hotelName = Console.ReadLine();
                                    Hotel hotel = new Hotel(hotelName);
                                    AppDbContext.AddHotel(hotel);
                                    condition2 = true;
                                    break;

                                case "2":
                                    Console.Clear();
                                    AppDbContext.ShowAllHotels();
                                    condition2 = true;
                                    break;

                                case "3":
                                    Console.Clear();

                                    Console.Write("Secmek istediyiniz hotel adi daxil edin:");
                                    string hotelName2 = Console.ReadLine();

                                    bool condition3 = AppDbContext.SelectHotel(hotelName2);

                                    if (condition3)
                                    {

                                        bool condition4 = true;
                                        do
                                        {
                                            Console.WriteLine("Otel ugurla secildi.");

                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine("1.Room yarat.");
                                            Console.WriteLine("2.Butun roomlari gor.");
                                            Console.WriteLine("3.Rezervasiya et.");
                                            Console.WriteLine("4.Evveli menuya qayit.");
                                            Console.WriteLine("0.Cixis");

                                            Console.WriteLine(" ");

                                            Console.Write("Zehmet olmasa secim edin:");

                                            string choice3 = Console.ReadLine();

                                            switch (choice3)
                                            {
                                                case "1":
                                                    Console.Clear();
                                                    Console.Write("Otaq adi daxil edin :");
                                                    string roomName = Console.ReadLine();

                                                    Console.WriteLine(" ");
                                                    bool condition5;
                                                    double roomPrice;
                                                    do
                                                    {
                                                        Console.Write("Otagin qiymetini daxil edin :");
                                                        condition5 = double.TryParse(Console.ReadLine(), out roomPrice);
                                                    } while (!condition5);

                                                    Console.WriteLine(" ");


                                                    bool condition6;
                                                    int roomCapacity;
                                                    do
                                                    {
                                                        Console.Write("Otagin tutumunu daxil edin :");

                                                        condition6 = int.TryParse(Console.ReadLine(), out roomCapacity);

                                                    } while (!condition6);

                                                    Room room = new Room(roomName, roomPrice, roomCapacity);

                                                    AppDbContext.AddRoom(room);

                                                    Console.WriteLine("Otaq ugurla yaradildi.");

                                                    break;
                                                case "2":
                                                    Console.Clear();
                                                    AppDbContext.ShowAllRooms();
                                                    break;

                                                case "3":
                                                    Console.Clear();

                                                    bool condition7;
                                                    int roomId;
                                                    do
                                                    {
                                                        AppDbContext.ShowAllRooms();
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.Write("Zehmet olmasa rezervasiya etmek istediyiniz otagin id daxil edin:");
                                                        condition7 = int.TryParse(Console.ReadLine(), out roomId);

                                                    } while (!condition7);

                                                    Console.WriteLine(" ");

                                                    bool condition8;
                                                    int personCapacity;
                                                    do
                                                    {
                                                        Console.WriteLine("Zehmet olmasa musteri sayini daxil edin:");
                                                        condition8 = int.TryParse(Console.ReadLine(), out personCapacity);

                                                    } while (!condition8);

                                                    AppDbContext.MakeReservation(roomId,personCapacity);   

                                                    break;
                                                case "4":
                                                    condition4 = true;
                                                    break;
                                                case "0":
                                                    Console.WriteLine("Proqramdan cixilir...");
                                                    condition = true;
                                                    break;

                                            }



                                        } while (!condition4);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bele otel movcud deyil.");
                                    }
                                    condition2 = true;
                                    break;

                                case "0":
                                    Console.Clear();
                                    condition = true;
                                    Console.WriteLine("Proqramdan cixilir.");
                                    break;

                                default:
                                    Console.WriteLine("Duzgun secim edin.");
                                    break;
                            }
                        } while (!condition2);
                        break;

                    case "0":
                        condition = true;
                        Console.WriteLine("Proqramdan cixis edilir...");
                        break;

                    default:
                        Console.WriteLine("Duzgun secim edin.");
                        break;
                }
            } while (!condition);
        }
    }
}
