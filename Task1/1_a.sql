select Contents.Name from Contents join Actors A on A.Id = Contents.MainActor
where Genre = 'action' and A.Name = 'Jackie' and A.Surname = 'Chan';