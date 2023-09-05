using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stage2023.Dto;
using Stage2023.Models;
using static Stage2023.Models.TypePoste;

namespace Stage2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePosteController : ControllerBase
    {
        private readonly McContext context;

        public TypePosteController(McContext context)
        {
            this.context = context;
        }
        [HttpPost("create")]
        public async Task<ActionResult<TypePoste>> create([FromBody] TypePosteDto typeposteDto)
        {

            try
            {
                if (typeposteDto == null)
                {

                    return BadRequest("Erreur");

                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("ModelState non valide ");
                }
                // Vérifier la contrainte
                var existingFamillePoste = await context.FamillePostes.FirstOrDefaultAsync(fp => fp.Code == typeposteDto.Code);
                if (existingFamillePoste != null)
                {
                    return BadRequest("Le code de famille de poste existe déjà");
                }
                TypePoste typePoste = new TypePoste(typeposteDto.Code, typeposteDto.Libelle, typeposteDto.Description, typeposteDto.IdFamilleposteFK);
                context.TypePostes.Add(typePoste);
                await context.SaveChangesAsync();

                return Ok(typePoste);

            }

            catch (Exception ex)
            {
                return StatusCode(500, "internal " + ex.Message);
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<TypePoste>> Get()
        {
            try
            {
                var typePostes = context.TypePostes.ToList();
                return Ok(typePostes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePoste>> GetById(long id)
        {
            try
            {
                var typePoste = await context.TypePostes.FindAsync(id);
                if (typePoste == null)
                {
                    return NotFound();
                }

                return Ok(typePoste);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var typePoste = await context.TypePostes.FindAsync(id);
                if (typePoste == null)
                {
                    return NotFound();
                }

                context.TypePostes.Remove(typePoste);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] TypePosteDto typeposteDto)
        {
            try
            {
                if (typeposteDto == null)
                {
                    return BadRequest("Erreur");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("ModelState non valide");
                }

                var typePoste = await context.TypePostes.FindAsync(id);
                if (typePoste == null)
                {
                    return NotFound();
                }
                var existingFamillePoste = await context.FamillePostes.FirstOrDefaultAsync(fp => fp.Code == typeposteDto.Code);
                if (existingFamillePoste != null)
                {
                    return BadRequest("Le code de famille de poste existe déjà");
                }

                typePoste.Code = typeposteDto.Code;
                typePoste.Libelle = typeposteDto.Libelle;
                typePoste.Description = typeposteDto.Description;
                typePoste.IdFamilleposteFK = typeposteDto.IdFamilleposteFK;

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }
        [HttpGet("countPostes")]
        public ActionResult<IEnumerable<object>> GetCountPostesByType()
        {
            try
            {
                var countPostesByType = context.TypePostes.Select(typePoste => new
                {
                    TypePoste = typePoste,
                    NombrePostes = context.Postes.Count(poste => poste.typePoste.id == typePoste.id)
                }).ToList();

                return Ok(countPostesByType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }


        }
    }

    }














    

