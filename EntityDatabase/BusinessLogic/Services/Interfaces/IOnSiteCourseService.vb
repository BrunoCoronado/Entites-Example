Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnSiteCourseService

        Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse)

        Sub CreateOnsiteCourse(onsiteCourse As OnsiteCourse)

        Sub DeleteOnsiteCourse(onsiteCourse As String)

        Sub EditOnsiteCourse(onsiteCourse As OnsiteCourse)

        Function FindOnsiteCourseByID(onsiteCourse As Integer)
    End Interface
End Namespace


