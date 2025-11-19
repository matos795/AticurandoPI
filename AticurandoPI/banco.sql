ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Alunos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Senha` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DataNascimento` datetime(6) NOT NULL,
    CONSTRAINT `PK_Alunos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Cursos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Cursos` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Materias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Descricao` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Materias` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Professores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Cpf` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Telefone` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Professores` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;


CREATE TABLE `Turmas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Capacidade` int NOT NULL,
    `Turno` longtext CHARACTER SET utf8mb4 NOT NULL,
    `DataInicio` datetime(6) NOT NULL,
    `DataFim` datetime(6) NOT NULL,
    `CursoId` int NOT NULL,
    CONSTRAINT `PK_Turmas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Turmas_Cursos_CursoId` FOREIGN KEY (`CursoId`) REFERENCES `Cursos` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `Aulas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Data` datetime(6) NOT NULL,
    `Conteudo` longtext CHARACTER SET utf8mb4 NOT NULL,
    `MateriaId` int NOT NULL,
    `TurmaId` int NOT NULL,
    `ProfessorId` int NULL,
    CONSTRAINT `PK_Aulas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Aulas_Materias_MateriaId` FOREIGN KEY (`MateriaId`) REFERENCES `Materias` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Aulas_Professores_ProfessorId` FOREIGN KEY (`ProfessorId`) REFERENCES `Professores` (`Id`),
    CONSTRAINT `FK_Aulas_Turmas_TurmaId` FOREIGN KEY (`TurmaId`) REFERENCES `Turmas` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `Matriculas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `DataHora` datetime(6) NOT NULL,
    `Frequencia` float NOT NULL,
    `Status` int NOT NULL,
    `MotivoCancelamento` longtext CHARACTER SET utf8mb4 NULL,
    `AlunoId` int NOT NULL,
    `TurmaId` int NOT NULL,
    CONSTRAINT `PK_Matriculas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Matriculas_Alunos_AlunoId` FOREIGN KEY (`AlunoId`) REFERENCES `Alunos` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Matriculas_Turmas_TurmaId` FOREIGN KEY (`TurmaId`) REFERENCES `Turmas` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE TABLE `Presencas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Presente` tinyint(1) NOT NULL,
    `Data` datetime(6) NOT NULL,
    `MatriculaId` int NOT NULL,
    `AulaId` int NOT NULL,
    CONSTRAINT `PK_Presencas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Presencas_Aulas_AulaId` FOREIGN KEY (`AulaId`) REFERENCES `Aulas` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Presencas_Matriculas_MatriculaId` FOREIGN KEY (`MatriculaId`) REFERENCES `Matriculas` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;


CREATE INDEX `IX_Aulas_MateriaId` ON `Aulas` (`MateriaId`);


CREATE INDEX `IX_Aulas_ProfessorId` ON `Aulas` (`ProfessorId`);


CREATE INDEX `IX_Aulas_TurmaId` ON `Aulas` (`TurmaId`);


CREATE INDEX `IX_Matriculas_AlunoId` ON `Matriculas` (`AlunoId`);


CREATE INDEX `IX_Matriculas_TurmaId` ON `Matriculas` (`TurmaId`);


CREATE INDEX `IX_Presencas_AulaId` ON `Presencas` (`AulaId`);


CREATE INDEX `IX_Presencas_MatriculaId` ON `Presencas` (`MatriculaId`);


CREATE INDEX `IX_Turmas_CursoId` ON `Turmas` (`CursoId`);


