using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Logic
{
    public class AnimeLogic : IAnimeLogic
    {
        IAnimeRepository animeRepository;
        public AnimeLogic(IAnimeRepository animeRepository)
        {
            this.animeRepository = animeRepository;
        }

        public void CreateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            animeRepository.CreateAnime(anime_id, studio_id, anime_name, type, aired, source);
        }

        public void DeleteAnime(int anime_id)
        {
            animeRepository.DeleteAnime(anime_id);
        }

        public IEnumerable<Anime> ReadAllAnime()
        {
            return animeRepository.ReadAllAnime();
        }

        public Anime ReadAnime(int anime_id)
        {
            return animeRepository.ReadAnime(anime_id);
        }

        public void UpdateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            animeRepository.UpdateAnime(anime_id, studio_id, anime_name, type, aired, source);
        }
    }
}
