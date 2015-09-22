Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OnlineCourseService
        Implements IOnlineCourseService

        Public Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse) Implements IOnlineCourseService.GetAllOnlineCourse
            Return DataContext.DBEntities.OnlineCourses
        End Function
    End Class
End Namespace

