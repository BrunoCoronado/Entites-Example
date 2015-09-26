Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.OnsiteCoures.ViewModel
    Public Class OnsiteCousesViewModel
        Inherits ViewModelBase

        Private _OnsiteCourse As ObservableCollection(Of Global.OnsiteCourse)
        Private dataAccess As IOnSiteCourseService

        Public Property OnsiteCourse As ObservableCollection(Of Global.OnsiteCourse)
            Get
                Return Me._OnsiteCourse
            End Get
            Set(value As ObservableCollection(Of Global.OnsiteCourse))
                Me._OnsiteCourse = value
                OnPropertyChanged("OnsiteCourse")
            End Set
        End Property

        ' Function to get all departments from service
        Private Function GetAllOnsiteCourses() As IQueryable(Of OnsiteCourse)
            Return Me.dataAccess.GetAllOnsiteCourses
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._OnsiteCourse = New ObservableCollection(Of Global.OnsiteCourse)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of IOnSiteCourseService)(New OnSiteCourseService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of IOnSiteCourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllOnsiteCourses
                Me._OnsiteCourse.Add(element)
            Next
        End Sub
    End Class
End Namespace

