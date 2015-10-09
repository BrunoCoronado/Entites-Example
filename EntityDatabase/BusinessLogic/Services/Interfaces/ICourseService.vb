Namespace BusinessLogic.Services.Interfaces
    Public Interface ICourseService

        Function GetAllCourses() As IQueryable(Of Course)

        Sub CreateCourse(course As Course)

        Sub DeleteCourse(course As String)

        Sub EditCourse(course As Course)

        Function FindCourseByID(course As Integer)
    End Interface
End Namespace


