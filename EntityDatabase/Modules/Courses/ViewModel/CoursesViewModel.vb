Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Courses.ViewModels
    Public Class CoursesViewModel
        Inherits ViewModelBase

        Private _Courses As ObservableCollection(Of Course)
        Private _Departments As ObservableCollection(Of Department)
        Private _dataAccess As ICourseService
        Private _departmentDataAccess As IDepartmentService
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _title As String
        Private _credits As String
        Private _department As Integer
        Private _deleteCourse As Integer
        Private _editCourse As Integer
        Private _editTitle As String
        Private _editCredits As String
        Private _editDepartment As Integer

        Public Property Course As ObservableCollection(Of Course)
            Get
                Return Me._Courses
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._Courses = value
                OnPropertyChanged("Course")
            End Set
        End Property

        Public Property Departments As ObservableCollection(Of Department)
            Get
                Return Me._Departments
            End Get
            Set(value As ObservableCollection(Of Department))
                Me._Departments = value
                OnPropertyChanged("Departments")
            End Set
        End Property

        Public Property CreateCourseTitle As String
            Get
                Return _title
            End Get
            Set(value As String)
                _title = value
                OnPropertyChanged("CreateCourseTitle")
            End Set
        End Property

        Public Property EditCourseTitle As String
            Get
                Return _editTitle
            End Get
            Set(value As String)
                _editTitle = value
                OnPropertyChanged("EditCourseTitle")
            End Set
        End Property

        Public Property CreateCourseCredits As String
            Get
                Return _credits
            End Get
            Set(value As String)
                _credits = value
                OnPropertyChanged("CreateCourseCredits")
            End Set
        End Property

        Public Property EditCourseCredits As String
            Get
                Return _editCredits
            End Get
            Set(value As String)
                _editCredits = value
                OnPropertyChanged("EditCourseCredits")
            End Set
        End Property

        Public Property CreateCourseDepartmentID As Integer
            Get
                Return _department
            End Get
            Set(value As Integer)
                _department = value
                OnPropertyChanged("CreateCourseDepartmentID")
            End Set
        End Property

        Public Property EditCourseDepartmentID As Integer
            Get
                Return _editDepartment
            End Get
            Set(value As Integer)
                _editDepartment = value
                OnPropertyChanged("EditCourseDepartmentID")
            End Set
        End Property

        Public Property DeleteCourse As Integer
            Get
                Return _deleteCourse
            End Get
            Set(value As Integer)
                _deleteCourse = value
                OnPropertyChanged("DeleteCourse")
            End Set
        End Property

        Public Property EditCourse As Integer
            Get
                Return _editCourse
            End Get
            Set(value As Integer)
                _editCourse = value
                ChangeData(value)
                OnPropertyChanged("EditCourse")
            End Set
        End Property

        Public ReadOnly Property ButtonCreateCourse
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf CreateCourse)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeleteCourse
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf DeleteACourse)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdateCourse
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf UpdateACourse)
                End If
                Return _buttonUpdate
            End Get
        End Property

        Private Sub CreateCourse()
            If CreateCourseTitle <> "" And CreateCourseCredits <> "" And CreateCourseDepartmentID <> 0 Then
                Dim course As New Course
                course.CourseID = _Courses.ToArray.Length + 1
                course.Title = CreateCourseTitle
                course.Credits = CInt(CreateCourseCredits)
                course.DepartmentID = CreateCourseDepartmentID
                _dataAccess.CreateCourse(course)
                Me._Courses.Add(course)
                MsgBox("Course Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateCourseTitle = Nothing
                CreateCourseCredits = Nothing
                CreateCourseDepartmentID = Nothing
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub DeleteACourse()
            If DeleteCourse <> 0 Then
                Me._dataAccess.DeleteCourse((DeleteCourse).ToString)
                _Courses.Clear()
                For Each element In Me.GetAllCourses
                    Me._Courses.Add(element)
                Next
            Else
                MsgBox("Select a Course", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub UpdateACourse()
            If EditCourse <> 0 Then
                If EditCourseTitle <> "" And EditCourseCredits <> "" And EditCourseDepartmentID > 0 Then
                    Dim courseEdit As New Course
                    courseEdit.CourseID = EditCourse
                    courseEdit.Title = EditCourseTitle
                    courseEdit.Credits = CInt(EditCourseCredits)
                    courseEdit.DepartmentID = EditCourseDepartmentID
                    Me._dataAccess.EditCourse(courseEdit)
                    Me._Courses.Clear()
                    For Each element In Me.GetAllCourses
                        Me._Courses.Add(element)
                    Next
                    EditCourse = Nothing
                    EditCourseTitle = Nothing
                    EditCourseCredits = Nothing
                    EditCourseDepartmentID = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select a Course", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New Course
            oldData = Me._dataAccess.FindCourseByID(id)
            If oldData IsNot Nothing Then
                EditCourseTitle = oldData.Title
                EditCourseCredits = oldData.Credits.ToString
                EditCourseDepartmentID = oldData.DepartmentID
            End If
        End Sub

        Private Function GetAllCourses() As IQueryable(Of Course)
            Return Me._dataAccess.GetAllCourses
        End Function

        Private Function GetAllDepartments() As IQueryable(Of Department)
            Return Me._departmentDataAccess.GetAllDepartments
        End Function

        Sub New()
            Me._Courses = New ObservableCollection(Of Course)
            Me._Departments = New ObservableCollection(Of Department)
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            Me._dataAccess = GetService(Of ICourseService)()
            ServiceLocator.RegisterService(Of IDepartmentService)(New DepartmentService)
            Me._departmentDataAccess = GetService(Of IDepartmentService)()
            For Each element In Me.GetAllCourses
                Me._Courses.Add(element)
            Next
            For Each element In Me.GetAllDepartments
                Me._Departments.Add(element)
            Next
        End Sub
    End Class
End Namespace

