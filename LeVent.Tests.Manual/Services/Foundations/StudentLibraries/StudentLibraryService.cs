// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using LeVent.Tests.Manual.Models.Students;
using System;

namespace LeVent.Tests.Manual.Services.Foundations.StudentLibraries
{
    public class StudentLibraryService : IStudentLibraryService
    {
        public void RegisterStudentLibaryCard(Student student) =>
            Console.WriteLine($"{student.Name} Library Card Registered");
    }
}
