using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGT2SA_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAnimeLogic animeLogic;
        ICharacterLogic characterLogic;
        IStudioLogic studioLogic;

        public StatController(IAnimeLogic animeLogic, ICharacterLogic characterLogic, IStudioLogic studioLogic)
        {
            this.animeLogic = animeLogic;
            this.characterLogic = characterLogic;
            this.studioLogic = studioLogic;
        }

        [HttpGet]
        public IEnumerable<string> AnimesWhereCharacterName(string name)
        {
            return animeLogic.AnimesWhereCharacterName(name);
        }

        [HttpGet]
        public IEnumerable<string> StudiosNameWhereAnimeName(string name)
        {
            return animeLogic.StudiosNameWhereAnimeName(name);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> AnimeNameCharacterNameWhereSource(string source)
        {
            return animeLogic.AnimeNameCharacterNameWhereSource(source);
        }

        [HttpGet]
        public IEnumerable<string> CharacterNameWhereStudio(string studio)
        {
            return animeLogic.CharacterNameWhereStudio(studio);
        }

        [HttpGet]
        public IEnumerable<string> AiredWhereStudioName(string studio)
        {
            return animeLogic.AiredWhereStudioName(studio);
        }
    }
}
