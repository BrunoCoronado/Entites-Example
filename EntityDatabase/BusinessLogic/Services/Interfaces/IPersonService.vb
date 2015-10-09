Namespace BusinessLogic.Services.Interfaces
    Public Interface IPersonService

        Function GetAllPeople() As IQueryable(Of Person)

        Sub CreatePerson(person As Person)

        Sub DeletePerson(person As String)

        Sub EditPerson(person As Person)

        Function FindPersonByID(person As Integer)

    End Interface
End Namespace
