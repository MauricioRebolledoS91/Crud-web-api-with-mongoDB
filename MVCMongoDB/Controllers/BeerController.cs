using Microsoft.AspNetCore.Mvc;
using MVCMongoDB.Models;
using MVCMongoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMongoDB.Controllers
{
    public class BeerController : Controller
    {
        public BeerService _beerService;

        public BeerController(BeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public ActionResult<List<Beer>> Get()
        {
            return _beerService.GetAllBeers();
        }

        [HttpPost]
        public ActionResult<List<Beer>> Create(Beer beer)
        {
             _beerService.CreateBeer(beer);
            return Ok(beer);
        }

        [HttpPut]
        public ActionResult Update(Beer beer)
        {
            _beerService.UpdateBeer(beer.Id, beer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id, Beer beer)
        {
            _beerService.DeleteBeer(id);
            return Ok();
        }
    }
}
