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
            TiposUsuario tipoBuscado = ctx.TiposUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoUsuario.Titulo;
            }

            ctx.TiposUsuario.Update(tipoBuscado!);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            return ctx.TiposUsuario.FirstOrDefault(t => t.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            ctx.TiposUsuario.Add(tipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuario.Find(id)!;

            ctx.TiposUsuario.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }
    }
}
