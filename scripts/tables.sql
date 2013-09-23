
create table Juego(
	Id int identity Primary Key,
	Resultado varchar(20),
	Fecha DateTime,
	Lugar varchar(100),
	EquipoGanador int
);

create table Galeria(
	Id int identity Primary Key,
	IdJuego int,
	Descripcion varchar(100),
	Objecto varbinary,
	MimeTypeObjeto varbinary,
	CONSTRAINT FK_Galeria_Juego FOREIGN KEY (IdJuego)
	REFERENCES Juego(Id)
);

create table Comentario(
	Id int identity Primary Key,
	IdJuego int,
	Fecha DateTime,
	Texto varchar(100),
	CONSTRAINT FK_Comentario_Juego FOREIGN KEY(IdJuego)
	REFERENCES Juego(Id)
);

create table Jugador(
	Id int identity Primary Key,
	Nombre varchar(50),
	NickName varchar(50),
	Avatar varbinary,
	AvatarMimeType varbinary,
	Correo varchar(100),
	Contrasenna varchar(200),
	Telefono varchar(30)
)

create table JuegoJugador(
	Id int identity Primary Key,
	IdJugador int,
	IdJuego int,
	Puesto varchar(10),
	Numero int,
	Equipo int,
	CantLesionados int,
	CantGoles int
	CONSTRAINT FK_JuegoJugador_Juego FOREIGN KEY(IdJuego)
	REFERENCES Juego(Id),
	CONSTRAINT FK_JuegoJugador_Jugador FOREIGN KEY(IdJugador)
	REFERENCES Jugador(Id)
)



