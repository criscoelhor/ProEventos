using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);

         Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    }
}