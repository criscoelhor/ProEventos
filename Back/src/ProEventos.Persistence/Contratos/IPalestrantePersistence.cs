using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersistence
    {
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);

    }
}