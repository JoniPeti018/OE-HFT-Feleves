using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OGT2SA_HFT_2021221.Logic;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        IStudioLogic studioLogic;
        public StudioController(IStudioLogic studioLogic)
        {
            this.studioLogic = studioLogic;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Studio> Get()
        {
            return studioLogic.ReadAllStudio();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Studio Get(int id)
        {
            return studioLogic.ReadStudio(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            studioLogic.CreateStudio(studio_id, founded, studio_name, founder, headquarters);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] int studio_id, string founded, string studio_name, string founder, string headquarters)
        {
            studioLogic.UpdateStudio(studio_id, founded, studio_name, founder, headquarters);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            studioLogic.DeleteStudio(id);
        }
    }
}
