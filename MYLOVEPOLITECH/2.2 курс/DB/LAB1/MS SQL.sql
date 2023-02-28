use kotorman_geeks

CREATE TABLE users (
  [ID] bigint NOT NULL PRIMARY KEY,
  [login] varchar(90) NOT NULL,
  [password] varchar(255) NOT NULL,
  [first_name] varchar(255) NOT NULL,
  [last_name] varchar(255) NOT NULL,
  [avatar_src] varchar(300) DEFAULT '../../frontend/files/images/person-icon.jpg' ,
  [description] varchar(300) DEFAULT NULL ,
  [registration_date] date NOT NULL ,
  [validated] smallint NOT NULL DEFAULT '0' 
) ;


INSERT INTO users ([ID], [login], [password], [first_name], [last_name], [avatar_src], [description], [registration_date], [validated]) VALUES
(12, 'wadw@awf.fefsgdh', 'cb379855a0bb089818c105460d549c2316cdcfac3d7e9e984ab6faab4435cac3', 'awdawd', 'awdwad', NULL, NULL, '2021-12-17', 0),
(13, 'awd@fawfa.awf', '8eba282802d63426c66f68f512938966a8af780016cefab6d44636ea0168003c', 'цвфв', 'фцвфцв', NULL, NULL, '2021-12-17', 0),
(15, '123@gmail.com', '932f3c1b56257ce8539ac269d7aab4250ca77979ca0a6b365f06372f81a3f602', '123', '123', NULL, 'Хто я', '2021-12-20', 0),
(16, 'awdawd@egseg.t', 'af71d0326d8a969c891bd1a51c826602e0c103a3ad87000cd5b103b2e64eca90', 'rjrjrthr', 'adafeeg', NULL, NULL, '2021-12-20', 0),
(17, 'ddd@ddd.d', 'dddddddd', 'dddd', 'dddd', NULL, NULL, '2021-12-20', 0),
(18, 'aaa@aaa.aaa', 'wd', 'Big', 'Comraded agah', 'user-files/b_17_flying_fortress_nine_o_nine_by_hendrikaviationart_ddqykhk.jpg', 'Ye ij                                                                       ', '2021-12-20', 0),
(19, '123@g.c', '932f3c1b56257ce8539ac269d7aab425a0f943ba2bd8904a064214c95f639213', '123', '123', NULL, NULL, '2021-12-20', 0),
(20, 'petya@gmail.com', 'ef797c8118f02dfb649607dd5d3f8c76c21455d88fd737dfae0c8be5860af920', 'First', 'Dev', 'user-files/20/avatar.webp', 'Перестаньте переставати і почніть починати! Будь-як буде, як-небудь та буде, ніколи ще не було, щоб ніяк не було...', '2021-12-20', 1),
(25, 'qedqe@gmail.com', '7e071fd9b023ed8f18458a73613a0834656c9a5ddb247809cdddb084d9d0878c', 'wad', 'awd', '../../frontend/files/images/person-icon.jpg', NULL, '2021-12-22', 0)



CREATE TABLE officer_positions (
  [ID] int NOT NULL PRIMARY KEY,
  [name] varchar(250) NOT NULL,
  [name2] varchar(250) NOT NULL
) ;
INSERT INTO officer_positions ([ID], [name], [name2]) VALUES
(1, 'Main Admin', 'Helmlord'),
(2, 'Admin', 'Lord'),
(3, 'Main Judge', 'Helmlinbiorne');


CREATE TABLE officer_corps (
  [userID] bigint NOT NULL,
  [positionID] int NOT NULL,

  CONSTRAINT FK_officer_corps_userID FOREIGN KEY (userID) REFERENCES users(ID),
  CONSTRAINT FK_officer_corps_positionID FOREIGN KEY (positionID) REFERENCES officer_positions(ID),
) ;
INSERT INTO officer_corps ([userID], [positionID]) VALUES
(20, 1);


CREATE TABLE activation_codes (
  [userID] bigint NOT NULL UNIQUE,
  [code] int NOT NULL,

  CONSTRAINT FK_activation_codes_userID FOREIGN KEY (userID) REFERENCES users(ID),
) ;
INSERT INTO activation_codes ([userID], [code]) VALUES
(12, 78091),
(16, 59450),
(20, 77382);


CREATE TABLE prison (
  [userID] bigint NOT NULL PRIMARY KEY,
  [reason] varchar(255) NOT NULL,
  [imprisoned_on] date NOT NULL,
  [gets_out] date NOT NULL,

    CONSTRAINT FK_prison_userID FOREIGN KEY (userID) REFERENCES users(ID),
) ;


CREATE TABLE languages (
  [lang_code] varchar(3) NOT NULL PRIMARY KEY,
  [lang_name] varchar(30) NOT NULL UNIQUE
) ;

INSERT INTO languages ([lang_code], [lang_name]) VALUES
('be', 'Belarussian'),
('en', 'English'),
('de', 'German'),
('lv', 'Latvian'),
('pl', 'Polish'),
('ru', 'Russian'),
('es', 'Spanish'),
('sv', 'Swedish'),
('ua', 'Ukrainian');



CREATE TABLE articles (
  [articleID] bigint NOT NULL PRIMARY KEY,
  [authorID] bigint NOT NULL,
  [datetime] datetime2(0) DEFAULT NULL ,
  [time_to_read] int NOT NULL ,
  [title] varchar(50) NOT NULL ,
  [language] varchar(3) DEFAULT NULL ,
  [description] varchar(200) NOT NULL ,
  [tags] varchar(200) NOT NULL DEFAULT ' ' ,
  [original_url] varchar(200) DEFAULT NULL ,
  [blocks] varchar(max) ,
  [is_published] binary(1) NOT NULL DEFAULT 0,


  CONSTRAINT FK_articles_authorID FOREIGN KEY (authorID) REFERENCES users(ID),
  CONSTRAINT FK_articles_language FOREIGN KEY (language) REFERENCES languages(lang_code),
) ;


INSERT INTO articles ([articleID], [authorID], [datetime], [time_to_read], [title], [language], [description], [tags], [original_url], [blocks], [is_published]) VALUES
(1, 20, '2022-01-04 12:20:30', 10, 'Gaijin news', 'en', 'фцафцафафісфіфіафацйаауапіпуфпуфпфп', '', '', '[{"type":"heading","content":"Gaijin<br>"},{"type":"image","content":"posts-files/8/images/2.bmp"},{"type":"image","content":"posts-files/8/images/1(1).png"},{"type":"video","content":"https://www.youtube.com/embed/Hwz56hBW9KI"}]',1),
(2, 15,  '2022-01-04 12:20:30', 20, 'Gaijin news', 'en', 'ssssssss', '', '', '[{"type":"heading","content":"g<br>"},{"type":"image","content":"posts-files/8/images/2.bmp"},{"type":"image","content":"posts-files/8/images/1(1).png"},{"type":"video","content":"https://www.youtube.com/embed/Hwz56hBW9KI"}]',1),
(3, 16,  '2022-01-04 12:20:30', 30, 'Gaijin news', 'en', 'dddddd', '', '', '[{"type":"heading","content":"a<br>"},{"type":"image","content":"posts-files/8/images/2.bmp"},{"type":"image","content":"posts-files/8/images/1(1).png"},{"type":"video","content":"https://www.youtube.com/embed/Hwz56hBW9KI"}]',1)





CREATE TABLE article_marks (
  [userID] bigint NOT NULL,
  [articleID] bigint NOT NULL,
  [action] varchar(20) NOT NULL,

  CONSTRAINT FK_article_marks_userID FOREIGN KEY (userID) REFERENCES users(ID),
  CONSTRAINT FK_article_marks_articleID FOREIGN KEY (articleID) REFERENCES articles(articleID),
) ;


CREATE TABLE row_data (
  row_amount int NOT NULL,
  changed_at datetime NOT NULL,
) ;


CREATE TABLE cell_data (
  cell_amount int NOT NULL,
  changed_at datetime NOT NULL,
) ;


----------------PROCESSES-------------------------
CREATE PROC proc_n1 AS
declare @sum int = 0;

SET @sum+=(SELECT COUNT(*) FROM users)
SET @sum+=(SELECT COUNT(*) FROM languages)
SET @sum+=(SELECT COUNT(*) FROM activation_codes)
SET @sum+=(SELECT COUNT(*) FROM officer_corps)
SET @sum+=(SELECT COUNT(*) FROM officer_positions)
SET @sum+=(SELECT COUNT(*) FROM article_marks)
SET @sum+=(SELECT COUNT(*) FROM prison)
SET @sum+=(SELECT COUNT(*) FROM articles)

select @sum;
INSERT INTO row_data(row_amount, changed_at) VALUES (@sum, GETDATE())
return @sum;



CREATE PROC proc_n2 AS
declare @sum int = 0;

SET @sum+=((SELECT COUNT(*) FROM users) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='users'))
SET @sum+=((SELECT COUNT(*) FROM articles) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='articles'))
SET @sum+=((SELECT COUNT(*) FROM languages) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='languages'))
SET @sum+=((SELECT COUNT(*) FROM activation_codes) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='activation_codes'))
SET @sum+=((SELECT COUNT(*) FROM officer_corps) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='officer_corps'))
SET @sum+=((SELECT COUNT(*) FROM officer_positions) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='officer_positions'))
SET @sum+=((SELECT COUNT(*) FROM article_marks) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='article_marks'))
SET @sum+=((SELECT COUNT(*) FROM prison) * (SELECT COUNT(*) FROM information_schema.columns WHERE table_name ='prison'))

select @sum;
INSERT INTO cell_data(cell_amount, changed_at) VALUES (@sum, GETDATE())
return @sum;


CREATE PROC proc_n3 @row varchar(255) AS
declare @sum int = 0;
SET @sum+=(SELECT Count(DISTINCT @row) FROM users)
SET @sum+=(SELECT Count(DISTINCT @row) FROM articles)
SET @sum+=(SELECT Count(DISTINCT @row) FROM languages)
SET @sum+=(SELECT Count(DISTINCT @row) FROM officer_corps)
SET @sum+=(SELECT Count(DISTINCT @row) FROM activation_codes)
SET @sum+=(SELECT Count(DISTINCT @row) FROM article_marks)
SET @sum+=(SELECT Count(DISTINCT @row) FROM officer_positions)
SET @sum+=(SELECT Count(DISTINCT @row) FROM prison)
select @sum;

EXEC proc_n3 'ID'







-----------------TRIGGERS-------------------

--UPDATЕ
CREATE TRIGGER trigger_update_n2
ON users
AFTER UPDATE
AS
declare @ID int    
SET @ID = (SELECT ID FROM updated)    
UPDATE articles SET authorID = @ID WHERE authorID = @ID

CREATE TRIGGER trigger_update_n3
ON users
FOR UPDATE AS
DECLARE @ID int    
SET @ID = (SELECT ID FROM updated)    
SELECT * FROM articles WHERE authorID = @ID;
IF @@ROWCOUNT > 0
ROLLBACK TRANSACTION



--DELETE
CREATE TRIGGER trigger_user_DELETE
ON users AFTER DELETE AS
DECLARE @ID int    
SET @ID = (SELECT ID FROM deleted)    
DELETE FROM articles where articles.authorID = @ID

CREATE TRIGGER trigger_user_DENY_DELETE
ON users FOR DELETE AS
DECLARE @ID int    
SET @ID = (SELECT ID FROM deleted)    
SELECT * FROM articles WHERE authorID = @ID;
IF @@ROWCOUNT > 0
ROLLBACK TRANSACTION




--INSERTION
CREATE TRIGGER trigger_user_INSERT
ON users AFTER INSERT AS
EXEC proc_n1;