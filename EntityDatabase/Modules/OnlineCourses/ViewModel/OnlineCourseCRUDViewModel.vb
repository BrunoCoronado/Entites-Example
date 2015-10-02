Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCourseCRUDViewModel
        Inherits ViewModelBase

        Private _dataAcces As IOnlineCourseService
        Private _onlineCourseA As String
        Private _onlineCourseB As String
        Private _onlineCourseC As String
        Private _urlA As String
        Private _urlB As String
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _onlineCourses As ObservableCollection(Of Global.OnlineCourse)

        Public Property OnlineCourseA As String
            Get
                Return _onlineCourseA
            End Get
            Set(value As String)
                _onlineCourseA = value
                OnPropertyChanged("OnlineCourseA")
            End Set
        End Property

        Public Property OnlineCourseB As String
            Get
                Return _onlineCourseB
            End Get
            Set(value As String)
                _onlineCourseB = value
                OnPropertyChanged("OnlineCourseB")
            End Set
        End Property

        Public Property OnlineCourseC As String
            Get
                Return _onlineCourseC
            End Get
            Set(value As String)
                _onlineCourseC = value
                OnPropertyChanged("OnlineCourseC")
            End Set
        End Property

        Public Property URLA As String
            Get
                Return _urlA
            End Get
            Set(value As String)
                _urlA = value
                OnPropertyChanged("URLA")
            End Set
        End Property

        Public Property URLB As String
            Get
                Return _urlB
            End Get
            Set(value As String)
                _urlB = value
                OnPropertyChanged("URLB")
            End Set
        End Property

        Public Property OnlineCourses As ObservableCollection(Of Global.OnlineCourse)
            Get
                Return _onlineCourses
            End Get
            Set(value As ObservableCollection(Of Global.OnlineCourse))
                _onlineCourses = value
                OnPropertyChanged("OnlineCourses")
            End Set
        End Property

        Public ReadOnly Property ButtonCreateOnlineCourse
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf Create)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeleteOnlineCourse
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf Delete)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdateOnlineCourse
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf Update)
                End If
                Return _buttonUpdate
            End Get
        End Property

        Private Sub Update()
            If OnlineCourseB <> Nothing And URLB <> Nothing Then
                Dim onlineCourse As New Global.OnlineCourse
                onlineCourse.CourseID = OnlineCourseB
                onlineCourse.URL = URLB
                _dataAcces.EditOnlineCourse(onlineCourse)
                OnlineCourseB = Nothing
                URLB = Nothing
            Else
                MsgBox("llene todos los campos")
            End If
        End Sub

        Private Sub Delete()
            Dim onlineCourse As New Global.OnlineCourse
            If OnlineCourseC <> Nothing Then
                Dim dOnlineCourse As New Global.OnlineCourse
                Me._dataAcces.DeleteOnlineCourse(dOnlineCourse)
            Else
                OnlineCourseC = Nothing
            End If
        End Sub

        Private Sub Create()
            If OnlineCourseA <> Nothing And URLA <> Nothing Then
                Dim newOnlineCourse As New Global.OnlineCourse
                newOnlineCourse.CourseID = OnlineCourseA
                newOnlineCourse.URL = URLA
                _dataAcces.CreateOnlineCourse(newOnlineCourse)
                Me._onlineCourses.Add(newOnlineCourse)
                OnlineCourseA = Nothing
                URLA = Nothing
            Else
                MsgBox("llene todos los campos")
            End If
        End Sub

        Private Function GetAllOnlineCourses() As IQueryable(Of Global.OnlineCourse)
            Return Me._dataAcces.GetAllOnlineCourse
        End Function

        Public Sub New()
            Me._onlineCourses = New ObservableCollection(Of Global.OnlineCourse)
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            Me._dataAcces = GetService(Of IOnlineCourseService)()
            For Each element In Me.GetAllOnlineCourses
                Me._onlineCourses.Add(element)
            Next
        End Sub
    End Class
End Namespace

