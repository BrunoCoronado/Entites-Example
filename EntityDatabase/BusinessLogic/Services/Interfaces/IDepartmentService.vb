Namespace BusinessLogic.Services.Interfaces
    Public Interface IDepartmentService

        Function GetAllDepartments() As IQueryable(Of Department)

        Sub CreateDepartment(Department As Department)

        Sub EditDepartment(Department As Department)

        Sub DeleteDepartment(Department As Department)

    End Interface
End Namespace

