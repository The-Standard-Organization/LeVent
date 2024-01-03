// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

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