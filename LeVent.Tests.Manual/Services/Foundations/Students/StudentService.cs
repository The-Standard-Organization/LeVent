// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using System;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Foundations.Students
{
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student) =>
            Console.WriteLine($"{student.Name} Added.");
    }
}
