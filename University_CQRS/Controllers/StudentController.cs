using MediatR;
using Microsoft.AspNetCore.Mvc;
using University_CQRS.Commands;

namespace University
{
    [Route("api/students")]
    public sealed class StudentController : Controller
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetList(string enrolled, int? numberOfCourses)
        {
            var result =  _mediator.Send(new GetListQuery(enrolled, numberOfCourses));

            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult Register([FromBody] NewStudentDto dto)
        {
            var result = _mediator.Send(new RegisterCommand(
                 dto.Name, dto.Email,
                 dto.Course1, dto.Course1Grade,
                 dto.Course2, dto.Course2Grade));

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public IActionResult Unregister(long id)
        {
            var result = _mediator.Send(new UnregisterCommand(id));
            return Ok(result.Result);
        }

        [HttpPost("{id}/enrollments")]
        public IActionResult Enroll(long id, [FromBody] StudentEnrollmentDto dto)
        {
            var result = _mediator.Send(new EnrollCommand(id, dto.Course, dto.Grade));
            return Ok(result.Result);
        }

        [HttpPut("{id}/enrollments/{enrollmentIndex}")]
        public IActionResult Transfer(
          long id, int enrollmentIndex, [FromBody] StudentTransferDto dto)
        {
            var result = _mediator.Send(new TransferCommand(id, enrollmentIndex, dto.Course, dto.Grade));
            return Ok(result.Result);
        }

        [HttpPost("{id}/enrollments/{enrollmentIndex}/disenroll")]
        public IActionResult Disenroll(
           long id, int enrollmentNumber, [FromBody] StudentDisenrollmentDto dto)
        {
            var result = _mediator.Send(new DisenrollCommand(id, enrollmentNumber, dto.Comment));
            return Ok(result.Result);
        }

        [HttpPut("{id}")]
        public IActionResult EditPersonalInfo(long id, [FromBody] StudentPersonalInfoDto dto)
        {
            var result = _mediator.Send(new EditPersonalInfoCommand(id, dto.Name, dto.Email));
            return Ok(result.Result);
        }
    }
}
