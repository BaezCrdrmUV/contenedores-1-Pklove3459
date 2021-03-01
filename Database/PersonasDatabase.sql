-- MySQL Workbench Forward Engineering
-- -----------------------------------------------------
-- Schema PersonasDatabase
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema PersonasDatabase
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `PersonasDatabase` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `PersonasDatabase` ;

-- -----------------------------------------------------
-- Table `PersonasDatabase`.`persona`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PersonasDatabase`.`persona` (
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
CREATE TABLE IF NOT EXISTS `PersonasDatabase`.`correoselectronicos` (
  `idCorreosElectronico` INT NOT NULL,
  `Curp` VARCHAR(45) NULL DEFAULT NULL,
  `correo` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idCorreosElectronico`),
  INDEX `Curp_idx` (`Curp` ASC) VISIBLE,
  CONSTRAINT `Curp`
    FOREIGN KEY (`Curp`)
    REFERENCES `PersonasDatabase`.`persona` (`CURP`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `PersonasDatabase`.`direcciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PersonasDatabase`.`direcciones` (
  `idDirecciones` INT NOT NULL,
  `Curp` VARCHAR(45) NULL DEFAULT NULL,
  `direcciones` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`idDirecciones`),
  INDEX `Curp_idx` (`Curp` ASC) VISIBLE,
  CONSTRAINT `direccionCurp`
    FOREIGN KEY (`Curp`)
    REFERENCES `PersonasDatabase`.`persona` (`CURP`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;
