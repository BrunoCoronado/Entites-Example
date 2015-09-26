Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OnSiteCourseService
        Implements IOnSiteCourseService

        Public Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse) Implements IOnSiteCourseService.GetAllOnsiteCourses
            Return DataContext.DBEntities.OnsiteCourses
        End Function
    End Class
End Namespace

