using System;
using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;

namespace HotelFinder.Business.Concrete;

public class HotelManager : IHotelService
{
    // Hotel Repository Örneği Lazım.
    private IHotelRepository hotelRepository;
    public HotelManager(IHotelRepository hotelRepository)
    {
        this.hotelRepository = hotelRepository;
    }
    public async Task<Hotel> CreateHotel(Hotel hotel)
    {
        return await this.hotelRepository.CreateHotel(hotel);
    }

    public async Task DeleteHotel(int id)
    {
        await this.hotelRepository.DeleteHotel(id);
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
        return await this.hotelRepository.GetAllHotels();
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        if (id > 0)
        {
            return await this.hotelRepository.GetHotelById(id);
        }
        throw new Exception("Id 1'den küçük olamaz!");
    }

    public async Task<Hotel> GetHotelByName(string name)
    {
        return await this.hotelRepository.GetHotelByName(name);
    }

    public async Task<Hotel> UpdateHotel(Hotel hotel)
    {
        return await this.hotelRepository.UpdateHotel(hotel);
    }
}
