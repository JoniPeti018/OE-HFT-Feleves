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
    public class CharacterController : ControllerBase
    {
        ICharacterLogic characterLogic;
        public CharacterController(ICharacterLogic characterLogic)
        {
            this.characterLogic = characterLogic;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return characterLogic.ReadAllCharacter();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Character Get(int id)
        {
            return characterLogic.ReadCharacter(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            characterLogic.CreateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            characterLogic.UpdateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            characterLogic.DeleteCharacter(id);
        }
    }
}
