using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;



namespace Mooooc.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Duration { get; set; }
        public int Semestre { get; set; }

        [Ignore]
        public List<Teacher> Teachers
        {
            get {
                return App._db.Query<Teacher>("Select * from Course C JOIN TeacherCourse TC on C.ID = TC.CourseId JOIN Teacher T on T.ID = TC.TeacherId where C.ID = ? Order By T.LastName ASC", this.ID ).ToList();
            }
        }

        [Ignore]
        public List<Student> Students
        {
            get
            {
                return App._db.Query<Student>("Select * from Course C JOIN StudentCourse SC on C.ID = SC.CourseId JOIN Student S on S.ID = SC.StudentId where C.ID = ? Order By S.LastName ASC", this.ID).ToList();
            }
        }
        public string GetAbbreviation()
        {
            string[] tab = Name.Split(' ');
            string abr = "";
            foreach (var word in tab)
            {
                abr += word[0].ToString();
            }
            return abr.ToUpper();
        }

        public void DeleteTeacher(int id)
        {
            App._db.Query<Teacher>("delete from TeacherCourse where TeacherId = ?", id);
        }
    }
}
