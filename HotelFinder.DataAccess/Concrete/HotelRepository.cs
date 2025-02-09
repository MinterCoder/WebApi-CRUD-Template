using System;
using System.Security.Cryptography.X509Certificates;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;

namespace HotelFinder.DataAccess.Concrete;

public class HotelRepository : IHotelRepository
{
    public Hotel CreateHotel(Hotel hotel)
    {
        using (var hotelDbContext = new HotelDBContext()){
            hotelDbContext.Hotels.Add(hotel);
            hotelDbContext.SaveChanges();
            return hotel;
        }
    }

    public void DeleteHotel(int id)
    {
        using(var hotelDbContext = new HotelDBContext()){
            var deletedHotel = GetHotelById(id);
            hotelDbContext.Hotels.Remove(deletedHotel);
            hotelDbContext.SaveChanges();
        }
    }

    public List<Hotel> GetAllHotels()
    {
        using(var hotelDbContext = new HotelDBContext()){
            return hotelDbContext.Hotels.ToList<Hotel>();
        }
    }

    public Hotel GetHotelById(int id)
    {
        using(var hotelDbContext = new HotelDBContext()){
            return hotelDbContext.Hotels.Find(id);
        }
    }

    public Hotel GetHotelByName(string name)
    {
        using(var hotelDbContext = new HotelDBContext()){
            return hotelDbContext.Hotels.FirstOrDefault(x=>x.Name.ToLower()==name.ToLower());
        }
    }

    public Hotel UpdateHotel(Hotel hotel)
    {
        using(var hotelDbContext = new HotelDBContext()){
            hotelDbContext.Hotels.Update(hotel);
            hotelDbContext.SaveChanges();
            return hotel;
        }
    }
}
