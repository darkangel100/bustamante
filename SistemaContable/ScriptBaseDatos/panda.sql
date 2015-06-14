-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-06-2015 a las 16:13:01
-- Versión del servidor: 5.6.17
-- Versión de PHP: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `panda`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asiento`
--

CREATE TABLE IF NOT EXISTS `asiento` (
  `nombre_asiento` varchar(30) NOT NULL,
  PRIMARY KEY (`nombre_asiento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asiento_contable`
--

CREATE TABLE IF NOT EXISTS `asiento_contable` (
  `id_usuario` int(11) DEFAULT NULL,
  `id_asiento` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_asiento` varchar(30) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `tipo` varchar(30) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_asiento`),
  KEY `FK_asiento_contable` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE IF NOT EXISTS `cuenta` (
  `id_usuario` int(11) NOT NULL,
  `usuario` varchar(25) NOT NULL,
  `contrasenia` varchar(30) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_factura`
--

CREATE TABLE IF NOT EXISTS `detalle_factura` (
  `id_factura` int(11) DEFAULT NULL,
  `id_detalle` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) DEFAULT NULL,
  `cantidad` int(11) NOT NULL,
  `nombre_producto` varchar(30) NOT NULL,
  `costo_unitario` double NOT NULL,
  `costo_total` double NOT NULL,
  PRIMARY KEY (`id_detalle`),
  KEY `FK_detalle_factura` (`id_factura`),
  KEY `FK_detalle_facturaP` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `distribuidora`
--

CREATE TABLE IF NOT EXISTS `distribuidora` (
  `id_distribuidora` int(11) NOT NULL AUTO_INCREMENT,
  `nombreDistribuidora` varchar(40) NOT NULL,
  `direccionDistribuidora` varchar(50) NOT NULL,
  `telefonoDistribuidora` varchar(10) NOT NULL,
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_distribuidora`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `factura`
--

CREATE TABLE IF NOT EXISTS `factura` (
  `id_proveedor` int(11) DEFAULT NULL,
  `id_factura` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `total` double NOT NULL,
  `subtotal` double NOT NULL,
  `iva` double NOT NULL DEFAULT '0',
  `tipo_fac` varchar(1) NOT NULL,
  PRIMARY KEY (`id_factura`),
  KEY `FK_facturaC` (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `lote`
--

CREATE TABLE IF NOT EXISTS `lote` (
  `codLote` varchar(20) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `stock_unidades` int(11) NOT NULL,
  `fechaVencimiento` date NOT NULL,
  `fechaElaboracion` date NOT NULL,
  PRIMARY KEY (`codLote`),
  KEY `FK_lote_idx` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `lote`
--

INSERT INTO `lote` (`codLote`, `id_producto`, `descripcion`, `stock_unidades`, `fechaVencimiento`, `fechaElaboracion`) VALUES
('A000', 18, 'Compra de pilas 10 de febrero', 78, '2020-01-01', '2014-01-01'),
('A001', 19, 'Compra baterias por falta', 99, '2020-02-02', '2010-02-02');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE IF NOT EXISTS `pago` (
  `id_pago` int(11) NOT NULL AUTO_INCREMENT,
  `fecha_ingreso` date NOT NULL,
  `monto` double NOT NULL,
  PRIMARY KEY (`id_pago`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE IF NOT EXISTS `producto` (
  `id_producto` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `precio` double NOT NULL,
  `estado` varchar(1) NOT NULL,
  `stock_global` int(11) NOT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`id_producto`, `nombre`, `precio`, `estado`, `stock_global`) VALUES
(18, 'pila', 2.3, 'a', 78),
(19, 'bateria', 3, 'a', 100),
(20, 'cuaderno 100 hojas', 0.7, 'a', 25),
(21, 'Lapiz', 0.45, 'a', 30),
(22, 'Esfero', 0.4, 'a', 60),
(23, 'Corrector', 0.5, 'a', 60),
(24, 'Carpeta folder', 0.35, 'a', 45);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE IF NOT EXISTS `proveedor` (
  `id_distribuidora` int(11) DEFAULT NULL,
  `id_proveedor` int(11) NOT NULL AUTO_INCREMENT,
  `nombreProveedor` varchar(40) NOT NULL,
  `correoProveedor` varchar(50) DEFAULT NULL,
  `celularProveedor` varchar(10) NOT NULL,
  `tiempoVisita` varchar(20) DEFAULT '0',
  `estado` varchar(1) NOT NULL,
  PRIMARY KEY (`id_proveedor`),
  KEY `FK_proveedor` (`id_distribuidora`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE IF NOT EXISTS `rol` (
  `id_rol` int(11) NOT NULL,
  `tipo` varchar(1) NOT NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE KEY `id` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `cedula` varchar(10) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `direccion` varchar(50) NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `asiento_contable`
--
ALTER TABLE `asiento_contable`
  ADD CONSTRAINT `FK_asiento_contable` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`);

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `FK_cuenta` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`);

--
-- Filtros para la tabla `detalle_factura`
--
ALTER TABLE `detalle_factura`
  ADD CONSTRAINT `FK_detalle_factura` FOREIGN KEY (`id_factura`) REFERENCES `factura` (`id_factura`),
  ADD CONSTRAINT `FK_detalle_facturaP` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`);

--
-- Filtros para la tabla `factura`
--
ALTER TABLE `factura`
  ADD CONSTRAINT `FK_factura` FOREIGN KEY (`id_factura`) REFERENCES `asiento_contable` (`id_asiento`),
  ADD CONSTRAINT `FK_facturaC` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`id_proveedor`);

--
-- Filtros para la tabla `lote`
--
ALTER TABLE `lote`
  ADD CONSTRAINT `FK_lote` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `FK_pago` FOREIGN KEY (`id_pago`) REFERENCES `asiento_contable` (`id_asiento`);

--
-- Filtros para la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD CONSTRAINT `FK_proveedor` FOREIGN KEY (`id_distribuidora`) REFERENCES `distribuidora` (`id_distribuidora`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `FK_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `rol` (`id_rol`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
