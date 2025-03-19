using GerenciamentoUsuarios.Infrastructure.Entities;

namespace GerenciamentoUsuarios.Communication.Responses
{
    public class ResponseUsuariosDetailsJson
    {
       public IList<Usuarios> ListaUsuarios { get; set; }
    }
}
