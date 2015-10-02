Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Namespace BusinessLogic.Services.Implementations
    Public Class DepartmentService
        Implements IDepartmentService

        Public Function GetAllDepartments() As IQueryable(Of Department) Implements IDepartmentService.GetAllDepartments
            Return DataContext.DBEntities.Departments
        End Function

        Public Sub CreateDepartment(Department As Department) Implements IDepartmentService.CreateDepartment
            If IfNotExist(Department.Name) Then
                Try
                    DataContext.DBEntities.Departments.Add(Department)
                    DataContext.DBEntities.SaveChanges()
                Catch ex As Exception
                    Console.WriteLine(ex)
                End Try
            End If
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

        Public Function DeleteDepartment(Department As String) As Object Implements IDepartmentService.DeleteDepartment
            Try
                Dim dep = (From d In DataContext.DBEntities.Departments Where d.Name = Department).FirstOrDefault
                DataContext.DBEntities.Departments.Remove(dep)
                DataContext.DBEntities.SaveChanges()
                Return dep
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try            
        End Function

        Private Function IfNotExist(Department As String) As Boolean
            Dim dep = (From d In DataContext.DBEntities.Departments Where d.Name = Department).FirstOrDefault
            If dep Is Nothing Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

