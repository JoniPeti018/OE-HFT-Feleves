﻿using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Repository
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        public AnimeRepository(DbContext context) : base(context)
        {
        }
        public override Anime GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.anime_id == id);
        }
        public void CreateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            Anime anime = new Anime() { anime_id = anime_id, anime_name = anime_name, type = type, aired = aired, source = source, studio_id = studio_id };
            Create(anime);
            context.SaveChanges();
        }

        public void DeleteAnime(int anime_id)
        {
            Delete(GetOne(anime_id));
            context.SaveChanges();
        }

        public HashSet<Anime> ReadAllAnime()
        {
            return (HashSet<Anime>)GetAll();
        }

        public Anime ReadAnime(int anime_id)
        {
            return GetOne(anime_id);
        }

        public void UpdateAnime(int anime_id, int studio_id, string anime_name, string type, string aired, string source)
        {
            DeleteAnime(anime_id);
            CreateAnime(anime_id, studio_id, anime_name, type, aired, source);
            context.SaveChanges();
        }
    }
}
