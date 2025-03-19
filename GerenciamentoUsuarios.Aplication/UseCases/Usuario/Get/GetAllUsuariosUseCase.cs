using GerenciamentoUsuarios.Communication.Responses;
using GerenciamentoUsuarios.Infrastructure;
using GerenciamentoUsuarios.Infrastructure.Entities;

namespace GerenciamentoUsuarios.Aplication.UseCases.Usuario.Get
{
    public class GetAllUsuariosUseCase
    {
        public ResponseUsuariosDetailsJson Execute() {
            var dbContext = new UsuariosDbContext();
            var usuarios = dbContext.Usuarios.ToList();

            return new ResponseUsuariosDetailsJson
            {
                ListaUsuarios = usuarios.Select(usuario => new Usuarios
                {
                    ID = usuario.ID,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Idade = usuario.Idade
                }).ToList()
            };
        }
    }
}
