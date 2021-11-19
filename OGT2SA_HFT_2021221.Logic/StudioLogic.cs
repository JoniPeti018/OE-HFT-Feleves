using OGT2SA_HFT_2021221.Models;
using OGT2SA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Logic
{
    public class StudioLogic : IStudioLogic
    {
        IStudioRepository studioRepository;
        public StudioLogic(IStudioRepository studioRepository)
        {
            this.studioRepository = studioRepository;
        }
        public void CreateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            studioRepository.CreateStudio(studio_id, founded, studio_name, founder, headquarters);
        }

        public void DeleteStudio(int studio_id)
        {
            studioRepository.DeleteStudio(studio_id);
        }

        public IEnumerable<Studio> ReadAllStudio()
        {
            return studioRepository.ReadAllStudio();
        }

        public Studio ReadStudio(int studio_id)
        {
            return studioRepository.ReadStudio(studio_id);
        }

        public void UpdateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            studioRepository.UpdateStudio(studio_id, founded, studio_name, founder, headquarters);
        }
    }
}
