using Core.Helper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class AppDBContext
    {
        private List<Hotel> hotels = new List<Hotel>();
        private List<Room> rooms = new List<Room>();
        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }
        public List<Room> FindAllAvailableRooms() 
        {
            List<Room> farooms= new List<Room>(); 
            foreach (var room in rooms) 
            
            {
                if(room.IsAvailable) 
                {  
                    farooms.Add(room); 
                }                             
            }
            return farooms;
        }
        public void MakeReservation(int? roomId,int count)
        {
            if(roomId == null)
            {
                throw new NullReferenceException("Otaq Id si bos ola bilmez");
            }
            Room room = rooms.FirstOrDefault(r => r.Id == roomId);
            if(room == null)
            {
                throw new ArgumentException("bele id ye sahib otaq tapilmadi");
            }
            if (!room.IsAvailable)
            {
                throw new NotAvaliableException("Otaq artiq rezervasiya olunub");
            }
            if (room.PersonCapacity < count)
            {
                throw new ArgumentException("otaq tutumu kifayet deyil");
            }

            room.IsAvailable = false;
            Console.WriteLine("otaq rezervasiya edildi");
        }
        public void AddHotel(Hotel hotel)
        {
            hotels.Add(hotel);
        }
        public Hotel FindHotelByName(string name)
        {
            
            return hotels.FirstOrDefault(r => r.Name == name);
        }
        public List<Hotel> GetAllHotels()
        {
            return hotels;
        }

    }
}
