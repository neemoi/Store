-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: webstore
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20231016214318_Initial','7.0.12'),('20231101214729_ChangingUserFields','7.0.12'),('20231103121945_СhanginTеablesAndPropertiesOrderDeliveryPayment','7.0.12'),('20231103123049_СhanginTheTеablesAndPropertiesDeliveryPayment','7.0.12'),('20231106175608_AddTableCategory','7.0.12'),('20231106180631_AddRelationshipBetweenTablesProductToCategory','7.0.12'),('20231106182521_AddFieldOrder','7.0.12'),('20231121192639_UpdateCascadeDelete','7.0.12');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Description` varchar(5000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Phone','Do more using your voice.Ask Google Assistant to summarize, read aloud, or translate web pages.10 And write messages twice as fast with your voice. Explore before you go.Get extra help with emails.Gmail provides useful prompts and suggestions to help you write, send, and prioritize emails.Gmail Reimagine your photos. Right on your phone. Use Magic Editor in Google Photos to add custom edits and studio-quality enhancements to any photo.27 Improve lighting and background, move a subject, and more, with just a few taps. Reimagine your photos. Right on your phone. Use Magic Editor in Google Photos to add custom edits and studio-quality enhancements to any photo.27 Improve lighting and background, move a subject, and more, with just a few taps.'),(2,'Watch','Watch your heart.Get alerted when you’re above or below your resting heart rate. Check your heart rhythm for AFib from the ECG app and receive irregular heart rhythm notifications. Tune into your wellness.Detect possible changes to your health by tracking your skin temperature, blood oxygen levels, heart rate variability, resting heart rate, and more. Improve your sleep habits. Learn about the quality and duration of your previous night\'s rest with your Sleep Score.4 See the time spent in light, deep, and REM stages. And get a monthly analysis from your Sleep Profile.'),(3,'Headphones','Active Noise Cancellation adapts to your ear.Powered by a custom processor, algorithms, and speakers, Active Noise Cancellation uses Silent Seal™ to maximize the outside noise being blocked.Small buds built for big music.Custom-designed 11 mm speaker drivers make music sound powerful, yet nuanced. A full 5-band EQ lets you customize the sound to your preferences. Volume EQ brings out the details.It adjusts the tuning as you turn the volume up or down, so highs, mids, and lows consistently sound balanced at any level.Transparency mode helps you hear what’s outside.Hear outside sounds in real time so you can be more aware of your surroundings, like when crossing the street.'),(4,'Pixel Tablet','Home is where Hub Mode is. With Hub Mode, you get the best features of a smart display when your tablet is locked and docked – like a digital photo frame, smart home controls, and hands-free help from Google Assistant. Ask Google Assistant for hands-free help.Play music and videos, get answers, control smart home devices, set timers, and more. Just say “Hey Google” to get started. The perfect setup for video calls and streaming. Simply dock the tablet for stationary work and play. It’s the ideal setup for Google Meet calls and binge-watching your favorite TV shows. See your photos come to life. View your pics on the Pixel Tablet’s immersive screen.'),(5,'Accessories','Tech specs Dimensions and weight Length: 6.6 in (167.0 mm) Width: 3.2 in (80.9 mm). Height: 0.5 in (13.4 mm). Weight: 1.1 oz (31.3 g). Materials Case is made with 42% recycled materials based on product weight. Case has a polycarbonate shell made with 75% recycled plastics. The external portion of the case’s power and volume buttons is made with 100% recycled aluminum');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deliveries`
--

DROP TABLE IF EXISTS `deliveries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deliveries` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Type` enum('pickup','courier','mail') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deliveries`
--

LOCK TABLES `deliveries` WRITE;
/*!40000 ALTER TABLE `deliveries` DISABLE KEYS */;
INSERT INTO `deliveries` VALUES (2,'mail',30.00),(3,'pickup',0.00),(4,'courier',15.00);
/*!40000 ALTER TABLE `deliveries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderitems`
--

DROP TABLE IF EXISTS `orderitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderitems` (
  `OrderId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  PRIMARY KEY (`OrderId`,`ProductId`),
  KEY `ProductId` (`ProductId`),
  CONSTRAINT `orderitems_ibfk_1` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `orderitems_ibfk_2` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderitems`
--

LOCK TABLES `orderitems` WRITE;
/*!40000 ALTER TABLE `orderitems` DISABLE KEYS */;
INSERT INTO `orderitems` VALUES (34,23,1),(35,4,2),(36,4,5),(37,4,1),(38,4,1),(38,5,1),(39,4,2),(39,9,2),(40,3,1),(40,23,1),(41,4,1),(42,4,1),(42,9,1),(43,4,2),(43,19,2),(44,10,2),(44,15,2),(45,20,2),(45,21,2),(46,10,3),(46,20,3),(47,20,1),(48,6,2),(48,26,2),(49,1,1),(51,4,2),(51,5,2),(52,1,1),(52,22,1),(53,25,2),(54,3,1),(55,4,1),(55,12,1),(55,22,1),(57,11,1),(58,21,2),(59,15,1),(59,16,1),(63,4,1),(64,3,1),(64,22,1),(67,1,1),(67,10,1),(68,4,1),(68,14,1),(69,8,2),(70,19,1),(71,21,1),(72,1,1),(72,25,1),(73,17,1),(74,8,2),(75,1,1),(76,21,2),(77,6,2),(77,21,2),(78,7,2),(79,1,1),(80,12,1),(81,24,1),(82,26,1),(83,1,1),(84,1,3),(85,8,1),(86,16,2),(87,1,1),(87,10,1),(90,7,1),(91,3,1),(91,19,1),(92,19,1),(93,4,1);
/*!40000 ALTER TABLE `orderitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `Status` enum('new','processed','delivered') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeliverId` int NOT NULL DEFAULT '0',
  `PaymentId` int NOT NULL DEFAULT '0',
  `TotalPrice` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`Id`),
  KEY `UserId` (`UserId`),
  KEY `IX_orders_DeliverId` (`DeliverId`),
  KEY `IX_orders_PaymentId` (`PaymentId`),
  CONSTRAINT `orders_delivery_ibfk` FOREIGN KEY (`DeliverId`) REFERENCES `deliveries` (`Id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `orders_payment_ibfk` FOREIGN KEY (`PaymentId`) REFERENCES `payments` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=97 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (34,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 01:53:52','new',2,5,85.49),(35,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 01:55:45','new',2,5,2798.00),(36,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 01:56:44','new',2,5,6995.00),(37,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:10:47','new',2,5,1429.50),(38,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:10:57','new',2,5,2128.50),(39,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:11:39','new',2,5,3726.50),(40,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:16:07','new',4,7,768.99),(41,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:30:06','new',2,5,1429.50),(42,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:30:14','new',2,5,1878.50),(43,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:30:28','new',2,5,3426.50),(44,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 02:41:50','new',2,5,1526.50),(45,'5657c1af-fac3-41dc-888f-b221c1f94365','2023-11-11 02:44:54','new',2,5,3626.50),(46,'5657c1af-fac3-41dc-888f-b221c1f94365','2023-11-11 02:47:05','new',2,5,4074.50),(47,'5657c1af-fac3-41dc-888f-b221c1f94365','2023-11-11 02:47:42','new',2,5,929.50),(48,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 20:17:05','new',2,5,1686.50),(49,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 20:37:32','new',4,5,614.50),(51,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 20:44:41','new',4,6,4214.00),(52,'3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','2023-11-11 20:46:05','new',2,5,684.49),(53,'5657c1af-fac3-41dc-888f-b221c1f94365','2023-11-11 21:06:36','new',2,5,208.50),(54,'5657c1af-fac3-41dc-888f-b221c1f94365','2023-11-13 21:50:48','new',2,5,729.50),(55,'708ee2ba-5b48-4427-bc20-055a2fdc3596','2023-11-14 00:04:11','new',2,5,2033.49),(57,'8945fa17-808e-490d-aad6-605779d3387f','2023-11-16 01:35:51','new',3,7,449.00),(58,'8945fa17-808e-490d-aad6-605779d3387f','2023-11-16 02:41:38','new',3,7,1798.00),(59,'8945fa17-808e-490d-aad6-605779d3387f','2023-11-16 02:54:48','new',4,7,613.00),(63,'a569bfdd-aaed-4c12-87f7-33ef3cd4d98f','2023-11-17 03:28:21','new',2,5,1429.50),(64,'a569bfdd-aaed-4c12-87f7-33ef3cd4d98f','2023-11-17 03:28:29','new',4,7,768.99),(67,'e532e613-6ebb-4bff-abee-4eda9e69f13d','2023-11-19 22:27:45','new',2,5,1078.50),(68,'cec3f26b-354c-40a0-a504-0fd66b410e0d','2023-11-20 13:43:16','new',2,5,1978.50),(69,'cec3f26b-354c-40a0-a504-0fd66b410e0d','2023-11-20 13:43:24','new',2,5,2148.50),(70,'cec3f26b-354c-40a0-a504-0fd66b410e0d','2023-11-20 13:43:49','new',4,7,314.00),(71,'6712a20c-9532-49ee-b966-fdc0a78d9111','2023-11-20 13:45:07','new',4,7,914.00),(72,'6712a20c-9532-49ee-b966-fdc0a78d9111','2023-11-20 13:45:29','new',2,5,718.50),(73,'33163c2b-710d-4381-aae2-ef9013c1a34c','2023-11-20 13:46:33','new',2,5,329.50),(74,'33163c2b-710d-4381-aae2-ef9013c1a34c','2023-11-20 13:46:41','new',4,7,2133.00),(75,'47d411d1-0f13-4799-b17f-d92265275618','2023-11-20 13:47:52','new',2,5,629.50),(76,'47d411d1-0f13-4799-b17f-d92265275618','2023-11-20 13:48:05','new',2,5,1828.50),(77,'47d411d1-0f13-4799-b17f-d92265275618','2023-11-20 13:48:26','new',2,5,3346.50),(78,'f955b2b0-40fb-4c80-8a89-841926ea3d12','2023-11-20 13:49:13','new',2,5,2388.50),(79,'f955b2b0-40fb-4c80-8a89-841926ea3d12','2023-11-20 13:49:23','new',4,7,614.00),(80,'bf40adfd-339c-438c-8eda-0b9e34a68f50','2023-11-20 13:50:34','new',4,7,564.00),(81,'bf40adfd-339c-438c-8eda-0b9e34a68f50','2023-11-20 13:50:48','new',4,7,104.00),(82,'d5e76540-0a65-4e38-b407-91216b4b7ac1','2023-11-20 13:52:14','new',4,5,84.50),(83,'d5e76540-0a65-4e38-b407-91216b4b7ac1','2023-11-20 13:52:20','new',4,5,614.50),(84,'1fffbebe-d440-4c59-8067-d24a45037580','2023-11-20 13:55:04','new',4,7,1812.00),(85,'412dba82-f2df-4136-868f-615e9b330b73','2023-11-20 13:55:39','new',4,7,1074.00),(86,'194c2c3b-6f84-4180-8668-5fc9027705d7','2023-11-20 13:56:25','new',2,5,628.50),(87,'194c2c3b-6f84-4180-8668-5fc9027705d7','2023-11-20 13:56:38','new',4,7,1063.00),(90,'15b07bfa-ea05-4af0-a1b2-efaedabacfb2','2023-11-20 13:58:45','new',4,7,1194.00),(91,'e532e613-6ebb-4bff-abee-4eda9e69f13d','2023-11-20 14:08:25','new',4,7,1013.00),(92,'e532e613-6ebb-4bff-abee-4eda9e69f13d','2023-11-20 14:08:58','new',2,5,329.50),(93,'15b07bfa-ea05-4af0-a1b2-efaedabacfb2','2023-11-21 01:25:00','new',2,5,1429.50);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Type` enum('cash','card','e-money') CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Amount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (5,'card',0.50),(6,'e-money',3.00),(7,'cash',0.00);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` decimal(10,2) NOT NULL,
  `CategoryId` int NOT NULL DEFAULT '0',
  `Color` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Memory` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_products_CategoryId` (`CategoryId`),
  CONSTRAINT `products_category_bdab` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Pixel 7','Name: Pixel 7, Price: 599$, Memory: 12\\128 GB, Color: Lemongrass',599.00,1,'Lemongrass','12\\128 GB'),(2,'Pixel 6 a','Name: Pixel 6 a, Price: 345$, Memory: 6\\128 GB, Color: Sage',345.00,1,'Sage','6\\128 GB'),(3,'Pixel 8','Name: Pixel 8, Price: 699$, Memory: 6\\128 GB, Color: Hazel',699.00,1,'Hazel','6\\128 GB'),(4,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1399$, Memory: 12\\1 TB, Color: Bay',1399.00,1,'Bay','12\\1 TB'),(5,'Pixel 8','Name: Pixel 8, Price: 699$, Memory: 6\\128 GB, Color: Obsidian',699.00,1,'Obsidian','6\\128 GB'),(6,'Pixel 8','Name: Pixel 8, Price: 699$, Memory: 8\\256 GB, Color: Rose',759.00,1,'Rose','8\\256 GB'),(7,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1179$, Memory: 12\\512 GB, Color: Porcelain',1179.00,1,'Porcelain','12\\512 GB'),(8,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1059$, Memory: 12\\256 GB, Color: Obsidian',1059.00,1,'Obsidian','12\\256 GB'),(9,'Pixel Watch ','Name: Pixel Watch, Price: 449$, Memory: 1 GB, Color: Black',449.00,2,'Black','1 GB'),(10,'Pixel Watch ','Name: Pixel Watch, Price: 449$, Memory: 1 GB, Color: Rose',449.00,2,'Rose','1 GB'),(11,'Pixel Watch ','Name: Pixel Watch, Price: 449$, Memory: 1 GB, Color: Blue',449.00,2,'Blue','1 GB'),(12,'Pixel Watch 2','Name: Pixel Watch2, Price: 549$, Memory: 3 GB, Color: Black',549.00,2,'Black','3 GB'),(13,'Pixel Watch 2','Name: Pixel Watch2, Price: 549$, Memory: 3 GB, Color: Rose',549.00,2,'Rose','3 GB'),(14,'Pixel Watch 2','Name: Pixel Watch2, Price: 549$, Memory: 3 GB, Color: Brown',549.00,2,'Brown','3 GB'),(15,'Pixel Buds Pro','Name: Pixel Buds Pro, Price: 299$, Memory: 0.5 MB, Color: Bay',299.00,3,'Bay','0.5 MB'),(16,'Pixel Buds Pro','Name: Pixel Buds Pro, Price: 299$, Memory: 0.5 MB, Color: Porcelain',299.00,3,'Porcelain','0.5 MB'),(17,'Pixel Buds Pro','Name: Pixel Buds Pro, Price: 299$, Memory: 0.5 MB, Color: Lemongrass',299.00,3,'Lemongrass','0.5 MB'),(18,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1399$, Memory: 12\\1 TB, Color: Black',1399.00,1,'Black','12/1 TB'),(19,'Pixel Buds Pro','Name: Pixel Buds Pro, Price: 299$, Memory: 0.5 MB, Color:  Fog',299.00,3,'Fog','0.5 MB'),(20,'Pixel Tablet','Name: Pixel Tablet, Price: 899$, Memory: 12/512  GB, Color:  Porcelain',899.00,4,'Porcelain','12/512  GB'),(21,'Pixel Tablet','Name: Pixel Tablet, Price: 899$, Memory: 12/512  GB, Color:  Hazel',899.00,4,'Hazel','12/512  GB'),(22,'Pixel 8 Pro Case','Name: Pixel 8 Pro Case, Price: 54.99$, Memory: 12/512  GB, Color:  Coral | Google Store exclusive',54.99,5,'Coral | Google Store exclusive','12/512  GB'),(23,'Pixel 8 Case','Name: Pixel 8 Pro Case, Price: 54.99$, Memory: 12/512  GB, Color:  Rose',54.99,5,'Rose','12/512  GB'),(24,'Pixel Watch Woven Band','Name: Pixel Watch Woven Band, Price: 89$, Memory: 0.5 MB, Color:  Lemongrass',89.00,5,'Lemongrass','0.5 MB'),(25,'Pixel Watch Stretch Band','Name: Pixel Watch Stretch Band, Price: 89$, Memory: 0.5 MB, Color:  Coral',89.00,5,'Coral','0.5 MB'),(26,'Pixel Watch Active Sport Band','Name: Pixel Watch Active Sport Band, Price: 69$, Memory: 0.5 MB, Color:  Porcelain',69.00,5,'Porcelain','0.5 MB'),(27,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1399$, Memory: 12\\1 TB, Color: Rouse',1399.00,1,'Rouse','12/1 TB'),(28,'Pixel 8 pro','Name: Pixel 8 pro, Price: 1399$, Memory: 12\\1 TB, Color: Lemongrass',1399.00,1,'Lemongrass','12/1 TB'),(29,'Pixel 6 a','Name: Pixel 6 a, Price: 445$, Memory: 6\\256 GB, Color: Black',445.00,1,'Black','6\\256 GB'),(30,'Pixel 6 a','Name: Pixel 6 a, Price: 445$, Memory: 6\\256 GB, Color: Rouse',445.00,1,'Rouse','6\\256 GB'),(31,'Pixel 6 a','Name: Pixel 6 a, Price: 445$, Memory: 6\\256 GB, Color: Lemongrass',445.00,1,'Lemongrass','6\\256 GB'),(32,'Pixel 7','Name: Pixel 7, Price: 799$, Memory: 12\\256 GB, Color: Lemongrass',799.00,1,'Lemongrass','12\\256 GB'),(33,'Pixel 7','Name: Pixel 7, Price: 799$, Memory: 12\\256 GB, Color: Black',799.00,1,'Black','12\\256 GB'),(34,'Pixel 7','Name: Pixel 7, Price: 799$, Memory: 12\\256 GB, Color: Rouse',799.00,1,'Rouse','12\\256 GB'),(35,'Pixel 8 Case','Name: Pixel 8 Pro Case, Price: 54.99$, Memory: 12/512  GB, Color:  Black',54.99,5,'Black','12/512  GB');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleclaims`
--

DROP TABLE IF EXISTS `roleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleclaims`
--

LOCK TABLES `roleclaims` WRITE;
/*!40000 ALTER TABLE `roleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `roleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NormalizedName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('54b18c4c-e4a6-43ea-89ee-51c93a62f0ea','Admin','ADMIN',NULL),('d968d618-f044-4a8c-a1ed-164133e36da4','User','USER',NULL);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userclaims`
--

DROP TABLE IF EXISTS `userclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userclaims`
--

LOCK TABLES `userclaims` WRITE;
/*!40000 ALTER TABLE `userclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `userclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlogins`
--

DROP TABLE IF EXISTS `userlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlogins`
--

LOCK TABLES `userlogins` WRITE;
/*!40000 ALTER TABLE `userlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES ('04375911-da48-464f-8990-ebab53c9331f','d968d618-f044-4a8c-a1ed-164133e36da4'),('06880034-a854-4010-a03b-66b26aab73b2','d968d618-f044-4a8c-a1ed-164133e36da4'),('0fe7fc66-f311-499f-9349-5df5303de5e5','d968d618-f044-4a8c-a1ed-164133e36da4'),('17fe9a6e-229b-448a-85d2-3fdd23783969','d968d618-f044-4a8c-a1ed-164133e36da4'),('194c2c3b-6f84-4180-8668-5fc9027705d7','d968d618-f044-4a8c-a1ed-164133e36da4'),('1fffbebe-d440-4c59-8067-d24a45037580','d968d618-f044-4a8c-a1ed-164133e36da4'),('262c53a6-c40c-4171-8b09-d265be4160a6','d968d618-f044-4a8c-a1ed-164133e36da4'),('33163c2b-710d-4381-aae2-ef9013c1a34c','d968d618-f044-4a8c-a1ed-164133e36da4'),('3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','d968d618-f044-4a8c-a1ed-164133e36da4'),('412dba82-f2df-4136-868f-615e9b330b73','d968d618-f044-4a8c-a1ed-164133e36da4'),('47d411d1-0f13-4799-b17f-d92265275618','d968d618-f044-4a8c-a1ed-164133e36da4'),('488923d5-30c3-43aa-b963-9b5580f56237','d968d618-f044-4a8c-a1ed-164133e36da4'),('4a85e264-ab3c-476a-b9bb-c14b4da87c5b','d968d618-f044-4a8c-a1ed-164133e36da4'),('4ba99073-abf4-4f89-accc-8f35553e05c8','d968d618-f044-4a8c-a1ed-164133e36da4'),('5657c1af-fac3-41dc-888f-b221c1f94365','d968d618-f044-4a8c-a1ed-164133e36da4'),('5beb93e5-86f6-401b-9d24-3f3ff15884c6','d968d618-f044-4a8c-a1ed-164133e36da4'),('609f1f97-752d-4001-9153-d14a2e43719c','d968d618-f044-4a8c-a1ed-164133e36da4'),('6712a20c-9532-49ee-b966-fdc0a78d9111','d968d618-f044-4a8c-a1ed-164133e36da4'),('708ee2ba-5b48-4427-bc20-055a2fdc3596','d968d618-f044-4a8c-a1ed-164133e36da4'),('77b25ce1-6c4a-465c-8c20-956827ed48b4','d968d618-f044-4a8c-a1ed-164133e36da4'),('82f4a2d7-a9e7-41fc-b860-cbd3470cc203','d968d618-f044-4a8c-a1ed-164133e36da4'),('8945fa17-808e-490d-aad6-605779d3387f','d968d618-f044-4a8c-a1ed-164133e36da4'),('8f658195-d2c8-4dce-9c29-484e071782c9','d968d618-f044-4a8c-a1ed-164133e36da4'),('95d164aa-e177-4d1b-9a2a-4f4b6fda0a99','d968d618-f044-4a8c-a1ed-164133e36da4'),('a569bfdd-aaed-4c12-87f7-33ef3cd4d98f','d968d618-f044-4a8c-a1ed-164133e36da4'),('b50946b4-080e-4f1b-891c-8923ad2895aa','d968d618-f044-4a8c-a1ed-164133e36da4'),('bf40adfd-339c-438c-8eda-0b9e34a68f50','d968d618-f044-4a8c-a1ed-164133e36da4'),('c01c11a3-41da-4610-b08f-fc2e90ef7901','d968d618-f044-4a8c-a1ed-164133e36da4'),('cec3f26b-354c-40a0-a504-0fd66b410e0d','d968d618-f044-4a8c-a1ed-164133e36da4'),('d5e76540-0a65-4e38-b407-91216b4b7ac1','d968d618-f044-4a8c-a1ed-164133e36da4'),('e532e613-6ebb-4bff-abee-4eda9e69f13d','54b18c4c-e4a6-43ea-89ee-51c93a62f0ea'),('e5e5b4e1-5602-42ec-88d9-5d12b28b8bc7','d968d618-f044-4a8c-a1ed-164133e36da4'),('f86691d9-cdfe-4aa7-a570-96885b5fc110','d968d618-f044-4a8c-a1ed-164133e36da4'),('f955b2b0-40fb-4c80-8a89-841926ea3d12','d968d618-f044-4a8c-a1ed-164133e36da4');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NormalizedUserName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `NormalizedEmail` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `Address` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `City` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `State` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('04375911-da48-464f-8990-ebab53c9331f','user3','das@s1D','user3','USER3','user3@example.com','USER3@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAECVGaB9d0rKe+GThv7LBVERI/RnSQp0sKKTCJ9We72PuU2L0+8vCFSfA6ehjAVD7PA==','C5RN7DJHN3A3PU3VX7OZJM6C2ILU23SA','36941b00-57dc-4fa1-bd48-2c9d6d47a383','43100718',0,0,NULL,1,0,'adress3','city3','state3'),('06880034-a854-4010-a03b-66b26aab73b2','user32','fdv$lLNBH8','user32','USER32','user32@example.com','USER32@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEPWVRu1sy/iT4KB25DqUZic1cZOod/ZEkGkrTaWq/izlBRV4q3HaOjQUd4Jkyg2eIg==','OKJRY7EAZ3FDMOGI2CZZGRQ3HOARBXML','51fa2674-bee3-48ab-8b94-7b19f6d46992','39918473',0,0,NULL,1,0,NULL,NULL,NULL),('0fe7fc66-f311-499f-9349-5df5303de5e5','user28','lfdkg&qK2','user28','USER28','user28@example.com','USER28@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEAbQaP+5G2er9I/cZbSMgo4wdEhpSOCAirBpcVRBqWjUOgZWRlG4xf4wAzNM32BBrg==','NE3D7PDWIC3WTTSYO2SEXNZY3KLMLXIQ','53a34c10-44a6-4f7a-9f53-8bc1ff63f67c','334657192',0,0,NULL,1,0,NULL,NULL,NULL),('15b07bfa-ea05-4af0-a1b2-efaedabacfb2','user30','kdgkg*N8','user30','USER30','user30@example.com','USER30@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEL49ndiK8TecDQorDqcq4CYyTcH1qJ9Y131ScM8N4sd3C/qTA4IlLbf50H+9DOtIww==','ANTDVI5QC65IN2XVGEFKNB5ILVJTQILY','d1ad6227-ca03-49d2-93ea-8ba401a5d51c','99401857',0,0,NULL,1,0,'adress30','city30','state30'),('17fe9a6e-229b-448a-85d2-3fdd23783969','user14','fdkam%1fF','user14','USER14','user14@example.com','USER14@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEO9q5jcORTuKE2MIA3uhp3N6gjmh1Eq+C8bA1QQkkHFAlmHwzqHHyHAAsOBZp9VnQQ==','KDUMGTCAVGOY23IF2WACF2ZJSYGSORCO','e8ba7031-e6f5-4dff-ad06-ca1f01f83df3','30188524',0,0,NULL,1,0,NULL,NULL,NULL),('194c2c3b-6f84-4180-8668-5fc9027705d7','user27','kdgj#Jdn4','user27','USER27','user27@example.com','USER27@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEJAD8B5Q97ThW0LC7upDUydI0q3LVzcdRRFkVPJ+IB9bwPc32502ymcvL2veoq5X4A==','V3VOYI3ZZQKCF2KWZ57UJYX6F6JG4M23','53f3f4a9-e0f8-415a-b447-36637cbed997','99104556',0,0,NULL,1,0,'adress27','city27','state27'),('1fffbebe-d440-4c59-8067-d24a45037580','user22','lfadf!9J','user22','USER22','user22@example.com','USER22@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAELWnXvvIb3vVvVSIoDyngJYFZ5EpzHT1Pr85NT8ccnaYMyG/hFHAoUZ9J6QwNNtR+Q==','O2HHCDSULB7EDRN7M4VDRBSWAMD2QNXK','d1605740-6c43-44f8-a5fe-a4d314b3aacd','39185135',0,0,NULL,1,0,'adress22','city22','state22'),('262c53a6-c40c-4171-8b09-d265be4160a6','user4','saff@acsA1','user4','USER4','user4@example.com','USER4@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEGQiyUESXkB/5eOIeeT45svOWUHxRzRdLXOAqj9tQSMNhVv9nbtFJBPWdKxYoszCzA==','WFRNWBBQQU6LFCGQXCQ7YGWUKAMD4LJQ','5d4c50fd-c80b-4d97-8d27-a8bf94265cda','34157751',0,0,NULL,1,0,'adress4','city4','state4'),('33163c2b-710d-4381-aae2-ef9013c1a34c','user11','fasf<K2','user11','USER11','user11@example.com','USER11@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEHXOILbNqVyDfCuL114Zqjqw51O5nvfJuuwPmhRqv2XzvfG7fpndPltCzFngzpvHTw==','MIV6QGYVQ3UJGHUB4XLUOGRMKARBEUSH','e7dd942d-0310-427c-9a68-9790ba283058','30199415',0,0,NULL,1,0,'adress11','city11','state11'),('3fef2645-b259-4974-a8c1-3dfb4dfa1ccd','user2','saf2c@sS','user2','USER2','user2@example.com','USER2@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEGFHsewSidEmA66Wfdwo5Y5uqMKHQ+bFTmbLkS4FaR5moMh71tjhchfYuryE8asn6Q==','FP42YYV4AGC76YL5M4WTQRT5HGWDQONH','b956c43d-c593-4b75-9e81-6177d7f1a841','43918473',0,0,NULL,1,0,'adress2','ciyt2','state2'),('412dba82-f2df-4136-868f-615e9b330b73','user24','fas=31fV','user24','USER24','user24@example.com','USER24@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEAnd7CtbnA6gU7o+9wT/aTZc5ey6Kgv9pH577Bm/FWA1uhA35AlD46wQBdbPrdIAmw==','6MMHV7NG5PWJBGOTEBQSZCBGXADDNU5N','09316ddb-bc89-403f-91d8-88734f55bd86','77133410',0,0,NULL,1,0,'adress24','city24','state24'),('47d411d1-0f13-4799-b17f-d92265275618','user12',',adsf)3K','user12','USER12','user12@example.com','USER12@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEH9kS0U8MVP6xKy3rHmloKdpq4QUUuIRS8gK4cIET8TeSdBkojURACcSt0UcW6C3pg==','XBDIB5QU5VNDANBJBKVY7AT6WZ4NGAMI','160c67ce-774c-4fd9-9e8f-5f41182667c7','11039482',0,0,NULL,1,0,'adress12','city12','state12'),('488923d5-30c3-43aa-b963-9b5580f56237','user9','sfsaf@SD1','user9','USER9','user9@example.com','USER9@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAELyfl8gt5/3YFuVazBxxCJu7CWt7otTxdkFysoOkkDJGgI2HHL7+AOm2qSEKvB/9Xg==','P7ENXESLCR5NNBWNNNCUL5GYNZ3QEV4E','2c723c84-0890-4a65-b13f-d7634e4fde8b','95382059',0,0,NULL,1,0,NULL,NULL,NULL),('4a85e264-ab3c-476a-b9bb-c14b4da87c5b','user21','gksl&euH4','user21','USER21','user21@example.com','USER21@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEJDqRZFim56Q1pta/lEu4LwapnfNxWJNVx1r4d/un/SIZmzmEYjN0p6fWYsp3RQMMQ==','MSHXQAT7JIKEUZAEDETSFZWGTIYLTJKM','648f6584-d963-4e6b-a7e3-5b54fdbf0e8d','39184751',0,0,NULL,1,0,NULL,NULL,NULL),('4ba99073-abf4-4f89-accc-8f35553e05c8','user20','jsdgvnF3!','user20','USER20','user20@example.com','USER20@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEDKoCgku6BNlRySvMnwG6P1BcrH0+s8JozRhI0oXV8dUzrtlOEhdxxZP+Fnj3GixHQ==','UBWZVCITJOI6T7SODRTPEHEFXRL5BXGV','067a8522-1f25-4f4a-bb64-29881b89bcf3','194881736',0,0,NULL,1,0,NULL,NULL,NULL),('5657c1af-fac3-41dc-888f-b221c1f94365','user1','das@s1D','user1','USER1','user1@example.com','USER1@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEB4FKlIwk96eJQi0l0deS4Rx37ecZBjJ2YnP0wRliro+waQsbN+rkAJxYNxzoC3P7A==','OB6MMD2L5M3PYKDIVFE7WNJHW65JAYN4','bfca9812-cb60-49ae-9272-139e6be66d58','22222222',0,0,NULL,1,0,'adress1','city1','state1'),('5beb93e5-86f6-401b-9d24-3f3ff15884c6','user8','adga@S1','user8','USER8','user8@example.com','USER8@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEFYZCcFBrGEescaw22JxrZICJxR4tBPr1tpL+CVQtodnjfNS11TaVXgh5zvPyKlUSw==','AVVT3KFDKEW6QU44NJ3W5SKZTNMVAMVU','c4bbecb6-da81-4a63-b776-ecbca29c07fd','58493817',0,0,NULL,1,0,'adress8','city8','state8'),('609f1f97-752d-4001-9153-d14a2e43719c','user18','jgdsogj(H4','user18','USER18','user18@example.com','USER18@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEGqgZK1Doe68sEn2akD5UeUGfwMaSJkxtDXL3DC4mPwsFnqXWVhAJdM2oBqrok9stw==','N7L2Z5JX7DCF6RWHASILYHY5YJUBH3MB','18ef3f80-c55c-4701-926a-3e8d5db8e6e8','0395817',0,0,NULL,1,0,NULL,NULL,NULL),('6712a20c-9532-49ee-b966-fdc0a78d9111','user10','fasf@4F','user10','USER10','user10@example.com','USER10@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEIHguPqn5qeIEKVkPZBToLXu4z28ce2Gxsi2ohJ4BDR097LGiWjBYGyT7ZCbSq8cDQ==','MHYVTHMLXUJH7B4V4PSUGJ2QXUIGEPA3','2ed571db-18c2-46b4-a4d1-f8d52575e95f','33140591',0,0,NULL,1,0,'adress10','city10','state10'),('708ee2ba-5b48-4427-bc20-055a2fdc3596','user5','fas@1Fs','user5','USER5','user5@example.com','USER5@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEFyT3RP9eji70Dwi7rLk6PMn2mVVEEzfsUfD1D0QJgwOHm7sD04A8wufKPoQnKLyfA==','TJA6AKUAOGUIP4PNTLPHR5MTTEUEUJ2Z','7554aa70-8485-4457-bb67-07b39314eb07','51300716',0,0,NULL,1,0,'adress5','city5','state5'),('77b25ce1-6c4a-465c-8c20-956827ed48b4','user19','gdkag%Nd4','user19','USER19','user19@example.com','USER19@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEHCu0FFrwnYrvWmzNJ378z8v5E44Z+xJ7gSfEWmVzdiEYck1HhmgV2tX0Y2yREUsYw==','7USPHDMJQTSWDVJDKIDZQLVCTQJGMHH3','a9ade2a0-74b0-431c-b424-99961f8b03fe','08571544',0,0,NULL,1,0,'adress19','city19','state19'),('82f4a2d7-a9e7-41fc-b860-cbd3470cc203','user25','GDK7&3m','user25','USER25','user25@example.com','USER25@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEOn1O2M69QWUE5Ls+HSTR30er5nFRgVaEdJBDZPQa8gxkll0Nnuy6abXwe0YfOWgfg==','XJQC4QN4TA7M44NXNNO2HJINO7LU5S6V','69e9cf24-84dc-4f63-a226-04df6a1d3d67','99914314',0,0,NULL,1,0,NULL,NULL,NULL),('8945fa17-808e-490d-aad6-605779d3387f','user6','afBF@2','user6','USER6','user6@example.com','USER6@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEOfO2tUpS+EriroMwmAhfdMaxDXXwcSlBAAC/Rwp5qgf+DG82hrSirEW+ZTgQCDlLw==','2LMATNH3K7ZE7KTLVM5LFFPWPWMDK5EZ','94b561b4-80ea-4362-b426-e615da4a1a87','53199147',0,0,NULL,1,0,NULL,NULL,NULL),('8f658195-d2c8-4dce-9c29-484e071782c9','user15','lfkdfk(3F','user15','USER15','user15@example.com','USER15@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEMpVtfiPP3v4oC/rlmtrXgIxDYdyQ5mbGKM3xfANu4yI0WHC39/KRrlkL9YUL7NlSA==','QYYUZFYI4JVW7XO5QVW2KTXTX3BUNBM3','612c093e-40f0-48f0-9d98-2e73f26670b1','20018574',0,0,NULL,1,0,NULL,NULL,NULL),('95d164aa-e177-4d1b-9a2a-4f4b6fda0a99','user23','gldg_g4V','user23','USER23','user23@example.com','USER23@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEAkDQEifoakA8hjlkN8PtTcjQfckzCer3wT+6kGa5K61bHUSEGJbkOyEDoqp8/IqTQ==','RAHD2LTXMFEROXYKZHXZBU4B6KRRREXN','2c039553-c424-4e84-a0c6-8dc156bf3025','857771934',0,0,NULL,1,0,NULL,NULL,NULL),('a569bfdd-aaed-4c12-87f7-33ef3cd4d98f','user7','afa@as1S','user7','USER7','user7@example.com','USER7@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEFARPm0F2CzdzkoB3/plb1QsGpQ5haW2hCU6C82MXbx1XDuY/2E0/mikk1ReuZinJw==','BQFNORQUXFULGZQKU5HA6XME4B2SOXJ2','7a067704-522a-4b9a-83e2-9467db883c98','24195883',0,0,NULL,1,0,'adress7','city7','state7'),('b50946b4-080e-4f1b-891c-8923ad2895aa','user31','jdgnv#K3','user31','USER31','user31@example.com','USER31@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEH4G/dRdSCTSpuKJpM0/gZdrK+3OO5+sAws4VfgSwbWlUMYOGEJBxxQtchH7lz492g==','77ZCBRKZRIYWEOCR4QEGC2TU6OQXO2NE','d5e62c9a-6875-425f-b2f1-f6d2d1603893','88104566',0,0,NULL,1,0,NULL,NULL,NULL),('bf40adfd-339c-438c-8eda-0b9e34a68f50','user16','ldfa$f2kK','user16','USER16','user16@example.com','USER16@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAELz1UFc48aWqLXCpfR0lSD5h2QMSCgx3dvfPGrVHkj04G8myyXwKUDPs4uuqQnizZA==','76CR66PH7YGLK2BESL6CSRPOWPEZ7CFQ','6ea28ffe-c14d-40bd-8201-a6db071e7f8e','33718395',0,0,NULL,1,0,'adress16','city16','state16'),('c01c11a3-41da-4610-b08f-fc2e90ef7901','user33','agavm#54F','user33','USER33','user33@example.com','USER33@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEJshIXjImO4Akn+kVRfSG803F0A+EL9R7m1yaSXW+23WYYDfeCoWZVuxdyWSnsBWEw==','W4VX43FJNR5Z2BEDXXV2CWL6CN3A22IW','49732a98-19aa-49c5-8856-5d1f3ead595c','99185561',0,0,NULL,1,0,NULL,NULL,NULL),('cec3f26b-354c-40a0-a504-0fd66b410e0d','user','das@s1D','user','USER','user@example.com','USER@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEPjS+Mun7KgaaTPqPO9rjuKsg31phBOTjO571jADC4+rYO7MCgdBJLBa3zkUoumrDA==','2SZFE4XYYCK2Z2WG23NF5CO56SU3NTZ7','16baab9a-82ce-4380-a76a-5f3803da8253','11111111',0,0,NULL,1,0,'adress','city','state'),('d5e76540-0a65-4e38-b407-91216b4b7ac1','user17','dafgmv$S2','user17','USER17','user17@example.com','USER17@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEIderikye8uQ9z4Xtwvx1PMV2CRWdKyVnUxQDf4oAxU66QSS2cpAsI/2l0FK9DcqAA==','QMBXTL44ZQ3HTCTLFGYIUDLK7T63LG26','2394fe80-2d1a-4dee-b16a-60f2c50c831c','39918451',0,0,NULL,1,0,'adress17','city17','state17'),('e532e613-6ebb-4bff-abee-4eda9e69f13d','admin','admin@1Q','admin','ADMIN','admin@example.com','ADMIN@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEHMEO/Bbv/1SoS3VFnmSv79CvTj43imehdSyLBZKeSNr80tsau9aMNPS14KagRH6ew==','NQLJ6WGHZCINSVNFGGNS5GPEGZ6Q74IJ','7bffe189-06b4-49fb-b9de-edd5c8344b26','43146210',0,0,NULL,1,0,'AdressAdmin','AdressAdmin','AdressAdmin'),('e5e5b4e1-5602-42ec-88d9-5d12b28b8bc7','user35','ldgkmvsjNV94#','user35','USER35','user35@example.com','USER35@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAELOF0OE2/li8Mwq1nlbX+VqznBF9kfbY7UYzlB9ikOK8QK20bxJb3fE7L64L1v53fw==','7LDB7CV4PLISIXEBHZP5J3ZLEAJYOCYD','420cc48d-058a-4c9d-a58d-f73a3ef1c6f7','33457105',0,0,NULL,1,0,NULL,NULL,NULL),('f86691d9-cdfe-4aa7-a570-96885b5fc110','user26','ldgk&31hJ','user26','USER26','user26@example.com','USER26@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEFeXS59XUUvlEXm2P4oMOuMPnCGfwidwqhtVNLxo6oF2WMnOt2btL+uM7JFWaBDYrA==','NTEMYBR4PVTDPVF7VGV5FA74JCE6SO2B','e2e3b0df-d2f7-43ab-891e-a64ed6d2ee9c','318857135',0,0,NULL,1,0,NULL,NULL,NULL),('f955b2b0-40fb-4c80-8a89-841926ea3d12','user13','lfa;:31F','user13','USER13','user13@example.com','USER13@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEH+QNsjW8LWaQrE2Zz5+qVZSoB4Z8No4GlN20gU5JCfX0MJUdevnhN9iDU5kojtStA==','7YCCBRMNEUEX5MNSKMLPFKRKX3YNGQEZ','a675e8bc-83b8-422e-aa99-dc2c58b26b22','00491842',0,0,NULL,1,0,'adress13','city13','state13');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usertokens`
--

DROP TABLE IF EXISTS `usertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usertokens` (
  `UserId` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LoginProvider` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usertokens`
--

LOCK TABLES `usertokens` WRITE;
/*!40000 ALTER TABLE `usertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `usertokens` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-22  2:25:55
