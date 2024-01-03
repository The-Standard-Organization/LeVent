// -------------------------------------------------------------------------------
// Copyright (c) The Standard Community, a coalition of the Good-Hearted Engineers 
// -------------------------------------------------------------------------------

using LeVent.Tests.Manual.Models.Students;

namespace LeVent.Tests.Manual.Services.Foundations.StudentLibraries
{
    public interface IStudentLibraryService
    {
        void RegisterStudentLibaryCard(Student student);
    }
}
