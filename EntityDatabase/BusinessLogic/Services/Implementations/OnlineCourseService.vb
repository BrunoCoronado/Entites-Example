Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OnlineCourseService
        Implements IOnlineCourseService

        Public Function GetAllOnlineCourse() As IQueryable(Of OnlineCourse) Implements IOnlineCourseService.GetAllOnlineCourse
            Return DataContext.DBEntities.OnlineCourses
        End Function

        Public Sub CreateOnlineCourse(onlineCourse As OnlineCourse) Implements IOnlineCourseService.CreateOnlineCourse
            Try
                DataContext.DBEntities.OnlineCourses.Add(onlineCourse)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditOnlineCourse(onlineCourse As OnlineCourse) Implements IOnlineCourseService.EditOnlineCourse
            Try
                Dim newData = (From c In DataContext.DBEntities.OnlineCourses Where c.CourseID = onlineCourse.CourseID).FirstOrDefault
                newData.URL = onlineCourse.URL
                DataContext.DBEntities.SaveChanges()
                MsgBox("Online Course Edited Correctly", MsgBoxStyle.OkOnly, "School")
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteOnlineCourse(onlineCourse As String) Implements IOnlineCourseService.DeleteOnlineCourse
            Try
                Dim course = (From c In DataContext.DBEntities.OnlineCourses Where c.CourseID = onlineCourse).FirstOrDefault
                DataContext.DBEntities.OnlineCourses.Remove(course)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Online Course Deleted Correctly", MsgBoxStyle.OkOnly, "School")
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Function FindOnlineCourseByID(onlineCourse As Integer) As Object Implements IOnlineCourseService.FindOnlineCourseByID
            Try
                Dim courseFinder = (From c In DataContext.DBEntities.OnlineCourses Where c.CourseID = onlineCourse).FirstOrDefault
                Return courseFinder
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Function
    End Class
End Namespace

