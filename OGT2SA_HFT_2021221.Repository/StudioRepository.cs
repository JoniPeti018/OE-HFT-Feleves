using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Data;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Repository
{
    public class StudioRepository : Repository<Studio>, IStudioRepository
    {
        public StudioRepository(AnimeDataDbContext context) : base(context)
        {
        }
        public override Studio GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.studio_id == id);
        }
        public void CreateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            Studio studio = new Studio() { studio_id = studio_id, studio_name = studio_name, founded = founded, founder = founder, headquarters = headquarters };
            Create(studio);
            context.SaveChanges();
        }

        public void DeleteStudio(int studio_id)
        {
            Delete(GetOne(studio_id));
            context.SaveChanges();
        }

        public IQueryable<Studio> ReadAllStudio()
        {
            return GetAll();
        }

        public Studio ReadStudio(int studio_id)
        {
            return GetOne(studio_id);
        }

        public void UpdateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            var update = ReadStudio(studio_id);
            update.founded = founded;
            update.studio_name = studio_name;
            update.founder = founder;
            update.headquarters = headquarters;
            context.SaveChanges();
        }
    }
}
