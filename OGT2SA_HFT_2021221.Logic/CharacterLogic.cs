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
            characterRepository.CreateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
        }

        public void DeleteCharacter(int character_id)
        {
            characterRepository.DeleteCharacter(character_id);
        }

        public IEnumerable<Character> ReadAllCharacter()
        {
            return characterRepository.ReadAllCharacter();
        }

        public Character ReadCharacter(int character_id)
        {
            return characterRepository.ReadCharacter(character_id);
        }

        public void UpdateCharacter(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            characterRepository.UpdateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
        }
    }
}
