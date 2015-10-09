Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OfficeAssignments.ViewModels
    Public Class OfficeAssignmentsViewModel
        Inherits ViewModelBase

        Private _Assignments As ObservableCollection(Of OfficeAssignment)
        Private _Instructor As ObservableCollection(Of Person)
        Private _AbleInstructor As ObservableCollection(Of Person)
        Private _dataAccess As IOfficeAssignmentService
        Private _personDataAccess As IPersonService
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _createInstructorID As Integer
        Private _updateInstructorID As Integer
        Private _deleteInstructorID As Integer
        Private _createLocation As String
        Private _updateLocation As String

        Public Property Assignments As ObservableCollection(Of OfficeAssignment)
            Get
                Return Me._Assignments
            End Get
            Set(value As ObservableCollection(Of OfficeAssignment))
                Me._Assignments = value
                OnPropertyChanged("OfficeAssignments")
            End Set
        End Property

        Public Property AbleInstructor As ObservableCollection(Of Person)
            Get
                Return Me._AbleInstructor
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._AbleInstructor = value
                OnPropertyChanged("AbleInstructor")
            End Set
        End Property

        Public Property Instructor As ObservableCollection(Of Person)
            Get
                Return Me._Instructor
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._Instructor = value
                OnPropertyChanged("Instructor")
            End Set
        End Property

        Public Property CreateID As Integer
            Get
                Return _createInstructorID
            End Get
            Set(value As Integer)
                _createInstructorID = value
                OnPropertyChanged("CreateID")
            End Set
        End Property

        Public Property UpdateID As Integer
            Get
                Return _updateInstructorID
            End Get
            Set(value As Integer)
                _updateInstructorID = value
                ChangeData(value)
                OnPropertyChanged("UpdateID")
            End Set
        End Property

        Public Property DeleteID As Integer
            Get
                Return _deleteInstructorID
            End Get
            Set(value As Integer)
                _deleteInstructorID = value
                OnPropertyChanged("DeleteID")
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

        Public ReadOnly Property ButtonCreate
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf Create)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDelete
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf Delete)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdate
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf Update)
                End If
                Return _buttonUpdate
            End Get
        End Property

        Private Sub Create()
            If CreateID > 0 And CreateLocation <> "" Then
                Dim office As New OfficeAssignment
                office.InstructorID = CreateID
                office.Location = CreateLocation
                _dataAccess.CreateOfficeAssigment(office)
                Me._Assignments.Add(office)
                MsgBox("Office Assignment Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateID = Nothing
                CreateLocation = Nothing
                _AbleInstructor.Clear()
                _Instructor.Clear()
                For Each element In Me.GetAllInstructors
                    If element.OfficeAssignment IsNot Nothing Then
                        Me._Instructor.Add(element)
                    End If
                Next
                For Each element In Me.GetAllInstructors
                    If element.OfficeAssignment Is Nothing Then
                        Me._AbleInstructor.Add(element)
                    End If
                Next
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub Delete()
            If DeleteID <> 0 Then
                Me._dataAccess.DeleteOfficeAssigment((DeleteID).ToString)
                _Assignments.Clear()
                For Each element In Me.GetAllOfficeAsignments
                    Me._Assignments.Add(element)
                Next
                _AbleInstructor.Clear()
                _Instructor.Clear()
                For Each element In Me.GetAllInstructors
                    If element.OfficeAssignment IsNot Nothing Then
                        Me._Instructor.Add(element)
                    End If
                Next
                For Each element In Me.GetAllInstructors
                    If element.OfficeAssignment Is Nothing Then
                        Me._AbleInstructor.Add(element)
                    End If
                Next
                DeleteID = Nothing
            Else
                MsgBox("Select Assingment", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub Update()
            If UpdateID <> 0 Then
                If UpdateLocation <> "" Then
                    Dim office As New OfficeAssignment
                    office.InstructorID = UpdateID
                    office.Location = UpdateLocation
                    Me._dataAccess.EditOfficeAssigment(office)
                    Me._Assignments.Clear()
                    For Each element In Me.GetAllOfficeAsignments
                        Me._Assignments.Add(element)
                    Next
                    UpdateID = Nothing
                    UpdateLocation = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select Assignment", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New OfficeAssignment
            oldData = Me._dataAccess.FindOfficeByID(id)
            If oldData IsNot Nothing Then
                UpdateLocation = oldData.Location
            End If
        End Sub

        Private Function GetAllOfficeAsignments() As IQueryable(Of OfficeAssignment)
            Return Me._dataAccess.GetAllOfficeAssignment
        End Function

        Private Function GetAllInstructors() As IQueryable(Of Person)
            Return Me._personDataAccess.GetAllPeople
        End Function

        Sub New()
            Me._Assignments = New ObservableCollection(Of OfficeAssignment)
            Me._Instructor = New ObservableCollection(Of Person)
            Me._AbleInstructor = New ObservableCollection(Of Person)
            ServiceLocator.RegisterService(Of IOfficeAssignmentService)(New OfficeAssignmentServices)
            Me._dataAccess = GetService(Of IOfficeAssignmentService)()
            ServiceLocator.RegisterService(Of IPersonService)(New PersonService)
            Me._personDataAccess = GetService(Of IPersonService)()
            For Each element In Me.GetAllOfficeAsignments
                Me._Assignments.Add(element)
            Next
            For Each element In Me.GetAllInstructors
                If element.OfficeAssignment IsNot Nothing Then
                    Me._Instructor.Add(element)
                End If
            Next
            For Each element In Me.GetAllInstructors
                If element.OfficeAssignment Is Nothing Then
                    Me._AbleInstructor.Add(element)
                End If
            Next
        End Sub
    End Class
End Namespace

