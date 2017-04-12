using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Mooooc.Models
{
    public class Degree
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float MeanValue { get; set; }
        
        [Ignore]
        public Course Course { get; set; }
    }
}
