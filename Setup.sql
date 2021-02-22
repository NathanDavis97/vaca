use vacation2;

CREATE TABLE flights (
  id INT NOT NULL AUTO_INCREMENT,
  title VARCHAR(255),
  beginning VARCHAR(255),
  final VARCHAR(255),
  price DECIMAL(8 , 2) NOT NULL,
  description VARCHAR(255),
PRIMARY KEY (id)
);

-- CREATE TABLE cruises (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   destination VARCHAR(255),
--   price DECIMAL(8 , 2) NOT NULL,
--     PRIMARY KEY (id)
-- );






















-- DROP TABLE flights2
