using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento tiposEvento);

        void Deletar(Guid id);

        List<TiposEvento> Listar();

        TiposEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposEvento tiposEvento);
    }
}
