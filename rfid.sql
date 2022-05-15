-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 15, 2022 at 04:46 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rfid`
--

-- --------------------------------------------------------

--
-- Table structure for table `Employee`
--

CREATE TABLE `Employee` (
  `employee_id` varchar(20) NOT NULL,
  `name` varchar(30) NOT NULL,
  `gender` varchar(10) NOT NULL,
  `date_of_birth` date NOT NULL,
  `department` varchar(30) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(200) NOT NULL,
  `is_enable` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Employee`
--

INSERT INTO `Employee` (`employee_id`, `name`, `gender`, `date_of_birth`, `department`, `username`, `password`, `is_enable`) VALUES
('EMP001', 'Nguyễn Phạm Minh Quân', 'Male', '2000-01-06', 'Warehouse Manager', 'admin1', '2bevi1vhEgW7EYM5ha+v7Q==', 1),
('EMP002', 'Lương Vĩ Lâm', 'Male', '1998-03-03', 'Warehouse Staff', 'user2', '2bevi1vhEgW7EYM5ha+v7Q==', 1),
('EMP003', 'Charlotte J.William', 'Female', '1992-09-03', 'Sales Executive', 'admin2', '2bevi1vhEgW7EYM5ha+v7Q==', 1),
('EMP004', 'Nguyễn Thị Thanh Nguyệt', 'Female', '2001-09-01', 'Sales Staff', 'user1', '2bevi1vhEgW7EYM5ha+v7Q==', 1);

-- --------------------------------------------------------

--
-- Table structure for table `GoodsReceiptNote`
--

CREATE TABLE `GoodsReceiptNote` (
  `grn_id` varchar(20) NOT NULL,
  `employee_id` varchar(20) NOT NULL,
  `employee_check_id` varchar(20) DEFAULT NULL,
  `created_time` datetime NOT NULL,
  `total_expected_quantity` int(11) NOT NULL DEFAULT 0,
  `total_actual_quantity` int(11) NOT NULL DEFAULT -1,
  `total_price` int(11) NOT NULL DEFAULT 0,
  `note` text DEFAULT NULL,
  `is_enable` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `GoodsReceiptNote`
--

INSERT INTO `GoodsReceiptNote` (`grn_id`, `employee_id`, `employee_check_id`, `created_time`, `total_expected_quantity`, `total_actual_quantity`, `total_price`, `note`, `is_enable`) VALUES
('GRN001', 'EMP001', 'EMP001', '2022-04-19 04:57:46', 4, 4, 0, 'Completed quantity', 1),
('GRN002', 'EMP002', 'EMP001', '2022-04-19 04:57:46', 5, 0, 0, 'New GRN', 1),
('GRN003', 'EMP003', 'EMP001', '2022-04-19 04:57:46', 3, 3, 0, 'Completed quantity', 1),
('GRN004', 'EMP001', 'EMP001', '2022-04-20 11:10:31', 7, 7, 0, 'Completed quantity', 1),
('GRN005', 'EMP004', 'EMP001', '2022-04-20 11:14:39', 4, 3, 0, 'Missing quantity', 1);

-- --------------------------------------------------------

--
-- Table structure for table `GoodsReceiptNoteDetail`
--

CREATE TABLE `GoodsReceiptNoteDetail` (
  `grn_id` varchar(20) NOT NULL,
  `product_line_id` varchar(20) NOT NULL,
  `expected_quantity` int(11) NOT NULL DEFAULT 0,
  `actual_quantity` int(11) NOT NULL DEFAULT 0,
  `import_price` int(11) NOT NULL DEFAULT 0,
  `is_checked` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `GoodsReceiptNoteDetail`
--

INSERT INTO `GoodsReceiptNoteDetail` (`grn_id`, `product_line_id`, `expected_quantity`, `actual_quantity`, `import_price`, `is_checked`) VALUES
('GRN001', 'AP.BA01', 2, 2, 0, 1),
('GRN001', 'LT.AG01', 1, 1, 0, 1),
('GRN001', 'MO.AE23', 1, 1, 0, 1),
('GRN002', 'MO.AE23', 1, 0, 0, 0),
('GRN002', 'ST.S501', 3, 0, 0, 0),
('GRN002', 'SW.XS01', 1, 0, 0, 0),
('GRN003', 'AP.BA01', 2, 2, 0, 1),
('GRN003', 'LT.AG01', 1, 1, 0, 1),
('GRN004', 'AP.BA01', 2, 2, 0, 1),
('GRN004', 'LT.AG01', 2, 2, 0, 1),
('GRN004', 'MO.AE23', 3, 3, 0, 1),
('GRN005', 'AP.BA01', 3, 3, 0, 1),
('GRN005', 'LT.AG01', 1, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `Product`
--

CREATE TABLE `Product` (
  `product_line_id` varchar(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `price` decimal(10,0) NOT NULL DEFAULT 0,
  `unit` varchar(15) NOT NULL,
  `min_stock_quantity` int(11) NOT NULL DEFAULT 0,
  `stock_quantity` int(11) NOT NULL DEFAULT 0,
  `type` varchar(20) NOT NULL,
  `description` text DEFAULT NULL,
  `is_enable` tinyint(1) NOT NULL,
  `created_date` datetime NOT NULL,
  `modified_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Product`
--

INSERT INTO `Product` (`product_line_id`, `name`, `price`, `unit`, `min_stock_quantity`, `stock_quantity`, `type`, `description`, `is_enable`, `created_date`, `modified_date`) VALUES
('AP.BA01', 'Apple AirPods 3 Bluetooth Headset', '4490000', 'Pieces (PCE)', 20, 112, 'Airpods', 'AirPods 3 - New sound brings an impressive experience\r\nIt is predicted that Apple will launch Apple AirPods 3 at the end of 2021 and will cause a big buzz like its two seniors. Along with that are new technological upgrades to bring better quality to users compared to previous generations of AirPods bluetooth headset.', 1, '2022-04-19 04:41:23', '2022-04-19 04:41:23'),
('bdxbd', 'aaa', '1000', 'Dozen (DZN)', 1, 1, 'aaa', 'bdbdhdn', 0, '2022-04-19 17:37:59', '2022-04-19 21:47:19'),
('iii', 'iuuu', '661000', 'Pieces (PCE)', 6661, 661, 'uuuu', 'iii7gfvf', 0, '2022-04-19 22:04:40', '2022-04-19 22:04:55'),
('LT.AG01', 'Laptop Asus Gaming Rog Strix G15 G513IH HN015W', '23990000', 'Pieces (PCE)', 20, 106, 'Laptop', 'Asus gaming laptop Rog Strix G15 G513IH-HN015W - Powerful configuration to fight game\r\nAsus ROG Strix G15 G513IH-HN015TW is a powerful configuration laptop that can meet most of the games on the market today. Even when operating for many hours, the device is still quite cool due to the advanced heat dissipation system. If you are a gamer or a user who wants to find a machine with high configuration, do not ignore this quality Asus laptop.', 1, '2022-04-19 04:41:23', '2022-04-19 04:41:23'),
('MO.AE23', 'Mouse Apple Magic Mouse 2021 MK2E3', '2990000', 'Pieces (PCE)', 50, 200, 'Mouse Bluetooth', 'Exquisite design with modern silver color\r\nMagic Mouse 2021 MK2E3 has a modern design with delicate curves, no wires, the top has a luxurious hidden Apple logo. Optimized leg design, super light weight of only 0.099kg for easy and quick movement.', 1, '2022-04-19 04:41:23', '2022-04-19 04:41:23'),
('ST.S501', 'Smart Tivi 4K The Serif Samsung 55 inch QA55LS01TA', '27900000', 'Pieces (PCE)', 20, 101, 'Smart Tivi', 'Masterpiece design with top technology. If you are a design lover and a fan of sophistication, I believe this is the TV for you.\r\nThe perfect intersection of design and technology...', 1, '2022-04-19 04:41:23', '2022-04-19 04:41:23'),
('SW.XS01', 'Xiaomi Watch S1 Active Smart Watch', '4490000', 'Pieces (PCE)', 50, 103, 'Smart Watch', 'Xiaomi Watch S1 Active - raising the bar for smart watches\r\nTo open up its new technological era, Xiaomi has launched the Xiaomi Watch S1 Active smartwatch. This product is a new design that hits the smartwatch market of Xiaomi and opens a new wave for mid- and high-end smart watches.', 1, '2022-04-19 04:41:23', '2022-04-19 04:41:23');

-- --------------------------------------------------------

--
-- Table structure for table `ProductRFID`
--

CREATE TABLE `ProductRFID` (
  `rfid` varchar(20) NOT NULL,
  `product_line_id` varchar(20) NOT NULL,
  `mapping_time` datetime NOT NULL,
  `is_checked` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ProductRFID`
--

INSERT INTO `ProductRFID` (`rfid`, `product_line_id`, `mapping_time`, `is_checked`) VALUES
('075L1', 'ST.S501', '2022-04-18 10:07:07', 0),
('087H5', 'ST.S501', '2022-04-18 10:07:09', 0),
('094K1', 'MO.AE23', '2022-04-18 10:07:03', 0),
('0A3B6', 'LT.AG01', '2022-04-17 08:07:03', 1),
('0F86E', 'AP.BA01', '2022-04-17 08:06:57', 1),
('0GHJ1', 'SW.XS01', '2022-04-18 10:07:15', 0),
('0H8A2', 'AP.BA01', '2022-04-17 08:07:00', 1),
('0UHG6', 'MO.AE23', '2022-04-17 08:07:07', 1),
('36D1G', 'bdxbd', '2022-04-22 00:27:35', 1),
('958T1', 'ST.S501', '2022-04-18 10:07:11', 0),
('ABCTEST', 'iii', '2022-04-20 10:07:07', 0),
('GFH82', 'SW.XS01', '2022-04-22 00:27:35', 0),
('GHL88', 'LT.AG01', '2022-04-19 10:07:18', 1),
('UGB43', 'iii', '2022-04-22 00:27:35', 1),
('UGH12', 'AP.BA01', '2022-04-19 10:07:11', 1),
('UY752', 'AP.BA01', '2022-04-19 10:07:16', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Employee`
--
ALTER TABLE `Employee`
  ADD PRIMARY KEY (`employee_id`);

--
-- Indexes for table `GoodsReceiptNote`
--
ALTER TABLE `GoodsReceiptNote`
  ADD PRIMARY KEY (`grn_id`),
  ADD KEY `employee_id` (`employee_id`),
  ADD KEY `employee_check_id` (`employee_check_id`);

--
-- Indexes for table `GoodsReceiptNoteDetail`
--
ALTER TABLE `GoodsReceiptNoteDetail`
  ADD PRIMARY KEY (`grn_id`,`product_line_id`),
  ADD KEY `product_line_id` (`product_line_id`);

--
-- Indexes for table `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`product_line_id`);

--
-- Indexes for table `ProductRFID`
--
ALTER TABLE `ProductRFID`
  ADD PRIMARY KEY (`rfid`),
  ADD KEY `product_line_id` (`product_line_id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `GoodsReceiptNote`
--
ALTER TABLE `GoodsReceiptNote`
  ADD CONSTRAINT `goodsreceiptnote_ibfk_1` FOREIGN KEY (`employee_id`) REFERENCES `Employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `goodsreceiptnote_ibfk_2` FOREIGN KEY (`employee_check_id`) REFERENCES `Employee` (`employee_id`);

--
-- Constraints for table `GoodsReceiptNoteDetail`
--
ALTER TABLE `GoodsReceiptNoteDetail`
  ADD CONSTRAINT `goodsreceiptnotedetail_ibfk_1` FOREIGN KEY (`grn_id`) REFERENCES `GoodsReceiptNote` (`grn_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `goodsreceiptnotedetail_ibfk_2` FOREIGN KEY (`product_line_id`) REFERENCES `Product` (`product_line_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `ProductRFID`
--
ALTER TABLE `ProductRFID`
  ADD CONSTRAINT `productrfid_ibfk_1` FOREIGN KEY (`product_line_id`) REFERENCES `Product` (`product_line_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
