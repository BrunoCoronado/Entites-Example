Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Departments.ViewModels
    Public Class DepartmentsViewModel
        Inherits ViewModelBase

        Private _departments As ObservableCollection(Of Department)
        Private _dataAccess As IDepartmentService
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _name As String
        Private _budget As String
        Private _startDate As Date
        Private _Administrator As String
        Private _editName As String
        Private _editBudget As String
        Private _editAdministrator As String
        Private _editStartDate As String
        Private _deletedDepartmentID As Integer
        Private _updateDepartmentID As Integer


        Public Property Departments As ObservableCollection(Of Department)
            Get
                Return Me._departments
            End Get
            Set(value As ObservableCollection(Of Department))
                Me._departments = value
                OnPropertyChanged("Departments")
            End Set
        End Property

        Public Property DeleteDepartment As Integer
            Get
                Return _deletedDepartmentID
            End Get
            Set(value As Integer)
                _deletedDepartmentID = value
                OnPropertyChanged("DeleteDepartment")
            End Set
        End Property

        Public Property UpdateDepartment As Integer
            Get
                Return _updateDepartmentID
            End Get
            Set(value As Integer)
                _updateDepartmentID = value
                ChangeData(value)
                OnPropertyChanged("UpdateDepartment")
            End Set
        End Property

        Public Property CreateDepartmentName As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
                OnPropertyChanged("CreateDepartmentName")
            End Set
        End Property

        Public Property CreateDepartmentStartDate As Date
            Get
                Return _startDate
            End Get
            Set(value As Date)
                _startDate = value
                OnPropertyChanged("CreateDepartmentStartDate")
            End Set
        End Property

        Public Property CreateDepartmentBudget As String
            Get
                Return _budget
            End Get
            Set(value As String)
                _budget = value
                OnPropertyChanged("CreateDepartmentBudget")
            End Set
        End Property

        Public Property CreateDepartmentAdministrator As String
            Get
                Return _Administrator
            End Get
            Set(value As String)
                _Administrator = value
                OnPropertyChanged("CreateDepartmentAdministrator")
            End Set
        End Property

        Public Property EditDepartmentName As String
            Get
                Return _editName
            End Get
            Set(value As String)
                _editName = value
                OnPropertyChanged("EditDepartmentName")
            End Set
        End Property

        Public Property EditDepartmentStartDate As Date
            Get
                Return _editStartDate
            End Get
            Set(value As Date)
                _editStartDate = value
                OnPropertyChanged("EditDepartmentStartDate")
            End Set
        End Property

        Public Property EditDepartmentBudget As String
            Get
                Return _editBudget
            End Get
            Set(value As String)
                _editBudget = value
                OnPropertyChanged("EditDepartmentBudget")
            End Set
        End Property

        Public Property EditDepartmentAdministrator As String
            Get
                Return _editAdministrator
            End Get
            Set(value As String)
                _editAdministrator = value
                OnPropertyChanged("EditDepartmentAdministrator")
            End Set
        End Property

        Public ReadOnly Property ButtonCreateDepartment
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf CreateDepartment)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeleteDepartment
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf DeleteADepartment)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdateDepartment
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf UpdateADepartment)
                End If
                Return _buttonUpdate
            End Get
        End Property

        Private Sub CreateDepartment()
            If CreateDepartmentName <> "" And CreateDepartmentBudget <> "" And CreateDepartmentAdministrator <> "" Then
                Dim department As New Department
                department.DepartmentID = _departments.ToArray.Length + 1
                department.Name = CreateDepartmentName
                department.Budget = CDbl(CreateDepartmentBudget)
                department.StartDate = CreateDepartmentStartDate
                department.Administrator = CInt(CreateDepartmentAdministrator)
                _dataAccess.CreateDepartment(department)
                Me._departments.Add(department)
                MsgBox("Department Created Correctly", MsgBoxStyle.OkOnly, "School")
                CreateDepartmentName = Nothing
                CreateDepartmentBudget = Nothing
                CreateDepartmentAdministrator = Nothing
            Else
                MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub DeleteADepartment()
            If DeleteDepartment <> 0 Then
                Me._dataAccess.DeleteDepartment((DeleteDepartment).ToString)
                _departments.Clear()
                For Each element In Me.GetAllDepartments
                    Me._departments.Add(element)
                Next
            Else
                MsgBox("Select a Department", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub


        Private Sub UpdateADepartment()
            If UpdateDepartment <> 0 Then
                If EditDepartmentName <> "" And EditDepartmentBudget <> "" And EditDepartmentAdministrator <> "" Then
                    Dim departmentEdit As New Department
                    departmentEdit.DepartmentID = UpdateDepartment
                    departmentEdit.Name = EditDepartmentName
                    departmentEdit.Budget = CDbl(EditDepartmentBudget)
                    departmentEdit.Administrator = CInt(EditDepartmentAdministrator)
                    departmentEdit.StartDate = EditDepartmentStartDate
                    Me._dataAccess.EditDepartment(departmentEdit)
                    Me._departments.Clear()
                    For Each element In Me.GetAllDepartments
                        Me._departments.Add(element)
                    Next
                    EditDepartmentName = Nothing
                    UpdateDepartment = Nothing
                    EditDepartmentAdministrator = Nothing
                    EditDepartmentStartDate = Nothing
                    EditDepartmentBudget = Nothing
                Else
                    MsgBox("Fill all the spaces in blank", MsgBoxStyle.OkOnly, "School")
                End If
            Else
                MsgBox("Select a Department", MsgBoxStyle.OkOnly, "School")
            End If
        End Sub

        Private Sub ChangeData(id As Integer)
            Dim oldData As New Department
            oldData = Me._dataAccess.FindDepartmentByID(id)
            If oldData IsNot Nothing Then
                EditDepartmentName = oldData.Name
                EditDepartmentAdministrator = oldData.Administrator.ToString
                EditDepartmentStartDate = oldData.StartDate
                EditDepartmentBudget = oldData.Budget.ToString
            End If
        End Sub

        Private Function GetAllDepartments() As IQueryable(Of Department)
            Return Me._dataAccess.GetAllDepartments
        End Function

        Sub New()
            Me._departments = New ObservableCollection(Of Department)
            ServiceLocator.RegisterService(Of IDepartmentService)(New DepartmentService)
            Me._dataAccess = GetService(Of IDepartmentService)()
            For Each element In Me.GetAllDepartments
                Me._departments.Add(element)
            Next
            CreateDepartmentStartDate = Date.Now
        End Sub
    End Class
End Namespace

