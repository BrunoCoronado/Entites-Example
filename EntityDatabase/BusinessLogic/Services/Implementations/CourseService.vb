Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Imports System.Linq


Namespace BusinessLogic.Services.Implementations
    Public Class CourseService
        Implements ICourseService

        Public Function GetAllCourses() As IQueryable(Of Course) Implements ICourseService.GetAllCourses
            Return DataContext.DBEntities.Courses
        End Function

        Public Function CoursesInDepartments() As Course Implements ICourseService.CoursesInDepartments
            Dim cursosDepartamentos = From C In GetAllCourses()
                                      Join dep In DataContext.DBEntities.Departments
                                      On C.DepartmentID Equals dep.DepartmentID
                                      Select C.CourseID, C.Title, dep.Name
            Return cursosDepartamentos
        End Function
    End Class
End Namespace
