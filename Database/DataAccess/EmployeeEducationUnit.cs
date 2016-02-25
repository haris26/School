using System.Data.Entity;

namespace Database
{
    public class EmployeeEducationUnit : Repository<EmployeeEducation>
    {
        public EmployeeEducationUnit(SchoolContext context) : base(context)
        { }

        public override void Insert(EmployeeEducation entity)
        {
            context.EmployeeEducations.Add(entity);
            context.Entry(entity.Employee).State = EntityState.Unchanged;
            context.Entry(entity.Education).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(EmployeeEducation entity, int id)
        {
            EmployeeEducation oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Employee = entity.Employee;
                oldEnt.Education = entity.Education;
                context.SaveChanges();
            }
        }
    }
}
