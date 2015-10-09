Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.People.ViewModels
    Public Class PersonViewModel
        Inherits ViewModelBase

        Private _People As ObservableCollection(Of Person)
        Private _dataAccess As IPersonService
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _createLastName As String
        Private _createFirsName As String
        Private _editLastName As String
        Private _editFirstName As String
        Private _createEnrollment As Date
        Private _editEntollment As Date
        Private _createHire As Date
        Private _editHire As Date
        Private _editID As Integer
        Private _deleteID As Integer

        Public Property People As ObservableCollection(Of Person)
            Get
                Return Me._People
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._People = value
                OnPropertyChanged("People")
            End Set
        End Property

        Public Property EditPerson As Integer
            Get
                Return _editID
            End Get
            Set(value As Integer)
                _editID = value
                ChangeData(value)
                OnPropertyChanged("EditPerson")
            End Set
        End Property

        Public Property DeletePerson As Integer
            Get
                Return _deleteID
            End Get
            Set(value As Integer)
                _deleteID = value
                OnPropertyChanged("DeletePerson")
            End Set
        End Property

        Public Property CreateLastName As String
            Get
                Return _createLastName
            End Get
            Set(value As String)
                _createLastName = value
                OnPropertyChanged("CreateLastName")
            End Set
        End Property

        Public Property UpdateLastName As String
            Get
                Return _editLastName
            End Get
            Set(value As String)
                _editLastName = value
                OnPropertyChanged("UpdateLastName")
            End Set
        End Property

        Public Property CreateFirstName As String
            Get
                Return _createFirsName
            End Get
            Set(value As String)
                _createFirsName = value
                OnPropertyChanged("CreateFirstName")
            End Set
        End Property

        Public Property UpdateFirstName As String
            Get
                Return _editFirstName
            End Get
            Set(value As String)
                _editFirstName = value
                OnPropertyChanged("UpdateFirstName")
            End Set
        End Property

        Public Property CreateEnrollmentDate As Date
            Get
                Return _createEnrollment
            End Get
            Set(value As Date)
                _createEnrollment = value
                OnPropertyChanged("CreateEnrollmentDate")
            End Set
        End Property

        Public Property UpdateEnrollmentDate As Date
            Get
                Return _editEntollment
            End Get
            Set(value As Date)
                _editEntollment = value
                OnPropertyChanged("UpdateEnrollmentDate")
            End Set
        End Property

        Public Property CreateHireDate As Date
            Get
                Return _createHire
            End Get
            Set(value As Date)
                _createHire = value
                OnPropertyChanged("CreateHireDate")
            End Set
        End Property

        Public Property UpdateHireDate As Date
            Get
                Return _editHire
            End Get
            Set(value As Date)
                _editHire = value
                OnPropertyChanged("UpdateHireDate")
            End Set
        End Property

        Public ReadOnly Property ButtonCreatePerson
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf Create)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeletePerson
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf Delete)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdatePerson
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf Update)
                End If
                Return _buttonUpdate
            End Get
        End Property


        Private Sub Create()
            If CreateLastName <> "" And CreateFirstName <> "" And CreateEnrollmentDate.ToString <> "" And CreateHireDate.ToString <> "" Then
                Dim person As New Person
                person.PersonID = _People.ToArray.Length + 1
                person.FirstName = CreateFirstName
                person.LastName = CreateLastName
                person.HireDate = CreateHireDate
                person.EnrollmentDate = CreateEnrollmentDate
                _dataAccess.CreatePerson(person)
                Me._People.Clear()
                For Each element In Me.GetAllPeople
                    Me._People.Add(element)
                Next
                MsgBox("Person Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateLastName = Nothing
                CreateFirstName = Nothing
                CreateEnrollmentDate = Nothing
                CreateHireDate = Nothing
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub Delete()
            If DeletePerson <> 0 Then
                Me._dataAccess.DeletePerson((DeletePerson).ToString)
                _People.Clear()
                For Each element In Me.GetAllPeople
                    Me._People.Add(element)
                Next
            Else
                MsgBox("Select a Person", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub Update()
            If EditPerson <> 0 Then
                If UpdateEnrollmentDate.ToString <> "" And UpdateHireDate.ToString <> "" And UpdateFirstName <> "" And UpdateLastName <> "" Then
                    Dim person As New Person
                    person.PersonID = EditPerson
                    person.FirstName = UpdateFirstName
                    person.LastName = UpdateLastName
                    person.HireDate = UpdateHireDate
                    person.EnrollmentDate = UpdateEnrollmentDate
                    Me._dataAccess.EditPerson(person)
                    Me._People.Clear()
                    For Each element In Me.GetAllPeople
                        Me._People.Add(element)
                    Next
                    EditPerson = Nothing
                    UpdateEnrollmentDate = Nothing
                    UpdateHireDate = Nothing
                    UpdateFirstName = Nothing
                    UpdateLastName = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select a Person", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New Person
            oldData = Me._dataAccess.FindPersonByID(id)
            If oldData IsNot Nothing Then
                If oldData.EnrollmentDate IsNot Nothing Then
                    UpdateEnrollmentDate = oldData.EnrollmentDate
                End If
                If oldData.HireDate IsNot Nothing Then
                    UpdateHireDate = oldData.HireDate
                End If
                UpdateFirstName = oldData.FirstName
                UpdateLastName = oldData.LastName
            End If
        End Sub

        Private Function GetAllPeople() As IQueryable(Of Person)
            Return Me._dataAccess.GetAllPeople
        End Function

        Sub New()
            CreateEnrollmentDate = Date.Now
            CreateHireDate = Date.Now
            Me._People = New ObservableCollection(Of Person)
            ServiceLocator.RegisterService(Of IPersonService)(New PersonService)
            Me._dataAccess = GetService(Of IPersonService)()
            For Each element In Me.GetAllPeople
                Me._People.Add(element)
            Next
        End Sub
    End Class
End Namespace

