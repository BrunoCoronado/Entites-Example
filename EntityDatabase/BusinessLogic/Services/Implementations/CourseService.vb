Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers


Namespace BusinessLogic.Services.Implementations
    Public Class CourseService
        Implements ICourseService

        Public Function GetAllCourses() As IQueryable(Of Course) Implements ICourseService.GetAllCourses
            Return DataContext.DBEntities.Courses
        End Function

        Public Sub CreateCourse(course As Course) Implements ICourseService.CreateCourse
            Try
                DataContext.DBEntities.Courses.Add(course)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

        End Sub
        Public Sub DeleteCourse(course As String) Implements ICourseService.DeleteCourse
            Dim deletedCourse As Course
            Try
                deletedCourse = (From c In DataContext.DBEntities.Courses Where c.CourseID = course).FirstOrDefault
                If deletedCourse.OnlineCourse Is Nothing And deletedCourse.OnsiteCourse Is Nothing And deletedCourse.StudentGrades.ToArray.Length = 0 And deletedCourse.People.ToArray.Length = 0 Then
                    DataContext.DBEntities.Courses.Remove(deletedCourse)
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Course Deleted Correctly", MsgBoxStyle.OkOnly, "School")
                Else
                    MsgBox("Imposible to Delete, Course has many uses", MsgBoxStyle.OkOnly, "School")
                End If
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditCourse(course As Course) Implements ICourseService.EditCourse
            Try
                Dim newData = (From c In DataContext.DBEntities.Courses Where c.CourseID = course.CourseID).FirstOrDefault
                If newData.OnlineCourse Is Nothing And newData.OnsiteCourse Is Nothing And newData.StudentGrades.ToArray.Length = 0 And newData.People.ToArray.Length = 0 Then
                    newData.Title = course.Title
                    newData.Credits = course.Credits
                    newData.DepartmentID = course.DepartmentID
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Course Edited Correctly", MsgBoxStyle.OkOnly, "School")
                Else
                    MsgBox("Imposible to Delete, Course has many uses", MsgBoxStyle.OkOnly, "School")
                End If
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Function FindCourseByID(course As Integer) As Object Implements ICourseService.FindCourseByID
            Try
                Dim courseFinder = (From c In DataContext.DBEntities.Courses Where c.CourseID = course).FirstOrDefault
                Return courseFinder
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Function
    End Class
End Namespace
