Namespace BusinessLogic.Services.Interfaces
    Public Interface IOfficeAssignmentService

        Function GetAllOfficeAssignment() As IQueryable(Of OfficeAssignment)

        Sub CreateOfficeAssigment(officeAssigment As OfficeAssignment)

        Sub DeleteOfficeAssigment(officeAssigment As OfficeAssignment)

        Sub EditOfficeAssigment(officeAssigment As OfficeAssignment)

    End Interface
End Namespace

