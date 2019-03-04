CREATE DATABASE IF NOT EXISTS catalog;
USE catalog;

CREATE TABLE IF NOT EXISTS `books`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `title` varchar(128) NOT NULL,
    `authorIds` varchar(128) NOT NULL,
    `publisherId` int NOT NULL,
    `pages` int NOT NULL,
    `publicationYear` int NOT NULL,
    `categoryIds` varchar(128) NOT NULL,
    `price` decimal(5, 2) NOT NULL,
    `photo` LONGBLOB
);

CREATE TABLE IF NOT EXISTS `authors`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `publishers`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `categories`
(
	`id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(128) NOT NULL
);