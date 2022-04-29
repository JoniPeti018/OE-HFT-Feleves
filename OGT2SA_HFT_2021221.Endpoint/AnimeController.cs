using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OGT2SA_HFT_2021221.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;
        public AnimeController(IAnimeLogic animeLogic, IHubContext<SignalRHub> hub)
        {
            this.animeLogic = animeLogic;
            this.hub = hub;
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
        public void Post([FromBody] Anime anime)
        {
            this.animeLogic.CreateAnime(anime.anime_id, (int)anime.studio_id, anime.anime_name, anime.type, anime.aired, anime.source);
            this.hub.Clients.All.SendAsync("AnimeCreated", anime);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Anime anime)
        {
            this.animeLogic.UpdateAnime(anime.anime_id, (int)anime.studio_id, anime.anime_name, anime.type, anime.aired, anime.source);
            this.hub.Clients.All.SendAsync("AnimeUpdated", anime);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var anime = this.animeLogic.ReadAnime(id);
            this.animeLogic.DeleteAnime(id);
            this.hub.Clients.All.SendAsync("AnimeDeleted", anime);
        }
    }
}
