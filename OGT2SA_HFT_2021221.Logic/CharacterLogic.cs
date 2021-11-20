using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Logic
{
    public class CharacterLogic : ICharacterLogic
    {
        ICharacterRepository characterRepository;
        public CharacterLogic(ICharacterRepository characterRepository)
        {
            this.characterRepository = characterRepository;
        }
        public void CreateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            var temp = from characters in characterRepository.GetAll() where characters.character_id == character_id select characters.character_id;
            if (temp.Count() > 0)
            {
                throw new ArgumentException("Already exists!");
            }
            if (String.IsNullOrEmpty(anime_id.ToString()) || String.IsNullOrEmpty(studio_id.ToString()) || String.IsNullOrEmpty(character_id.ToString()) || main_character == null || main_voice == null || support_character == null || support_voice == null)
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                characterRepository.CreateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
            }
        }

        public void DeleteCharacter(int character_id)
        {
            try
            {
                ReadCharacter(character_id);
                characterRepository.DeleteCharacter(character_id);
            }
            catch (Exception)
            {

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Character> ReadAllCharacter()
        {
            return characterRepository.ReadAllCharacter();
        }

        public Character ReadCharacter(int character_id)
        {
            var temp = from characters in characterRepository.GetAll() where characters.character_id == character_id select characters.character_id;
            if (temp.Count() > 0)
            {
                return characterRepository.ReadCharacter(character_id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            DeleteCharacter(character_id);
            CreateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
        }
    }
}
