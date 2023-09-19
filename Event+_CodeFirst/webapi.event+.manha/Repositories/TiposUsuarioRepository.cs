using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Variavel privada somente para leitura para armazenar os dados do contexto
        /// </summary>
        private readonly EventContext ctx;
        /// <summary>
        /// Construtor do repositorio
        /// Toda vez que o repositorio for iinstanciado
        /// Ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public TiposUsuarioRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            ctx.TiposUsuarios.Add(tipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
