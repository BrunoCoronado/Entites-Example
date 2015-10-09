Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCourseViewModel
        Inherits ViewModelBase

        Private _OnlineCourse As ObservableCollection(Of Global.OnlineCourse)
        Private _Course As ObservableCollection(Of Course)
        Private _AbleCourse As ObservableCollection(Of Course)
        Private _dataAccess As IOnlineCourseService
        Private _courseDataAccess As ICourseService
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _courseID As Integer
        Private _deleteCourseID As Integer
        Private _editCourseID As Integer
        Private _url As String
        Private _editURL As String


        Public Property OnlineCourse As ObservableCollection(Of Global.OnlineCourse)
            Get
                Return Me._OnlineCourse
            End Get
            Set(value As ObservableCollection(Of Global.OnlineCourse))
                Me._OnlineCourse = value
                OnPropertyChanged("OnlineCourse")
            End Set
        End Property

        Public Property Course As ObservableCollection(Of Course)
            Get
                Return Me._Course
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._Course = value
                OnPropertyChanged("Course")
            End Set
        End Property

        Public Property AbleCourse As ObservableCollection(Of Course)
            Get
                Return Me._AbleCourse
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._AbleCourse = value
                OnPropertyChanged("AbleCourse")
            End Set
        End Property

        Public Property CreateCourseID As Integer
            Get
                Return _courseID
            End Get
            Set(value As Integer)
                _courseID = value
                OnPropertyChanged("CreateCourseID")
            End Set
        End Property

        Public Property DeleteCourseID As Integer
            Get
                Return _deleteCourseID
            End Get
            Set(value As Integer)
                _deleteCourseID = value
                OnPropertyChanged("DeleteCourseID")
            End Set
        End Property

        Public Property EditCourseID As Integer
            Get
                Return _editCourseID
            End Get
            Set(value As Integer)
                _editCourseID = value
                ChangeData(value)
                OnPropertyChanged("EditCourseID")
            End Set
        End Property

        Public Property CreateCourseURL As String
            Get
                Return _url
            End Get
            Set(value As String)
                _url = value
                OnPropertyChanged("CreateCourseURL")
            End Set
        End Property

        Public Property EditCourseURL As String
            Get
                Return _editURL
            End Get
            Set(value As String)
                _editURL = value
                OnPropertyChanged("EditCourseURL")
            End Set
        End Property

        Public ReadOnly Property ButtonCreateCourse
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf CreateOCourse)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeleteCourse
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf DeleteOCourse)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdateCourse
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf UpdateOCourse)
                End If
                Return _buttonUpdate
            End Get
        End Property


        Private Sub CreateOCourse()
            If CreateCourseID > 0 And CreateCourseURL <> "" Then
                Dim course As New OnlineCourse
                course.CourseID = CreateCourseID
                course.URL = CreateCourseURL
                _dataAccess.CreateOnlineCourse(course)
                Me._OnlineCourse.Add(course)
                MsgBox("Online Course Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateCourseID = Nothing
                CreateCourseURL = Nothing
                _Course.Clear()
                _AbleCourse.Clear()
                For Each element In Me.GetAllCourses
                    If element.OnlineCourse Is Nothing Then
                        Me._Course.Add(element)
                    End If
                Next
                For Each element In Me.GetAllCourses
                    If element.OnlineCourse IsNot Nothing Then
                        Me._AbleCourse.Add(element)
                    End If
                Next
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub DeleteOCourse()
            If DeleteCourseID <> 0 Then
                Me._dataAccess.DeleteOnlineCourse((DeleteCourseID).ToString)
                _OnlineCourse.Clear()
                For Each element In Me.GetAllOnlineCourses
                    Me._OnlineCourse.Add(element)
                Next
                _Course.Clear()
                _AbleCourse.Clear()
                For Each element In Me.GetAllCourses
                    If element.OnlineCourse Is Nothing Then
                        Me._Course.Add(element)
                    End If
                Next
                For Each element In Me.GetAllCourses
                    If element.OnlineCourse IsNot Nothing Then
                        Me._AbleCourse.Add(element)
                    End If
                Next
                DeleteCourseID = Nothing
            Else
                MsgBox("Select a Course", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub UpdateOCourse()
            If EditCourseID <> 0 Then
                If EditCourseURL <> "" Then
                    Dim courseEdit As New OnlineCourse
                    courseEdit.CourseID = EditCourseID
                    courseEdit.URL = EditCourseURL
                    Me._dataAccess.EditOnlineCourse(courseEdit)
                    Me._OnlineCourse.Clear()
                    For Each element In Me.GetAllOnlineCourses
                        Me._OnlineCourse.Add(element)
                    Next
                    EditCourseID = Nothing
                    EditCourseURL = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select a Course", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New OnlineCourse
            oldData = Me._dataAccess.FindOnlineCourseByID(id)
            If oldData IsNot Nothing Then
                EditCourseURL = oldData.URL
            End If
        End Sub
        Private Function GetAllOnlineCourses() As IQueryable(Of Global.OnlineCourse)
            Return Me._dataAccess.GetAllOnlineCourse
        End Function

        Private Function GetAllCourses() As IQueryable(Of Course)
            Return Me._courseDataAccess.GetAllCourses
        End Function

        Sub New()
            Me._OnlineCourse = New ObservableCollection(Of Global.OnlineCourse)
            Me._Course = New ObservableCollection(Of Course)
            Me._AbleCourse = New ObservableCollection(Of Course)
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            Me._dataAccess = GetService(Of IOnlineCourseService)()
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            Me._courseDataAccess = GetService(Of ICourseService)()
            For Each element In Me.GetAllOnlineCourses
                Me._OnlineCourse.Add(element)
            Next
            For Each element In Me.GetAllCourses
                If element.OnlineCourse Is Nothing Then
                    Me._Course.Add(element)
                End If
            Next
            For Each element In Me.GetAllCourses
                If element.OnlineCourse IsNot Nothing Then
                    Me._AbleCourse.Add(element)
                End If
            Next
        End Sub
    End Class
End Namespace

