CREATE TABLE StudStatus
(
Id INT PRIMARY KEY,
StatusDescr VARCHAR(100)
);

INSERT INTO StudStatus
(Id, StatusDescr)
VALUES
(1, 'Редовен'),
(2, 'Самост. подготовка'),
(3, 'Задочен'),
(4, 'Прекъснал по успех'),
(5, 'Прекъснал по болест'),
(6, 'Прекъснал по майчинство')