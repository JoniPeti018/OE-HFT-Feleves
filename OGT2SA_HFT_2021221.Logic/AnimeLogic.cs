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
        public AnimeLogic(IAnimeRepository animeRepository, ICharacterRepository characterRepository, IStudioRepository studioRepository)
        {
            this.animeRepository = animeRepository;
            this.characterRepository = characterRepository;
            this.studioRepository = studioRepository;
        }

        public void CreateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            if (String.IsNullOrEmpty(anime_id.ToString()) || anime_name == null || type == null || aired == null || source == null || String.IsNullOrEmpty(studio_id.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from animes in animeRepository.GetAll() where animes.anime_id == anime_id select animes.anime_id;
                if (temp.Count() > 0)
                {
                    throw new ArgumentException("Already exists!");
                }
                else
                {
                    animeRepository.CreateAnime(anime_id, studio_id, anime_name, type, aired, source);
                }
            }
        }

        public void DeleteAnime(int anime_id)
        {
            try
            {
                ReadAnime(anime_id);
                animeRepository.DeleteAnime(anime_id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Anime> ReadAllAnime()
        {
            return animeRepository.ReadAllAnime();
        }

        public Anime ReadAnime(int anime_id)
        {
            var temp = from animes in animeRepository.GetAll() where animes.anime_id == anime_id select animes.anime_id;
            if (temp.Count() > 0)
            {
                return animeRepository.ReadAnime(anime_id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            if (String.IsNullOrEmpty(anime_id.ToString()) || anime_name == null || type == null || aired == null || source == null || String.IsNullOrEmpty(studio_id.ToString()))
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                try
                {
                    ReadAnime(anime_id);
                    animeRepository.UpdateAnime(anime_id, studio_id, anime_name, type, aired, source);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }

        public IEnumerable<string> AnimesWhereCharacterName(string name)
        {
            //Animek neve ahol a foszereplo neve...
            var q1 = from x in characterRepository.GetAll()
                     where x.main_character == name
                     select (int)x.anime_id;
            List<int> helper = q1.ToList();
            var q2 = from x in animeRepository.GetAll()
                     where helper.Contains(x.anime_id)
                     select x.anime_name;
            /*var q3 = from x in characterRepository.GetAll()
                     where x.main_character == name
                     select x.Animes.anime_name;*/
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
                     select (int)x.studio_id;
            List<int> helper = q1.ToList();
            var q2 = from x in studioRepository.GetAll()
                     where helper.Contains(x.studio_id)
                     select x.studio_name;
            List<string> Studios = new List<string>();
            foreach (var item in q2)
            {
                Studios.Add(item);
            }
            return Studios;
        }
        public IEnumerable<KeyValuePair<string, string>> AnimeNameCharacterNameWhereSource(string source)
        {
            //Írjuk ki annak az Animének a nevét és foszereplojenek a nevét, ahol az anime forrása: Light Novel
            /*var q1 = from x in characterRepository.GetAll()
                     join y in animeRepository.GetAll() on x.anime_id equals y.anime_id
                     let joineditem = new { y.anime_name, x.main_character, y.source }
                     where joineditem.source == source
                     select new KeyValuePair<string, string>(joineditem.anime_name, joineditem.main_character);*/
            var q2 = from x in animeRepository.GetAll()
                     where x.source == source
                     select new KeyValuePair<string, int>( x.anime_name, x.anime_id );
            List<KeyValuePair<string, int>> helper = new List<KeyValuePair<string, int>>();
            foreach (var item in q2)
            {
                helper.Add(item);
            }
            var q3 = from x in characterRepository.GetAll()
                     select new KeyValuePair<string, int>(x.main_character, (int)x.anime_id);
            List<KeyValuePair<string, string>> helper2 = new List<KeyValuePair<string, string>>();
            foreach (var item in helper)
            {
                foreach (var item2 in q3)
                {
                    if (item.Value == item2.Value)
                    {
                        helper2.Add(new KeyValuePair<string, string>(item.Key, item2.Key));
                    }
                }
            }
            return helper2;
        }
        public IEnumerable<string> CharacterNameWhereStudio(string studio)
        {
            //Karakterek neve, ahol a stúdió...
            var q1 = from x in studioRepository.GetAll()
                     where x.studio_name == studio
                     select x.studio_id;
            List<int> helper = q1.ToList();
            var q2 = from x in characterRepository.GetAll()
                     where helper.Contains((int)x.studio_id)
                     select x.main_character;
            List<string> Characters = new List<string>();
            foreach (var item in q2)
            {
                Characters.Add(item);
            }
            return Characters;
        }
        public IEnumerable<string> AiredWhereStudioName(string studio)
        {
            //Adés kezdete, ahol a stúdió neve...
            var q1 = from x in studioRepository.GetAll()
                     where x.studio_name == studio
                     select x.studio_id;
            List<int> helper = q1.ToList();
            var q2 = from x in animeRepository.GetAll()
                     where helper.Contains((int)x.studio_id)
                     select x.aired;
            List<string> Aired = new List<string>();
            foreach (var item in q2)
            {
                Aired.Add(item);
            }
            return Aired;
        }
    }
}
