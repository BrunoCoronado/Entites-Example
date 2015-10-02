Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OnSiteCourseService
        Implements IOnSiteCourseService


        Public Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse) Implements IOnSiteCourseService.GetAllOnsiteCourses
            Return DataContext.DBEntities.OnsiteCourses
        End Function

        Public Sub CreateOnsiteCourse(onsiteCourse As OnsiteCourse) Implements IOnSiteCourseService.CreateOnsiteCourse
            Try
                DataContext.DBEntities.OnsiteCourses.Add(onsiteCourse)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteOnsiteCourse(onsiteCourse As OnsiteCourse) Implements IOnSiteCourseService.DeleteOnsiteCourse
            Try
                Dim oCourse = (From oc In DataContext.DBEntities.OnsiteCourses Where oc.CourseID = onsiteCourse.CourseID).FirstOrDefault
                DataContext.DBEntities.OnsiteCourses.Remove(oCourse)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditOnsiteCourse(onsiteCourse As OnsiteCourse) Implements IOnSiteCourseService.EditOnsiteCourse
            Try
                Dim oCourse = (From oc In DataContext.DBEntities.OnsiteCourses Where oc.CourseID = onsiteCourse.CourseID).FirstOrDefault
                oCourse.Location = onsiteCourse.Location
                oCourse.Days = onsiteCourse.Days
                oCourse.Time = onsiteCourse.Time
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace

