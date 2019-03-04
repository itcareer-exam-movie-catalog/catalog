CREATE DATABASE IF NOT EXISTS catalog;
USE catalog;


CREATE TABLE IF NOT EXISTS `authors`
(
	`id` INT(3) AUTO_INCREMENT PRIMARY KEY,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `publishers`
(
	`id` INT(3) AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `category`
(
	`id` INT(3) AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `directors`
(
	`id` INT(3) AUTO_INCREMENT PRIMARY KEY,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `actors`
(
	`id` INT(3) AUTO_INCREMENT PRIMARY KEY,
    `firstName` VARCHAR(128) NOT NULL,
    `lastName` VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS `books`
(
	`id` int(3) AUTO_INCREMENT PRIMARY KEY,
    `title` varchar(128) NOT NULL,
    `authorId` int(3) NOT NULL,
    `publisherId` int(3) NOT NULL,
    `pages` int(3) NOT NULL,
    `publicationYear` DATE NOT NULL,
    `categoryIds` varchar(128) NOT NULL,
    `price` decimal(5, 2) NOT NULL,
    `photo` LONGBLOB,
    FOREIGN KEY (`publisherId`) REFERENCES `publishers`(`id`),
    FOREIGN KEY (`authorId`) REFERENCES `authors`(`id`)
);

CREATE TABLE IF NOT EXISTS `movies`
(
	`id` int(3) AUTO_INCREMENT PRIMARY KEY,
    `title` varchar(128) NOT NULL,
    `directorId` int(3) NOT NULL,
    `actorIds` varchar(128) NOT NULL,
    `publicationYear` DATE NOT NULL,
    `categoryIds` varchar(128) NOT NULL,
    `price` decimal(5, 2) NOT NULL,
    `photo` LONGBLOB,
    FOREIGN KEY (`directorId`) REFERENCES `directors`(`id`)
);
