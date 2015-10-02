Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Departments.ViewModels
    Public Class DepartmentsCRUDViewModel
        Inherits ViewModelBase

        Private _dataAcces As IDepartmentService
        Private _departmentNameA As String
        Private _departmentNameB As String
        Private _name As String
        Private _budget As String
        Private _Administrator As String
        Private _nameA As String
        Private _budgetA As String
        Private _AdministratorA As String
        Private _startDate As DateTime = DateTime.Now
        Private _buttonCreate As ICommand
        Private _buttonDelete As ICommand
        Private _buttonUpdate As ICommand
        Private _departments As ObservableCollection(Of Department)

        Public Property DepartmentNameC As String
            Get
                Return _departmentNameA
            End Get
            Set(value As String)
                _departmentNameA = value
                OnPropertyChanged("DepartmentNameC")
            End Set
        End Property

        Public Property DepartmentNameB As String
            Get
                Return _departmentNameB
            End Get
            Set(value As String)
                _departmentNameB = value
                OnPropertyChanged("DepartmentNameB")
            End Set
        End Property

        Public Property DepartmentName As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
                OnPropertyChanged("DepartmentName")
            End Set
        End Property

        Public Property DepartmentBudget As String
            Get
                Return _budget
            End Get
            Set(value As String)
                _budget = value
                OnPropertyChanged("DepartmentBudget")
            End Set
        End Property

        Public Property DepartmentAdministrator As String
            Get
                Return _Administrator
            End Get
            Set(value As String)
                _Administrator = value
                OnPropertyChanged("DepartmentAdministrator")
            End Set
        End Property

        Public Property DepartmentNameA As String
            Get
                Return _nameA
            End Get
            Set(value As String)
                _nameA = value
                OnPropertyChanged("DepartmentNameA")
            End Set
        End Property

        Public Property DepartmentBudgetA As String
            Get
                Return _budgetA
            End Get
            Set(value As String)
                _budgetA = value
                OnPropertyChanged("DepartmentBudgetA")
            End Set
        End Property

        Public Property DepartmentAdministratorA As String
            Get
                Return _AdministratorA
            End Get
            Set(value As String)
                _AdministratorA = value
                OnPropertyChanged("DepartmentAdministratorA")
            End Set
        End Property

        Public Property Departments As ObservableCollection(Of Department)
            Get
                Return _departments
            End Get
            Set(value As ObservableCollection(Of Department))
                _departments = value
                OnPropertyChanged("Departments")
            End Set
        End Property

        Public ReadOnly Property ButtonCreateDepartment
            Get
                If _buttonCreate Is Nothing Then
                    _buttonCreate = New RelayCommand(AddressOf Create)
                End If
                Return _buttonCreate
            End Get
        End Property

        Public ReadOnly Property ButtonDeleteDepartment
            Get
                If _buttonDelete Is Nothing Then
                    _buttonDelete = New RelayCommand(AddressOf Delete)
                End If
                Return _buttonDelete
            End Get
        End Property

        Public ReadOnly Property ButtonUpdateDepartment
            Get
                If _buttonUpdate Is Nothing Then
                    _buttonUpdate = New RelayCommand(AddressOf Update)
                End If
                Return _buttonUpdate
            End Get
        End Property

        Private Sub Update()
            If DepartmentName <> Nothing And DepartmentBudget <> Nothing And DepartmentAdministrator <> Nothing Then
                Dim department As New Department
                department.Name = DepartmentNameA
                department.Budget = DepartmentBudgetA
                department.Administrator = DepartmentAdministratorA
                department.StartDate = _startDate
                _dataAcces.EditDepartment(department)
                DepartmentNameA = Nothing
                DepartmentBudgetA = Nothing
                DepartmentAdministratorA = Nothing
            Else
                MsgBox("llene todos los campos")
            End If
        End Sub

        Private Sub Delete()
            Dim department As New Department
            If DepartmentNameA <> Nothing Then
                department = Me._dataAcces.DeleteDepartment(DepartmentNameA)
            Else
                DepartmentNameA = Nothing
            End If
        End Sub

        Private Sub Create()
            If DepartmentName <> Nothing And DepartmentBudget <> Nothing And DepartmentAdministrator <> Nothing Then
                Dim newDepartment As New Department
                newDepartment.Name = DepartmentName
                newDepartment.Budget = DepartmentBudget
                newDepartment.Administrator = DepartmentAdministrator
                _dataAcces.CreateDepartment(newDepartment)
                Me._departments.Add(newDepartment)
                DepartmentName = Nothing
                DepartmentBudget = Nothing
                DepartmentAdministrator = Nothing
            Else
                MsgBox("llene todos los campos")
            End If
        End Sub

        Private Function GetAllDepartments() As IQueryable(Of Department)
            Return Me._dataAcces.GetAllDepartments()
        End Function

        Public Sub New()
            ServiceLocator.RegisterService(Of IDepartmentService)(New DepartmentService)
            Me._dataAcces = ServiceLocator.GetService(Of IDepartmentService)()
            Me._departments = New ObservableCollection(Of Department)
            For Each element In Me.GetAllDepartments
                Me._departments.Add(element)
            Next
        End Sub
    End Class
End Namespace
