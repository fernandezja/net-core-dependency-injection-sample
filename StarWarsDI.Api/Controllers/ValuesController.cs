using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsDI.Business.Interfaces;
using StarWarsDI.Entities.Interfaces;

namespace StarWarsDI.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IPartyBusiness PartyBusiness { get; set; }
        private IVaso Vaso { get; set; }

        public ValuesController(IPartyBusiness partyBusiness,
                                IVaso vaso)
        {
            PartyBusiness = partyBusiness;
            Vaso = vaso;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            PartyBusiness.ServirAsync(Vaso);

            return new string[] { $"{Vaso.Contenido}", $"{Vaso.EstaLleno}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
