﻿Namespace BusinessLogic.Services.Interfaces
    Public Interface IPersonService

        Function GetAllPeople() As IQueryable(Of Person)

        Sub CreatePerson(person As Person)

        Sub DeletePerson(person As Person)

        Sub EditPerson(person As Person)

    End Interface
End Namespace

