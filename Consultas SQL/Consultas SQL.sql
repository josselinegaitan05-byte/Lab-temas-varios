USE productosdb;

CREATE TABLE IF NOT EXISTS permisos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Usuario VARCHAR(50),
    Contrasena VARCHAR(50),
    Administrador INT,
    Correo VARCHAR(100),
    UsuarioSistema INT,
    FechaModificacion DATE,
    Modulo_Personal INT,
    Modulo_Horario INT,
    Modulo_Valor INT
);

-- Reemplazamos '0000-00-00' por '2020-01-01' para evitar el error de MySQL
INSERT INTO permisos (id, Usuario, Contrasena, Administrador, Correo, UsuarioSistema, FechaModificacion, Modulo_Personal, Modulo_Horario, Modulo_Valor) VALUES
(135, 'vielkarosmery', 'MTIzNDU=', 1, 'vreyes@umip.ac.pa', 0, '2020-01-01', 1, 1, 0),
(144, 'armando', 'cjNjdXJzMHM=', 1, 'amartinez@umip.ac.pa', 0, '2020-01-01', 1, 1, 1),
(145, 'pbarbax', 'YmF5YmF1bWlw', 1, 'pbarba@umip.ac.pa', 1, '2020-01-01', 0, 0, 0),
(146, 'root', 'TmV5bGFmUjUxNA==', 1, 'dream.pbarba@umip.ac.pa', 0, '2020-05-20', 1, 1, 1);

-- Consultas de prueba
SELECT * FROM permisos WHERE Usuario = '' OR '1'='1' AND Contrasena = '' OR '1'='1';

SELECT * FROM permisos WHERE Usuario = 'root'; -- ' AND password = 'mypassword';

-- Consulta con inyección de tiempo aplicada a tu tabla 'productos'
SELECT * FROM productos WHERE id = 1 - SLEEP(15);

