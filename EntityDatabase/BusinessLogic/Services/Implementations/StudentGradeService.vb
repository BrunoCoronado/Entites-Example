Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class StudentGradeService
        Implements IStudentGradeService

        Public Function GetAllStudentGrade() As IQueryable(Of StudentGrade) Implements IStudentGradeService.GetAllStudentGrade
            Return DataContext.DBEntities.StudentGrades
        End Function

        Public Sub CreateStudentGrade(studentGrade As StudentGrade) Implements IStudentGradeService.CreateStudentGrade
            Try
                DataContext.DBEntities.StudentGrades.Add(studentGrade)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteStudentGrade(studentGrade As StudentGrade) Implements IStudentGradeService.DeleteStudentGrade
            Try
                DataContext.DBEntities.StudentGrades.Remove(studentGrade)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditStudentGrade(studentGrade As StudentGrade) Implements IStudentGradeService.EditStudentGrade
            Try
                Dim grades = (From sg In DataContext.DBEntities.StudentGrades Where sg.EnrollmentID = studentGrade.EnrollmentID).FirstOrDefault
                grades.Grade = studentGrade.Grade
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace
