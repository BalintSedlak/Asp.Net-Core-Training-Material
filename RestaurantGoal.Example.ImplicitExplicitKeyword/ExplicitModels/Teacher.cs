public class Teacher : Person
{
    public string Class { get; set; }
    public int IdContract { get; set; }

    public static explicit operator Pupil(Teacher prof)
    {
        return new Pupil { Name = prof.Name, Class = prof.Class, IdsCourse = new List<int>() };
    }
}
