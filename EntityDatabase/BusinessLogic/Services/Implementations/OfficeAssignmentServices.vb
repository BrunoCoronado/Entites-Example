Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OfficeAssignmentServices
        Implements IOfficeAssignmentService

        Public Function GetAllOfficeAssignment() As IQueryable(Of OfficeAssignment) Implements IOfficeAssignmentService.GetAllOfficeAssignment
            Return DataContext.DBEntities.OfficeAssignments
        End Function

        Public Sub CreateOfficeAssigment(officeAssigment As OfficeAssignment) Implements IOfficeAssignmentService.CreateOfficeAssigment
            Try
                DataContext.DBEntities.OfficeAssignments.Add(officeAssigment)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteOfficeAssigment(officeAssigment As String) Implements IOfficeAssignmentService.DeleteOfficeAssigment
            Try
                Dim office = (From o In DataContext.DBEntities.OfficeAssignments Where o.InstructorID = officeAssigment).FirstOrDefault
                DataContext.DBEntities.OfficeAssignments.Remove(office)
                DataContext.DBEntities.SaveChanges()
                MsgBox("Office Assignment  Deleted Correctly", MsgBoxStyle.OkOnly, "School")
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditOfficeAssigment(officeAssigment As OfficeAssignment) Implements IOfficeAssignmentService.EditOfficeAssigment
            Try
                Dim newData = (From o In DataContext.DBEntities.OfficeAssignments Where o.InstructorID = officeAssigment.InstructorID).FirstOrDefault
                newData.Location = officeAssigment.Location
                DataContext.DBEntities.SaveChanges()
                MsgBox("Office Assignment  Edited Correctly", MsgBoxStyle.OkOnly, "School")
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Function FindOfficeByID(officeAssigment As Integer) As Object Implements IOfficeAssignmentService.FindOfficeByID
            Try
                Dim officeFinder = (From o In DataContext.DBEntities.OfficeAssignments Where o.InstructorID = officeAssigment).FirstOrDefault
                Return officeFinder
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Function
    End Class
End Namespace


