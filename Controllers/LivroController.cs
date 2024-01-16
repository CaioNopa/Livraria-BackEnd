using Livro.Data;
using Livro.Models;
using Microsoft.AspNetCore.Mvc;

namespace livro.Controller
{
    [ApiController]
    public class livroController: ControllerBase
    {
         //todos os metodos(post,get...)


        [HttpGet("/")]
        public IActionResult Get([FromServices]AppDbContext context){

            return Ok(context.Livros.ToList());
        }

         [HttpPost("/")]
        public IActionResult Post([FromBody]LivroModel umLivro,[FromServices]AppDbContext context){

            context.Livros.Add(umLivro);
            context.SaveChanges();
            return Created($"/{umLivro.Id}",umLivro);
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices]AppDbContext context
        )
        {
            var livro = context.Livros.Find(id);

            if(livro is null) return NotFound();

            return Ok(livro);
        }

        [HttpPut("/{id:int}")]
          public IActionResult Put(
            [FromRoute] int id,
            [FromBody] LivroModel umLivro,
            [FromServices]AppDbContext context
        )
        {
            var livro = context.Livros.Find(id);

            if(livro is null) return NotFound();

            livro.Editora = umLivro.Editora;
            livro.Titulo = umLivro.Titulo;
            livro.Ano = umLivro.Ano;
            livro.Autor = umLivro.Autor;
            livro.QtdEstoque = umLivro.QtdEstoque;

            context.SaveChanges();

            return Accepted();
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
        [FromRoute] int id,
        [FromServices] AppDbContext context
        )
        {   
            var livro = context.Livros.Find(id);

            if(livro is null) return NotFound();

            context.Livros.Remove(livro);
            context.SaveChanges();

            return Accepted();
        }
        
         [HttpGet("/{editora}")]
         public IActionResult GetByEditora(
             [FromRoute] string editora,
             [FromServices]AppDbContext context
         )
         {
             var livro = context.Livros.Where(livro => livro.Editora == editora);

             if(livro is null) return NotFound();

             return Ok(livro);
         }

         [HttpGet("/addEstoque/{alterar:int}/{id:int}")]
        public IActionResult AdicionarEstoque([FromRoute]int alterar, [FromRoute]int id, [FromServices]AppDbContext context)
        {
            var livro = context.Livros.Find(id);
            if(livro is null){
                return NotFound();
            }
            livro.QtdEstoque = livro.QtdEstoque + alterar;
            context.SaveChanges();
            return Ok(livro);
        }
        
        [HttpGet("/removeEstoque/{alterar:int}/{id:int}")]
        public IActionResult RemoverEstoque([FromRoute]int alterar, [FromRoute]int id, [FromServices]AppDbContext context)
        {
            var livro = context.Livros.Find(id);
            if(livro is null){
                return NotFound();
            }
            livro.QtdEstoque = livro.QtdEstoque - alterar;
            context.SaveChanges();
            return Ok(livro);
        }
    }
}