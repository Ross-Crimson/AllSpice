-- Active: 1715613932305@@127.0.0.1@3306@thoughtful_chimera_0d6c07_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE recipes (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    title VARCHAR(255) NOT NULL,
    instructions VARCHAR(5000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    category ENUM(
        "breakfast",
        "lunch",
        "dinner",
        "snack",
        "dessert"
    ) DEFAULT "dinner",
    creatorId VARCHAR(255),
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE ingredients (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    quantity VARCHAR(255) NOT NULL,
    recipeId INT NOT NULL,
    -- not sure about this next like
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE
);

--recipeId and account Id might need to be foreign keys to cascade delete all
CREATE TABLE favorites (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    recipeId INT NOT NULL,
    accountId VARCHAR(255) NOT NULL,
    -- not sure
    FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
    FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE
)