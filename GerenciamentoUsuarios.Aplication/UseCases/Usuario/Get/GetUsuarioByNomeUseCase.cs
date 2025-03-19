using GerenciamentoUsuarios.Communication.Responses;
using GerenciamentoUsuarios.Exceptions.ExceptionBase;
using GerenciamentoUsuarios.Exceptions;
using GerenciamentoUsuarios.Infrastructure;
using GerenciamentoUsuarios.Exceptions.Execeptions;

namespace GerenciamentoUsuarios.Aplication.UseCases.Usuario.Get
{
    public class GetUsuarioByNomeUseCase
    {
        public ResponseUsuarioDetailsJson Execute(string nome)
        {
            Validate(nome);
            var dbContext = new UsuariosDbContext();
            var usuario = dbContext.Usuarios.FirstOrDefault(u => u.Nome.ToLower() == nome.ToLower());

            if(usuario == null)
            {
                throw new UsuarioNotFoundException(ResourceErrorMessages.USUARIO_NAO_ENCONTRADO);
            }

            return new ResponseUsuarioDetailsJson { 
                ID = usuario.ID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Idade = usuario.Idade
            };
        }

        private void Validate(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new UsuarioException(ResourceErrorMessages.NOME_INVALIDO);
            }

        }
    }
}
