create table clients (client char(20) ASCII primary key, aeskey char(24) not null, cbciv char(24) not null, expire timestamp);
