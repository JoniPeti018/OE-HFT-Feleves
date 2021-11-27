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
            if (String.IsNullOrEmpty(studio_id.ToString()) || founded == null || studio_name == null || founder == null || headquarters == null)
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                var temp = from studios in studioRepository.GetAll() where studios.studio_id == studio_id select studios.studio_id;
                if (temp.Count() > 0)
                {
                    throw new ArgumentException("Already exists!");
                }
                else
                {
                    studioRepository.CreateStudio(studio_id, founded, studio_name, founder, headquarters);
                }
            }
        }

        public void DeleteStudio(int studio_id)
        {
            try
            {
                ReadStudio(studio_id);
                studioRepository.DeleteStudio(studio_id);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<Studio> ReadAllStudio()
        {
            return studioRepository.ReadAllStudio();
        }

        public Studio ReadStudio(int studio_id)
        {
            var temp = from studios in studioRepository.GetAll() where studios.studio_id == studio_id select studios.studio_id;
            if (temp.Count() > 0)
            {
                return studioRepository.ReadStudio(studio_id);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void UpdateStudio(int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            if (String.IsNullOrEmpty(studio_id.ToString()) || founded == null || studio_name == null || founder == null || headquarters == null)
            {
                throw new ArgumentException("Value cannot be null!");
            }
            else
            {
                try
                {
                    studioRepository.UpdateStudio(studio_id, founded, studio_name, founder, headquarters);
                }
                catch (Exception)
                {

                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
