Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OnSiteCourseService
        Implements IOnSiteCourseService

        Public Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse) Implements IOnSiteCourseService.GetAllOnlineCourse
            Return DataContext.DBEntities.OnlineCourse
        End Function
    End Class
End Namespace

