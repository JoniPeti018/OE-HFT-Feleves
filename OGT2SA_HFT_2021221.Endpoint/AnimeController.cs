using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        IAnimeLogic animeLogic;
        public AnimeController(IAnimeLogic animeLogic)
        {
            this.animeLogic = animeLogic;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Anime> Get()
        {
            return animeLogic.ReadAllAnime();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Anime Get(int id)
        {
            return animeLogic.ReadAnime(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            animeLogic.CreateAnime(anime_id, studio_id, anime_name, type, aired, source);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            animeLogic.UpdateAnime(anime_id, studio_id, anime_name, type, aired, source);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            animeLogic.DeleteAnime(id);
        }
    }
}
