namespace University_CQRS.Contracts.Entities.Students
{
    public class StudentAggregate : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }

        public virtual int NumberOfEnrollments { get; set; }
        public virtual string FirstCourseName { get; set; }

        public virtual int? FirstCourseCredits { get; set; }
        public virtual string FirstCourseGrade { get; set; }

        public virtual string SecondCourseName { get; set; }

        public virtual int? SecondCourseCredits { get; set; }
        public virtual string SecondCourseGrade { get; set; }

    }
}
