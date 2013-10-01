
create table Juego(
	Id int identity Primary Key,
	Resultado varchar(20) DEFAULT '0 - 0',
	Fecha DateTime,
	Lugar varchar(100),
	EquipoGanador int,--0 Ninguno, 1 Gano equipo Rojo , 2 Gana equipo Blanco, --3  Empate
	Estado int DEFAULT 0 ---0 ( NO JUGADO) ---1(Juego activo) ---2(Juego terminado)
);

create table Galeria(
	Id int identity Primary Key,
	IdJuego int,
	Descripcion varchar(100),
	Objecto varbinary(MAX),
	MimeTypeObjeto varchar(50),
	CONSTRAINT FK_Galeria_Juego FOREIGN KEY (IdJuego)
	REFERENCES Juego(Id)
);

create table Jugador(
	Id int identity Primary Key,
	Nombre varchar(50),
	NickName varchar(50),
	Avatar varbinary(MAX),
	AvatarMimeType varchar(50),
	Correo varchar(100),
	Contrasenna varchar(200),
	Telefono varchar(30),
	Administrador  BIT DEFAULT 0
);

create table Comentario(
	Id int identity Primary Key,
	IdJuego int,
	IdJugador int,
	Fecha DateTime,
	Texto varchar(100),
	CONSTRAINT FK_Comentario_Juego FOREIGN KEY(IdJuego)
	REFERENCES Juego(Id),
	CONSTRAINT FK_Comentario_Jugador FOREIGN KEY(IdJugador)
	REFERENCES Jugador(Id)
);

create table JuegoJugador(
	Id int identity Primary Key,
	IdJugador int,
	IdJuego int,
	Puesto varchar(10),
	Numero int,
	Equipo int,
	CantLesionados int,
	CantGoles int,
	EsInvitado bit DEFAULT 0,
	CONSTRAINT FK_JuegoJugador_Juego FOREIGN KEY(IdJuego)
	REFERENCES Juego(Id),
	CONSTRAINT FK_JuegoJugador_Jugador FOREIGN KEY(IdJugador)
	REFERENCES Jugador(Id)
);




