CREATE DATABASE LibraryDB;
USE LibraryDB;

DROP TABLE IF EXISTS Categories;

CREATE TABLE Categories(
categoryID int PRIMARY KEY,
categoryName varchar(255) NOT NULL,
categoryFloor int NOT NULL
);

INSERT INTO Categories
VALUES
(1, 'Horror', 3),
(2, 'Fiction', 2),
(3, 'Sci-Fi', 3),
(4, 'Mystry', 1),
(5, 'Graphic Novel', 1),
(6, 'Fairy Tales', 2),
(7, 'Romance', 3);

DROP TABLE IF EXISTS Books;
CREATE TABLE Books(
bookID int IDENTITY(101, 1) PRIMARY KEY,
bookName varchar(255),
authorName varchar(255),
categoryID int FOREIGN KEY
REFERENCES Categories(categoryID)
);
INSERT INTO Books (bookName, authorName, categoryID)
VALUES
('The Shining', 'Steven King', 1),
('Darcula', 'Bram Stoker', 1),
('Beloved', 'Tony Morrison', 1),
('1984', 'George Orwell', 2),
('Alas, Babylon', 'Pat Frank', 2),
('To Kill a Mockingbird', 'Harper Lee', 2),
('I, Robot', 'Isaac Asimov', 3),
('Ender''s Game', 'Orson Scott Card', 3),
('Jane Eyre', 'Charlotte Bronte', 3),
('Rebbeca', 'Daphne du Maurier', 4),
('Watchmen', 'Alan Moore', 5),
('The Story of the Prince and his Horse', 'Guillaume Spitta-Bey', 6),
('The Tale of the Woodcutter and his Daughters', 'Enno Littman', 6),
('The Golden Bird', 'Mouloud Mammeri', 6),
('Court of Mist and Fury', 'Sara Janet', 7),
('New Moon', 'Stephany Meir', 7),
('To all the Boys Loved Before', 'Jenny Hann', 7);

SELECT * 
FROM Categories;
SELECT *
FROM Books;