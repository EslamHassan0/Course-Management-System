﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.DataAccess.Entities
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
