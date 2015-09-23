Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.People.ViewModels
    Public Class PersonViewModel
        Inherits ViewModelBase

        Private _People As ObservableCollection(Of Person)
        Private dataAccess As IPersonService

        Public Property People As ObservableCollection(Of Person)
            Get
                Return Me._People
            End Get
            Set(value As ObservableCollection(Of Person))
                Me._People = value
                OnPropertyChanged("People")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllPeople() As IQueryable(Of Person)
            Return Me.dataAccess.GetAllPeople
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._People = New ObservableCollection(Of Person)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IPersonService)(New PersonService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IPersonService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllPeople
                Me._People.Add(element)
            Next
        End Sub
    End Class
End Namespace

