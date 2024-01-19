namespace BackendApi.Controllers
{
    public class Discipline
    {
        public int IdDiscipline { get; set; }
        public string NameDiscipline { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int NumCourse { get; set; }
    }
}
