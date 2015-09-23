Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCourseViewModel
        Inherits ViewModelBase

        Private _OnlineCourse As ObservableCollection(Of OnlineCourse)
        Private dataAccess As IOnlineCourseService

        Public Property OnlineCourse As ObservableCollection(Of OnlineCourse)
            Get
                Return Me._OnlineCourse
            End Get
            Set(value As ObservableCollection(Of OnlineCourse))
                Me._OnlineCourse = value
                OnPropertyChanged("OnlineCourses")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllOnlineCourses() As IQueryable(Of OnlineCourse)
            Return Me.dataAccess.GetAllOnlineCourse
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._OnlineCourse = New ObservableCollection(Of OnlineCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IDepartmentService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOnlineCourses
                Me._OnlineCourse.Add(element)
            Next
        End Sub
    End Class
End Namespace

