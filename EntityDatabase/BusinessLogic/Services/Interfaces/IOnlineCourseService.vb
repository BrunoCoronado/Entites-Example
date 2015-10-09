Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnlineCourseService

        Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse)

        Sub CreateOnlineCourse(onlineCourse As OnlineCourse)

        Sub EditOnlineCourse(onlineCourse As OnlineCourse)

        Sub DeleteOnlineCourse(onlineCourse As String)

        Function FindOnlineCourseByID(onlineCourse As Integer)
    End Interface
End Namespace




