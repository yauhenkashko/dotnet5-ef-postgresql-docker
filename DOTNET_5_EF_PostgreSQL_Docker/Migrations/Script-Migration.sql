﻿--not recommended to use Database.Migrate in production for scaled out applications
--use the SQL scripts in deployment instead
--https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/migrations?view=aspnetcore-5.0&tabs=visual-studio

--package manager console:	Script-Migration
--or dotnet CLI: 			dotnet ef migrations script


CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Phones" (
    "PhoneId" integer GENERATED BY DEFAULT AS IDENTITY,
    "Manufacturer" text NULL,
    "Model" text NULL,
    "Price" integer NOT NULL,
    CONSTRAINT "PK_Phones" PRIMARY KEY ("PhoneId")
);

CREATE TABLE "Orders" (
    "OrderId" integer GENERATED BY DEFAULT AS IDENTITY,
    "UserName" text NULL,
    "ContactPhone" text NULL,
    "PhoneId" integer NOT NULL,
    CONSTRAINT "PK_Orders" PRIMARY KEY ("OrderId"),
    CONSTRAINT "FK_Orders_Phones_PhoneId" FOREIGN KEY ("PhoneId") REFERENCES "Phones" ("PhoneId") ON DELETE CASCADE
);

CREATE INDEX "IX_Orders_PhoneId" ON "Orders" ("PhoneId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211016183908_Initial', '5.0.11');

COMMIT;

