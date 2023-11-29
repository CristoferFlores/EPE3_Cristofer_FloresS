using EPE3.Data.Repositories;
using EPE3.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPE3_Cristofer_FloresS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoControllers : ControllerBase
    {
        private readonly IMedicoRepositry _medicoRepositry;

        public MedicoControllers(IMedicoRepositry medicoRepositry)
        {
            _medicoRepositry = medicoRepositry;
        }
        [HttpGet]
        public async Task<IActionResult> GetALLMedico()
        {
            return Ok(await _medicoRepositry.GetALLMedicos());

        }
        [HttpGet("{IdMedico}")] 
        public async Task<IActionResult> GetMedicoDetails(int IdMedico)
        {
            return Ok(await _medicoRepositry.GetDetails(IdMedico));
        }
        [HttpPost]
        public async Task<IActionResult> CreateMedico([FromBody] Medico medico)
        {
            if (medico == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _medicoRepositry.InsertMedico(medico);
            return Created("created", created);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMedico([FromBody] Medico medico)
        {
            if (medico == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _medicoRepositry.UpdateMedico(medico);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMedico(int IdMedico)
        {
            await _medicoRepositry.DeleteMedico(new Medico { idMedico = IdMedico });
            return NoContent();
        }
    }
}
