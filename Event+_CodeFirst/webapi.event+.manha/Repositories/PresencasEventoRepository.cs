using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext ctx;
        public PresencasEventoRepository()
        {
            ctx = new EventContext();
        }
        public void CancelarParticipacao(Guid eventoId, Guid usuarioId)
        {
            var presenca = ctx.Presencas.FirstOrDefault(p => p.IdEvento == eventoId && p.IdUsuario == usuarioId)!;

            if (presenca == null)
            {
                ctx.Presencas.Remove(presenca);
                ctx.SaveChanges();
            }
        }

        public List<PresencasEvento> ListarPresencas(Guid usuarioId)
        {
            return ctx.Presencas.Where(i => i.IdUsuario == usuarioId).ToList();
        }

        public void ParticiparEvento(Guid eventoID, Guid usuarioId)
        {
            var presenca = new PresencasEvento
            {
                IdEvento = eventoID,
                IdUsuario = usuarioId
            };

            ctx.Presencas.Add(presenca);
            ctx.SaveChanges();
        }
    }
}
