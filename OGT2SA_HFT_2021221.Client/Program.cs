using OGT2SA_HFT_2021221.Data;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Repository;
using System;

namespace OGT2SA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimeDataDbContext context = new AnimeDataDbContext();
            
            AnimeRepository animeRepository = new AnimeRepository(context);
            CharacterRepository characterRepository = new CharacterRepository(context);
            StudioRepository studioRepository = new StudioRepository(context);

            AnimeLogic animeLogic = new AnimeLogic(animeRepository, characterRepository, studioRepository);
            CharacterLogic characterLogic = new CharacterLogic(characterRepository);
            StudioLogic studioLogic = new StudioLogic(studioRepository);

            var q1 = animeLogic.AnimesWhereCharacterName("Shiba Tatsuya");
            var q2 = animeLogic.AnimeNameCharacterNameWhereSource("Light Novel");
            
        }
    }
}
