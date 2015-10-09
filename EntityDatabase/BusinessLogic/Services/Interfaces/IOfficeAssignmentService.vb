Namespace BusinessLogic.Services.Interfaces
    Public Interface IOfficeAssignmentService

        Function GetAllOfficeAssignment() As IQueryable(Of OfficeAssignment)

        Sub CreateOfficeAssigment(officeAssigment As OfficeAssignment)

        Sub DeleteOfficeAssigment(officeAssigment As String)

        Sub EditOfficeAssigment(officeAssigment As OfficeAssignment)

        Function FindOfficeByID(officeAssigment As Integer)

    End Interface
End Namespace

