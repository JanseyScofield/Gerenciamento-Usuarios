using GerenciamentoUsuarios.Communication.Requests;
using GerenciamentoUsuarios.Communication.Responses;
using GerenciamentoUsuarios.Exceptions.ExceptionBase;
using GerenciamentoUsuarios.Exceptions;
using GerenciamentoUsuarios.Infrastructure;
using GerenciamentoUsuarios.Infrastructure.Entities;


namespace GerenciamentoUsuarios.Aplication.UseCases.Usuario.Register
{
    public class RegisterUsuarioUseCase
    {
        public ResponseUsuarioDetailsJson Execute(RequestRegisterUsuariosJson request)
        {
            Validate(request);
            var dbContext = new UsuariosDbContext();
            var entity = new Usuarios { 
                Nome = request.Nome,
                Email = request.Email,
                Idade = request.Idade
            };

            dbContext.Usuarios.Add(entity);
            dbContext.SaveChanges();
            return new ResponseUsuarioDetailsJson { 
                ID = entity.ID,
                Nome = entity.Nome,
                Email = entity.Email,
                Idade = entity.Idade
            };
        }

        private void Validate(RequestRegisterUsuariosJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
            {
                throw new UsuarioException(ResourceErrorMessages.NOME_INVALIDO);
            }

            if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains(".com") || !request.Email.Contains("@"))
            {
                throw new UsuarioException(ResourceErrorMessages.EMAIL_INVALIDO);
            }

             

            if (request.Idade <= 0)
            {
                throw new UsuarioException(ResourceErrorMessages.IDADE_INVALIDA);
            }

        }
    }
}
