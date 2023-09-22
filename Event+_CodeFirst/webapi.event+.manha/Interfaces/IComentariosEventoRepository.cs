using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IComentariosEventoRepository
    {
        void Comentar(ComentariosEvento comentario);

        void Deletar(Guid id);

        List<ComentariosEvento> ListarPorEvento(Guid id);
    }
}
