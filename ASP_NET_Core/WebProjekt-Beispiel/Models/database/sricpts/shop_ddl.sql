create database if not exists db_shop collate utf8mb4_general_ci;

use db_shop;

create table articles (
	articleid int unsigned not null auto_increment,
    name varchar(200) not null,
    price decimal(6,2) not null,
    releasedate date null,
    category int not null,
    image varchar(200) not null,
    constraint articleid_PK primary key(articleid)
) engine=InnoDb;


insert into articles values(null, "Kairi Plush", 59.90, "2019-12-20", 3, "https://cdn-prod.scalefast.com/public/assets/user/1614900/sample/f5e58fed683482e0f5001eb9f3098556.jpg");

drop table articles;

select * from articles;