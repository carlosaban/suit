INSERT INTO `suit_poloservices`.`parameter`
(
`initials`,
`name`,
`createdBy`,
`createdDate`,
`updatedBy`,
`updatedDate`,
`isEnabled`)
VALUES
(
'RECPRO',
'Protección',
'marko.polo',
null,
null,
null,
1);



INSERT INTO `suit_poloservices`.`parameterdetail`
(
`idparameter`,
`value`,
`text`,
`order`,
`createdBy`,
`createdDate`,
`updatedBy`,
`updatedDate`,
`idparameterdetailparent`,
`isEnabled`)
VALUES
(
(select idparameter from parameter where initials = 'RECPRO'),
'0',
'Protección',
1,
'marko.polo',
null ,
null ,
null ,
null ,
1);
-- --------------------------------------------------------------------

INSERT INTO `suit_poloservices`.`parameter`
(
`initials`,
`name`,
`createdBy`,
`createdDate`,
`updatedBy`,
`updatedDate`,
`isEnabled`)
VALUES
(
'RECMAO',
'Mano de Obra',
'marko.polo',
null,
null,
null,
1);



INSERT INTO `suit_poloservices`.`parameterdetail`
(
`idparameter`,
`value`,
`text`,
`order`,
`createdBy`,
`createdDate`,
`updatedBy`,
`updatedDate`,
`idparameterdetailparent`,
`isEnabled`)
VALUES
(
(select idparameter from parameter where initials = 'RECMAO'),
'0',
'Mano de Obra',
10,
'marko.polo',
null ,
null ,
null ,
null ,
1);