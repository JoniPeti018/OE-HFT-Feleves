using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Data;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Repository
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(AnimeDataDbContext context) : base(context)
        {
        }
        public override Character GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.character_id == id);
        }

        public void CreateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            Character character = new Character() { anime_id = anime_id, character_id = character_id, main_character = main_character, main_voice = main_voice, studio_id = studio_id, support_character = support_character, support_voice = support_voice };
            Create(character);
            context.SaveChanges();
        }

        public void DeleteCharacter(int character_id)
        {
            Delete(GetOne(character_id));
            context.SaveChanges();
        }

        public IQueryable<Character> ReadAllCharacter()
        {
            return GetAll();
        }

        public Character ReadCharacter(int character_id)
        {
            return GetOne(character_id);
        }

        public void UpdateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            var update = ReadCharacter(character_id);
            update.anime_id = studio_id;
            update.studio_id = studio_id;
            update.main_character = main_character;
            update.main_voice = main_voice;
            update.support_character = support_character;
            update.support_voice = support_voice;
            context.SaveChanges();
        }
    }
}
