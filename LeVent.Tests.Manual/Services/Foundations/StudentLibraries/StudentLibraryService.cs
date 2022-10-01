// -------------------------------------------------
// Copyright (c) PiorSoft, LLC. All rights reserved.
// -------------------------------------------------

using System;
using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Foundations.StudentLibraries
{
    public class StudentLibraryService : IStudentLibraryService
    {
        public void RegisterStudentLibaryCard(Student student) =>
            Console.WriteLine($"{student.Name} Library Card Registered");
    }
}
