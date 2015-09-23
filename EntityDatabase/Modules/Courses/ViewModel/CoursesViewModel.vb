Imports BusinessLogic.Helpers
Imports BusinessLogic.Services.Implementations
Imports BusinessLogic.Services.Interfaces
Imports System.Collections.ObjectModel

Namespace Modules.Courses.ViewModels
    Public Class CoursesViewModel
        Inherits ViewModelBase

        Private _Courses As ObservableCollection(Of Course)
        Private dataAccess As ICourseService

        Public Property Course As ObservableCollection(Of Course)
            Get
                Return Me._Courses
            End Get
            Set(value As ObservableCollection(Of Course))
                Me._Courses = value
                OnPropertyChanged("Course")
            End Set
        End Property

        Private Function GetAllCourses() As IQueryable(Of Course)
            Return Me.dataAccess.GetAllCourses
        End Function

        Sub New()
            'Initialize property variable of departments
            Me._Courses = New ObservableCollection(Of Course)
            ' Register service with ServiceLocator
            ServiceLocator.RegisterService(Of ICourseService)(New CourseService)
            ' Initialize dataAccess from service
            Me.dataAccess = GetService(Of ICourseService)()
            ' Populate departments property variable 
            For Each element In Me.GetAllCourses
                Me._Courses.Add(element)
            Next
        End Sub
    End Class
End Namespace

