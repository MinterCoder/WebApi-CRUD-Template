using System;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{

    private IHotelService hotelService;

    public HotelsController(IHotelService hotelService)
    {
        this.hotelService = hotelService;
    }

    /// <summary>
    /// Get All Hotels
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public List<Hotel> Get(){
        return this.hotelService.GetAllHotels();
    }

    [HttpGet]
    [Route("{id}")]
    public Hotel Get(int id){
        return this.hotelService.GetHotelById(id);
    }

    [HttpPost]
    public Hotel Post([FromBody] Hotel hotel){
        return this.hotelService.CreateHotel(hotel);
    }
    
    [HttpPut]
    public Hotel Put([FromBody] Hotel hotel){
        return this.hotelService.UpdateHotel(hotel);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id){
        this.hotelService.DeleteHotel(id);
    }
}
