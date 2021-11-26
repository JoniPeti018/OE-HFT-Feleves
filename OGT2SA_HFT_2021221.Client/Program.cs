using OGT2SA_HFT_2021221.Data;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;

namespace OGT2SA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:9346");
            rest.Post<Anime>(new Anime (){ anime_name = "Eighty Six", type = "TV", aired = "2021.04.11", source = "Light Novel", studio_id = 5 }, "anime");
            var animes = rest.Get<Anime>("anime");

            var animesWhereCharacterName = rest.Get<string>("stat/AnimesWhereCharacterName?name=Tachibana Kanade");

            var studiosNameWhereAnimeName = rest.Get<string>("stat/StudiosNameWhereAnimeName?name=Sword Art Online");

            var animeNameCharacterNameWhereSource = rest.Get<KeyValuePair<string, string>>("stat/AnimeNameCharacterNameWhereSource?source=Light Novel");

            var characterNameWhereStudio = rest.Get<string>("stat/CharacterNameWhereStudio?studio=Trigger");

            var airedWhereStudioName = rest.Get<string>("stat/AiredWhereStudioName?studio=P.A. Works");
            ;
        }
    }
}
