using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace muharrem.Controllers;

[ApiController]
[Route("[controller]")]
public class TravelController : ControllerBase
{
    DbContextOptions<TravelDbContext> options;

    public TravelController()
    {
        options = new DbContextOptionsBuilder<TravelDbContext>()
        .UseInMemoryDatabase(databaseName: "Travel")
        .Options;
    }

    [HttpPost("AddTravel")]
    public ActionResult<bool> AddTravel([FromBody] Travel travel)
    {

        using (var context = new TravelDbContext(options))
        {
            var model = travel;

            context.Travels.Add(model);

            return context.SaveChanges() > 0;
        }
    }
    [HttpGet("GetAll")]
    public List<Travel> GetAll([FromQuery] String arrival, String destination)
    {
        using (var context = new TravelDbContext(options))
        {
            return context.Travels.Where(x => x.ArrivalCity == arrival && x.DepartureCity == destination).ToList();
        }
    }
    [HttpPut("ChangePublishState")]
    public bool ChangePublishState([FromQuery] int id)
    {
        using (var context = new TravelDbContext(options))
        {
            var travel = context.Travels.Where(x => x.Id == id).FirstOrDefault();
            if (travel != null)
            {
                travel.Ispublished = !travel.Ispublished;
                context.Travels.Update(travel);
            }

            return context.SaveChanges() > 0;
        }
    }
    [HttpPut("AddPassengerToTravel")]
    public ActionResult<bool> AddPassengerToTravel([FromQuery] int passengerCount, int travelId)
    {
        using (var context = new TravelDbContext(options))
        {
            var travel = context.Travels.Where(x => x.Id == travelId).FirstOrDefault();
            if (travel != null)
            {
                if (travel.NumberofSeats < travel.PassengerCount + passengerCount)
                {
                    return BadRequest("Yolcu Limiti Aşıldı. Maximum yeni yolcu sayısı: " + (travel.NumberofSeats - travel.PassengerCount));
                }


                travel.PassengerCount = travel.PassengerCount + passengerCount;
                context.Travels.Update(travel);
            }

            return Ok(context.SaveChanges() > 0);
        }
    }
}
