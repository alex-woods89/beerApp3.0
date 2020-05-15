using BeerApp.Models;
using BeerApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerApp.Controllers
{
        [Route("api/Beers")]
        [ApiController]
        public class beersController : ControllerBase
        {
            private readonly BeerService _beerService;

            public beersController(BeerService beerService)
            {
                _beerService = beerService;
            }

            [HttpGet]
            public ActionResult<List<Beer>> Get() =>
                _beerService.Get();

            [HttpGet("{id:length(24)}", Name = "Getbeer")]
            public ActionResult<Beer> Get(string id)
            {
                var beer = _beerService.Get(id);

                if (beer == null)
                {
                    return NotFound();
                }

                return beer;
            }

            [HttpPost]
            public ActionResult<Beer> Create(Beer beer)
            {
                _beerService.Create(beer);

                return CreatedAtRoute("Getbeer", new { id = beer.Id.ToString() }, beer);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Beer beerIn)
            {
                var beer = _beerService.Get(id);

                if (beer == null)
                {
                    return NotFound();
                }

                _beerService.Update(id, beerIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var beer = _beerService.Get(id);

                if (beer == null)
                {
                    return NotFound();
                }

                _beerService.Remove(beer.Id);

                return NoContent();
            }
        }
    }


