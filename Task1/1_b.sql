select count(TypeOfContent) count from Contents join Countries C on C.Id = Contents.Country
where CountryName = 'Brazil' and TypeOfContent='series'
group by TypeOfContent