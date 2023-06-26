public class Pupil : Person
{
    public string Class { get; set; }
    public List<int> IdsCourse { get; set; }

    public static explicit operator Teacher(Pupil alum)
    {
        return new Teacher { Name = alum.Name, Class = alum.Class, IdContract = -1 };
    }
}
