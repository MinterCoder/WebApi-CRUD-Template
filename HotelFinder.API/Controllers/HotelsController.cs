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
    public async Task<IActionResult> Get(){
        var hotels = await this.hotelService.GetAllHotels();
        return Ok(hotels); // 200 + body kısmına hotels'i ekle
    }

    [HttpGet]
    [Route("GetHotelById/{id}")]
    public async Task<IActionResult> Get(int id){
        var hotel = await this.hotelService.GetHotelById(id);
        if (hotel != null){
            return Ok(hotel); // 200 + data
        }
        return NotFound();
    }

    [HttpGet]
    [Route("[action]/{name}")]
    public async Task<IActionResult> GetHotelByName(string name){
        var hotel = await this.hotelService.GetHotelByName(name);
        if (hotel != null){
            return Ok(hotel);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Hotel hotel){
        var createdHotel = await this.hotelService.CreateHotel(hotel);
        return CreatedAtAction("Get",new {id=createdHotel.Id},createdHotel); // 201 + data
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Hotel hotel){
        if (await this.hotelService.GetHotelById(hotel.Id) != null){
            return Ok(await this.hotelService.UpdateHotel(hotel));
        }
        return NotFound();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id){
        if (await this.hotelService.GetHotelById(id) != null){
            await this.hotelService.DeleteHotel(id);
            return Ok();
        }
        return NotFound();
    }
}
