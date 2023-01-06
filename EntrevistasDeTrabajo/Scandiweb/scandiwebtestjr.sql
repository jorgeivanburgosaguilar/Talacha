-- Scandiweb Junior Developer Test Task
-- Incomplete solution, time constrain hit attribute metadata is missing (+ app development)


CREATE TABLE `scandiwebtest`.`product_type_unit` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `scandiwebtest`.`product_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `product_type_unit_id` INT NOT NULL,
  `name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `id_idx` (`product_type_unit_id` ASC) VISIBLE,
  CONSTRAINT `fk_product_type_unit_id`
    FOREIGN KEY (`product_type_unit_id`)
    REFERENCES `scandiwebtest`.`product_type_unit` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE `scandiwebtest`.`product` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `product_type_id` INT NOT NULL,
  `sku` VARCHAR(255) NOT NULL,
  `name` NVARCHAR(255) NOT NULL,
  `price` DECIMAL(15,2) NOT NULL,
  UNIQUE INDEX `sku_UNIQUE` (`sku` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  INDEX `fk_product_type_id_idx` (`product_type_id` ASC) VISIBLE,
  CONSTRAINT `fk_product_type_id`
    FOREIGN KEY (`product_type_id`)
    REFERENCES `scandiwebtest`.`product_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);