Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class OfficeAssignmentServices
        Implements IOfficeAssignmentService

        Public Function GetAllOfficeAssignment() As IQueryable(Of OfficeAssignment) Implements IOfficeAssignmentService.GetAllOfficeAssignment
            Return DataContext.DBEntities.OfficeAssignments
        End Function
    End Class
End Namespace


