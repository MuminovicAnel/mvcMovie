CREATE DATABASE movies;
GO
USE movies;

CREATE TABLE users(
id INT IDENTITY(1,1) PRIMARY KEY,
firstname VARCHAR(45),
lastname VARCHAR(45),
pseudo VARCHAR(45),
email VARCHAR(50),
password VARCHAR(50));

CREATE TABLE categories(
id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(40));

CREATE TABLE films(
id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(50),
year DATETIME,
image TEXT,
description VARCHAR(255),
category_id INT FOREIGN KEY REFERENCES categories(id));

CREATE TABLE statuses(
id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(30));

CREATE TABLE films_users(
id INT IDENTITY(1,1) PRIMARY KEY,
rating INT,
user_id INT FOREIGN KEY REFERENCES users(id),
film_id INT FOREIGN KEY REFERENCES films(id),
status_id INT FOREIGN KEY REFERENCES statuses(id));