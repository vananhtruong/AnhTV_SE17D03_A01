
insert into Employee( EmployeeName, EmployeePosition)
values
(N'A',N'Leader'),
(N'B',N'Staff'),
(N'C',N'Staff'),
(N'D',N'Staff'),
(N'E',N'Staff');

insert into Project(ProjectName, ProjectDescription)
values
(N'Project A',N'ABC'),
(N'Project B',N'ABC'),
(N'Project C',N'ABC'),
(N'Project D',N'ABC'),
(N'Project E',N'ABC');

select * from Employee
select * from Project
select * from ProjectDetails
insert into Project(EmployeeID, ProjectID, [Role])
values
(1,1,N'Leader'),
(2,2,N'Staff'),
(3,3,N'Staff'),
(4,4,N'Staff'),
(5,5,N'Leader');

INSERT INTO ProjectDetails (EmployeeID, ProjectID, [Role])
VALUES
(1, 1, N'Leader'),
(2, 2, N'Staff'),
(3, 3, N'Staff'),
(4, 4, N'Staff'),
(5, 5, N'Leader');