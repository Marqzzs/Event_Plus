using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly EventContext ctx;
        public ComentariosEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Comentar(ComentariosEvento comentario)
        {
            ctx.ComentariosEvento.Add(comentario);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentariosEvento comentario = ctx.ComentariosEvento.Find(id)!;

            ctx.ComentariosEvento.Remove(comentario);

            ctx.SaveChanges();
        }

        public List<ComentariosEvento> ListarPorEvento(Guid id)
        {
            return ctx.ComentariosEvento.Where(c => c.IdEvento == id).ToList();
        }
    }
}
