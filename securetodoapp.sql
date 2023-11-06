-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 06. Nov 2023 um 13:49
-- Server-Version: 10.4.28-MariaDB
-- PHP-Version: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `securetodoapp`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('1', 'user', 'USER', NULL),
('2', 'admin', 'ADMIN', NULL),
('3', 'organizer', 'ORGANIZER', NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('1757a108-eb1c-4cd3-990f-a63535471be6', '1'),
('27a208bc-d855-4fd6-a175-d27b77b89cb2', '2'),
('cc0b7133-c9b2-4329-996b-4080be599fd9', '3');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `Lastname` varchar(50) NOT NULL,
  `DateOfBirth` datetime(6) DEFAULT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `Firstname`, `Lastname`, `DateOfBirth`, `CreatedOn`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('1757a108-eb1c-4cd3-990f-a63535471be6', 'user', 'user', '2023-10-14 16:03:04.840000', '2023-10-15 12:09:24.444966', 'user', 'USER', 'user@gmail.com', 'USER@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEIkF3E7eo097/MbSHAgnMmnZffHzg1LkZQvacPZWoHcEljMNhOIYSZCCyDLsLrJ8Gg==', '4C3EFGER6CDATZS7FMNKRHPELCZN7OES', 'd0a519a8-ed61-4e16-be4f-342a2152a958', NULL, 0, 0, NULL, 1, 0),
('27a208bc-d855-4fd6-a175-d27b77b89cb2', 'admin', 'admin', '2023-10-14 16:03:04.840000', '2023-10-15 12:09:34.818970', 'admin', 'ADMIN', 'admin@gmail.com', 'ADMIN@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEHFlQC2rsCeAmE6DpSL+K1727oeph3drTEcp4OyC4R46AnfybN8QOYEJ4heDokpjTQ==', 'KBOYV6LIWM2V4S5WAKEOQZ5CGN2RHEKV', 'face71f4-7f25-4873-92f3-35743eb119d4', NULL, 0, 0, NULL, 1, 0),
('cc0b7133-c9b2-4329-996b-4080be599fd9', 'organizer', 'organizer', '2023-10-14 16:03:04.840000', '2023-10-15 12:09:06.915997', 'organizer', 'ORGANIZER', 'organizer@gmail.com', 'ORGANIZER@GMAIL.COM', 0, 'AQAAAAIAAYagAAAAEFDNRsvmWP6ldevl6f2h9OdqoU7zl6xXjUiEAkqRoIesp9BpaVrjzjlm7eX77tjkNg==', 'FM6TYQ3JQMSFCZ32ETFXM4YTQQH5TSTJ', '840f7664-a69a-4788-9539-514654856fb7', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `todos`
--

CREATE TABLE `todos` (
  `Id` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `Description` longtext DEFAULT NULL,
  `Deadline` datetime(6) NOT NULL,
  `Information` longtext DEFAULT NULL,
  `Done` tinyint(1) NOT NULL,
  `AuthorId` varchar(255) NOT NULL,
  `AssignedUserId` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `todos`
--

INSERT INTO `todos` (`Id`, `Title`, `Description`, `Deadline`, `Information`, `Done`, `AuthorId`, `AssignedUserId`) VALUES
(2, 'Todo', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '27a208bc-d855-4fd6-a175-d27b77b89cb2', '27a208bc-d855-4fd6-a175-d27b77b89cb2'),
(3, 'Test Todo', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '27a208bc-d855-4fd6-a175-d27b77b89cb2', '27a208bc-d855-4fd6-a175-d27b77b89cb2'),
(4, 'Whatever', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '27a208bc-d855-4fd6-a175-d27b77b89cb2', '27a208bc-d855-4fd6-a175-d27b77b89cb2'),
(5, 'Melanie beschenken', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '27a208bc-d855-4fd6-a175-d27b77b89cb2', '27a208bc-d855-4fd6-a175-d27b77b89cb2'),
(7, 'Whatever', 'string', '2023-10-14 15:43:16.129000', 'string', 1, '1757a108-eb1c-4cd3-990f-a63535471be6', NULL),
(8, 'PC aufsetzen', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '1757a108-eb1c-4cd3-990f-a63535471be6', NULL),
(9, 'Product Backlog aufstellen', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '1757a108-eb1c-4cd3-990f-a63535471be6', NULL),
(18, 'Test Todo', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '1757a108-eb1c-4cd3-990f-a63535471be6', NULL),
(24, 'Frontend finishen', 'string', '2023-10-14 15:43:16.129000', 'string', 0, '1757a108-eb1c-4cd3-990f-a63535471be6', NULL),
(25, 'Tee kochen', 'string', '2023-10-14 15:43:16.129000', 'string', 1, '1757a108-eb1c-4cd3-990f-a63535471be6', '1757a108-eb1c-4cd3-990f-a63535471be6');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Daten für Tabelle `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231015100801_startup', '7.0.9');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indizes für die Tabelle `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indizes für die Tabelle `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indizes für die Tabelle `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indizes für die Tabelle `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indizes für die Tabelle `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indizes für die Tabelle `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indizes für die Tabelle `todos`
--
ALTER TABLE `todos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Todos_AssignedUserId` (`AssignedUserId`),
  ADD KEY `IX_Todos_AuthorId` (`AuthorId`);

--
-- Indizes für die Tabelle `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `todos`
--
ALTER TABLE `todos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `todos`
--
ALTER TABLE `todos`
  ADD CONSTRAINT `FK_Todos_AspNetUsers_AssignedUserId` FOREIGN KEY (`AssignedUserId`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `FK_Todos_AspNetUsers_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
