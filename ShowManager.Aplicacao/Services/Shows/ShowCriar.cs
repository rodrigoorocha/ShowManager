using AutoMapper;
using FluentValidation;
using MediatR;
using ShowManager.Dominio.Features.Organizadores;
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
        public string NomeShow { get; set; } = string.Empty;
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public int OrganizadorId { get; set; }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(b => b.NomeShow)
                    .NotEmpty().WithMessage("O nome do show é obrigatório")
                    .MaximumLength(200).WithMessage("O nome do show deve ter no máximo 200 caracteres");

                RuleFor(b => b.DataInicio)
                    .NotEmpty().WithMessage("A data de início é obrigatória");

                RuleFor(b => b.DataFim)
                    .GreaterThanOrEqualTo(b => b.DataInicio)
                    .WithMessage("A data de fim deve ser maior ou igual à data de início");

                RuleFor(b => b.OrganizadorId)
                    .GreaterThan(0).WithMessage("O ID do organizador é obrigatório e deve ser maior que zero");
            }
        }
    }

    public class Handler() : IRequestHandler<Command, Unit>
    {
        private readonly IShowRepository _showRepository;
        private readonly IOrganizadorRepository _organizadorRepository;
        private readonly IMapper _mapper;

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var organizador = await _organizadorRepository.BuscarPorIdAsync(request.OrganizadorId);
            if (organizador == null)
            {
                throw new Exception("Organizador not found");
            }

            var show = _mapper.Map<Show>(request);
            await _showRepository.Adicionar(show, true);
            return Unit.Value;
        }
    }
}