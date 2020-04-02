using Microsoft.AspNetCore.Mvc;
using MetingApi.DTOs;
using MetingApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;

namespace MetingApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MetingController : ControllerBase
    {
        private readonly IMetingRepository _metingRepository;

        public MetingController(IMetingRepository context)
        {
            _metingRepository = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<Meting> GetMetingen(string resultaatType = null)
        {
            if (string.IsNullOrEmpty(resultaatType))
                return _metingRepository.GetAll();
            return _metingRepository.GetBy(resultaatType);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Meting> GetMeting(int id)
        {
            Meting meting = _metingRepository.GetBy(id);
            if (meting == null) return NotFound();
            return meting;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Meting> PostMeting(MetingDTO meting)
        {
            Meting metingToCreate = new Meting() { };
            foreach (var i in meting.Resultaten)
                metingToCreate.AddResultaat(new Resultaat(i.Type, i.Amount));
            _metingRepository.Add(metingToCreate);
            _metingRepository.SaveChanges();

            return CreatedAtAction(nameof(GetMeting), new { id = metingToCreate.Id }, metingToCreate);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult PutMeting(int id, Meting meting)
        {
            if (id != meting.Id)
            {
                return BadRequest();
            }
            _metingRepository.Update(meting);
            _metingRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult DeleteMeting(int id)
        {
            Meting meting = _metingRepository.GetBy(id);
            if (meting == null)
            {
                return NotFound();
            }
            _metingRepository.Delete(meting);
            _metingRepository.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/resultaten/{resultaatId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Resultaat> GetResultaat(int id, int resultaatId)
        {
            if (!_metingRepository.TryGetMeting(id, out var meting))
            {
                return NotFound();
            }
            Resultaat resultaat = meting.GetResultaat(resultaatId);
            if (resultaat == null)
                return NotFound();
            return resultaat;
        }

        [HttpPost("{id}/resultaten")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Resultaat> PostResultaat(int id, ResultaatDTO resultaat)
        {
            if (!_metingRepository.TryGetMeting(id, out var meting))
            {
                return NotFound();
            }
            var resultaatToCreate = new Resultaat(resultaat.Type, resultaat.Amount);
            meting.AddResultaat(resultaatToCreate);
            _metingRepository.SaveChanges();
            return CreatedAtAction("Getresultaat", new { id = meting.Id, resultaatId = resultaatToCreate.Id }, resultaatToCreate);
        }
    }
}
