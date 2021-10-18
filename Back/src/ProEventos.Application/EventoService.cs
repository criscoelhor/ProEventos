using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IBasePersistence _basePersistence;
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IMapper _mapper;

        public EventoService(IBasePersistence basePersistence, IEventoPersistence eventoPersistence, IMapper mapper)
        {
            _eventoPersistence = eventoPersistence;
            _basePersistence = basePersistence;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEvento(EventoDto eventoDto)
        {
            try
            {
                var evento = _mapper.Map<Evento>(eventoDto);

                _basePersistence.Add<Evento>(evento);

                if (await _basePersistence.SaveChangesAsync())
                {
                    var retorno = await _eventoPersistence.GetEventoByIdAsync(evento.Id);

                    return _mapper.Map<EventoDto>(retorno);   
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto eventoDto)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                if (evento == null) return null;

                eventoDto.Id = evento.Id;

                _mapper.Map(eventoDto, evento);

                _basePersistence.Update<Evento>(evento);

                if (await _basePersistence.SaveChangesAsync())
                {
                    var retorno = await _eventoPersistence.GetEventoByIdAsync(evento.Id);
                    return _mapper.Map<EventoDto>(retorno);                    
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
                if (evento == null)
                    throw new Exception("Evento não foi encontrado.");

                _basePersistence.Delete<Evento>(evento);
                return await _basePersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                 var dtos = _mapper.Map<EventoDto[]>(eventos);

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                var dtos = _mapper.Map<EventoDto[]>(eventos);

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                var dto = _mapper.Map<EventoDto>(evento);

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}