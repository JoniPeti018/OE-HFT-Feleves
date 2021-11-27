using Moq;
using NUnit.Framework;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OGT2SA_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        AnimeLogic animeLogic;
        CharacterLogic characterLogic;
        StudioLogic studioLogic;

        [SetUp]
        public void Init()
        {
            var mockAnimeRepositroy = new Mock<IAnimeRepository>();
            var mockCharacterRepositroy = new Mock<ICharacterRepository>();
            var mockStudioRepositroy = new Mock<IStudioRepository>();
            //Fake data
            Studio fakestudio = new Studio() 
            { 
                studio_id = 1, 
                studio_name = "Madhouse", 
                founded = "1972.10.17", 
                founder = "Masao Maruyama", 
                headquarters = "Nakano" 
            };
            Anime fakeanime = new Anime() 
            { 
                anime_id = 10, 
                anime_name = "Mahouka Koukou no Rettousei", 
                type = "TV",
                aired = "2014.04.06", 
                source = "Light Novel", 
                studio_id = 1, 
                Studios = fakestudio 
            };
            var Characters = new List<Character> 
            {
            new Character() 
            { 
                anime_id = 10, 
                character_id = 8,
                main_character = "Shiba Tatsuya",
                main_voice = "Nakamura Yuuichi", 
                studio_id = 1, 
                support_character = "Saegusa Mayumi",
                support_voice = "Hanazawa Kana", 
                Studios=fakestudio,
                Animes=fakeanime 
            },
            new Character() 
            { 
                anime_id = 10, 
                character_id = 13,
                main_character = "Shiba Miyuki",
                main_voice = "Hayami Saori",
                studio_id = 1,
                support_character = "Saegusa Mayumi", 
                support_voice = "Hanazawa Kana", 
                Studios = fakestudio,
                Animes = fakeanime 
            }
            }.AsQueryable();
            var Animes = new List<Anime> { fakeanime }.AsQueryable();
            var Studios = new List<Studio> { fakestudio }.AsQueryable();


            mockCharacterRepositroy.Setup(t => t.GetAll()).Returns(Characters);
            mockAnimeRepositroy.Setup(t => t.GetAll()).Returns(Animes);
            mockStudioRepositroy.Setup(t => t.GetAll()).Returns(Studios);
            characterLogic = new CharacterLogic(mockCharacterRepositroy.Object);
            animeLogic = new AnimeLogic(mockAnimeRepositroy.Object, mockCharacterRepositroy.Object, mockStudioRepositroy.Object);
            studioLogic = new StudioLogic(mockStudioRepositroy.Object);
        }

        [TestCase(1, 1, null, "TV", "2021.04.11", "Light Novel")]
        public void AnimeCreateTest(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            Assert.That(() => animeLogic.CreateAnime(anime_id, studio_id, anime_name, type, aired, source), Throws.TypeOf<ArgumentException>());
        }
        [TestCase(1, 2, 2, "Shiba Tatsuya", null, "Saegusa Mayumi", "Hanazawa Kana")]
        public void CharacterCreateTest(int character_id, int anime_id, int studio_id, string main_character, string main_voice, string support_character, string support_voice)
        {
            Assert.That(() => characterLogic.CreateCharacter(character_id, anime_id, studio_id, main_character, main_voice, support_character, support_voice), Throws.TypeOf<ArgumentException>());
        }
        [TestCase(2, "Madhouse", null, "Masao Maruyama", "Nakano")]
        public void StudioCreateTest(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            Assert.That(() => studioLogic.CreateStudio(studio_id, founded, studio_name, founder, headquarters), Throws.TypeOf<ArgumentException>());
        }
        [TestCase("Shiba Tatsuya")]
        public void AnimesWhereCharacterNameTest(string name)
        {
            var exp = new List<string>()
            {
                "Mahouka Koukou no Rettousei"
            };
            Assert.That(animeLogic.AnimesWhereCharacterName(name), Is.EqualTo(exp));
        }
        [TestCase("Mahouka Koukou no Rettousei")]
        public void StudiosNameWhereAnimeNameTester(string name)
        {
            var exp = new List<string>()
            {
                "Madhouse"
            };
            Assert.That(animeLogic.StudiosNameWhereAnimeName(name), Is.EqualTo(exp));
        }
        [TestCase("Light Novel")]
        public void AnimeNameCharacterNameWhereSourceTest(string source)
        {
            var exp = new List<KeyValuePair<string, string>>()
            {
               new KeyValuePair<string,string>("Mahouka Koukou no Rettousei", "Shiba Tatsuya"),
               new KeyValuePair<string,string>("Mahouka Koukou no Rettousei", "Shiba Miyuki")
            };
            Assert.That(animeLogic.AnimeNameCharacterNameWhereSource(source), Is.EqualTo(exp));
        }
        [TestCase("Madhouse")]
        public void CharacterNameWhereStudioTest(string studio)
        {
            var exp = new List<string>()
            {
                "Shiba Tatsuya",
                "Shiba Miyuki"
            };
            Assert.That(animeLogic.CharacterNameWhereStudio(studio), Is.EqualTo(exp));
        }
        [TestCase("Madhouse")]
        public void AiredWhereStudioNameTest(string studio)
        {
            var exp = new List<string>()
            {
                "2014.04.06"
            };
            Assert.That(animeLogic.AiredWhereStudioName(studio), Is.EqualTo(exp));
        }
        [TestCase(20)]
        public void AnimeDeleteExceptionTest(int anime_id)
        {
            Assert.That(() => animeLogic.DeleteAnime(anime_id), Throws.TypeOf<KeyNotFoundException>());
        }
        [TestCase(20, 2, "Mahouka Koukou no Rettousei", "TV", "2021.04.11", "Light Novel")]
        public void AnimeUpdateException(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            Assert.That(() => animeLogic.UpdateAnime(anime_id, studio_id, anime_name, type, aired, source), Throws.TypeOf < KeyNotFoundException>());
        }
    }
}
