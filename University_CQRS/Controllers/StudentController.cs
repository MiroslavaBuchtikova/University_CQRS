using MediatR;
using Microsoft.AspNetCore.Mvc;
using University_CQRS.Commands;
using University_CQRS.Queries;

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

        [HttpDelete("{studentId}")]
        public IActionResult Unregister(long studentId)
        {
            var result = _mediator.Send(new UnregisterCommand(studentId));
            return Ok(result.Result);
        }

        [HttpPost("{studentId}/enrollments")]
        public IActionResult Enroll(long studentId, [FromBody] StudentEnrollmentDto dto)
        {
            var result = _mediator.Send(new EnrollCommand(studentId, dto.Course, dto.Grade));
            return Ok(result.Result);
        }

        [HttpPut("{studentId}/enrollments/{enrollmentIndex}")]
        public IActionResult Transfer(
          long studentId, int enrollmentIndex, [FromBody] StudentTransferDto dto)
        {
            var result = _mediator.Send(new TransferCommand(studentId, enrollmentIndex, dto.Course, dto.Grade));
            return Ok(result.Result);
        }

        [HttpPost("{studentId}/enrollments/{enrollmentIndex}/disenroll")]
        public IActionResult Disenroll(
           long studentId, int enrollmentNumber, [FromBody] StudentDisenrollmentDto dto)
        {
            var result = _mediator.Send(new DisenrollCommand(studentId, enrollmentNumber, dto.Comment));
            return Ok(result.Result);
        }

        [HttpPut("{studentId}")]
        public IActionResult EditPersonalInfo(long studentId, [FromBody] StudentPersonalInfoDto dto)
        {
            var result = _mediator.Send(new EditPersonalInfoCommand(studentId, dto.Name, dto.Email));
            return Ok(result.Result);
        }
    }
}
