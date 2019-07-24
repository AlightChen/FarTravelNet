/*
Navicat MySQL Data Transfer

Source Server         : 本机Mysql
Source Server Version : 50719
Source Host           : localhost:3306
Source Database       : far_travel_net

Target Server Type    : MYSQL
Target Server Version : 50719
File Encoding         : 65001

Date: 2019-07-02 16:17:56
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo` (
  `ID` varchar(50) NOT NULL COMMENT '用户ID',
  `USERCODE` varchar(255) NOT NULL COMMENT '用户账号',
  `USERNAME` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_mysql500_ci NOT NULL COMMENT '用户昵称',
  `PASSWORD` varchar(255) NOT NULL COMMENT '密码',
  `HEADPORTRAIT` varchar(255) DEFAULT NULL COMMENT '用户头像',
  `CREATETIME` datetime DEFAULT NULL COMMENT '创建时间',
  `UPDATETIME` datetime DEFAULT NULL COMMENT '更新时间',
  `LASRLOGINTIME` datetime DEFAULT NULL COMMENT '最后登入时间',
  `ENABLE` tinyint(1) NOT NULL DEFAULT '0' COMMENT '是否启用',
  `UMDELETE` tinyint(1) NOT NULL DEFAULT '0' COMMENT '标记删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of userinfo
-- ----------------------------
INSERT INTO `userinfo` VALUES ('1543048387572', 'ceshi', '测试用户', 'c566e6f53ebb5409f59b152e1947a7ba', '', '2018-11-24 16:33:07', '2018-11-24 16:33:07', '2018-11-24 16:33:07', '1', '0');
INSERT INTO `userinfo` VALUES ('1543048387573', 'ceshi', '测试用户', 'c566e6f53ebb5409f59b152e1947a7ba', '', '2018-11-24 16:33:07', '2018-11-24 16:33:07', '2018-11-24 16:33:07', '1', '0');
