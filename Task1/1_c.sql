select Contents.Name, count(Actor) actorsCount from Contents join Actors A on A.Id = Contents.Actor
group by Contents.Name having actorsCount > 1