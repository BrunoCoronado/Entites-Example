Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnlineCourseService

        Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse)

        Sub CreateOnlineCourse(onlineCourse As OnlineCourse)

        Sub EditOnlineCourse(onlineCourse As OnlineCourse)

        Function DeleteOnlineCourse(onlineCourse As String)

    End Interface
End Namespace

