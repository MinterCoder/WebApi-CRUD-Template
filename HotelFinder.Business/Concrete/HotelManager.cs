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
    public Hotel CreateHotel(Hotel hotel)
    {
        return this.hotelRepository.CreateHotel(hotel);
    }

    public void DeleteHotel(int id)
    {
        this.hotelRepository.DeleteHotel(id);
    }

    public List<Hotel> GetAllHotels()
    {
        return this.hotelRepository.GetAllHotels();
    }

    public Hotel GetHotelById(int id)
    {
        if (id > 0)
        {
            return this.hotelRepository.GetHotelById(id);
        }
        throw new Exception("Id 1'den küçük olamaz!");
    }

    public Hotel GetHotelByName(string name)
    {
        return this.hotelRepository.GetHotelByName(name);
    }

    public Hotel UpdateHotel(Hotel hotel)
    {
        return this.hotelRepository.UpdateHotel(hotel);
    }
}
