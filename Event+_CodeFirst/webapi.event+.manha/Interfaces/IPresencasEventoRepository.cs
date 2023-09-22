using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void ParticiparEvento(Guid eventoID, Guid usuarioId);

        void CancelarParticipacao(Guid eventoId, Guid usuarioId);
        List<PresencasEvento> ListarPresencas(Guid usuarioId);
    }
}
 