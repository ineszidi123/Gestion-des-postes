using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stage2023.Dto;
using Stage2023.Models;

namespace Stage2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamillePosteController : ControllerBase
    {
        private readonly McContext context;

        public FamillePosteController(McContext context)
        {
            this.context = context;
        }
        [HttpPost("create")]
        public async Task<ActionResult<FamillePoste>> create([FromBody] FamillePosteDto familleposteDto)
        {

            try
            {
                if (familleposteDto == null)
                {

                    return BadRequest("Erreur");

                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("ModelState non valide ");
                }
                var existingFamillePoste = await context.FamillePostes.FirstOrDefaultAsync(p => p.Code == familleposteDto.Code);
                if (existingFamillePoste != null)
                {
                    return BadRequest("Le nom de réseau du famille de poste existe déjà");
                }
                FamillePoste FamillePoste = new FamillePoste(familleposteDto.Code,familleposteDto.Libelle);
                context.FamillePostes.Add(FamillePoste);
              await  context.SaveChangesAsync();
                return Ok(FamillePoste);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal " + ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<FamillePoste>> Get()
        {
            try
            {
                var famillePostes = context.FamillePostes.ToList();
                return Ok(famillePostes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FamillePoste>> GetById(long id)
        {
            try
            {
                var famillePoste = await context.FamillePostes.FindAsync(id);
                if (famillePoste == null)
                {
                    return NotFound();
                }

                return Ok(famillePoste);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var famillePoste = await context.FamillePostes.FindAsync(id);
                if (famillePoste == null)
                {
                    return NotFound();
                }

                context.FamillePostes.Remove(famillePoste);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] FamillePosteDto famillePosteDto)
        {
            try
            {
                if (famillePosteDto == null)
                {
                    return BadRequest("Erreur");
                }

                var famillePoste = await context.FamillePostes.FindAsync(id);
                if (famillePoste == null)
                {
                    return NotFound();
                }
                var existingFamillePoste = await context.FamillePostes.FirstOrDefaultAsync(p => p.Code == famillePosteDto.Code);
                if (existingFamillePoste != null && existingFamillePoste.id!=id)
                {
                    return BadRequest("Le nom de réseau du famille de poste existe déjà");
                }

                famillePoste.Code = famillePosteDto.Code;
                famillePoste.Libelle = famillePosteDto.Libelle;

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }

        
    }
}
