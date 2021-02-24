using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_AlunosVS.Library.Services.Interfaces;
using WebAPI_AlunosVS.Library.Entities;

namespace WebAPI_AlunosVS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public readonly IAlunoServices _IAlunoServices;

        public AlunoController(IAlunoServices IAlunoServices)
        {
            _IAlunoServices = IAlunoServices;
        }

        [HttpGet("GetAllAlunos")]
        public ActionResult<List<Aluno>> GetAlunos()
        {          
            var result = _IAlunoServices.GetAlunos().ToList();
            
            return Ok(result);
        }

        [HttpGet("GetAluno/{id}", Name = "GetAluno")]
        public ActionResult<Aluno> GetByIdAluno(string id)
        {
            if(id == "")
            {
                return BadRequest("AlunoId not found");
            }

            var result = _IAlunoServices.GetByIdAluno(Convert.ToInt32(id));

            return Ok(result);
        }

         [HttpPost]
         [Route("InsertAluno")]
         public IActionResult InsertAluno([FromBody]Aluno aluno)
         {
             if(aluno == null)
             {
                 return BadRequest("Aluno not found");
             }

             var result = _IAlunoServices.InsertAluno(aluno);

             return CreatedAtRoute("GetAluno",new { id = result },result);
         }

        
       
        [HttpPut("UpdateAluno/{id}")]
        public IActionResult UpdateAluno(int id,[FromBody] Aluno aluno)
        {
            if(id == 0)
            {
                return BadRequest("AlunoId not found");
            }

            if(aluno == null)
            {
                return BadRequest("Aluno not found");
            }

            _IAlunoServices.UpdateAluno(aluno);

            return NoContent();
        }

        [HttpDelete("DeleteAluno/{id}")]
        public IActionResult DeleteAluno(int id)
        {
            if(id == 0)
            {
                return BadRequest("AlunoId not found");
            }

            _IAlunoServices.DeleteAluno(Convert.ToInt32(id));

            return NoContent();
        }
    }
}