CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE recipes (
   id SERIAL PRIMARY KEY,
   user_id INT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
   title VARCHAR(100) NOT NULL,
   ingredients TEXT NOT NULL,
   description TEXT,
   is_public BOOLEAN DEFAULT TRUE,
   created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
   updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
   cooking_time INT
);

CREATE TABLE collections (
   id SERIAL PRIMARY KEY,
   user_id INT NOT NULL REFERENCES users(id) ON DELETE CASCADE,
   name VARCHAR(100) NOT NULL,
   description TEXT,
   is_public BOOLEAN DEFAULT TRUE,
   created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE collection_recipes (
   id SERIAL PRIMARY KEY,
   collection_id INT NOT NULL REFERENCES collections(id) ON DELETE CASCADE,
   recipe_id INT NOT NULL REFERENCES recipes(id) ON DELETE CASCADE
);
