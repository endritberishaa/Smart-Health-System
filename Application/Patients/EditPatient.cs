using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Patients
{
    public class EditPatient
    {

        public class Command : IRequest
        {
            public Patient Patient { get; set; }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;
                public Handler(DataContext context, IMapper mapper)
                {
                    _mapper = mapper;
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var patient = await _context.Patients.FindAsync(request.Patient.Id);

                    patient.Name = request.Patient.Name?? patient.Name;
                    patient.LastName = request.Patient.LastName?? patient.LastName;
                    patient.BirthDate = request.Patient.BirthDate ?? patient.BirthDate;
                    patient.Address = request.Patient.Address?? patient.Address;
                    patient.PhoneNumber = request.Patient.PhoneNumber?? patient.PhoneNumber;
                    patient.Language = request.Patient.Language?? patient.Language;
                    patient.Profession = request.Patient.Profession?? patient.Profession;
                    
                    await _context.SaveChangesAsync();

                    return Unit.Value;
                }
            }
        }
    }
}
