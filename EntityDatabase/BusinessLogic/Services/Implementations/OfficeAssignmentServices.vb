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

        Public Sub DeleteOfficeAssigment(officeAssigment As OfficeAssignment) Implements IOfficeAssignmentService.DeleteOfficeAssigment
            Try
                DataContext.DBEntities.OfficeAssignments.Remove(officeAssigment)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditOfficeAssigment(officeAssigment As OfficeAssignment) Implements IOfficeAssignmentService.EditOfficeAssigment
            Try
                Dim newData = (From o In DataContext.DBEntities.OfficeAssignments Where o.InstructorID = officeAssigment.InstructorID).FirstOrDefault
                newData.Location = officeAssigment.Location
                newData.Person = officeAssigment.Person
                newData.Timestamp = officeAssigment.Timestamp
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace


