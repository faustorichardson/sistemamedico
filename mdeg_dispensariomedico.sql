/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : mdeg_dispensariomedico

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2014-11-30 10:18:30
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `departamentos`
-- ----------------------------
DROP TABLE IF EXISTS `departamentos`;
CREATE TABLE `departamentos` (
  `departamento_id` int(11) NOT NULL AUTO_INCREMENT,
  `departamento_descripcion` varchar(50) NOT NULL,
  `departamento_tipoespecialidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`departamento_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of departamentos
-- ----------------------------
INSERT INTO `departamentos` VALUES ('1', 'OFTALMOLOGIA', null);
INSERT INTO `departamentos` VALUES ('2', 'CARDIOLOGIA', null);
INSERT INTO `departamentos` VALUES ('3', 'ORTODONCIA', null);
INSERT INTO `departamentos` VALUES ('4', 'PEDIATRIA', null);
INSERT INTO `departamentos` VALUES ('5', 'Alergología', '4');
INSERT INTO `departamentos` VALUES ('6', 'ENDOCRINOLOGIA', '4');
INSERT INTO `departamentos` VALUES ('7', 'CIRUGIA CARDIOVASCULAR', '2');

-- ----------------------------
-- Table structure for `doctores`
-- ----------------------------
DROP TABLE IF EXISTS `doctores`;
CREATE TABLE `doctores` (
  `doctores_id` int(11) NOT NULL AUTO_INCREMENT,
  `doctores_cedula` varchar(13) DEFAULT NULL,
  `doctores_rango` int(11) DEFAULT NULL,
  `doctores_nombre` varchar(50) DEFAULT NULL,
  `doctores_apellido` varchar(50) DEFAULT NULL,
  `doctores_edad` varchar(2) DEFAULT NULL,
  `doctores_sexo` varchar(1) DEFAULT NULL,
  `doctores_exequatur` varchar(45) DEFAULT NULL,
  `doctores_especialidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`doctores_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of doctores
-- ----------------------------
INSERT INTO `doctores` VALUES ('1', '001-1236078-9', '2', 'FAUSTO RAFAEL', 'RICHARDSON HERNANDEZ', '36', 'M', '22342331456', '2');

-- ----------------------------
-- Table structure for `especialidades`
-- ----------------------------
DROP TABLE IF EXISTS `especialidades`;
CREATE TABLE `especialidades` (
  `especialidades_id` int(11) NOT NULL AUTO_INCREMENT,
  `especialidades_departamento` int(11) NOT NULL,
  `especialidades_descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`especialidades_id`),
  UNIQUE KEY `especialidades_descripcion_UNIQUE` (`especialidades_descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of especialidades
-- ----------------------------
INSERT INTO `especialidades` VALUES ('1', '2', 'CARDIOLOGIA');
INSERT INTO `especialidades` VALUES ('2', '6', 'ENDOCRINOLOGO');
INSERT INTO `especialidades` VALUES ('3', '6', 'TURBI');

-- ----------------------------
-- Table structure for `especialidades_tipo`
-- ----------------------------
DROP TABLE IF EXISTS `especialidades_tipo`;
CREATE TABLE `especialidades_tipo` (
  `id_tipoespecialidad` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion_tipoespecialidad` varchar(50) NOT NULL,
  PRIMARY KEY (`id_tipoespecialidad`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of especialidades_tipo
-- ----------------------------
INSERT INTO `especialidades_tipo` VALUES ('1', 'QUIRURGICAS');
INSERT INTO `especialidades_tipo` VALUES ('2', 'MEDICO QUIRURGICAS');
INSERT INTO `especialidades_tipo` VALUES ('3', 'ESPECIALIDADES DE LABORATORIO O DIAGNOSTICA');
INSERT INTO `especialidades_tipo` VALUES ('4', 'CLINICAS');

-- ----------------------------
-- Table structure for `paciente`
-- ----------------------------
DROP TABLE IF EXISTS `paciente`;
CREATE TABLE `paciente` (
  `id_paciente` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(13) NOT NULL,
  `rango` int(11) NOT NULL,
  `nombre` varchar(75) NOT NULL,
  `apellido` varchar(75) NOT NULL,
  `edad` int(11) NOT NULL,
  `sexo` varchar(1) NOT NULL,
  `dato_nacimiento` mediumtext,
  `dato_alimentacion` mediumtext,
  `dato_condicionespsicologicas` mediumtext,
  `dato_sexualidad` mediumtext,
  `dato_operaciones` mediumtext,
  `dato_intoleranciamedicinal` mediumtext,
  `dato_saludpadres` mediumtext,
  `dato_saludhermanos` mediumtext,
  `dato_saludesposahijos` mediumtext,
  `dato_saludfamiliargeneral` mediumtext,
  `fecharegistro` datetime NOT NULL,
  `fechaupdate` datetime NOT NULL,
  PRIMARY KEY (`id_paciente`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of paciente
-- ----------------------------
INSERT INTO `paciente` VALUES ('1', '001-1236078-9', '1', 'Fausto R.', 'Richardson H.', '36', 'F', 'NONE', 'NONE', 'PRUEBA', 'NONE', 'NONE', 'NONE', 'NONE', 'NONE', 'NONE', 'NONE', '2014-11-06 11:32:30', '2014-11-30 10:10:33');

-- ----------------------------
-- Table structure for `rangos`
-- ----------------------------
DROP TABLE IF EXISTS `rangos`;
CREATE TABLE `rangos` (
  `rango_id` int(11) NOT NULL AUTO_INCREMENT,
  `rango_descripcion` varchar(50) NOT NULL,
  PRIMARY KEY (`rango_id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of rangos
-- ----------------------------
INSERT INTO `rangos` VALUES ('1', 'Almirante');
INSERT INTO `rangos` VALUES ('2', 'Vicealmirante');
INSERT INTO `rangos` VALUES ('3', 'Contralmirante');
INSERT INTO `rangos` VALUES ('4', 'Capitan de Navio');
INSERT INTO `rangos` VALUES ('5', 'Capitan de Fragata');
INSERT INTO `rangos` VALUES ('6', 'Capitan de Corbeta');
INSERT INTO `rangos` VALUES ('7', 'Teniente de Navio');
INSERT INTO `rangos` VALUES ('8', 'Teniente de Fragata');
INSERT INTO `rangos` VALUES ('9', 'Teniente de Corbeta');
INSERT INTO `rangos` VALUES ('10', 'Guardiamarina');
INSERT INTO `rangos` VALUES ('11', 'Sargento Mayor');
INSERT INTO `rangos` VALUES ('12', 'Sargento');
INSERT INTO `rangos` VALUES ('13', 'Cabo');
INSERT INTO `rangos` VALUES ('14', 'Marinero');
INSERT INTO `rangos` VALUES ('15', 'Marinero Auxiliar');

-- ----------------------------
-- Procedure structure for `departamentos_proximo`
-- ----------------------------
DROP PROCEDURE IF EXISTS `departamentos_proximo`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `departamentos_proximo`()
BEGIN
	declare nRegistros int default 0;
	
	SELECT max(departamento_id) + 1 as proximo from departamentos;
	
	SET nRegistros = row_count();
	IF nRegistros = 0 then
		SELECT 1 as proximo, departamento_id from departamentos;
	ELSE
		SELECT max(departamento_id) + 1 as proximo from departamentos;
	END IF;

END
;;
DELIMITER ;
