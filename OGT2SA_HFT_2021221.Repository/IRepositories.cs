using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Repository
{
    public interface IRepositories<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }
    public interface IAnimeRepository : IRepositories<Anime>
    {
        //create
        void CreateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source);
        //read
        void ReadAnime(int anime_id);
        //readall
        void ReadAllAnime();
        //update
        void UpdateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source);
        //delete
        void DeleteAnime(int anime_id);
    }
    public interface ICharacterRepository : IRepositories<Character>
    {
        //create
        void CreateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice);
        //read
        void ReadCharacter(int character_id);
        //readall
        void ReadAllCharacter();
        //update
        void UpdateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice);
        //delete
        void DeleteCharacter(int character_id);
    }
    public interface IStudioRepository : IRepositories<Studio>
    {
        //create
        void CreateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters);
        //read
        void ReadStudio(int studio_id);
        //readall
        void ReadAllStudio();
        //update
        void UpdateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters);
        //delete
        void DeleteStudio(int studio_id);
    }
}
