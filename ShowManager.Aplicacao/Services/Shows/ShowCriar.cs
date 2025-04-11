using AutoMapper;
using MediatR;
using ShowManager.Dominio.Features.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Aplicacao.Services.Shows;

public class ShowCriar
{
    public class Command : IRequest<Unit>
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Local { get; set; } = string.Empty;
    }

    public class Handler() : IRequestHandler<Command, Unit>
    {
        private readonly IShowRepository _showRepository;
        private readonly IMapper _mapper;



        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var show = _mapper.Map<Show>(request);
            await _showRepository.Adicionar(show, true);
            return Unit.Value;
        }

    }
}
