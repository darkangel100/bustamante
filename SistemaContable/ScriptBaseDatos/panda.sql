/*
SQLyog Enterprise - MySQL GUI v8.18 
MySQL - 5.5.8-log : Database - panda
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`panda` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `panda`;

/*Table structure for table `asiento` */

DROP TABLE IF EXISTS `asiento`;

CREATE TABLE `asiento` (
  `nombre_asiento` varchar(30) NOT NULL,
  PRIMARY KEY (`nombre_asiento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `asiento` */

insert  into `asiento`(`nombre_asiento`) values ('CUENTAS POR COBRAR'),('CUENTAS POR PAGAR'),('IMPLEMENTOS DE OFICINA'),('SERVICIOS BASICOS');

/*Table structure for table `asiento_contable` */

DROP TABLE IF EXISTS `asiento_contable`;

CREATE TABLE `asiento_contable` (
  `id_usuario` int(11) DEFAULT NULL,
  `id_asiento` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_asiento` varchar(30) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_asiento`),
  KEY `FK_asiento_contable` (`id_usuario`),
  CONSTRAINT `asiento_contable_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `asiento_contable` */

insert  into `asiento_contable`(`id_usuario`,`id_asiento`,`nombre_asiento`,`descripcion`,`estado`) values (NULL,7,'COMPRA DE MERCADERIA','compra a ile','');

/*Table structure for table `cuenta` */

DROP TABLE IF EXISTS `cuenta`;

CREATE TABLE `cuenta` (
  `id_usuario` int(11) NOT NULL,
  `usuario` varchar(20) NOT NULL,
  `contrasenia` varchar(30) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_usuario`),
  CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `cuenta` */

insert  into `cuenta`(`id_usuario`,`usuario`,`contrasenia`,`estado`) values (1,'luis111','luis1','A'),(2,'dany111','dany1','A'),(3,'jennifer111','jenifer1','P'),(4,'jose111','jose1','A');

/*Table structure for table `detalle_factura` */

DROP TABLE IF EXISTS `detalle_factura`;

CREATE TABLE `detalle_factura` (
  `id_factura` int(11) DEFAULT NULL,
  `id_detalle` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) DEFAULT NULL,
  `cantidad` int(11) NOT NULL,
  `nombre_producto` varchar(30) NOT NULL,
  `costo_unitario` double NOT NULL,
  `costo_total` double NOT NULL,
  PRIMARY KEY (`id_detalle`),
  KEY `FK_detalle_factura` (`id_factura`),
  KEY `FK_detalle_facturaP` (`id_producto`),
  CONSTRAINT `FK_detalle_factura` FOREIGN KEY (`id_factura`) REFERENCES `factura` (`id_factura`),
  CONSTRAINT `FK_detalle_facturaP` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `detalle_factura` */

/*Table structure for table `distribuidora` */

DROP TABLE IF EXISTS `distribuidora`;

CREATE TABLE `distribuidora` (
  `id_distribuidora` int(11) NOT NULL AUTO_INCREMENT,
  `nombreDistribuidora` varchar(40) NOT NULL,
  `direccionDistribuidora` varchar(50) NOT NULL,
  `telefonoDistribuidora` varchar(10) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_distribuidora`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `distribuidora` */

/*Table structure for table `factura` */

DROP TABLE IF EXISTS `factura`;

CREATE TABLE `factura` (
  `id_proveedor` int(11) DEFAULT NULL,
  `id_factura` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `total` double NOT NULL,
  `subtotal` double NOT NULL,
  `iva` double NOT NULL DEFAULT '0',
  `tipo_fac` varchar(1) NOT NULL,
  PRIMARY KEY (`id_factura`),
  KEY `FK_facturaC` (`id_proveedor`),
  CONSTRAINT `FK_factura` FOREIGN KEY (`id_factura`) REFERENCES `asiento_contable` (`id_asiento`),
  CONSTRAINT `FK_facturaC` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `factura` */

/*Table structure for table `lote` */

DROP TABLE IF EXISTS `lote`;

CREATE TABLE `lote` (
  `codLote` varchar(20) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `stock_unidades` int(11) NOT NULL,
  `fechaVencimiento` date NOT NULL,
  `fechaElaboracion` date NOT NULL,
  PRIMARY KEY (`codLote`),
  KEY `FK_lote_idx` (`id_producto`),
  CONSTRAINT `FK_lote` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `lote` */

insert  into `lote`(`codLote`,`id_producto`,`descripcion`,`stock_unidades`,`fechaVencimiento`,`fechaElaboracion`) values ('A000',18,'Compra de pilas 10 de febrero',78,'2020-01-01','2014-01-01'),('A001',19,'Compra baterias por falta',99,'2020-02-02','2010-02-02');

/*Table structure for table `pago` */

DROP TABLE IF EXISTS `pago`;

CREATE TABLE `pago` (
  `id_pago` int(11) NOT NULL,
  `fecha_ingreso` date NOT NULL,
  `monto` double NOT NULL,
  PRIMARY KEY (`id_pago`),
  CONSTRAINT `FK_pago` FOREIGN KEY (`id_pago`) REFERENCES `asiento_contable` (`id_asiento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pago` */

/*Table structure for table `producto` */

DROP TABLE IF EXISTS `producto`;

CREATE TABLE `producto` (
  `id_producto` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `precio` double NOT NULL,
  `estado` varchar(1) NOT NULL,
  `stock_global` int(11) NOT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

/*Data for the table `producto` */

insert  into `producto`(`id_producto`,`nombre`,`precio`,`estado`,`stock_global`) values (18,'pila',2.3,'a',78),(19,'bateria',3.3,'a',99),(24,'',35,'A',40),(25,'',2,'A',20),(26,'',3,'A',15);

/*Table structure for table `proveedor` */

DROP TABLE IF EXISTS `proveedor`;

CREATE TABLE `proveedor` (
  `id_distribuidora` int(11) DEFAULT NULL,
  `id_proveedor` int(11) NOT NULL AUTO_INCREMENT,
  `nombreProveedor` varchar(40) NOT NULL,
  `correoProveedor` varchar(50) DEFAULT NULL,
  `celularProveedor` varchar(10) NOT NULL,
  `tiempoVisita` varchar(20) DEFAULT '0',
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_proveedor`),
  KEY `FK_proveedor` (`id_distribuidora`),
  CONSTRAINT `FK_proveedor` FOREIGN KEY (`id_distribuidora`) REFERENCES `distribuidora` (`id_distribuidora`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `proveedor` */

/*Table structure for table `rol` */

DROP TABLE IF EXISTS `rol`;

CREATE TABLE `rol` (
  `id_rol` int(11) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `rol` */

insert  into `rol`(`id_rol`,`tipo`) values (1,'A'),(2,'B'),(3,'C');

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `id_rol` int(11) NOT NULL,
  `cedula` varchar(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `id_rol` (`id_rol`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `usuario` */

insert  into `usuario`(`id_usuario`,`id_rol`,`cedula`,`nombre`,`apellido`,`telefono`,`direccion`) values (1,1,'111','Luis','Viñamagua','2580123','Argelia'),(2,3,'112','Dany','Romero','2580913','Sauces'),(3,3,'113','Jennifer','Bustamante','2580123','Pedestal'),(4,2,'114','Jose Luis','Astudillo','2580114','Cdla Daniel Alvarez');

/*Table structure for table `x` */

DROP TABLE IF EXISTS `x`;

CREATE TABLE `x` (
  `id_rol` int(11) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  UNIQUE KEY `id` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `x` */

/*Table structure for table `z` */

DROP TABLE IF EXISTS `z`;

CREATE TABLE `z` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(10) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `direccion` varchar(50) NOT NULL,
  PRIMARY KEY (`id_usuario`),
  CONSTRAINT `FK_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `x` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `z` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
