CREATE DATABASE inventory;
CREATE TABLE dumb_table(id SERIAL PRIMARY KEY, name VARCHAR);

insert into dumb_table(name) values('oskar');

SELECT id, name	FROM public.dumb_table;