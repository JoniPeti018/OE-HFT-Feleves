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
        ICharacterRepository characterRepository;
        IStudioRepository studioRepository;
        public AnimeLogic(IAnimeRepository animeRepository, ICharacterRepository characterRepository, StudioRepository studioRepository)
        {
            this.animeRepository = animeRepository;
            this.characterRepository = characterRepository;
            this.studioRepository = studioRepository;
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

        public IEnumerable<string> AnimesWhereCharacterName(string name)
        {
            //Animek neve ahol a foszereplo neve...
            var q1 = from x in characterRepository.GetAll()
                     where x.main_voice == name
                     select x.anime_id;
            var q2 = from x in animeRepository.GetAll()
                     where q1.Contains(x.anime_id)
                     select x.anime_name;
            List<string> Animes = new List<string>();
            foreach (var item in q2)
            {
                Animes.Add(item);
            }
            return Animes;
        }
        public IEnumerable<string> StudiosNameWhereAnimeName(string name)
        {
            //Studio neve ahol az anime neve...
            var q1 = from x in animeRepository.GetAll()
                     where x.anime_name == name
                     select x.anime_id;
            var q2 = from x in studioRepository.GetAll()
                     where q1.Contains(x.studio_id)
                     select x.studio_name;
            List<string> Studios = new List<string>();
            foreach (var item in q2)
            {
                Studios.Add(item);
            }
            return Studios;
        }
        public IEnumerable<KeyValuePair<string,string>> AnimeNameCharacterNameWhereSource(string source)
        {
            //Írjuk ki annak az Animének a nevét és foszereplojenek a nevét, ahol az anime forrása: Light Novel
            var q1 = from x in characterRepository.GetAll()
                     join y in animeRepository.GetAll() on x.anime_id equals y.anime_id
                     let joineditem = new { y.anime_name, x.main_character, y.source }
                     where joineditem.source == source
                     select new KeyValuePair<string, string>(joineditem.anime_name, joineditem.main_character);
            return q1;
        }

    }
}
