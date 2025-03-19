using GerenciamentoUsuarios.Exceptions.ExceptionBase;

namespace GerenciamentoUsuarios.Exceptions.Execeptions
{
    public class UsuarioNotFoundException : UsuarioException
    {
        public UsuarioNotFoundException(string message) : base(message)
        {
        }
    }
}
