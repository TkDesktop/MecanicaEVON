INSERT INTO tblVeiculo
(
    placa,
    ano,
    idModelo,
    idCombustivel,
    idCliente
)
VALUES
-- Gasolina
('BRA2E19', 2018, 1, 1, 1),
('FGH3J45', 2019, 3, 1, 2),

-- Etanol
('JKL4M67', 2017, 7, 2, 3),
('NOP5Q89', 2018, 8, 2, 4),

-- Flex
('QRS3T34', 2021, 10, 3, 5),
('UVW4X56', 2022, 15, 3, 6),

-- Diesel
('YZA5B78', 2023, 12, 4, 7),
('CDE6F90', 2022, 18, 4, 8),

-- GNV
('GHI7J12', 2016, 13, 5, 9),
('KLM8N34', 2017, 14, 5, 10),

-- Híbrido
('OPQ9R56', 2024, 27, 6, 1),
('STU1V78', 2024, 28, 6, 2),

-- Elétrico
('WXY2Z90', 2025, 68, 7, 3),
('BCD3E12', 2025, 69, 7, 4);