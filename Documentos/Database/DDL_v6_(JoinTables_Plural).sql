-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema future_inclusion
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Table `IMAGE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `IMAGE` ;

CREATE TABLE IF NOT EXISTS `IMAGE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `url` TEXT NOT NULL COMMENT '(public url to access the image)',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SPHERE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `SPHERE` ;

CREATE TABLE IF NOT EXISTS `SPHERE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL COMMENT '(country, state, city)',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `POWER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `POWER` ;

CREATE TABLE IF NOT EXISTS `POWER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `SPHERE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POWER_SPHERE1_idx` (`SPHERE_id` ASC),
  CONSTRAINT `fk_POWER_SPHERE1`
    FOREIGN KEY (`SPHERE_id`)
    REFERENCES `SPHERE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `COUNTRY`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `COUNTRY` ;

CREATE TABLE IF NOT EXISTS `COUNTRY` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `STATE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `STATE` ;

CREATE TABLE IF NOT EXISTS `STATE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `COUNTRY_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_STATE_COUNTRY1_idx` (`COUNTRY_id` ASC),
  CONSTRAINT `fk_STATE_COUNTRY1`
    FOREIGN KEY (`COUNTRY_id`)
    REFERENCES `COUNTRY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CITY`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `CITY` ;

CREATE TABLE IF NOT EXISTS `CITY` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `STATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_CITY_STATE1_idx` (`STATE_id` ASC),
  CONSTRAINT `fk_CITY_STATE1`
    FOREIGN KEY (`STATE_id`)
    REFERENCES `STATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MANDATE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `MANDATE` ;

CREATE TABLE IF NOT EXISTS `MANDATE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `start_date` DATE NOT NULL,
  `end_date` DATE NOT NULL,
  `title` VARCHAR(100) NOT NULL COMMENT '(Representative, Federal Deputy, State Deputy, Mayor, President, Senator)',
  `active` TINYINT(1) NOT NULL,
  `validated` TINYINT(1) NULL,
  `validated_date` DATE NULL,
  `POWER_id` INT UNSIGNED NOT NULL,
  `CITY_id` INT UNSIGNED NOT NULL,
  `STATE_id` INT UNSIGNED NOT NULL,
  `COUNTRY_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_MANDATE_POWER1_idx` (`POWER_id` ASC),
  INDEX `fk_MANDATE_CITY1_idx` (`CITY_id` ASC),
  INDEX `fk_MANDATE_STATE1_idx` (`STATE_id` ASC),
  INDEX `fk_MANDATE_COUNTRY1_idx` (`COUNTRY_id` ASC),
  CONSTRAINT `fk_MANDATE_POWER1`
    FOREIGN KEY (`POWER_id`)
    REFERENCES `POWER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_CITY1`
    FOREIGN KEY (`CITY_id`)
    REFERENCES `CITY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_STATE1`
    FOREIGN KEY (`STATE_id`)
    REFERENCES `STATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_COUNTRY1`
    FOREIGN KEY (`COUNTRY_id`)
    REFERENCES `COUNTRY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `USER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `USER` ;

CREATE TABLE IF NOT EXISTS `USER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL COMMENT ' (who manage the system)',
  `last_name` VARCHAR(255) NOT NULL,
  `level` TINYINT(1) UNSIGNED NOT NULL,
  `enabled` TINYINT(1) NOT NULL,
  `IMAGE_id` INT UNSIGNED NOT NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_USER_IMAGE_idx` (`IMAGE_id` ASC),
  INDEX `fk_USER_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_USER_IMAGE`
    FOREIGN KEY (`IMAGE_id`)
    REFERENCES `IMAGE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_USER_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `VOTER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `VOTER` ;

CREATE TABLE IF NOT EXISTS `VOTER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `last_name` VARCHAR(255) NULL,
  `email` VARCHAR(255) NULL,
  `password` VARCHAR(255) NULL,
  `document` VARCHAR(45) NULL,
  `enabled` TINYINT(1) NULL,
  `IMAGE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_VOTER_IMAGE1_idx` (`IMAGE_id` ASC),
  CONSTRAINT `fk_VOTER_IMAGE1`
    FOREIGN KEY (`IMAGE_id`)
    REFERENCES `IMAGE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `POLL`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `POLL` ;

CREATE TABLE IF NOT EXISTS `POLL` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `start` DATETIME NOT NULL,
  `end` DATETIME NOT NULL,
  `description` LONGTEXT NULL,
  `tag` VARCHAR(255) NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POLL_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_POLL_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `CHOICE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `CHOICE` ;

CREATE TABLE IF NOT EXISTS `CHOICE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `text` TEXT NOT NULL,
  `POLL_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_CHOICE_POLL1_idx` (`POLL_id` ASC),
  CONSTRAINT `fk_CHOICE_POLL1`
    FOREIGN KEY (`POLL_id`)
    REFERENCES `POLL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `VOTER_CHOICE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `VOTER_CHOICE` ;

CREATE TABLE IF NOT EXISTS `VOTER_CHOICE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `time` TIMESTAMP NOT NULL,
  `CHOICES_id` INT UNSIGNED NOT NULL,
  `VOTERS_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_VOTE_CHOICE1_idx` (`CHOICES_id` ASC),
  INDEX `fk_VOTE_VOTER1_idx` (`VOTERS_id` ASC),
  CONSTRAINT `fk_VOTE_CHOICE1`
    FOREIGN KEY (`CHOICES_id`)
    REFERENCES `CHOICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VOTE_VOTER1`
    FOREIGN KEY (`VOTERS_id`)
    REFERENCES `VOTER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `POST`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `POST` ;

CREATE TABLE IF NOT EXISTS `POST` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `text` LONGTEXT NOT NULL,
  `date` DATETIME NOT NULL,
  `POLL_id` INT UNSIGNED NOT NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POST_POLL1_idx` (`POLL_id` ASC),
  INDEX `fk_POST_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_POST_POLL1`
    FOREIGN KEY (`POLL_id`)
    REFERENCES `POLL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_POST_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `MANDATE_VOTER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `MANDATE_VOTER` ;

CREATE TABLE IF NOT EXISTS `MANDATE_VOTER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `VOTERS_id` INT UNSIGNED NOT NULL,
  `MANDATES_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_VOTER_has_MANDATE_MANDATE1_idx` (`MANDATES_id` ASC),
  INDEX `fk_VOTER_has_MANDATE_VOTER1_idx` (`VOTERS_id` ASC),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  CONSTRAINT `fk_VOTER_has_MANDATE_VOTER1`
    FOREIGN KEY (`VOTERS_id`)
    REFERENCES `VOTER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VOTER_has_MANDATE_MANDATE1`
    FOREIGN KEY (`MANDATES_id`)
    REFERENCES `MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
