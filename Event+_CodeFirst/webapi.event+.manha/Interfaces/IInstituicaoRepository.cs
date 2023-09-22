using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastar(Instituicao instituicao);

        void Deletar(Guid id);

        void Atualizar(Guid id, Instituicao instituicao);

        List<Instituicao> Listar();

        Instituicao BuscarPorId(Guid id);
    }
}
