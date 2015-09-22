Namespace BusinessLogic.Services.Interfaces
    Public Interface ICourseService

        Function GetAllCourses() As IQueryable(Of Course)

        Function CoursesInDepartments() As Course

    End Interface
End Namespace
