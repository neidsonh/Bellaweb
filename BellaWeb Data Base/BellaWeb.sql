-- MySQL dump 10.13  Distrib 5.6.17, for Win32 (x86)
--
-- Host: localhost    Database: bellaweb
-- ------------------------------------------------------
-- Server version	5.6.23-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `adm_administradores`
--

DROP TABLE IF EXISTS `adm_administradores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adm_administradores` (
  `adm_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `adm_nome` varchar(75) NOT NULL,
  PRIMARY KEY (`adm_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adm_administradores`
--

LOCK TABLES `adm_administradores` WRITE;
/*!40000 ALTER TABLE `adm_administradores` DISABLE KEYS */;
INSERT INTO `adm_administradores` VALUES (1,'Lucimar'),(2,'Neidson'),(3,'Douglas'),(4,'Jonatas');
/*!40000 ALTER TABLE `adm_administradores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cid_cidades`
--

DROP TABLE IF EXISTS `cid_cidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cid_cidades` (
  `cid_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cid_nome` varchar(75) NOT NULL,
  `etd_codigo` int(11) NOT NULL,
  PRIMARY KEY (`cid_codigo`),
  KEY `etd_codigo` (`etd_codigo`),
  CONSTRAINT `cid_cidades_ibfk_1` FOREIGN KEY (`etd_codigo`) REFERENCES `etd_estados` (`etd_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cid_cidades`
--

LOCK TABLES `cid_cidades` WRITE;
/*!40000 ALTER TABLE `cid_cidades` DISABLE KEYS */;
INSERT INTO `cid_cidades` VALUES (1,'Guaratinguetá',1),(2,'Lorena',1),(3,'Potim',1),(4,'Cruzeiro',1),(5,'Cachoeira Paulista',1),(7,'Cunha',1),(8,'Aparecida',1),(9,'Roseira',1),(10,'Pindamonhangaba',1);
/*!40000 ALTER TABLE `cid_cidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `des_destaques`
--

DROP TABLE IF EXISTS `des_destaques`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `des_destaques` (
  `des_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `adm_codigo` int(11) DEFAULT NULL,
  `des_titulo` varchar(75) DEFAULT NULL,
  `des_url` varchar(200) NOT NULL,
  `des_imgurl` varchar(200) NOT NULL,
  PRIMARY KEY (`des_codigo`),
  KEY `adm_codigo` (`adm_codigo`),
  CONSTRAINT `des_destaques_ibfk_1` FOREIGN KEY (`adm_codigo`) REFERENCES `adm_administradores` (`adm_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `des_destaques`
--

LOCK TABLES `des_destaques` WRITE;
/*!40000 ALTER TABLE `des_destaques` DISABLE KEYS */;
INSERT INTO `des_destaques` VALUES (2,1,'Marina Ruy Barbosa revela seus cuidados com os cabelos','http://ego.globo.com/beleza/noticia/2016/05/marina-ruy-barbosa-revela-seus-cuidados-com-os-cabelos.html','http://s2.glbimg.com/V-5QggP4zG8NSfLRu2QTdbjiOKU=/620x0/top/s.glbimg.com/jo/eg/f/original/2016/05/25/marina_.jpg'),(3,1,'Homens podem pintar o cabelo sem cair no acaju ou no preto asa de graúna','http://estilo.uol.com.br/beleza/noticias/redacao/2016/05/26/homens-podem-pintar-o-cabelo-sem-cair-no-acaju-ou-no-preto-asa-de-grauna.htm','http://imguol.com/c/entretenimento/81/2016/05/25/reynaldo-gianecchini-que-ja-e-grisalho-e-um-dos-exemplos-de-cabelo-colorido-e-natural-1464204864238_v2_900x506.jpg'),(4,1,'Como fortalecer as unhas e manter o visual em dia','http://beleza.terra.com.br/esmaltes-e-unhas/como-fortalecer-as-unhas-e-manter-o-visual-em-dia,118a11063171a5f4a27ac3969c6983075xtckwkw.html','https://p2.trrsf.com/image/fget/cf/940/0/images.terra.com/2016/03/23/como-fortalecer-as-unhas.jpg'),(5,1,'Victoria Beckham anuncia linha de maquiagem em parceria com a Estée Lauder','http://ffw.com.br/noticias/beleza/victoria-beckham-anuncia-linha-de-maquiagem-em-parceria-com-a-estee-lauder/','http://ffw.com.br/app/uploads/noticias/2016/04/victoria-beckham.jpg'),(6,1,'Um plano para deixar a pele perfeita para o verão!','http://capricho.abril.com.br/beleza/plano-deixar-pele-perfeita-verao-613823.shtml','http://i.capricho.abril.com.br/img/capricho/imagem540/cuidado-natal13667.jpg');
/*!40000 ALTER TABLE `des_destaques` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `est_estabelecimentos`
--

DROP TABLE IF EXISTS `est_estabelecimentos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `est_estabelecimentos` (
  `est_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cid_codigo` int(11) DEFAULT NULL,
  `est_fantasia` varchar(75) NOT NULL,
  `est_razaosocial` varchar(75) NOT NULL,
  `est_cnpj` varchar(14) NOT NULL,
  `est_endendereco` varchar(75) DEFAULT NULL,
  `est_endnumero` varchar(6) DEFAULT NULL,
  `est_endbairro` varchar(75) DEFAULT NULL,
  `est_endcep` varchar(8) DEFAULT NULL,
  `est_ativacaoestado` enum('APROVADO','AGUARDANDO','NEGADO') DEFAULT 'AGUARDANDO',
  `est_cxmensagemestado` enum('SIM','NAO') DEFAULT 'NAO',
  `est_posicaolat` double DEFAULT NULL,
  `est_posicaolong` double DEFAULT NULL,
  `est_plus` tinyint(4) DEFAULT '0',
  `est_nomeresponsavel` varchar(200) NOT NULL,
  `est_telefone` varchar(15) DEFAULT NULL,
  `est_celular` varchar(15) DEFAULT NULL,
  `est_imagemurl` varchar(255) NOT NULL DEFAULT 'http://res.cloudinary.com/jonatasleon/image/upload/v1464291111/nsuqvdqt6ypdswnhcw3c.png',
  PRIMARY KEY (`est_codigo`),
  UNIQUE KEY `est_cnpj` (`est_cnpj`),
  KEY `cid_codigo` (`cid_codigo`),
  CONSTRAINT `est_estabelecimentos_ibfk_1` FOREIGN KEY (`cid_codigo`) REFERENCES `cid_cidades` (`cid_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `est_estabelecimentos`
--

LOCK TABLES `est_estabelecimentos` WRITE;
/*!40000 ALTER TABLE `est_estabelecimentos` DISABLE KEYS */;
INSERT INTO `est_estabelecimentos` VALUES (1,1,'Leonina\'s Beauty','Jonatas Leon','11111111111111','Rua Issac Pereira Garcez','49','Vila Paraíba','12515360','APROVADO','NAO',0,0,0,'Jonatas Leon','1230134914','12996293377','http://res.cloudinary.com/jonatasleon/image/upload/v1464666451/mhklbatkkkmtksx8vbtt.png'),(2,1,'Douglas Barbearia','Douglas','12312312312312','Avenida Presidente Vargas','123','Nova Guará','12515320','APROVADO','NAO',0,0,0,'Douglas','(12) 3133-2909','(12) 98833-4565','http://res.cloudinary.com/jonatasleon/image/upload/v1464669048/cstc7wrsdgswhycrpuls.jpg'),(3,2,'Neid Hair','Salão Neid Hair','23423423423423','Rua Santa Izabel','234','Santo Antônio','12608360','APROVADO','NAO',0,0,1,'Neidson','(12) 3133-3311','(12) 99123-1233','http://res.cloudinary.com/jonatasleon/image/upload/v1464668684/crmuanoo8nhadfqtke99.png'),(4,1,'Lucybella','Lucy Belezura','34534534534534','Rua das Paineiras','345','Belveder Clube dos 500','12523240','APROVADO','NAO',0,0,0,'Lucimar','(12) 3133-2909','(12) 99161-5432','http://res.cloudinary.com/jonatasleon/image/upload/v1464669417/wbf48gljgfildoacsnsr.png'),(5,8,'Douglas fachion','Douglas Henrique Fashion','12323232323232','Rua Doutor Otávio Lima Carvalho','123','Parque São Francisco','12509240','APROVADO','NAO',0,0,0,'Douglas','(12) 3133-2525','(12) 99881-2345','http://res.cloudinary.com/jonatasleon/image/upload/v1464890586/lfyumbsrbf0ebia8ubdn.jpg'),(6,2,'Afrodite Hair','Salão Afrodite','23132121000187','Rua Antônieta Moreira','23','Portal das Palmeiras','12610101','APROVADO','NAO',0,0,0,'Lucas','(12) 3133-3311','(12) 99167-5432','http://res.cloudinary.com/jonatasleon/image/upload/v1466551851/mi9fdfdsbihpkckya5rx.jpg'),(7,2,'Al Capone Barbearia e Pub','alcapone Pub','12345123000165','Avenida Ângelo Molinari','654','Vila Geny','12604095','APROVADO','NAO',0,0,0,'João Alcapone','(12) 3133-2525','(12) 99787-5463','http://res.cloudinary.com/jonatasleon/image/upload/v1466552050/blkktrb3brzy2uhhxzti.jpg'),(8,1,'Arrazus Studio de Beleza','Estudio de Beleza Ltda','40929292000132','Rua Monsenhor Manoel Meireles','129','Vila Paraíba','12515340','APROVADO','NAO',0,0,0,'Leonora Arrazus','(12) 3076-5432','(12) 98154-3271','http://res.cloudinary.com/jonatasleon/image/upload/v1466556235/cyd0aa228uxt2bdsvp3o.jpg'),(9,1,'Barbearia do Bigode','Bigode Ltda-ME','23238998000123','Rua Tamandaré','356','Centro','12501150','APROVADO','NAO',0,0,0,'Zé Bigodão','(12) 3012-3456','(12) 99134-2356','http://res.cloudinary.com/jonatasleon/image/upload/v1466556959/jlnarzfgrfca5wevdjb7.jpg'),(10,1,'Bigode do Gato','Barbearia Bigode do Gato LTDA','23121213000132','Avenida Presidente Vargas','543','Nova Guará','12515320','APROVADO','NAO',0,0,0,'Gatão Felix','(12) 3324-7654','(12) 98832-3456','http://res.cloudinary.com/jonatasleon/image/upload/v1466557233/jgfsqhoks9hdpwyqa3pj.png'),(11,4,'Liz Mary Beleza e Estética','LizMary LTDA','54123234000122','Rua Antonieta Borges Alves','367','Parque Primavera','12722710','APROVADO','NAO',0,0,0,'Liz ','(12) 4573-7373','(12) 98831-5454','http://res.cloudinary.com/jonatasleon/image/upload/v1466557614/kheqjnrhsb4ikluj9nlx.jpg'),(12,10,'The Best Salon','Salon Pinda','76767345000122','Rua Professora Oliva Mazianzeno Campos','834','Jardim Boa Vista','12401160','APROVADO','NAO',0,0,0,'Rick','(12) 39988-3883','(12) 99123-4555','http://res.cloudinary.com/jonatasleon/image/upload/v1466558335/kz95cvkwpguj1pe4wuqq.jpg'),(13,5,'Viviane Tomaz','Instituto de Beleza','23489899000167','Rua Melchiades de Godoy Fleming','345','Embaú','12630971','APROVADO','NAO',0,0,0,'Viviane','(12) 4677-8888','(12) 99723-1212','http://res.cloudinary.com/jonatasleon/image/upload/v1466558695/lsiarlkn023rvvozg5un.png'),(14,3,'Carol Junqueira','Carl Make HAir LTDA','54545343000123','Rua Antonio de Oliveira Portes','968','Centro','12525970','APROVADO','NAO',0,0,0,'Carol','(12) 93534-3434','(12) 99754-5473','http://res.cloudinary.com/jonatasleon/image/upload/v1466559382/bqfqm1vtpgki6sgl9nuc.png'),(15,8,'Cheiro Cheiroso','Espaço Beleza Aparecida','54545434343433','Avenida Colombano Teixeira','343','Centro','12570970','APROVADO','NAO',0,0,0,'Luciana','(12) 5454-4443','(12) 99432-3232','http://res.cloudinary.com/jonatasleon/image/upload/v1466559847/m1ipsyqeew7vfcmhvdag.jpg'),(16,9,'Dondoquinha de Luxo','Dondoquinha','54545454540102','Avenida Deputado Federal Doutor Mário Tamborindeguy 363','478','Parque das Rosas','12580970','APROVADO','NAO',0,0,0,'Lady','(12) 4362-6262','(12) 98434-2222','http://res.cloudinary.com/jonatasleon/image/upload/v1466560209/c8binztru7ucjbhrtuwb.jpg'),(17,7,'El Barbero','Barbearia de Cunha','56562341000123','Rua Doutor Casemiro da Rocha','67','Centro','12530970','APROVADO','NAO',0,0,0,'Gonzaga','(12) 4344-4211','(12) 98143-5222','http://res.cloudinary.com/jonatasleon/image/upload/v1466562934/asyhjsgkmqo03milspjh.jpg');
/*!40000 ALTER TABLE `est_estabelecimentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etd_estados`
--

DROP TABLE IF EXISTS `etd_estados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `etd_estados` (
  `etd_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `etd_nome` varchar(75) NOT NULL,
  `etd_uf` varchar(3) NOT NULL,
  PRIMARY KEY (`etd_codigo`),
  UNIQUE KEY `etd_uf` (`etd_uf`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etd_estados`
--

LOCK TABLES `etd_estados` WRITE;
/*!40000 ALTER TABLE `etd_estados` DISABLE KEYS */;
INSERT INTO `etd_estados` VALUES (1,'São Paulo','SP');
/*!40000 ALTER TABLE `etd_estados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pro_promocoes`
--

DROP TABLE IF EXISTS `pro_promocoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pro_promocoes` (
  `pro_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `srv_codigo` int(11) NOT NULL,
  `pro_novovalor` double NOT NULL,
  `pro_datainicio` date NOT NULL,
  `pro_dataexpiracao` date NOT NULL,
  PRIMARY KEY (`pro_codigo`),
  KEY `srv_codigo` (`srv_codigo`),
  CONSTRAINT `pro_promocoes_ibfk_1` FOREIGN KEY (`srv_codigo`) REFERENCES `srv_servicos` (`srv_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pro_promocoes`
--

LOCK TABLES `pro_promocoes` WRITE;
/*!40000 ALTER TABLE `pro_promocoes` DISABLE KEYS */;
/*!40000 ALTER TABLE `pro_promocoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `srv_servicos`
--

DROP TABLE IF EXISTS `srv_servicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `srv_servicos` (
  `srv_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tps_codigo` int(11) NOT NULL,
  `est_codigo` int(11) NOT NULL,
  `srv_nome` varchar(75) NOT NULL,
  `srv_valor` double NOT NULL,
  PRIMARY KEY (`srv_codigo`),
  KEY `tps_codigo` (`tps_codigo`),
  KEY `est_codigo` (`est_codigo`),
  CONSTRAINT `srv_servicos_ibfk_1` FOREIGN KEY (`tps_codigo`) REFERENCES `tps_tiposervicos` (`tps_codigo`),
  CONSTRAINT `srv_servicos_ibfk_2` FOREIGN KEY (`est_codigo`) REFERENCES `est_estabelecimentos` (`est_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `srv_servicos`
--

LOCK TABLES `srv_servicos` WRITE;
/*!40000 ALTER TABLE `srv_servicos` DISABLE KEYS */;
INSERT INTO `srv_servicos` VALUES (1,11,1,'Corte Simples',30),(2,11,1,'Corte Completo',30),(3,12,1,'Californiana',30),(4,15,1,'Creme de Oliva',30),(5,17,1,'Francesinha',30),(6,21,1,'Esmaltação em Gel Colorido',25),(7,19,1,'Podologia',90),(8,40,1,'Maquiagem dos olhos',30),(9,42,1,'Maquiagem para Casamentos',69),(10,44,1,'Alongamento de Cilios',57),(11,35,1,'Depilação do Bigode',45),(13,10,3,'Apenas Máquina',10),(14,10,3,'Máquina + Tesoura',15),(15,11,3,'Alongamento',99),(16,17,3,'Francesinha Pedicure',25),(17,18,3,'Francesinha Manicure',30),(18,20,3,'Esmaltação simples',15),(19,54,3,'Serginho BBB',45),(20,53,3,'Barba e bigode',20),(21,28,3,'Limpesa da face',35),(22,30,3,'Nádegas',30),(31,46,4,'Local escolhido',69),(32,51,4,'Agulhas Quentes',45),(33,31,4,'Pra ficar biito',23),(34,19,4,'Só vim',90),(35,30,4,'Limpa tudo',100),(36,25,4,'Hollister',80),(37,25,3,'Henna Egipicia',100),(38,36,3,'Quase lá',24),(39,10,3,'Undercut',15),(40,18,3,'Francesinha',10),(41,19,3,'Qualquer',100),(42,18,4,'Francesinha',45),(44,9,2,'Masculino',8),(45,10,2,'Corte com Máquina',10),(46,10,2,'Máquina + Tesoura',15),(47,10,2,'Tesoura',20),(48,53,2,'Completa',20),(49,54,2,'Barba Estilosa',25),(50,55,2,'Bigode Hittler',15),(51,11,5,'Corte Ruth Raquel',150),(52,10,6,'Corte com tesoura',30),(53,12,6,'Coloração',50),(54,18,6,'Esmaltação simples',15),(55,21,6,'Esmaltação em Gel Colorido',25),(56,26,6,'Limpeza',20),(57,28,6,'Limpeza de Pele',30),(58,10,7,'Corte com tesoura',40),(59,10,7,'Corte com Máquina',15),(60,53,7,'Barba Completa',30),(61,54,7,'Barba Sec VII',40),(62,55,7,'Bigode Hittler',25),(63,15,8,'Hidratação Pantene',80),(64,56,8,'Progressiva',55),(65,33,8,'Virilha',35),(66,44,8,'Alongamento de Cilios',45),(67,24,8,'Design',45),(68,53,9,'Barba e bigode',25),(69,10,9,'Corte com tesoura',20),(70,10,9,'Corte com Máquina',15),(71,55,9,'Bigode especial',30),(72,10,10,'Corte com tesoura',35),(73,10,10,'Corte com Máquina',25),(74,54,10,'Barba Desenhada',35),(75,11,11,'Corte Curto',35),(76,12,11,'Luzes',69),(77,25,11,'Hena',35),(78,29,11,'Drenagem',45),(79,34,11,'Virilha simples',30),(80,45,11,'Massagem Relaxante',40),(81,11,12,'Corte Pontas',45),(82,18,12,'Francesinha',45),(83,28,12,'Limpeza de Pele Facial',50),(84,37,12,'Depilação das Pernas',39),(85,42,12,'Maquiagem especial da noite',75),(86,49,12,'Anti-Stress',55),(87,52,12,'Terpêutica',79),(88,28,13,'Limpeza de Pele',69),(89,30,13,'Anticelulite',79),(90,32,13,'Bronzeamento Facial',120),(91,13,13,'Escova em Gel',89),(92,33,13,'Virilha Intima',50),(93,37,13,'Depilação das Pernas',60),(94,10,14,'Corte com Máquina',15),(95,11,14,'Corte de pontas',30),(96,56,14,'Progressiva',50),(97,24,14,'Sobrancelhas Desenhadas',25),(98,28,14,'Limpeza de Pele',30),(99,41,14,'Maquiagem dos olhos',20),(100,45,14,'Massagem Relaxante',45),(101,10,15,'Corte com Máquina',10),(102,11,15,'Corte Simples',25),(103,13,15,'Escora Moleladora',30),(104,15,15,'Hidratação Capilar',40),(105,45,16,'Relaxante',60),(106,46,16,'Shiatsu',70),(107,52,16,'terap^rutica',90),(108,11,16,'Corte Simples',35),(109,10,17,'Corte com tesoura',20),(110,10,17,'Corte com Máquina',15),(111,10,17,'Maquina Zero',10),(112,53,17,'Barba Completa',15),(113,54,17,'Barba Modelada',20),(114,53,17,'Barba e bigode',35);
/*!40000 ALTER TABLE `srv_servicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tps_tiposervicos`
--

DROP TABLE IF EXISTS `tps_tiposervicos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tps_tiposervicos` (
  `tps_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tps_nome` varchar(30) NOT NULL,
  `tps_tipopai` int(11) DEFAULT NULL,
  PRIMARY KEY (`tps_codigo`),
  KEY `tps_tipopai` (`tps_tipopai`),
  CONSTRAINT `tps_tiposervicos_ibfk_1` FOREIGN KEY (`tps_tipopai`) REFERENCES `tps_tiposervicos` (`tps_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tps_tiposervicos`
--

LOCK TABLES `tps_tiposervicos` WRITE;
/*!40000 ALTER TABLE `tps_tiposervicos` DISABLE KEYS */;
INSERT INTO `tps_tiposervicos` VALUES (1,'Cabelo',NULL),(2,'Unhas',NULL),(3,'Sobrancelhas',NULL),(4,'Estética',NULL),(5,'Depilação',NULL),(6,'Maquiagem',NULL),(7,'Massagem',NULL),(8,'Barbearia',NULL),(9,'Penteado',1),(10,'Corte Masculino',1),(11,'Corte Feminino',1),(12,'Coloração',1),(13,'Escova Modeladora',1),(15,'Hidratação',1),(16,'Nutrição Capilar',1),(17,'Pedicure',2),(18,'Manicure',2),(19,'Podologia',2),(20,'Esmaltação',2),(21,'Esmaltação em gel',2),(22,'Unhas em gel',2),(23,'Francesinha',2),(24,'Design',3),(25,'Design com Henna',3),(26,'Limpeza',3),(27,'Coloração',3),(28,'Limpeza de pele',4),(29,'Drenagem Linfática',4),(30,'Tratamento Anticelulite',4),(31,'Estética facial',4),(32,'Bronzeamento Artificial',4),(33,'Virilha Intima',5),(34,'Virilha Simples',5),(35,'Buço',5),(36,'Axilas',5),(37,'Pernas',5),(38,'Meia perna',5),(39,'Masculina',5),(40,'Simples',6),(41,'Express',6),(42,'Para a noite',6),(43,'Microdepilação',6),(44,'Alongamento de cílios',6),(45,'Relaxante',7),(46,'Shiatsu',7),(47,'Redutora',7),(48,'Com pedras quentes',7),(49,'Anti-stress',7),(50,'Quiropraxia',7),(51,'Acupuntura',7),(52,'Terapêuta',7),(53,'Barba Completa',8),(54,'Barba Desenhada',8),(55,'Bigode',8),(56,'Escova Progressiva',1);
/*!40000 ALTER TABLE `tps_tiposervicos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usr_usuarios`
--

DROP TABLE IF EXISTS `usr_usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usr_usuarios` (
  `usr_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `est_codigo` int(11) DEFAULT NULL,
  `adm_codigo` int(11) DEFAULT NULL,
  `usr_ativo` tinyint(1) NOT NULL,
  `usr_email` varchar(75) NOT NULL,
  `usr_senha` varchar(100) NOT NULL,
  PRIMARY KEY (`usr_codigo`),
  UNIQUE KEY `usr_email` (`usr_email`),
  KEY `est_codigo` (`est_codigo`),
  KEY `adm_codigo` (`adm_codigo`),
  CONSTRAINT `usr_usuarios_ibfk_1` FOREIGN KEY (`est_codigo`) REFERENCES `est_estabelecimentos` (`est_codigo`),
  CONSTRAINT `usr_usuarios_ibfk_2` FOREIGN KEY (`adm_codigo`) REFERENCES `adm_administradores` (`adm_codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usr_usuarios`
--

LOCK TABLES `usr_usuarios` WRITE;
/*!40000 ALTER TABLE `usr_usuarios` DISABLE KEYS */;
INSERT INTO `usr_usuarios` VALUES (1,NULL,1,1,'lucimarAdm@hotmail.com','x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A=='),(2,NULL,2,1,'neidsonAdm@hotmail.com','x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A=='),(3,NULL,3,1,'douglasAdm@hotmail.com','x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A=='),(4,NULL,NULL,1,'jonatasAdm@hotmail.com','x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37A=='),(5,1,NULL,1,'jonatas.leon@hotmail.com','rS1sjrQPPn/CDD9aiQ22yxt2zt3Vf/8xsQhgUs5W9iRw5vFzkpzcG2MLDAAPjMOUcFrBzAsNUC4bTQdRnpq+xw=='),(6,2,NULL,1,'douglas@bellaweb.com.br','jle6vjFIlyXC3ll2idYMEnU4ifBHYv4N5qNodDYmU1n+qGVXbAdR3fUGaB4hMURu218ZXR9E45PkERT0YUolAg=='),(7,3,NULL,1,'neidson@bellaweb.com.br','jle6vjFIlyXC3ll2idYMEnU4ifBHYv4N5qNodDYmU1n+qGVXbAdR3fUGaB4hMURu218ZXR9E45PkERT0YUolAg=='),(8,4,NULL,1,'lucimar@bellaweb.com.br','cW3G57nGFBWnvrPwfzT0xjvF3rgn48lA3kbcQqgc71jd7IzEuGs5aa3tEZJ5RFzShKhZ2SfgvHjaih1AcX2Pmg=='),(9,5,NULL,1,'douglas@bellaweb.com','wQ3cXa+pvF9bDapYjK164Y84hfc9hc/dFQxC3tZJEB2pL4LxQsrXa9/f56cn1sHyEf2pvFJN0IN+9R0af8Cryg=='),(10,6,NULL,1,'afroditehair@gmail.com','J9nDPCf0rco8fnGy8kDXCjTEFDBwkuC7VhcSPM56AAc4pMUMivyZcpYBR8LKGJGSPKQ4XSk4LrnCgzBoMR8hYQ=='),(11,7,NULL,1,'alcapone@gmail.com','+xpvCDUMisZvS0BTnMtxIA73QRyCnz20zyDrZedg6ZwYfa3vmsqYBOMn0WLywHhr7ZGxHC53bkccQOkYVzjmvA=='),(12,8,NULL,1,'arrazus@gmail.com','nPM4rWfMYMCqO3QVIxdekSs0rxtrWiHE7lwMFMARv6/kuFTxEyw1zybW0ByF/wnNDlv94fCoyxOnpjT7LqvoDQ=='),(13,9,NULL,1,'barbeariadobigode@gmail.com','AAsXaXzOvYyDZ1NYFmbEMC34aI1zkhnMmS1+IjKHvKKwpRdj0OyERdNaMed1aNL2VxydCHkFv+QIeYlZ44mu0Q=='),(14,10,NULL,1,'bigodedogato@gmail.com','UExbXYa2jA9M73nJWnMBpk2evnJYV1yiATMd+0XK206lUt383+Jajh390ALsvgPRkatwaQ9xupWZuPtgI1YI+w=='),(15,11,NULL,1,'lizmary@gmail.com.br','jLfXsgYNNA/BJwBOb497SbSvXGZWfqMojgBYHfs3UsWA6zEebqJ2tgmsTYtMRkQv3SuDNPFXi3tasu7nPpdvxg=='),(16,12,NULL,1,'thebest@gmail.com','lwqtxBWZORbCGODTZlie3Gsv2canb9PmKL0Jqbmp4iab+UM3PrRUfE5+5bzfdtKcq/PS9IVpGXJezeJLVIWSxQ=='),(17,13,NULL,1,'vivianetomaz@gmail.com','hmGZUjKeKGn1iUrzo84BBnGZrt4744EHD35iyLevC0N2upK13LTXHtfV+J/Z0HHwEcHKOhNpV8Nt3CduO9KyYA=='),(18,14,NULL,1,'carol@gmail.com','DBgLxuVuK5t57uoSiVaPdHYDEJ+AmMTptvPQxbrW7gveeMKb8tNt9GaAj5NqZ0G03Zp/fvxsPfoC0dB1GZ/+Vg=='),(19,15,NULL,1,'cheiro@gmail.com','1XiXjD2ajqRfJbf6nx5g8LyuRl4kdgT5R22sjqU0BkEroiiaxTfFeuWBUeqgKOJLb+RD1Yu04QKSBeEkbJl78g=='),(20,16,NULL,1,'dondoquinha@gmail.com','TBzTJLrjNh0eT/7zX45W3lOKYAP/zUL23cX7SmetV2scokCt+SE5vdwMgFGRt/E8RCdItHBHKTymPwAIuJtR3A=='),(21,17,NULL,1,'elbarbero@gmail.com','acFd1agORnd9ydFgJtHEIMFZnI/0uJBQIWtQpFLSA+uvVo7PlZe5rX2I9AXrwdRgJ3nnlC9pTbfc7LoQZK3LpA==');
/*!40000 ALTER TABLE `usr_usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `uss_usuariossociais`
--

DROP TABLE IF EXISTS `uss_usuariossociais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uss_usuariossociais` (
  `uss_codigo` int(11) NOT NULL AUTO_INCREMENT,
  `uss_facebookid` int(11) DEFAULT NULL,
  `uss_googleid` int(11) DEFAULT NULL,
  PRIMARY KEY (`uss_codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uss_usuariossociais`
--

LOCK TABLES `uss_usuariossociais` WRITE;
/*!40000 ALTER TABLE `uss_usuariossociais` DISABLE KEYS */;
/*!40000 ALTER TABLE `uss_usuariossociais` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-21 23:44:12
