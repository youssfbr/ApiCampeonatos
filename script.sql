CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Campeonatos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    CONSTRAINT `PK_Campeonatos` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Jogos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Jogada` longtext CHARACTER SET utf8mb4 NULL,
    `Resultado` longtext CHARACTER SET utf8mb4 NULL,
    `CampeonatoId` int NULL,
    CONSTRAINT `PK_Jogos` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Jogos_Campeonatos_CampeonatoId` FOREIGN KEY (`CampeonatoId`) REFERENCES `Campeonatos` (`Id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4;

CREATE INDEX `IX_Jogos_CampeonatoId` ON `Jogos` (`CampeonatoId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210904040953_Initial', '5.0.9');

COMMIT;

