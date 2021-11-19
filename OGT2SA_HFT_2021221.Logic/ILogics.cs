using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Logic
{
    public interface ILogics<T> where T : class
    {
        T GetOne(int id);
        IEnumerable<T> GetAll();
    }
    public interface IAnimeLogic : ILogics<Anime>
    {
        //create
        void CreateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source);
        //read
        Anime ReadAnime(int anime_id);
        //readall
        IEnumerable<Anime> ReadAllAnime();
        //update
        void UpdateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source);
        //delete
        void DeleteAnime(int anime_id);
    }
    public interface ICharacterLogic : ILogics<Character>
    {
        //create
        void CreateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice);
        //read
        Character ReadCharacter(int character_id);
        //readall
        IEnumerable<Character> ReadAllCharacter();
        //update
        void UpdateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice);
        //delete
        void DeleteCharacter(int character_id);
    }
    public interface IStudioLogic : ILogics<Studio>
    {
        //create
        void CreateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters);
        //read
        Studio ReadStudio(int studio_id);
        //readall
        IEnumerable<Studio> ReadAllStudio();
        //update
        void UpdateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters);
        //delete
        void DeleteStudio(int studio_id);
    }
}
