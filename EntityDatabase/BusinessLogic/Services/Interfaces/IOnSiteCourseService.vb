Namespace BusinessLogic.Services.Interfaces
    Public Interface IOnSiteCourseService

        Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse)

        Sub CreateOnsiteCourse(onsiteCourse As OnsiteCourse)

        Sub DeleteOnsiteCourse(onsiteCourse As OnsiteCourse)

        Sub EditOnsiteCourse(onsiteCourse As OnsiteCourse)
    End Interface
End Namespace

