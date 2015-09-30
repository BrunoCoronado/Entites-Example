Namespace BusinessLogic.Services.Interfaces
    Public Interface IDepartmentService

        Function GetAllDepartments() As IQueryable(Of Department)

        Sub CreateDepartment(Department As Department)

        Sub EditDepartment(Department As Department)

        Function DeleteDepartment(Department As String)

    End Interface
End Namespace

