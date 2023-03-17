// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Tests.Manual.Models.Students;
using System;

namespace LeVent.Tests.Manual.Services.Foundations.Students
{
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student) =>
            Console.WriteLine($"{student.Name} Added.");
    }
}
