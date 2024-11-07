CREATE DATABASE LibraryDB;


CREATE TABLE Categories(
categoryID int PRIMARY KEY,
catergoryName varchar(255) NOT NULL,
categoryFloor int NOT NULL
);

INSERT INTO Categories
VALUES
(1, 'Horror', 3),
(2, 'Fiction', 2),
(3, 'Sci-Fi', 3),
(4, 'Mystry', 1),
(5, 'Graphic Novel', 1),
(6, 'Fairy Tale', 2),
(7, 'Romance', 3);


CREATE TABLE Books(
bookID int PRIMARY KEY,
bookName varchar(255),
authorName varchar(255),
categoryID int FOREIGN KEY
REFERENCES Categories(categoryID)
);
INSERT INTO Books
VALUES
(101, 'The Shining', 'Steven King', 1),
(102, 'Darcula', 'Bram Stoker', 1),
(103, 'Beloved', 'Tony Morrison', 1),
(104, '1984', 'George Orwell', 2),
(105, 'Alas, Babylon', 'Ahmed Shokry', 2),
(106, 'To Kill a Mockingbird', 'Harper Lee', 2),
(107, 'I, Robot', 'Ahmed Mohammed', 3),
(108, 'Under Game', 'Abd ElSalam Hafez', 3),
(109, 'Jane Eyre', 'Charlotte Bronte', 3),
(110, 'Rebbeca', 'Daphne du Maurier', 4),
(111, 'Watchmen', 'Alan Moore', 5),
(112, 'The Story of the Prince and his Horse', 'Guillaume Spitta-Bey', 6),
(113, 'The Tale of the Woodcutter and his Daughters', 'Enno Littman', 6),
(114, 'The Golden Bird', 'Mouloud Mammeri', 6),
(115, 'Court of Mist and Fury', 'Sara Janet', 7),
(116, 'New Moon', 'Stephany Meir', 7),
(117, 'To all the Boys Loved Before', 'Jenny Hann', 7);