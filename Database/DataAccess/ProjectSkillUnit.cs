using System.Data.Entity;

namespace Database
{
    public class ProjectSkillUnit : Repository<ProjectSkill>
    {
        public ProjectSkillUnit(SchoolContext context) : base(context)
        { }

        public override void Insert(ProjectSkill entity)
        {
            context.ProjectSkills.Add(entity);
            context.Entry(entity.Team).State = EntityState.Unchanged;
            context.Entry(entity.Tool).State = EntityState.Unchanged;
            context.SaveChanges();
        }

        public override void Update(ProjectSkill entity, int id)
        {
            ProjectSkill oldEnt = Get(id);
            if (oldEnt != null)
            {
                context.Entry(oldEnt).CurrentValues.SetValues(entity);
                oldEnt.Team = entity.Team;
                oldEnt.Tool = entity.Tool;
                context.SaveChanges();
            }
        }
    }
}
