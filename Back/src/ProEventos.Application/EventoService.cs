using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IBasePersistence _basePersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IBasePersistence basePersistence, IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
            _basePersistence = basePersistence;

        }

        public async Task<Evento> AddEvento(Evento evento)
        {
            try
            {
                _basePersistence.Add<Evento>(evento);
                if(await _basePersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(evento.Id);
                }
                return null;
            }
            catch (Exception ex)
            {               
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var eventoConsultado = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                if(eventoConsultado == null) return null;

                evento.Id = eventoConsultado.Id;

                _basePersistence.Update(evento);
                 if(await _basePersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(evento.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                if(evento == null) 
                    throw new Exception("Evento não foi encontrado.");

                _basePersistence.Delete<Evento>(evento);
                return await _basePersistence.SaveChangesAsync();         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if(evento == null) return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}