using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx= new EventContext();
        }
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao instituto = ctx.Instituicao.Find(id)!;

            if (instituto != null)
            {
                instituto.CNPJ = instituicao.CNPJ;
                instituto.Endereco = instituicao.Endereco;
                instituto.NomeFantasia = instituto.NomeFantasia;
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return ctx.Instituicao.FirstOrDefault(i => i.IdInstituicao == id)!;
        }

        public void Cadastar(Instituicao instituicao)
        {
            ctx.Instituicao.Add(instituicao);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicao = ctx.Instituicao.Find(id)!;

            ctx.Instituicao.Remove(instituicao);

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
