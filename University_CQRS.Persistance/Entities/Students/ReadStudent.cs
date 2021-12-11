
public class ReadStudent : EntityBase
{
    public virtual string SSN { get; set; }
    public  virtual string Name { get; set; }
    public virtual string Email { get; set; }

    public virtual int NumberOfCourses { get; set; }

    public virtual string Course1 { get; set; }
    public virtual string Course1Grade { get; set; }
    public virtual string Course1DisenrollmentComment { get; set; }
    public virtual int? Course1Credits { get; set; }

    public virtual string Course2 { get; set; }
    public virtual string Course2Grade { get; set; }
    public virtual string Course2DisenrollmentComment { get; set; }
    public virtual int? Course2Credits { get; set; }
}

