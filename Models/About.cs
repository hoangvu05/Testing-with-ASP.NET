using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class About
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
