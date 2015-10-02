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

        Public Sub DeletePerson(person As Person) Implements IPersonService.DeletePerson
            Try
                DataContext.DBEntities.People.Remove(person)
                DataContext.DBEntities.SaveChanges()
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
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Sub
    End Class
End Namespace

