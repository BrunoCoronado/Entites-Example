Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers


Namespace BusinessLogic.Services.Implementations
    Public Class CourseService
        Implements ICourseService

        Public Function GetAllCourses() As IQueryable(Of Course) Implements ICourseService.GetAllCourses
            Return DataContext.DBEntities.Courses
        End Function

        Public Sub CreateCourse(couse As Course) Implements ICourseService.CreateCourse
            Try
                DataContext.DBEntities.Courses.Add(couse)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try        
        End Sub

        Public Sub DeleteCourse(couse As Course) Implements ICourseService.DeleteCourse
            Try
                Dim eliminar = (From c In DataContext.DBEntities.Courses Where c.CourseID = couse.CourseID).FirstOrDefault
                DataContext.DBEntities.Courses.Remove(eliminar)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditCourse(couse As Course) Implements ICourseService.EditCourse
            Try
                Dim newData = (From c In DataContext.DBEntities.Courses Where c.CourseID = couse.CourseID).FirstOrDefault
                newData.Title = couse.Title
                newData.Credits = couse.Credits
                newData.DepartmentID = couse.DepartmentID
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace
