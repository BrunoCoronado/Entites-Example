Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnlineCourseService

        Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse)

        Sub CreateOnlineCourse(onlineCourse As OnlineCourse)

        Sub EditOnlineCourse(onlineCourse As OnlineCourse)

        Sub DeleteOnlineCourse(onlineCourse As OnlineCourse)

    End Interface
End Namespace

