Imports BusinessLogic.Services.Interfaces
Imports BusinessObjects.Helpers
Imports System.Linq


Namespace BusinessLogic.Services.Implementations
    Public Class PersonService
        Implements IPersonService

        Public Function GetAllPeople() As IQueryable(Of Person) Implements IPersonService.GetAllPeople
            Return DataContext.DBEntities.People
        End Function

        Public Sub CreatePerson(person As Person) Implements IPersonService.CreatePerson
            Try
                DataContext.DBEntities.People.Add(person)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub DeletePerson(person As String) Implements IPersonService.DeletePerson
            Dim deletedPerson As Person
            Try
                deletedPerson = (From p In DataContext.DBEntities.People Where p.PersonID = person).FirstOrDefault
                If deletedPerson.OfficeAssignment Is Nothing And deletedPerson.StudentGrades.ToArray.Length = 0 Then
                    DataContext.DBEntities.People.Remove(deletedPerson)
                    DataContext.DBEntities.SaveChanges()
                    MsgBox("Person Deleted Correctly", MsgBoxStyle.OkOnly, "School")
                Else
                    MsgBox("Imposible to Delete, Peson has many uses", MsgBoxStyle.OkOnly, "School")
                End If
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Sub EditPerson(person As Person) Implements IPersonService.EditPerson
            Try
                Dim per = (From p In DataContext.DBEntities.People Where p.PersonID = person.PersonID).FirstOrDefault
                per.FirstName = person.FirstName
                per.LastName = person.LastName
                per.HireDate = person.HireDate
                per.EnrollmentDate = person.EnrollmentDate
                DataContext.DBEntities.SaveChanges()
                MsgBox("Person Edited Correctly", MsgBoxStyle.OkOnly, "School")
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub

        Public Function FindPersonByID(person As Integer) As Object Implements IPersonService.FindPersonByID
            Try
                Dim personFinder = (From p In DataContext.DBEntities.People Where p.PersonID = person).FirstOrDefault
                Return personFinder
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Function
    End Class
End Namespace

