using Core.Data;
using Core.Models;
using System;

namespace Hoteltask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDBContext dbContext = new AppDBContext();
            Hotel selectedHotel = null;

            while (true)
            {
                Console.WriteLine("********** Ana Menyu ***********");
                Console.WriteLine("1. Sisteme giris");
                Console.WriteLine("0. Cixis");
                Console.Write("Seçiminizi edin: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }
                else if (choice == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("********** Sistem Menyusu **********");
                        Console.WriteLine("1. Hotel yarat");
                        Console.WriteLine("2. Butun Hotelleri gor");
                        Console.WriteLine("3. Hotel sec");
                        Console.WriteLine("0. Cixis");
                        Console.Write("Seçiminizi edin: ");
                        choice = Console.ReadLine();

                        if (choice == "0")
                        {
                            break;
                        }
                        else if (choice == "1")
                        {
                            Console.Write("Hotel adı daxil edin: ");
                            string hotelName = Console.ReadLine();
                            if (dbContext.FindHotelByName(hotelName) != null)
                            {
                                Console.WriteLine("Bu adda artıq hotel movcuddur. Başqa ad seçin.");
                                continue;
                            }
                            try
                            {
                                dbContext.AddHotel(new Hotel(hotelName));
                                Console.WriteLine("Hotel yaradıldı.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        else if (choice == "2")
                        {
                            Console.WriteLine("Butun Hoteller:");
                            foreach (Hotel hotel in dbContext.GetAllHotels())
                            {
                               
                                Console.WriteLine(hotel);
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.Write("Hotel adı daxil edin: ");
                            string hotelName = Console.ReadLine();
                            selectedHotel = dbContext.FindHotelByName(hotelName);
                            if (selectedHotel != null)
                            {
                                Console.WriteLine($"Hotel seçildi: {selectedHotel.Name}");
                                HotelMenu(dbContext, selectedHotel); 
                            }
                            else
                            {
                                Console.WriteLine("Hotel tapılmadı.");
                            }
                        }
                    }
                }
            }
        }

       
        static void HotelMenu(AppDBContext dbContext, Hotel selectedHotel)
        {
            string choice;

            while (true)
            {
                Console.WriteLine($"********** {selectedHotel.Name} Hotel Menyusu **********");
                Console.WriteLine("1. Otaq yarat");
                Console.WriteLine("2. Otaqları gor");
                Console.WriteLine("3. Rezervasiya et");
                Console.WriteLine("0. Ana menyuya qayit");
                Console.Write("Seçiminizi edin: ");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("Ana menyuya qayidilir...");
                    break;
                }
                else if (choice == "1")
                {
                    Console.Write("Otaq adı daxil edin: ");
                    string roomName = Console.ReadLine();
                    Console.Write("Qiymət daxil edin: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Şəxsi tutum daxil edin: ");
                    int capacity = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        dbContext.AddRoom(new Room(roomName, price, capacity));
                        Console.WriteLine("Otaq yaradıldı.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Butun Otaqlar:");
                    foreach (Room room in dbContext.FindAllAvailableRooms())
                    {
                        Console.WriteLine(room);
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Rezervasiya üçün Otaq ID daxil edin: ");
                    int roomId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Musteri sayı daxil edin: ");
                    int customerCount = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        dbContext.MakeReservation(roomId, customerCount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}