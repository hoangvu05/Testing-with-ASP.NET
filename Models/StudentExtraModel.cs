using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ContosoUniversity.Models;

public class StudentExtraModel
{
    public List<Student>? Student { get; set; }
    public SelectList? Title { get; set; }
    public SelectList? Grade { get; set; }
    public string? StudentTitle { get; set; }
    public string? StudentGrade { get; set; }
}