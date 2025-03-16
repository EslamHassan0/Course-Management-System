using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Application.DTO
{
    public class ResponseDTO<T>
    {
        public IReadOnlyList<T> items { get; set; }
        public int TotalCount { get; set; }
    }
}
