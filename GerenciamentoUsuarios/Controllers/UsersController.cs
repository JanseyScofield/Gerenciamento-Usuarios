using Microsoft.AspNetCore.Mvc;
using GerenciamentoUsuarios.Communication.Requests;
using GerenciamentoUsuarios.Communication.Responses;
using GerenciamentoUsuarios.Exceptions;
using GerenciamentoUsuarios.Aplication;
using GerenciamentoUsuarios.Aplication.UseCases.Usuario.Register;
using GerenciamentoUsuarios.Exceptions.ExceptionBase;

namespace GerenciamentoUsuarios.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Endpoint para cadastrar um usuário. Recebe no corpo da requisição os dados de Nome,
        //Email e Idade e retorna o usuário criado.
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUsuarioDetailsJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarUsuario([FromBody] RequestRegisterUsuariosJson request)
        {
            try
            {
                var useCase = new RegisterUsuarioUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
