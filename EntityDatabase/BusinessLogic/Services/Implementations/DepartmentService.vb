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
                Dim newData = (From d In DataContext.DBEntities.Departments Where d.DepartmentID = Department.DepartmentID).FirstOrDefault
                If (newData.Courses).ToArray.Length = 0 Then
                    newData.Name = Department.Name
                    newData.Budget = Department.Budget
                    newData.StartDate = Department.StartDate
                    newData.Administrator = Department.Administrator
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Department Edited Correctly", MsgBoxStyle.OkOnly, "School")
                Else
                    MsgBox("Imposible to Edit, Delete Courses First", MsgBoxStyle.OkOnly, "School")
                End If
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeleteDepartment(Department As String) Implements IDepartmentService.DeleteDepartment
            Try
                Dim deletedDepartment = (From depart In DataContext.DBEntities.Departments Where depart.DepartmentID = Department).FirstOrDefault
                If (deletedDepartment.Courses).ToArray.Length = 0 Then
                    DataContext.DBEntities.Departments.Remove(deletedDepartment)
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Department Deleted Correctly", MsgBoxStyle.OkOnly, "School")
                Else
                    MsgBox("Imposible to Delete, Delete Courses First", MsgBoxStyle.OkOnly, "School")
                End If
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Function FindDepartmentByID(department As Integer) As Object Implements IDepartmentService.FindDepartmentByID
            Try
                Dim departmetnFinder = (From d In DataContext.DBEntities.Departments Where d.DepartmentID = department).FirstOrDefault
                Return departmetnFinder
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Function
    End Class
End Namespace

