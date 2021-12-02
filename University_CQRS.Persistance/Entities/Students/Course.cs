
namespace University_CQRS.Persistance.Entities.Students
{
    public class Course : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int Credits { get; set; }
    }
}
