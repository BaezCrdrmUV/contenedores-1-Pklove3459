-- MySQL Workbench Forward Engineering
-- -----------------------------------------------------
-- Schema PersonasDatabase
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema PersonasDatabase
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PersonasDatabase` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `PersonasDatabase`;

-- -----------------------------------------------------
-- Table `PersonasDatabase`.`persona`
-- -----------------------------------------------------
CREATE TABLE `PersonasDatabase`.`Persona` (
  `CURP` VARCHAR(45) NOT NULL,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `Apellido` VARCHAR(45) NULL DEFAULT NULL,
  `Estatura` VARCHAR(45) NULL DEFAULT NULL,
  `Peso` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`CURP`),
  UNIQUE INDEX `CURP_UNIQUE` (`CURP` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `PersonasDatabase`.`correoselectronicos`
-- -----------------------------------------------------
CREATE TABLE `PersonasDatabase`.`Correoselectronicos` (
  `idCorreosElectronico` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Curp` VARCHAR(45) NULL DEFAULT NULL,
  `correo` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idCorreosElectronico`),
  INDEX `Curp_idx` (`Curp` ASC) VISIBLE,
  CONSTRAINT `Curp`
    FOREIGN KEY (`Curp`)
    REFERENCES `PersonasDatabase`.`Persona` (`CURP`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `PersonasDatabase`.`direcciones`
-- -----------------------------------------------------
CREATE TABLE `PersonasDatabase`.`Direcciones` (
  `idDirecciones` INT NOT NULL AUTO_INCREMENT,
  `Curp` VARCHAR(45) NULL DEFAULT NULL,
  `direcciones` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idDirecciones`),
  INDEX `Curp_idx` (`Curp` ASC) VISIBLE,
  CONSTRAINT `direccionCurp`
    FOREIGN KEY (`Curp`)
    REFERENCES `PersonasDatabase`.`Persona` (`CURP`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

SET SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
CREATE USER 'PersonaAdmin' IDENTIFIED BY 'bobcholo1';
-- GRANT ALL PRIVILEGES ON *.* TO 'admin'@'localhost' WITH GRANT OPTION;
GRANT ALL PRIVILEGES ON *.* TO 'PersonaAdmin'@'%' WITH GRANT OPTION;
