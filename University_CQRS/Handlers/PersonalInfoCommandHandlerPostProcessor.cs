﻿
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class PersonalInfoCommandHandlerPostProcessor : IRequestPostProcessor<EditPersonalInfoCommand, ResultDto>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public PersonalInfoCommandHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(EditPersonalInfoCommand request, ResultDto response, CancellationToken cancellationToken)
        {
            if (response.IsSuccess)
            {
                var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);
                readStudentModel.Name = request.Name;
                readStudentModel.Email = request.Email;
                _studentReadRepository.Save(readStudentModel);
            }

            return Task.CompletedTask;
        }
    }
}