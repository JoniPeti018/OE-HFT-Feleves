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
            #region
            //RestService rest = new RestService("http://localhost:9346");
            //---Anime - CRUD---
            /*rest.Post<Anime>
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
            var animes = rest.Get<Anime>("anime");*/

            //---Character - CRUD---
            /*rest.Post<Character>
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
            var characters = rest.Get<Character>("character");*/

            //---Character - CRUD---
            /*rest.Post<Studio>
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
            var studios = rest.Get<Studio>("studio");*/

            //---NonCRUD methods---

            //var animesWhereCharacterName = rest.Get<string>("stat/AnimesWhereCharacterName?name=Tachibana Kanade");

            //var studiosNameWhereAnimeName = rest.Get<string>("stat/StudiosNameWhereAnimeName?name=Sword Art Online");

            //var animeNameCharacterNameWhereSource = rest.Get<KeyValuePair<string, string>>("stat/AnimeNameCharacterNameWhereSource?source=Light Novel");

            //var characterNameWhereStudio = rest.Get<string>("stat/CharacterNameWhereStudio?studio=Trigger");

            //var airedWhereStudioName = rest.Get<string>("stat/AiredWhereStudioName?studio=P.A. Works");
            #endregion
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }

        }
        private static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Create (anime, character, studio)");
            Console.WriteLine("2 - Read (From animes, characters, studios)");
            Console.WriteLine("3 - Update (anime, character, studio)");
            Console.WriteLine("4 - Delete (anime, character, studio)");
            Console.WriteLine("5 - Animes name where Character Name...");
            Console.WriteLine("6 - Studios name where Anime Name...");
            Console.WriteLine("7 - Animes and Characters name where Source...");
            Console.WriteLine("8 - Characters name where Studio name...");
            Console.WriteLine("9 - Aired where Studio name...");
            Console.WriteLine("10 - Exit...");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Create();
                    return true;
                case "2":
                    Read();
                    return true;
                case "3":
                    Update();
                    return true;
                case "4":
                    Delete();
                    return true;
                case "5":
                    ANWCN();
                    return true;
                case "6":
                    SNWAN();
                    return true;
                case "7":
                    ACNWS();
                    return true;
                case "8":
                    CNWSN();
                    return true;
                case "9":
                    AWSN();
                    return true;
                case "10":
                    return false;
                default:
                    Menu();
                    return true;
            }
        }
        private static void ANWCN() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Character name:");
            string characterName = Console.ReadLine();
            rest.Get<string>("stat/AnimesWhereCharacterName?name="+characterName);
            var writeCharacter = rest.Get<string>($"stat/AnimesWhereCharacterName?name={characterName}");
            Console.WriteLine(string.Join(",", writeCharacter));
            Console.ReadKey();
            Menu();
        }
        private static void SNWAN() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Anime name:");
            string animeName = Console.ReadLine();
            rest.Get<string>("stat/StudiosNameWhereAnimeName?name="+animeName);
            var writeAnime = rest.Get<string>("stat/StudiosNameWhereAnimeName?name=" + animeName);
            Console.WriteLine(string.Join(",", writeAnime));
            Console.ReadKey();
            Menu();
        }
        private static void ACNWS() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Source name:");
            string sourceName = Console.ReadLine();
            rest.Get<KeyValuePair<string, string>>("stat/AnimeNameCharacterNameWhereSource?source="+sourceName);
            var writeSource = rest.Get<KeyValuePair<string, string>>("stat/AnimeNameCharacterNameWhereSource?source=" + sourceName);
            Console.WriteLine(string.Join(",", writeSource));
            Console.ReadKey();
            Menu();
        }
        private static void CNWSN() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Studio name:");
            string studioName = Console.ReadLine();
            rest.Get<string>("stat/CharacterNameWhereStudio?studio="+studioName);
            var writeStudio = rest.Get<string>("stat/CharacterNameWhereStudio?studio=" + studioName);
            Console.WriteLine(string.Join(",", writeStudio));
            Console.ReadKey();
            Menu();
        }
        private static void AWSN() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Studio name:");
            string studioName = Console.ReadLine();
            rest.Get<string>("stat/AiredWhereStudioName?studio="+studioName);
            var writeStudio = rest.Get<string>("stat/AiredWhereStudioName?studio=" + studioName);
            Console.WriteLine(string.Join(",", writeStudio));
            Console.ReadKey();
            Menu();
        }
        private static void Create()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("What type of element do you want to insert? (anime,character,studio)");
            string table = Console.ReadLine();
            if (table == "anime" || table == "character" || table == "studio")
            {
                switch (table)
                {
                    case "anime":
                        Console.WriteLine("Name of the anime: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Type of the anime (TV, OVA, ONA, Special, Movie):");
                        string type = Console.ReadLine();
                        Console.WriteLine("When was the anime aired?");
                        string aired = Console.ReadLine();
                        Console.WriteLine("Source of the anime (Manga, Light Novel, Game)");
                        string source = Console.ReadLine();
                        Console.WriteLine("Studio ID: ");
                        int studioID = int.Parse(Console.ReadLine());
                        rest.Post(new Anime()
                        {
                            anime_name = name,
                            type = type,
                            aired = aired,
                            source = source,
                            studio_id = studioID
                        }, "anime");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        Menu();
                        break;
                    case "character":
                        Console.WriteLine("Name of the main character: ");
                        string mainCharacter = Console.ReadLine();
                        Console.WriteLine("Anime ID:");
                        int animeID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the main character's voice actor:");
                        string mainVoice = Console.ReadLine();
                        Console.WriteLine("Studio ID:");
                        int studID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the support character:");
                        string supportCharacter = Console.ReadLine();
                        Console.WriteLine("Name of the support character's voice actor:");
                        string supportVoice = Console.ReadLine();
                        rest.Post(new Character()
                        {
                            anime_id = animeID,
                            main_character = mainCharacter,
                            main_voice = mainVoice,
                            studio_id = studID,
                            support_character = supportCharacter,
                            support_voice = supportVoice
                        }, "character");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        Menu();
                        break;
                    case "studio":
                        Console.WriteLine("Name of the Studio:");
                        string studioName = Console.ReadLine();
                        Console.WriteLine("When was the studio founded?");
                        string founded = Console.ReadLine();
                        Console.WriteLine("Name of the founder: ");
                        string founderName = Console.ReadLine();
                        Console.WriteLine("Headquarters:");
                        string headquarters = Console.ReadLine();
                        rest.Post(new Studio()
                        {
                            studio_name = studioName,
                            founded = founded,
                            founder = founderName,
                            headquarters = headquarters
                        }, "studio");
                        Console.WriteLine("Item successfully added!");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                Menu();
            }
        }
        private static void Update()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("What type of element do you want to update ? (anime,character,studio");
            string table = Console.ReadLine();
            if (table == "anime" || table == "character" || table == "studio")
            {
                switch (table)
                {
                    case "anime":
                        Console.WriteLine("Name of the anime: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Type of the anime (TV, OVA, ONA, Special, Movie):");
                        string type = Console.ReadLine();
                        Console.WriteLine("When was the anime aired?");
                        string aired = Console.ReadLine();
                        Console.WriteLine("Source of the anime (Manga, Light Novel, Game)");
                        string source = Console.ReadLine();
                        Console.WriteLine("Studio ID: ");
                        int studioID = int.Parse(Console.ReadLine());
                        rest.Put(new Anime()
                        {
                            anime_name = name,
                            type = type,
                            aired = aired,
                            source = source,
                            studio_id = studioID
                        }, "anime");
                        Console.WriteLine("Item successfully updated!");
                        Console.ReadKey();
                        Menu();
                        break;
                    case "character":
                        Console.WriteLine("Name of the main character: ");
                        string mainCharacter = Console.ReadLine();
                        Console.WriteLine("Anime ID:");
                        int animeID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the main character's voice actor:");
                        string mainVoice = Console.ReadLine();
                        Console.WriteLine("Studio ID:");
                        int studID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name of the support character:");
                        string supportCharacter = Console.ReadLine();
                        Console.WriteLine("Name of the support character's voice actor:");
                        string supportVoice = Console.ReadLine();
                        rest.Put(new Character()
                        {
                            anime_id = animeID,
                            main_character = mainCharacter,
                            main_voice = mainVoice,
                            studio_id = studID,
                            support_character = supportCharacter,
                            support_voice = supportVoice
                        }, "character");
                        Console.WriteLine("Item successfully updated!");
                        Console.ReadKey();
                        Menu();
                        break;
                    case "studio":
                        Console.WriteLine("Name of the Studio:");
                        string studioName = Console.ReadLine();
                        Console.WriteLine("When was the studio founded?");
                        string founded = Console.ReadLine();
                        Console.WriteLine("Name of the founder: ");
                        string founderName = Console.ReadLine();
                        Console.WriteLine("Headquarters:");
                        string headquarters = Console.ReadLine();
                        Console.WriteLine("Item successfully updated!");
                        rest.Put(new Studio()
                        {
                            studio_name = studioName,
                            founded = founded,
                            founder = founderName,
                            headquarters = headquarters
                        }, "studio");
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                Menu();
            }

        }
        private static void Read()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Which table do you want to display? (anime,character,studio)");
            string table = Console.ReadLine();
            if (table == "anime" || table == "character" || table == "studio")
            {
                switch (table)
                {
                    case "anime":
                        var tempAnime = rest.Get<Anime>("anime");
                        foreach (var item in tempAnime)
                        {
                            Console.WriteLine($"{item.anime_id} - {item.anime_name} - {item.type} - {item.aired} - {item.source} - {item.studio_id}\n");
                        }
                        Console.ReadKey();
                        Menu();
                        break;
                    case "character":
                        var tempCharacter = rest.Get<Character>("character");
                        foreach (var item in tempCharacter) 
                        {
                            Console.WriteLine($"{item.anime_id} - {item.character_id} - {item.studio_id} - {item.main_character} - {item.main_voice} - {item.support_character} - {item.support_voice}\n");
                        }
                        Console.ReadKey();
                        Menu();
                        break;
                    case "studio":
                        var tempStudio = rest.Get<Studio>("studio");
                        foreach (var item in tempStudio) 
                        {
                            Console.WriteLine($"{item.studio_id} - {item.studio_name} - {item.founded} - {item.founder} - {item.headquarters}\n");
                        }
                        Console.WriteLine(string.Join(",", tempStudio));
                        Console.ReadKey();
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect table name!");
                Console.ReadKey();
                Menu();
            }
        }
        private static void Delete() 
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:9346");
            Console.WriteLine("Which table you want to delete from? (anime, character, studio)");
            string table = Console.ReadLine();
            Console.WriteLine("Which value with which ID do you want to delete?");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, table);
            Console.WriteLine("The item has been successfullz deleted!");
            Console.ReadKey();
            Menu();
        }
    }
}
