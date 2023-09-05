using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Stage2023.Dto;
using Stage2023.Models;

namespace Stage2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosteController : ControllerBase
    {
        private readonly McContext context;

        public PosteController(McContext context)    
        {
            this.context = context;
        }
        [HttpPost("create")]
        public async Task<ActionResult<Poste>> create([FromBody]PosteDto posteDto)
        {

            try
            {
                if(posteDto == null)
                {

                    return BadRequest("Erreur");

                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("ModelState non valide "); 
                }
                // Vérifier la contrainte
                var existingPoste = await context.Postes.FirstOrDefaultAsync(p => p.Nomreseau == posteDto.Nomreseau);
                if (existingPoste != null)
                {
                    return BadRequest("Le nom de réseau du poste existe déjà");
                }
                Poste poste = new Poste(posteDto.IdTypeposteFK, posteDto.Nomreseau, posteDto.Libelle, posteDto.Actif);

                _ = context.Postes.Add(poste);
                await context.SaveChangesAsync();

                return Ok(poste);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500,"internal "+ex.Message) ;
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<Poste>> Get()
        {
            try
            {
                var postes = context.Postes.ToList();
                return Ok(postes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Poste>> GetById(long id)
        {
            try
            {
                var poste = await context.TypePostes.FindAsync(id);
                if (poste == null)
                {
                    return NotFound();
                }

                return Ok(poste);
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
                var poste = await context.TypePostes.FindAsync(id);
                if (poste == null)
                {
                    return NotFound();
                }

                context.TypePostes.Remove(poste);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] PosteDto posteDto)
        {
            try
            {
                if (posteDto == null)
                {
                    return BadRequest("Erreur");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("ModelState non valide");
                }

                var poste = await context.Postes.FindAsync(id);
                if (poste == null)
                {
                    return NotFound();
                }
                var existingPoste = await context.Postes.FirstOrDefaultAsync(p => p.Nomreseau == posteDto.Nomreseau);
                if (existingPoste != null && existingPoste.id!=id)                {
                    return BadRequest("Le nom de réseau du poste existe déjà");
                }

                

                    poste.IdTypeposteFK = posteDto.IdTypeposteFK;
                    poste.Nomreseau = posteDto.Nomreseau;
                    poste.Libelle = posteDto.Libelle;
                    poste.Actif = posteDto.Actif;

                


                await context.SaveChangesAsync();

                return NoContent();
                
            }
            catch (Exception ex)
            {
               return StatusCode(500, "Internal " + ex.Message+ex.InnerException);
            }
        }

        [HttpGet("groupedByType")]
        public ActionResult<IEnumerable<object>> GetPostesGroupedByType()
        {
            try
            {
                var postesGroupedByType = (from poste in context.Postes
                                           join typePoste in context.TypePostes on poste.typePoste.id equals typePoste.id
                                           group poste by typePoste into groupe
                                           select new
                                           {
                                               TypePoste = groupe.Key,
                                               Postes = groupe.ToList(),
                                               PostesCount = groupe.ToList().Count
                                           }).ToList();

                return Ok(postesGroupedByType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);



            }
        }
        [HttpGet("nomreseau/{nomreseau}")]
        public ActionResult<Poste> GetPosteByNomReseau(string nomreseau)
        {
            try
            {
                var poste = context.Postes.FirstOrDefault(p => p.Nomreseau == nomreseau);

                if (poste == null)
                {
                    return NotFound(); 
                }

                return Ok(poste); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal " + ex.Message);
            }
        }












    }
}
