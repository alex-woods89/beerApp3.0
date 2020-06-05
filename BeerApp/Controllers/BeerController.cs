using BeerApp.Models;
using BeerApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


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

        [DisableCors]
        [HttpGet]
            public ActionResult<List<Beer>> Get() =>
                _beerService.Get();

        [DisableCors]
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

        [DisableCors]
        [HttpPost]
            public ActionResult<Beer> Create(Beer beer)
            {
                _beerService.Create(beer);

                return CreatedAtRoute("Getbeer", new { id = beer.objectid.ToString() }, beer);
            }

        [DisableCors]
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

        [DisableCors]
        [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var beer = _beerService.Get(id);

                if (beer == null)
                {
                    return NotFound();
                }

                _beerService.Remove(beer.objectid);

                return NoContent();
            }
        }
    }


