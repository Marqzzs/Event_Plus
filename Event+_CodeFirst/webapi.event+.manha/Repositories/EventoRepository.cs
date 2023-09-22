using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;
        public EventoRepository()
        {
            ctx= new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = ctx.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;

                ctx.Evento.Update(eventoBuscado);
            }
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return ctx.Evento.FirstOrDefault(e => e.IdEvento == id)!;
        }

        public void Cadastrar(Evento evento)
        {
            ctx.Evento.Add(evento);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoBusacado = ctx.Evento.Find(id)!;

            ctx.Evento.Remove(eventoBusacado!);

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
