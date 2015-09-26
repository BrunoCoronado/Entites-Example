Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OfficeAssignments.ViewModels
    Public Class OfficeAssignmentsViewModel
        Inherits ViewModelBase

        Private _Assignments As ObservableCollection(Of OfficeAssignment)
        Private dataAccess As IOfficeAssignmentService

        Public Property Assignments As ObservableCollection(Of OfficeAssignment)
            Get
                Return Me._Assignments
            End Get
            Set(value As ObservableCollection(Of OfficeAssignment))
                Me._Assignments = value
                OnPropertyChanged("OfficeAssignments")
            End Set
        End Property

        Private Function GetAllOfficeAsignments() As IQueryable(Of OfficeAssignment)
            Return Me.dataAccess.GetAllOfficeAssignment
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._Assignments = New ObservableCollection(Of OfficeAssignment)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOfficeAssignmentService)(New OfficeAssignmentServices)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IOfficeAssignmentService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOfficeAsignments
                Me._Assignments.Add(element)
            Next
        End Sub
    End Class
End Namespace

