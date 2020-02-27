USE `chapela` ;

-- -----------------------------------------------------
-- Table `chapela`.`IMAGE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`IMAGE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `url` TEXT NOT NULL COMMENT '(public url to access the image)',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`SPHERE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`SPHERE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL COMMENT '(country, state, city)',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`POWER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`POWER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `SPHERE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `SPHERE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POWER_SPHERE1_idx` (`SPHERE_id` ASC),
  CONSTRAINT `fk_POWER_SPHERE1`
    FOREIGN KEY (`SPHERE_id`)
    REFERENCES `chapela`.`SPHERE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`COUNTRY`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`COUNTRY` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`STATE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`STATE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `COUNTRY_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `COUNTRY_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_STATE_COUNTRY1_idx` (`COUNTRY_id` ASC),
  CONSTRAINT `fk_STATE_COUNTRY1`
    FOREIGN KEY (`COUNTRY_id`)
    REFERENCES `chapela`.`COUNTRY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`CITY`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`CITY` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `STATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `STATE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_CITY_STATE1_idx` (`STATE_id` ASC),
  CONSTRAINT `fk_CITY_STATE1`
    FOREIGN KEY (`STATE_id`)
    REFERENCES `chapela`.`STATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`MANDATE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`MANDATE` (
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
  PRIMARY KEY (`id`, `POWER_id`, `CITY_id`, `STATE_id`, `COUNTRY_id`),
  INDEX `fk_MANDATE_POWER1_idx` (`POWER_id` ASC),
  INDEX `fk_MANDATE_CITY1_idx` (`CITY_id` ASC),
  INDEX `fk_MANDATE_STATE1_idx` (`STATE_id` ASC),
  INDEX `fk_MANDATE_COUNTRY1_idx` (`COUNTRY_id` ASC),
  CONSTRAINT `fk_MANDATE_POWER1`
    FOREIGN KEY (`POWER_id`)
    REFERENCES `chapela`.`POWER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_CITY1`
    FOREIGN KEY (`CITY_id`)
    REFERENCES `chapela`.`CITY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_STATE1`
    FOREIGN KEY (`STATE_id`)
    REFERENCES `chapela`.`STATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_MANDATE_COUNTRY1`
    FOREIGN KEY (`COUNTRY_id`)
    REFERENCES `chapela`.`COUNTRY` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`USER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`USER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL COMMENT ' (who manage the system)',
  `last_name` VARCHAR(255) NOT NULL,
  `level` TINYINT(1) UNSIGNED NOT NULL,
  `enabled` TINYINT(1) NOT NULL,
  `IMAGE_id` INT UNSIGNED NOT NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `MANDATE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_USER_IMAGE_idx` (`IMAGE_id` ASC),
  INDEX `fk_USER_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_USER_IMAGE`
    FOREIGN KEY (`IMAGE_id`)
    REFERENCES `chapela`.`IMAGE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_USER_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `chapela`.`MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`VOTER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`VOTER` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `last_name` VARCHAR(255) NULL,
  `email` VARCHAR(255) NULL,
  `password` VARCHAR(255) NULL,
  `document` VARCHAR(45) NULL,
  `enabled` TINYINT(1) NULL,
  `IMAGE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `IMAGE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_VOTER_IMAGE1_idx` (`IMAGE_id` ASC),
  CONSTRAINT `fk_VOTER_IMAGE1`
    FOREIGN KEY (`IMAGE_id`)
    REFERENCES `chapela`.`IMAGE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`POLL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`POLL` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `start` DATETIME NOT NULL,
  `end` DATETIME NOT NULL,
  `description` LONGTEXT NULL,
  `tag` VARCHAR(255) NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `MANDATE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POLL_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_POLL_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `chapela`.`MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`CHOICE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`CHOICE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `text` TEXT NOT NULL,
  `POLL_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `POLL_id`),
  INDEX `fk_CHOICE_POLL1_idx` (`POLL_id` ASC),
  CONSTRAINT `fk_CHOICE_POLL1`
    FOREIGN KEY (`POLL_id`)
    REFERENCES `chapela`.`POLL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`VOTE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`VOTE` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `time` TIMESTAMP NOT NULL,
  `CHOICE_id` INT UNSIGNED NOT NULL,
  `VOTER_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `CHOICE_id`, `VOTER_id`),
  INDEX `fk_VOTE_CHOICE1_idx` (`CHOICE_id` ASC),
  INDEX `fk_VOTE_VOTER1_idx` (`VOTER_id` ASC),
  CONSTRAINT `fk_VOTE_CHOICE1`
    FOREIGN KEY (`CHOICE_id`)
    REFERENCES `chapela`.`CHOICE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VOTE_VOTER1`
    FOREIGN KEY (`VOTER_id`)
    REFERENCES `chapela`.`VOTER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`POST`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`POST` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `text` LONGTEXT NOT NULL,
  `date` DATETIME NOT NULL,
  `POLL_id` INT UNSIGNED NOT NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`, `POLL_id`, `MANDATE_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_POST_POLL1_idx` (`POLL_id` ASC),
  INDEX `fk_POST_MANDATE1_idx` (`MANDATE_id` ASC),
  CONSTRAINT `fk_POST_POLL1`
    FOREIGN KEY (`POLL_id`)
    REFERENCES `chapela`.`POLL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_POST_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `chapela`.`MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `chapela`.`VOTER_has_MANDATE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `chapela`.`VOTER_has_MANDATE` (
  `VOTER_id` INT UNSIGNED NOT NULL,
  `MANDATE_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`VOTER_id`, `MANDATE_id`),
  INDEX `fk_VOTER_has_MANDATE_MANDATE1_idx` (`MANDATE_id` ASC),
  INDEX `fk_VOTER_has_MANDATE_VOTER1_idx` (`VOTER_id` ASC),
  CONSTRAINT `fk_VOTER_has_MANDATE_VOTER1`
    FOREIGN KEY (`VOTER_id`)
    REFERENCES `chapela`.`VOTER` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_VOTER_has_MANDATE_MANDATE1`
    FOREIGN KEY (`MANDATE_id`)
    REFERENCES `chapela`.`MANDATE` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;