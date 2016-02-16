
namespace Database
{
    public class Engagement
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public virtual Person Person { get; set; }
        public virtual Role Role { get; set; }
        public virtual Team Team { get; set; }
    }
}
