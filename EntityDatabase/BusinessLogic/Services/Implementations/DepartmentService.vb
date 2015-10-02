Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class DepartmentService
        Implements IDepartmentService

        Public Function GetAllDepartments() As IQueryable(Of Department) Implements IDepartmentService.GetAllDepartments
            Return DataContext.DBEntities.Departments
        End Function

        Public Sub CreateDepartment(Department As Department) Implements IDepartmentService.CreateDepartment
            Try
                DataContext.DBEntities.Departments.Add(Department)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditDepartment(Department As Department) Implements IDepartmentService.EditDepartment
            Try
                Dim newData = (From d In DataContext.DBEntities.Departments Where d.Name = Department.Name).FirstOrDefault
                newData.Name = Department.Name
                newData.Budget = Department.Budget
                newData.StartDate = Department.StartDate
                newData.Administrator = Department.Administrator
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteDepartment(Department As Department) Implements IDepartmentService.DeleteDepartment
            Try
                DataContext.DBEntities.Departments.Remove(Department)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace

