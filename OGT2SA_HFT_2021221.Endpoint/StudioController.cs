using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OGT2SA_HFT_2021221.Endpoint.Services;
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
        IStudioLogic studioLogic; IHubContext<SignalRHub> hub;
        public StudioController(IStudioLogic studioLogic, IHubContext<SignalRHub> hub)
        {
            this.studioLogic = studioLogic;
            this.hub = hub;
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
        public void Post([FromBody] Studio studio)
        {
            studioLogic.CreateStudio(studio.studio_id, studio.founded, studio.studio_name, studio.founder, studio.headquarters);
            hub.Clients.All.SendAsync("StudioCreated", studio);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Studio studio)
        {
            studioLogic.UpdateStudio(studio.studio_id, studio.founded, studio.studio_name, studio.founder, studio.headquarters);
            hub.Clients.All.SendAsync("StudioUpdated", studio);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studio = this.studioLogic.ReadStudio(id);
            studioLogic.DeleteStudio(id);
            hub.Clients.All.SendAsync("StudioDeleted", studio);
        }
    }
}
