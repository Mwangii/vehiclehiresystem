-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 29, 2020 at 02:09 PM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `vehicle_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `check_in`
--

CREATE TABLE IF NOT EXISTS `check_in` (
  `Vehicle_ID` varchar(40) NOT NULL,
  `Client_ID` varchar(30) NOT NULL,
  `Return_Date` date NOT NULL,
  `Extra_Cost` int(20) DEFAULT NULL,
  PRIMARY KEY (`Vehicle_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `check_in`
--

INSERT INTO `check_in` (`Vehicle_ID`, `Client_ID`, `Return_Date`, `Extra_Cost`) VALUES
('34f', 'a', '0000-00-00', 300),
('DFGHJ', 'EDFGH', '0000-00-00', 455667),
('kaa', '2345', '0000-00-00', 3000),
('KAAA', 'EEE', '0000-00-00', 4000),
('kas', 'COM/001', '0000-00-00', 500),
('svbnm', 'asdfg', '0000-00-00', 0);

-- --------------------------------------------------------

--
-- Table structure for table `check_out`
--

CREATE TABLE IF NOT EXISTS `check_out` (
  `Vehicle_ID` varchar(200) NOT NULL,
  `Client_ID` varchar(30) NOT NULL,
  `Date` date NOT NULL,
  `Duration` int(30) NOT NULL,
  `Description` varchar(200) NOT NULL,
  `Status` varchar(35) NOT NULL,
  `Amount_Paid` int(20) NOT NULL,
  PRIMARY KEY (`Vehicle_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `check_out`
--

INSERT INTO `check_out` (`Vehicle_ID`, `Client_ID`, `Date`, `Duration`, `Description`, `Status`, `Amount_Paid`) VALUES
('kaa', '23456', '2018-07-05', 3, 'dgfhjkm,', '1', 20000),
('kax', 'EEE', '0000-00-00', 10, 'good', '1', 10000),
('KBA', 'COM/001', '0000-00-00', 10, 'good', '1', 5000),
('zxcv', 'qwert', '2018-07-05', 4, 'ertghj', '1', 45678);

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE IF NOT EXISTS `client` (
  `Client_ID` varchar(50) NOT NULL,
  `Client_Name` varchar(200) NOT NULL,
  `Mobile_No` varchar(12) NOT NULL,
  `Country` varchar(30) NOT NULL,
  `Status` varchar(200) NOT NULL,
  PRIMARY KEY (`Client_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`Client_ID`, `Client_Name`, `Mobile_No`, `Country`, `Status`) VALUES
('COM/001', 'MARTIN NJERI', '23456789', 'KENYA', '1'),
('EEE', 'FFWFW', '3434543K', 'UD', '1');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE IF NOT EXISTS `employee` (
  `Employee_ID` varchar(30) NOT NULL,
  `Employee_Name` varchar(200) NOT NULL,
  `Mobile_No` varchar(12) NOT NULL,
  PRIMARY KEY (`Employee_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Employee_ID`, `Employee_Name`, `Mobile_No`) VALUES
('sdfgbh', 'fghnjm', '23456789');

-- --------------------------------------------------------

--
-- Table structure for table `owner`
--

CREATE TABLE IF NOT EXISTS `owner` (
  `Owner_ID` varchar(50) NOT NULL,
  `Owner_Name` varchar(200) NOT NULL,
  `Mobile_No` varchar(30) NOT NULL,
  `Status` varchar(30) NOT NULL,
  PRIMARY KEY (`Owner_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `owner`
--

INSERT INTO `owner` (`Owner_ID`, `Owner_Name`, `Mobile_No`, `Status`) VALUES
('1234', 'ALEX', '2345678', '1'),
('a', 'vw', '22345', '1'),
('adf', 'sdfdfvdde', 'wdef', 'kAA'),
('asdf', 'sdf', '2345r', '1'),
('asjbvdnm', 'dvsda', '2345', '1'),
('sdfgh', 'x', '2345678', '1'),
('x', 'm', '1234567', '1');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE IF NOT EXISTS `payments` (
  `Payment_ID` varchar(30) NOT NULL,
  `Client_ID` varchar(40) NOT NULL,
  `Payment_Method` varchar(50) NOT NULL,
  PRIMARY KEY (`Payment_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`Payment_ID`, `Client_ID`, `Payment_Method`) VALUES
('CNG4578BGV', 'EEE', 'MPESA'),
('CSDFGG23JBNM', 'COM/0017', 'MPESA'),
('MP1234', '23FV ', 'CASH'),
('nk,m m', 'COM/001', 'CHEQUE'),
('SGVHBNMALK', 'HJKM', '0');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `User_ID` varchar(30) NOT NULL,
  `User_Name` varchar(200) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Priveledges` varchar(200) NOT NULL,
  `Status` smallint(30) NOT NULL,
  PRIMARY KEY (`User_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`User_ID`, `User_Name`, `Password`, `Priveledges`, `Status`) VALUES
(' c0m/0017', 'adm', '123', 'Admin', 1),
('com/0017', 'adm', 'adm', 'Admin', 1),
('com/0018', 'alex', 'alex', 'Normal', 1);

-- --------------------------------------------------------

--
-- Table structure for table `vehicle`
--

CREATE TABLE IF NOT EXISTS `vehicle` (
  `Vehicle_ID` varchar(50) NOT NULL,
  `Make` varchar(50) NOT NULL,
  `Model` varchar(80) NOT NULL,
  `Reg_Date` date NOT NULL,
  `Rate` varchar(20) NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `Owner_ID` varchar(50) NOT NULL,
  `Photo` varchar(1000) NOT NULL,
  PRIMARY KEY (`Vehicle_ID`),
  KEY `Owner_ID` (`Owner_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vehicle`
--

INSERT INTO `vehicle` (`Vehicle_ID`, `Make`, `Model`, `Reg_Date`, `Rate`, `Status`, `Owner_ID`, `Photo`) VALUES
('KAAA', 'MERCEDES', 'G GALSS', '2018-07-15', '234567', 1, 'a', 'C:__Users__ALEXK__Desktop__PICS__SUBARU.jpeg'),
('kas', 'toyota', 'v8', '0000-00-00', '5000', 1, 'shjm', 'C:__Users__ALEXK__Desktop__PICS__TOYOYAV8.jpeg'),
('kax', 'xxx', 'mmm', '0000-00-00', 'System.Windows.Forms', 1, 'System.Windows.Forms.TextBox, Text: asd', ''),
('KBA', 'eref', 'df', '0000-00-00', '0', 0, '1', 'C:__Users__ALEXK__Desktop__PICS__RANGE.jpeg'),
('KBC 223', 'SUBARU', 'FORESTER', '0000-00-00', '3500', 1, '2345678AXX', 'C:__Users__ALEXK__Desktop__PICS__SUBARU.jpeg'),
('KCA', 'fgvb', 'f', '0000-00-00', '0', 0, '1', 'C:__Users__ALEXK__Desktop__PICS__SUBARU_Copy.jpeg'),
('kcv', 'subaru', 'imprexa', '2018-06-26', '67788', 0, '1', 'C:__Users__ALEXK__Desktop__PICS__AUDI_Copy - Copy.jpeg'),
('q4677', 'dhh', 'ghgjk', '2018-07-02', '78', 0, '1', 'C:__Users__ALEXK__Desktop__PICS__AUDI.jpeg'),
('weretrytuiyou', 'xcvbnm,', 'rtdtfh', '2019-04-24', '46', 1, 'a', 'C:__Users__ALEXK__Desktop__CX__IMG_20170406_222737.JPG');
