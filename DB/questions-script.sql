-- This script was generated by a beta version of the ERD tool in pgAdmin 4.
-- Please log an issue at https://redmine.postgresql.org/projects/pgadmin4/issues/new if you find any bugs, including reproduction steps.
BEGIN;


CREATE TABLE IF NOT EXISTS public."QuestionTypes"
(
    "QuestionTypeId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_QuestionTypes" PRIMARY KEY ("QuestionTypeId")
);

CREATE TABLE IF NOT EXISTS public."Questions"
(
    "QuestionId" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Title" text COLLATE pg_catalog."default" NOT NULL,
    "Answer" text COLLATE pg_catalog."default" NOT NULL,
    "QuestionTypeId" integer NOT NULL,
    CONSTRAINT "PK_Questions" PRIMARY KEY ("QuestionId")
);

CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory"
(
    "MigrationId" character varying(150) COLLATE pg_catalog."default" NOT NULL,
    "ProductVersion" character varying(32) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

ALTER TABLE IF EXISTS public."Questions"
    ADD CONSTRAINT "FK_Questions_QuestionTypes_QuestionTypeId" FOREIGN KEY ("QuestionTypeId")
    REFERENCES public."QuestionTypes" ("QuestionTypeId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Questions_QuestionTypeId"
    ON public."Questions"("QuestionTypeId");

INSERT INTO public."QuestionTypes"("QuestionTypeId", "Name")
VALUES (1, 'ООП');

INSERT INTO public."Questions"("QuestionId", "Title", "Answer", "QuestionTypeId")
VALUES (1, 'Что такое ООП?', 'ООП (объектно-ориентированное программирование) — это тип программирования, основанный на объектах, а не только на функциях и процедурах. Отдельные объекты сгруппированы в классы. ООП внедряет в программирование реальные парадигмы, такие как наследование, полиморфизм, инкапсуляция и т. д. ООП также позволяет связывать данные и код вместе.', 1),
(2, 'Зачем использовать ООП?', 'ООП обеспечивает ясность в программировании и, следовательно, простоту в решении сложных задач.
Код может быть повторно использован посредством наследования, тем самым уменьшая избыточность
Данные и код связаны вместе инкапсуляцией
ООП позволяет скрывать данные, поэтому личные данные остаются конфиденциальными
Проблемы могут быть разделены на мелкие части, что облегчает их решение
Концепция полиморфизма придает программе гибкость, позволяя объектам иметь несколько форм.', 1),
(3, 'Назовите основные принципы ООП', 'Наследование
Инкапсуляция
Полиморфизм
Абстракция', 1);

END;