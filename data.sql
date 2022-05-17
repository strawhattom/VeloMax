USE velomax;
-- Bikes
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (101, 'Kilimandjaro', 'Adultes', 569, 'VTT', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (102, 'NorthPole', 'Adultes', 329, 'VTT', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (103, 'MontBlanc', 'Jeunes', 399, 'VTT', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (104, 'Hooligan', 'Jeunes', 199, 'VTT', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (105, 'Orléans', 'Hommes', 229, 'Vélo de course', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (106, 'Orléans', 'Dames', 229, 'Vélo de course', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (107, 'BlueJay', 'Hommes', 349, 'Vélo de course', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (108, 'BlueJay', 'Dames', 349, 'Vélo de course', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (109, 'Trail Explorer', 'Filles', 129, 'Classique', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (110, 'Trail Explorer', 'Garçons', 129, 'Classique', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (111, 'Night Hawk', 'Jeunes', 189, 'Classique', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (112, 'Tierra Verde', 'Hommes', 199, 'Classique', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (113, 'Tierra Verde', 'Dames', 199, 'Classique', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (114, 'Mud Zinger I', 'Jeunes', 279, 'BMX', '2022-04-26', '2022-04-26');
INSERT INTO `bikes` (`id`, `name`, `target`, `unit_price`, `type`, `introduction_date`, `discontinuation_date`) VALUES (115, 'Mud Zinger II', 'Adultes', 359, 'BMX', '2022-04-26', '2022-04-26');

-- Fidelity programs
INSERT INTO `fidelity_programs` (`id`, `label`, `cost`, `duration`, `discount`) VALUES (1, 'Fidélio', 15, 1, 5);
INSERT INTO `fidelity_programs` (`id`, `label`, `cost`, `duration`, `discount`) VALUES (2, 'Fidélio Or', 25, 2, 8);
INSERT INTO `fidelity_programs` (`id`, `label`, `cost`, `duration`, `discount`) VALUES (3, 'Fidélio Platine', 60, 2, 10);
INSERT INTO `fidelity_programs` (`id`, `label`, `cost`, `duration`, `discount`) VALUES (4, 'Fidélio Max', 100, 3, 12);

-- Parts
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (1, 'C32', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (2, 'C34', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (3, 'C76', 0, '2022-04-26', '2022-04-26', 0, 2, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (4, 'C43', 0, '2022-04-26', '2022-04-26', 0, 2, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (5, 'C44f', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (6, 'C43f', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (7, 'C01', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (8, 'C02', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (9, 'C15', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (10, 'C87', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (11, 'C87f', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (12, 'C25', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (13, 'C26', 0, '2022-04-26', '2022-04-26', 0, 1, 'Cadre');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (14, 'G7', 0, '2022-04-26', '2022-04-26', 0, 4, 'Guidon');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (15, 'G9', 0, '2022-04-26', '2022-04-26', 0, 4, 'Guidon');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (16, 'G12', 0, '2022-04-26', '2022-04-26', 0, 6, 'Guidon');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (17, 'F3', 0, '2022-04-26', '2022-04-26', 0, 6, 'Freins');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (18, 'F9', 0, '2022-04-26', '2022-04-26', 0, 7, 'Freins');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (19, 'S88', 0, '2022-04-26', '2022-04-26', 0, 4, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (20, 'S37', 0, '2022-04-26', '2022-04-26', 0, 2, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (21, 'S35', 0, '2022-04-26', '2022-04-26', 0, 2, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (22, 'S02', 0, '2022-04-26', '2022-04-26', 0, 1, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (23, 'S03', 0, '2022-04-26', '2022-04-26', 0, 1, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (24, 'S36', 0, '2022-04-26', '2022-04-26', 0, 2, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (25, 'S34', 0, '2022-04-26', '2022-04-26', 0, 1, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (26, 'S87', 0, '2022-04-26', '2022-04-26', 0, 2, 'Selle');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (27, 'DV133', 0, '2022-04-26', '2022-04-26', 0, 2, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (28, 'DV17', 0, '2022-04-26', '2022-04-26', 0, 2, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (29, 'DV87', 0, '2022-04-26', '2022-04-26', 0, 1, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (30, 'DV57', 0, '2022-04-26', '2022-04-26', 0, 4, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (31, 'DV15', 0, '2022-04-26', '2022-04-26', 0, 1, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (32, 'DV41', 0, '2022-04-26', '2022-04-26', 0, 2, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (33, 'DV132', 0, '2022-04-26', '2022-04-26', 0, 1, 'Dérailleur Avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (34, 'DR56', 0, '2022-04-26', '2022-04-26', 0, 1, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (35, 'DR87', 0, '2022-04-26', '2022-04-26', 0, 4, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (36, 'DR86', 0, '2022-04-26', '2022-04-26', 0, 3, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (37, 'DR23', 0, '2022-04-26', '2022-04-26', 0, 1, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (38, 'DR76', 0, '2022-04-26', '2022-04-26', 0, 2, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (39, 'DR52', 0, '2022-04-26', '2022-04-26', 0, 2, 'Dérailleur Arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (40, 'R45', 0, '2022-04-26', '2022-04-26', 0, 1, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (41, 'R48', 0, '2022-04-26', '2022-04-26', 0, 2, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (42, 'R12', 0, '2022-04-26', '2022-04-26', 0, 1, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (43, 'R19', 0, '2022-04-26', '2022-04-26', 0, 4, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (44, 'R1', 0, '2022-04-26', '2022-04-26', 0, 2, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (45, 'R11', 0, '2022-04-26', '2022-04-26', 0, 3, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (46, 'R44', 0, '2022-04-26', '2022-04-26', 0, 2, 'Roue avant');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (47, 'R46', 0, '2022-04-26', '2022-04-26', 0, 1, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (48, 'R47', 0, '2022-04-26', '2022-04-26', 0, 4, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (49, 'R32', 0, '2022-04-26', '2022-04-26', 0, 1, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (50, 'R18', 0, '2022-04-26', '2022-04-26', 0, 4, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (51, 'R2', 0, '2022-04-26', '2022-04-26', 0, 2, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (52, 'R12', 0, '2022-04-26', '2022-04-26', 0, 3, 'Roue arrière');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (53, 'R02', 0, '2022-04-26', '2022-04-26', 0, 4, 'Réflecteurs');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (54, 'R09', 0, '2022-04-26', '2022-04-26', 0, 2, 'Réflecteurs');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (55, 'R10', 0, '2022-04-26', '2022-04-26', 0, 3, 'Réflecteurs');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (56, 'P12', 0, '2022-04-26', '2022-04-26', 0, 6, 'Pédalier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (57, 'P34', 0, '2022-04-26', '2022-04-26', 0, 4, 'Pédalier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (58, 'P1', 0, '2022-04-26', '2022-04-26', 0, 2, 'Pédalier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (59, 'P15', 0, '2022-04-26', '2022-04-26', 0, 3, 'Pédalier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (60, 'O2', 0, '2022-04-26', '2022-04-26', 0, 2, 'Ordinateur');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (61, 'O4', 0, '2022-04-26', '2022-04-26', 0, 2, 'Ordinateur');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (62, 'S01', 0, '2022-04-26', '2022-04-26', 0, 1, 'Panier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (63, 'S05', 0, '2022-04-26', '2022-04-26', 0, 1, 'Panier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (64, 'S74', 0, '2022-04-26', '2022-04-26', 0, 2, 'Panier');
INSERT INTO `parts` (`id`, `description`, `unit_price`, `introduction_date`, `discontinuation_date`, `procurement_delay`, `quantity`, `type`) VALUES (65, 'S73', 0, '2022-04-26', '2022-04-26', 0, 1, 'Panier');

INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (1,1,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (2,2,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (3,3,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (4,3,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (5,4,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (6,5,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (7,4,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (8,6,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (9,7,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (10,8,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (11,9,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (12,10,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (13,11,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (14,12,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (15,13,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (16,14,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (17,14,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (18,14,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (19,14,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (20,15,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (21,15,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (22,15,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (23,15,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (24,16,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (25,16,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (26,16,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (27,16,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (28,16,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (29,14,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (30,14,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (31,17,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (32,17,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (33,17,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (34,17,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (35,18,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (36,18,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (37,18,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (38,18,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (41,18,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (42,18,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (43,18,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (44,17,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (45,17,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (46,19,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (47,19,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (48,19,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (49,19,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (50,20,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (51,21,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (52,20,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (53,21,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (54,22,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (55,23,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (56,24,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (57,24,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (58,25,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (59,26,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (60,26,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (61,27,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (62,28,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (63,28,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (64,29,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (65,30,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (66,30,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (67,30,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (68,30,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (71,31,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (72,32,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (73,32,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (74,33,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (75,33,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (76,34,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (77,35,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (78,35,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (79,36,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (80,36,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (81,36,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (82,35,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (83,35,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (86,37,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (87,38,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (88,38,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (89,39,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (90,39,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (91,40,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (92,41,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (93,41,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (94,42,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (95,43,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (96,43,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (97,43,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (98,43,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (99,44,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (100,44,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (101,45,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (102,45,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (103,45,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (104,46,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (105,46,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (106,47,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (107,48,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (108,48,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (109,49,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (110,50,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (111,50,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (112,50,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (113,50,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (114,51,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (115,51,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (116,52,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (117,52,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (118,52,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (119,48,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (120,48,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (125,53,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (126,53,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (127,53,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (128,53,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (129,54,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (130,54,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (131,55,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (132,55,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (133,55,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (136,56,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (137,56,102);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (138,56,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (139,56,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (140,57,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (141,57,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (142,57,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (143,57,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (144,58,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (145,58,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (146,59,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (147,59,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (148,59,113);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (149,56,114);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (150,56,115);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (151,60,101);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (153,60,103);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (154,61,104);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (155,62,105);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (156,63,106);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (157,61,107);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (158,61,108);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (159,62,109);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (160,63,110);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (161,64,111);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (162,64,112);
INSERT INTO `bike_parts`(id,parts_id,bikes_id) VALUES (163,64,113);

INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (1,'812210516','LaFraise Cycles','06 38 15 65 85','117 Rue Montgolfier, 59100 Roubaix','3');
INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (2,'503031544','lecyclo','04 86 77 80 90','43 Rue de l''Évêché, 13002 Marseille','4');
INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (3,'484395629','alltricks','01 20 48 52 82','9 Rue Auguste Gervais, 92130 Issy-les-Moulineaux','4');
INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (4,'832870950','BBB Cycling','31 7 15 79 15 80','Rooseveltstraat 46, 2321 BM Leiden, Pays-Bas','4');
INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (5,'794310110','beastybike','01 44 93 95 85','73 Rue de Turbigo, 75003 Paris','3');
INSERT INTO `suppliers`(id,siret,name,contact,location,label) VALUES (6,'750378936','Renadar','01 56 76 89 à3','67 Allée de la Citadelle, 34000 Montpellier',3);

INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (1,1,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (2,2,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (3,3,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (4,4,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (5,5,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (6,6,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (7,7,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (8,8,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (9,9,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (10,10,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (11,11,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (12,12,1);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (13,13,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (14,14,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (15,15,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (16,16,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (17,17,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (18,18,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (19,19,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (20,20,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (21,21,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (22,22,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (23,23,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (24,24,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (25,25,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (26,26,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (27,27,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (28,28,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (29,29,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (30,30,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (31,31,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (32,32,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (33,33,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (34,34,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (35,35,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (36,36,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (37,37,4);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (38,38,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (39,39,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (40,40,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (41,41,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (42,42,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (43,43,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (44,44,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (45,45,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (46,46,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (47,47,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (48,48,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (49,49,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (50,50,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (51,51,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (52,52,5);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (53,53,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (54,54,3);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (55,55,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (56,56,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (57,57,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (58,58,6);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (59,59,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (60,60,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (61,61,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (62,62,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (63,63,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (64,64,2);
INSERT INTO `procurement`(id,parts_id,suppliers_id) VALUES (65,65,2);

INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (1,'1 All. de la Carrière','Toucy','89130','Yonne','06 56 43 94 65','Paul.barbier@gmail.com');
INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (2,'Rue Jean Baptiste Say','Limoges','87000','Haute-Vienne','07 33 46 21 56','Christelle.gandon@gmail.com');
INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (3,'106 Rue du Faubourg Charrault','Saint-Maixent-l''École','79400','Deux-Sèvres','06 98 67 20 71','alexande67@hotmail.fr');
INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (4,'53 Rue Victor Hugo','Levallois-Perret','92300','Hauts-de-Seine','01 47 37 42 14','CyclesAlexSinger@gmail.com');
INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (5,'11 Rue Danton','Lyon','69003','Rhône','04 72 36 83 28','CylcesDGuideon@free.fr');
INSERT INTO `clients`(id,street,city,postal_code,province,phone,mail) VALUES (6,'2 Rue de l''Occitanie','Fenouillet','31150','Haute-Garonne','06 47 08 30 00','BAUDOUBIKES@gmail.com');

INSERT INTO `individuals`(id,first_name,last_name,id_fidelity) VALUES (1,'Paul','Barbier',1);
INSERT INTO `individuals`(id,first_name,last_name,id_fidelity) VALUES (2,'Christelle','Gandon',3);
INSERT INTO `individuals`(id,first_name,last_name,id_fidelity) VALUES (3,'Alexande','Rouste',2);

INSERT INTO `professionals`(id,company_name,contact_name,order_count) VALUES (3,'Cycle Alex Singer','Bast',8);
INSERT INTO `professionals`(id,company_name,contact_name,order_count) VALUES (4,'CycleDGuidon','Gorfle',31);
INSERT INTO `professionals`(id,company_name,contact_name,order_count) VALUES (5,'Baudou Bikes','Haussien',5);

INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (1,'2022-05-06','1 Rue Pasteur, 93160 Noisy-le-Grand','2022-06-08',1,2);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (2,'2022-03-05','24 Rue de Sévigné, 94370 Sucy-en-Brie','2022-07-05',3,3);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (3,'2022-02-01','1 Rue Augereau, 77000 Melun','2022-08-01',2,1);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (4,'2022-05-26','Rue Neuve des Carmes, 63000 Clermont-Ferrand','2022-05-28',20,4);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (5,'2022-07-16','53 Rue Victor Hugo, 92300 Levallois-Perret','2022-07-29',5,4);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (6,'2022-04-04','11 Rue Danton, 69003 Lyon','2022-04-21',12,5);
INSERT INTO `orders`(id,order_date,shipping_address,shipping_date,quantity,id_clients) VALUES (7,'2022-04-04','2 Rue de l''Occitanie , 31150 Fenouillet','2022-05-01',10,6);

INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (1,2,43,2);
INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (2,3,24,2);
INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (3,4,2,5);
INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (4,4,33,10);
INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (5,6,20,10);
INSERT INTO `ordered_parts`(id,orders_id,parts_id,quantity) VALUES (6,6,55,10);


INSERT INTO `ordered_bikes`(id,orders_id,bikes_id,quantity) VALUES (1,1,101,1);
INSERT INTO `ordered_bikes`(id,orders_id,bikes_id,quantity) VALUES (2,2,103,1);
INSERT INTO `ordered_bikes`(id,orders_id,bikes_id,quantity) VALUES (3,4,110,5);
INSERT INTO `ordered_bikes`(id,orders_id,bikes_id,quantity) VALUES (4,5,109,5);
INSERT INTO `ordered_bikes`(id,orders_id,bikes_id,quantity) VALUES (5,6,106,2);
