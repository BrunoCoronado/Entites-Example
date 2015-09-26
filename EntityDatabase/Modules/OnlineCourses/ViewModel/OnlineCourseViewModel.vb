Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnlineCourses.ViewModels
    Public Class OnlineCourseViewModel
        Inherits ViewModelBase

        Private _OnlineCourse As ObservableCollection(Of Global.OnlineCourse)
        Private dataAccess As IOnlineCourseService

        Public Property OnlineCourse As ObservableCollection(Of Global.OnlineCourse)
            Get
                Return Me._OnlineCourse
            End Get
            Set(value As ObservableCollection(Of Global.OnlineCourse))
                Me._OnlineCourse = value
                OnPropertyChanged("OnlineCourse")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllOnlineCourses() As IQueryable(Of Global.OnlineCourse)
            Return Me.dataAccess.GetAllOnlineCourse
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._OnlineCourse = New ObservableCollection(Of Global.OnlineCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnlineCourseService)(New OnlineCourseService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IOnlineCourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOnlineCourses
                Me._OnlineCourse.Add(element)
            Next
        End Sub
    End Class
End Namespace

