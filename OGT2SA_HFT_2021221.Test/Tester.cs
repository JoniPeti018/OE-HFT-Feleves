using Moq;
using NUnit.Framework;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System.Linq;
using System;
using System.Collections.Generic;

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
            Studio fakestudio = new Studio() { studio_id = 1, studio_name = "Madhouse", founded = "1972.10.17", founder = "Masao Maruyama", headquarters = "Nakano" };
            Anime fakeanime = new Anime() { anime_id = 10, anime_name = "Mahouka Koukou no Rettousei", type = "TV", aired = "2014.04.06", source = "Light Novel", studio_id = 1, Studios=fakestudio };
            var Characters = new List<Character> {
            new Character() { anime_id = 10, character_id = 8, main_character = "Shiba Tatsuya", main_voice = "Nakamura Yuuichi", studio_id = 1, support_character = "Saegusa Mayumi", support_voice = "Hanazawa Kana", Studios=fakestudio, Animes=fakeanime },
            new Character() { anime_id = 10, character_id = 13, main_character = "Shiba Miyuki", main_voice = "Hayami Saori", studio_id = 1, support_character = "Saegusa Mayumi", support_voice = "Hanazawa Kana", Studios = fakestudio, Animes = fakeanime }
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

    }
}
