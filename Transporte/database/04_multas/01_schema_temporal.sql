USE TransporteDB;
GO

/* TIPOMULTA */
IF OBJECT_ID('dbo.TipoMulta', 'U') IS NULL
BEGIN
  CREATE TABLE dbo.TipoMulta (
    IdTipoMulta INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Descripcion NVARCHAR(150) NOT NULL,
    MontoBase DECIMAL(10,2) NOT NULL,
    Activa BIT NOT NULL CONSTRAINT DF_TipoMulta_Activa DEFAULT (1)
  );

  CREATE UNIQUE INDEX UX_TipoMulta_Descripcion ON dbo.TipoMulta(Descripcion);
END
GO

/* MULTAS (TEMPORAL): IdVehiculo nullable, no FK yet */
IF OBJECT_ID('dbo.Multas', 'U') IS NULL
BEGIN
  CREATE TABLE dbo.Multas (
    IdMulta INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdVehiculo INT NULL,            -- TEMP: allows work before Vehiculos module is integrated
    IdTipoMulta INT NOT NULL,
    Fecha DATETIME NOT NULL,
    MontoAplicado DECIMAL(10,2) NOT NULL,
    Pagada BIT NOT NULL CONSTRAINT DF_Multas_Pagada DEFAULT (0),

    CONSTRAINT FK_Multas_TipoMulta
      FOREIGN KEY (IdTipoMulta) REFERENCES dbo.TipoMulta(IdTipoMulta)
  );
END
GO

-- Nota: La columna IdVehiculo es nullable y no tiene FK en esta etapa para permitir el desarrollo paralelo del módulo de Vehículos. Se agregará la restricción FK una vez que el módulo de Vehículos esté listo y se pueda garantizar la integridad referencial.