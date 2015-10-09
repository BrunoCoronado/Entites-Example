Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnsiteCoures.ViewModel
    Public Class OnsiteCousesViewModel
        Inherits ViewModelBase

        Private _OnsiteCourse As ObservableCollection(Of Global.OnsiteCourse)
        Private _Course As ObservableCollection(Of Course)
        Private _AbleCourse As ObservableCollection(Of Course)
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _dataAccess As IOnSiteCourseService
        Private _courseDataAccess As ICourseService
        Private _createCourseID As Integer
        Private _deleteCourseID As Integer
        Private _updateCourseID As Integer
        Private _createLocation As String
        Private _createDays As String
        Private _createTime As Date
        Private _updateLocation As String
        Private _updateDays As String
        Private _updateTime As Date


        Public Property OnsiteCourse As ObservableCollection(Of Global.OnsiteCourse)
            Get
                Return Me._OnsiteCourse
            End Get
            Set(value As ObservableCollection(Of Global.OnsiteCourse))
                Me._OnsiteCourse = value
                OnPropertyChanged("OnsiteCourse")
            End Set
        End Property

        Public Property AbleCourse As ObservableCollection(Of Course)
            Get
                Return Me._AbleCourse
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._AbleCourse = value
                OnPropertyChanged("OnsiteCourse")
            End Set
        End Property

        Public Property Course As ObservableCollection(Of Course)
            Get
                Return Me._Course
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._Course = value
                OnPropertyChanged("OnsiteCourse")
            End Set
        End Property

        Public Property CreateCourseID As Integer
            Get
                Return _createCourseID
            End Get
            Set(value As Integer)
                _createCourseID = value
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
                Return _updateCourseID
            End Get
            Set(value As Integer)
                _updateCourseID = value
                ChangeData(value)
                OnPropertyChanged("EditCourseID")
            End Set
        End Property

        Public Property CreateLocation As String
            Get
                Return _createLocation
            End Get
            Set(value As String)
                _createLocation = value
                OnPropertyChanged("CreateLocation")
            End Set
        End Property

        Public Property UpdateLocation As String
            Get
                Return _updateLocation
            End Get
            Set(value As String)
                _updateLocation = value
                OnPropertyChanged("UpdateLocation")
            End Set
        End Property

        Public Property CreateDays As String
            Get
                Return _createDays
            End Get
            Set(value As String)
                _createDays = value
                OnPropertyChanged("CreateDays")
            End Set
        End Property

        Public Property UpdateDays As String
            Get
                Return _updateDays
            End Get
            Set(value As String)
                _updateDays = value
                OnPropertyChanged("UpdateDays")
            End Set
        End Property

        Public Property CreateTime As Date
            Get
                Return _createTime
            End Get
            Set(value As Date)
                _createTime = value
                OnPropertyChanged("CreateTime")
            End Set
        End Property

        Public Property UpdateTime As Date
            Get
                Return _updateTime
            End Get
            Set(value As Date)
                _updateTime = value
                OnPropertyChanged("UpdateTime")
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
            If CreateCourseID > 0 And CreateDays <> "" And CreateLocation <> "" And CreateTime.ToString <> "" Then
                Dim course As New OnsiteCourse
                course.CourseID = CreateCourseID
                course.Location = CreateLocation
                course.Days = CreateDays
                course.Time = CreateTime
                _dataAccess.CreateOnsiteCourse(course)
                Me._OnsiteCourse.Add(course)
                MsgBox("Onsite Course Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateCourseID = Nothing
                CreateDays = Nothing
                CreateLocation = Nothing
                CreateTime = Nothing
                _Course.Clear()
                _AbleCourse.Clear()
                For Each element In Me.GetAllCourses
                    If element.OnsiteCourse IsNot Nothing Then
                        Me._Course.Add(element)
                    End If
                Next
                For Each element In Me.GetAllCourses
                    If element.OnsiteCourse Is Nothing Then
                        Me._AbleCourse.Add(element)
                    End If
                Next
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub DeleteOCourse()
            If DeleteCourseID <> 0 Then
                Me._dataAccess.DeleteOnsiteCourse((DeleteCourseID).ToString)
                _OnsiteCourse.Clear()
                For Each element In Me.GetAllOnsiteCourses
                    Me._OnsiteCourse.Add(element)
                Next
                _Course.Clear()
                _AbleCourse.Clear()
                For Each element In Me.GetAllCourses
                    If element.OnsiteCourse IsNot Nothing Then
                        Me._Course.Add(element)
                    End If
                Next
                For Each element In Me.GetAllCourses
                    If element.OnsiteCourse Is Nothing Then
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
                If UpdateDays <> "" And UpdateLocation <> "" And UpdateTime.ToString <> "" Then
                    Dim courseEdit As New OnsiteCourse
                    courseEdit.CourseID = EditCourseID
                    courseEdit.Location = UpdateLocation
                    courseEdit.Time = UpdateTime
                    courseEdit.Days = UpdateDays
                    Me._dataAccess.EditOnsiteCourse(courseEdit)
                    Me._OnsiteCourse.Clear()
                    For Each element In Me.GetAllOnsiteCourses
                        Me._OnsiteCourse.Add(element)
                    Next
                    EditCourseID = Nothing
                    UpdateDays = Nothing
                    UpdateLocation = Nothing
                    UpdateTime = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select a Course", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New OnsiteCourse
            oldData = Me._dataAccess.FindOnsiteCourseByID(id)
            If oldData IsNot Nothing Then
                UpdateDays = oldData.Days
                UpdateLocation = oldData.Location
                UpdateTime = oldData.Time
            End If
        End Sub

        Private Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse)
            Return Me._dataAccess.GetAllOnsiteCourses
        End Function

        Private Function GetAllCourses() As IQueryable(Of Course)
            Return Me._courseDataAccess.GetAllCourses
        End Function

        Sub New()
            CreateTime = Date.Now
            Me._OnsiteCourse = New ObservableCollection(Of Global.OnsiteCourse)
            Me._Course = New ObservableCollection(Of Course)
            Me._AbleCourse = New ObservableCollection(Of Course)
            ServiceLocator.RegisterService(Of IOnSiteCourseService)(New OnSiteCourseService)
            Me._dataAccess = GetService(Of IOnSiteCourseService)()
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            Me._courseDataAccess = GetService(Of ICourseService)()
            For Each element In Me.GetAllOnsiteCourses
                Me._OnsiteCourse.Add(element)
            Next
            For Each element In Me.GetAllCourses
                If element.OnsiteCourse IsNot Nothing Then
                    Me._Course.Add(element)
                End If
            Next
            For Each element In Me.GetAllCourses
                If element.OnsiteCourse Is Nothing Then
                    Me._AbleCourse.Add(element)
                End If
            Next
        End Sub
    End Class
End Namespace

