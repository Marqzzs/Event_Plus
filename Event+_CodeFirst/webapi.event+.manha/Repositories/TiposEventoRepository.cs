using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext ctx;

        public TiposEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, TiposEvento tiposEvento)
        {
            TiposEvento tipoBuscado = ctx.TiposEvento.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tiposEvento.Titulo;
            }

            ctx.TiposEvento.Update(tipoBuscado!);

            ctx.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            return ctx.TiposEvento.FirstOrDefault(t => t.IdTipoEvento == id)!;
        }

        public void Cadastrar(TiposEvento tiposEvento)
        {
            ctx.TiposEvento.Add(tiposEvento);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tipoBuscado = ctx.TiposEvento.Find(id)!;

            ctx.TiposEvento.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {
            return ctx.TiposEvento.ToList();
        }
    }
}