using System.Data.Entity;

namespace Database
{
    public class EmployeeSkillUnit : Repository<EmployeeSkill>
    {
        public EmployeeSkillUnit(SchoolContext context) : base (context)
        { } 

        public override void Insert (EmployeeSkill entity)
        {
            context.EmployeeSkills.Add(entity);
            context.Entry(entity.Employee).State = EntityState.Unchanged;
            context.Entry(entity.Tool).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(EmployeeSkill entity, int id)
        {
            EmployeeSkill oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Employee = entity.Employee;
                oldEnt.Tool = entity.Tool;
                context.SaveChanges();
            }
        }
    }
}
