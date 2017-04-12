using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Mooooc.Models
{
    public  class Student : IUser
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Degree> GetDegrees(int courseId)
        {
            return App._db.Query<Degree>("Select * from Degree where StudentId = ?  AND CourseId = ?", this.ID, courseId).ToList();
        }

        public List<Course> GetCourses()
        {
            return App._db.Query<Course>("Select * from ( Select * from Degree Group By StudentId, CourseId ) d JOIN Course c ON d.CourseId = c.ID where d.StudentId = ?", this.ID).ToList();
        }

    }
}
