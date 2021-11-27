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
            //---Anime - CRUD---
            rest.Post<Anime>
                (
                new Anime()
                {
                    anime_name = "Sword Art Online Alicitization",
                    type = "TV",
                    aired = "2021.12.11",
                    source = "Light Novel",
                    studio_id = 5
                }, "anime"
                );
            rest.Put<Anime>
                (
                new Anime()
                {
                    anime_id = 12,
                    anime_name = "Sword Art Online Alicitization",
                    type = "TV",
                    aired = "2021.12.11",
                    source = "Light Novel",
                    studio_id = 5
                }, "anime"
                );
            var anime = rest.GetSingle<Anime>("anime/13");
            rest.Delete(13, "anime");
            var animes = rest.Get<Anime>("anime");

            //---Character - CRUD---
            rest.Post<Character>
                (
                new Character()
                {
                    anime_id = 5,
                    main_character = "Kiryuuin Satsuki",
                    main_voice = "Yuzuki Ryouka",
                    studio_id = 2,
                    support_character = "Mikisugi Aikurou",
                    support_voice = "Miki Shinichiro"
                }, "character"
                );
            rest.Put<Character>
                (
                new Character() 
                { 
                    anime_id = 8, 
                    character_id = 14, 
                    main_character = "Berserk",
                    main_voice = "unknownmainvoice", 
                    studio_id = 8, 
                    support_character = "Lancer", 
                    support_voice = "unknownsupportvoice" 
                }, "character"
                );
            var character = rest.GetSingle<Character>("character/13");
            rest.Delete(13, "character");
            var characters = rest.Get<Character>("character");

            //---Character - CRUD---
            rest.Post<Studio>
                (
                new Studio()
                { 
                    studio_name = "newstudio", 
                    founded = "2021.12.22", 
                    founder = "someone", 
                    headquarters = "Nagasaki" 
                }, "studio"
                );
            rest.Put<Studio>
                (
                new Studio() 
                { 
                    studio_id = 11,
                    studio_name = "newstudioname", 
                    founded = "unknowndate",
                    founder = "unknownfounder", 
                    headquarters = "Tkoyo" 
                }, "studio"
                );
            var studio = rest.GetSingle<Studio>("studio/15");
            rest.Delete(15, "studio");
            var studios = rest.Get<Studio>("studio");
            //---NonCRUD methods---

            var animesWhereCharacterName = rest.Get<string>("stat/AnimesWhereCharacterName?name=Tachibana Kanade");

            var studiosNameWhereAnimeName = rest.Get<string>("stat/StudiosNameWhereAnimeName?name=Sword Art Online");

            var animeNameCharacterNameWhereSource = rest.Get<KeyValuePair<string, string>>("stat/AnimeNameCharacterNameWhereSource?source=Light Novel");

            var characterNameWhereStudio = rest.Get<string>("stat/CharacterNameWhereStudio?studio=Trigger");

            var airedWhereStudioName = rest.Get<string>("stat/AiredWhereStudioName?studio=P.A. Works");

        }
    }
}
