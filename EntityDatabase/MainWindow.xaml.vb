Imports Modules.Departments.ViewModels
Imports Modules.Courses.ViewModels
Imports Modules.People.ViewModels
Imports Modules.OfficeAssignments.ViewModels
Imports Modules.OnlineCourses.ViewModels
Imports Modules.OnsiteCoures.ViewModel
Imports Modules.StudentGrades.ViewModels

Class MainWindow
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DepartmenstUserControl.MainDepartmentGrid.DataContext = New DepartmentsViewModel
        Me.CoursesList.MainCourseGrid.DataContext = New CoursesViewModel
        Me.PeopleList.MainGrid.DataContext = New PersonViewModel
        Me.OfficeAssigmentList.MainGrid.DataContext = New OfficeAssignmentsViewModel
        Me.OnlineCoursesList.MainGrid.DataContext = New OnlineCourseViewModel
        Me.OnlineCourseUserControlCRUD.OnlineCourseCRUDGrid.DataContext = New OnlineCourseCRUDViewModel
        Me.OnsiteCoursesList.MainGrid.DataContext = New OnsiteCousesViewModel
        Me.StudentGradesList.MainGrid.DataContext = New StudentGradesViewModel
    End Sub
End Class
