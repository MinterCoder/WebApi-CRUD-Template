using System;
using System.Security.Cryptography.X509Certificates;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess.Concrete;

public class HotelRepository : IHotelRepository
{
    public async Task<Hotel> CreateHotel(Hotel hotel)
    {
        using (var hotelDbContext = new HotelDBContext()){
            hotelDbContext.Hotels.Add(hotel);
            await hotelDbContext.SaveChangesAsync();
            return hotel;
        }
    }

    public async Task DeleteHotel(int id)
    {
        using(var hotelDbContext = new HotelDBContext()){
            var deletedHotel = await GetHotelById(id);
            hotelDbContext.Hotels.Remove(deletedHotel);
            await hotelDbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
        using(var hotelDbContext = new HotelDBContext()){
            return await hotelDbContext.Hotels.ToListAsync();
        }
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        using(var hotelDbContext = new HotelDBContext()){
            return await hotelDbContext.Hotels.FindAsync(id);
        }
    }

    public async Task<Hotel> GetHotelByName(string name)
    {
        using(var hotelDbContext = new HotelDBContext()){
            return await hotelDbContext.Hotels.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());;
        }
    }

    public async Task<Hotel> UpdateHotel(Hotel hotel)
    {
        using(var hotelDbContext = new HotelDBContext()){
            hotelDbContext.Hotels.Update(hotel);
            await hotelDbContext.SaveChangesAsync();
            return hotel;
        }
    }
}
