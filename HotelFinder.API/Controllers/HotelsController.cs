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
    public IActionResult Get(){
        var hotels = this.hotelService.GetAllHotels();
        return Ok(hotels); // 200 + body kısmına hotels'i ekle
    }

    [HttpGet]
    [Route("GetHotelById/{id}")]
    public IActionResult Get(int id){
        var hotel = this.hotelService.GetHotelById(id);
        if (hotel != null){
            return Ok(hotel); // 200 + data
        }
        return NotFound();
    }

    [HttpGet]
    [Route("[action]/{name}")]
    public IActionResult GetHotelByName(string name){
        var hotel = this.hotelService.GetHotelByName(name);
        if (hotel != null){
            return Ok(hotel);
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Hotel hotel){
        var createdHotel = this.hotelService.CreateHotel(hotel);
        return CreatedAtAction("Get",new {id=createdHotel.Id},createdHotel); // 201 + data
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Hotel hotel){
        if (this.hotelService.GetHotelById(hotel.Id) != null){
            return Ok(this.hotelService.UpdateHotel(hotel));
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id){
        if (this.hotelService.GetHotelById(id) != null){
            this.hotelService.DeleteHotel(id);
            return Ok();
        }
        return NotFound();
    }
}
