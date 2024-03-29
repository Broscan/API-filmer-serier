﻿using API_films_and_series.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_films_and_series.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    // https://localhost:7294/v1/Films
    public class Films_And_Series_Controller : ControllerBase
    {
        public static List<Films> Film { get; set; } = new()
        {
         new Films { Id = 1, Name = "Mad Max", Director = "John Doe", Genre = "Horror", Rating = 8 },
         new Films { Id = 2, Name = "LOTR", Director = "Peter Jackson", Genre = "Adventure", Rating = 10 },
         new Films { Id = 3, Name = "Star Wars", Director = "John max", Genre = "Action", Rating = 9 },
         new Films { Id = 4, Name = "Barbie", Director = "Gilbert", Genre = "Comedy", Rating = 7 },
         new Films { Id = 5, Name = "Kingsman", Director = "Matthew Vaughn", Genre = "Action", Rating = 7 },
         new Films { Id = 6, Name = "Interstellar", Director = "Christopher Nolan", Genre = "Action", Rating = 9 },
         new Films { Id = 7, Name = "American Pie", Director = "Paul Weitz", Genre = "Comedy", Rating = 5 },
        };

        [HttpGet]
        public ActionResult<List<Films>> Get()
        {
            if (Film != null && Film.Any())
            {
                // Returnera en lista med filmer
                return Ok(Film);

            }

            return NotFound("Could not find dogs");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Films?> Get(int id)
        {
            Films? film = Film.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                // Kunde inte hitta filmen med det id:t

                // Returnera ett statusmeddelande 404
                return NotFound("That Dog was not found"); // ActionResult som vi kan returnera
            }

            // Returnera en film med id
            return Ok(film);
        }

        [HttpPost]
        public ActionResult Post(Films? film)
        {
            if (film != null)
            {
                Film.Add(film);

                return Ok("New film added!");
            }

            return BadRequest("Could not add film. Check your JSON and try again!");

        }

        [HttpPut]
        public ActionResult UpdateItem(int id, Films film)
        {
            var item = Film.FirstOrDefault(f => f.Id == id);

            if (item == null)
            {
                return NotFound($"{film.Id} Id not found");
            }

            item.Id = id;
            item.Name = film.Name;
            item.Director = film.Director;
            item.Genre = film.Genre;
            item.Rating = film.Rating;

            Film.Add(item);

            return Ok(item);
        }

        [HttpDelete]
        public ActionResult DeleteItem(int id)
        {
            var item = Film.FirstOrDefault(f => f.Id == id);

            if (item == null)
            {
                return NotFound("Id not found");
            }

            Film.Remove(item);

            return Ok($"{item.Name} has successfully been removed");

        }

    }
}
