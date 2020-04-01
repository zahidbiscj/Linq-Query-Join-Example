using System;
using System.Collections.Generic;
using System.Text;

namespace FirstCodingExample
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string CourseId { get; set; }
        public double CG{ get; set; }
    }
}
