using System;
using System.Collections.Generic;
using HotelFinder.Entities;
namespace HotelFinder.DataAccess.Abstract;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAllHotels();
    Task<Hotel> GetHotelById(int id);
    Task<Hotel> GetHotelByName(string name);
    Task<Hotel> CreateHotel(Hotel hotel);
    Task<Hotel> UpdateHotel(Hotel hotel);
    Task DeleteHotel(int id);

}
