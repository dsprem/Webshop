USE master
CREATE DATABASE WebShop
GO

USE [WebShop]
GO
/****** Object:  Table [dbo].[MjereProizvoda]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MjereProizvoda](
	[Id] [smallint] NOT NULL,
	[Naziv] [nvarchar](10) NULL,
 CONSTRAINT [PK_MjereProizvoda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnici]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Korisnici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[AdresaDostave] [nvarchar](250) NOT NULL,
	[Kontakt] [varchar](50) NOT NULL,
	[Napomena] [nvarchar](max) NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kategorije]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorije](
	[Id] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](500) NULL,
 CONSTRAINT [PK_Kategorije] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Narudzbe]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Narudzbe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikId] [int] NOT NULL,
	[DatumKreiranja] [datetime] NOT NULL,
	[DatumVrijemeDostave] [datetime] NOT NULL,
	[JeDostavljeno] [bit] NOT NULL,
 CONSTRAINT [PK_Narudzbe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvodi]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proizvodi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MjeraProizvodaId] [smallint] NOT NULL,
	[VrijemeKreiranja] [datetime] NOT NULL,
	[Naziv] [varchar](50) NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Dostupan] [bit] NOT NULL,
 CONSTRAINT [PK_Proizvodi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NarudzbeDetalji]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NarudzbeDetalji](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NarudzbaId] [int] NOT NULL,
	[ProizvodId] [int] NOT NULL,
	[Kolicina] [decimal](18, 2) NOT NULL,
	[JedCijena] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_NarudzbeDetalji] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KategorijeProizvodi]    Script Date: 11/25/2015 12:31:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KategorijeProizvodi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProizvodId] [int] NOT NULL,
	[KategorijaId] [int] NOT NULL,
 CONSTRAINT [PK_KategorijeProizvodi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Narudzbe_DatumKreiranja]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Narudzbe] ADD  CONSTRAINT [DF_Narudzbe_DatumKreiranja]  DEFAULT (getdate()) FOR [DatumKreiranja]
GO
/****** Object:  Default [DF_Narudzbe_JeDostavljeno]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Narudzbe] ADD  CONSTRAINT [DF_Narudzbe_JeDostavljeno]  DEFAULT ((0)) FOR [JeDostavljeno]
GO
/****** Object:  Default [DF_Proizvodi_VrijemeKreiranja]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Proizvodi] ADD  CONSTRAINT [DF_Proizvodi_VrijemeKreiranja]  DEFAULT (getdate()) FOR [VrijemeKreiranja]
GO
/****** Object:  Default [DF_Proizvodi_Dostupan]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Proizvodi] ADD  CONSTRAINT [DF_Proizvodi_Dostupan]  DEFAULT ((1)) FOR [Dostupan]
GO
/****** Object:  ForeignKey [FK_KategorijeProizvodi_Kategorije]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[KategorijeProizvodi]  WITH CHECK ADD  CONSTRAINT [FK_KategorijeProizvodi_Kategorije] FOREIGN KEY([KategorijaId])
REFERENCES [dbo].[Kategorije] ([Id])
GO
ALTER TABLE [dbo].[KategorijeProizvodi] CHECK CONSTRAINT [FK_KategorijeProizvodi_Kategorije]
GO
/****** Object:  ForeignKey [FK_KategorijeProizvodi_Proizvodi]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[KategorijeProizvodi]  WITH CHECK ADD  CONSTRAINT [FK_KategorijeProizvodi_Proizvodi] FOREIGN KEY([ProizvodId])
REFERENCES [dbo].[Proizvodi] ([Id])
GO
ALTER TABLE [dbo].[KategorijeProizvodi] CHECK CONSTRAINT [FK_KategorijeProizvodi_Proizvodi]
GO
/****** Object:  ForeignKey [FK_Narudzbe_Korisnici]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Narudzbe]  WITH CHECK ADD  CONSTRAINT [FK_Narudzbe_Korisnici] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[Narudzbe] CHECK CONSTRAINT [FK_Narudzbe_Korisnici]
GO
/****** Object:  ForeignKey [FK_NarudzbeDetalji_Narudzbe]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[NarudzbeDetalji]  WITH CHECK ADD  CONSTRAINT [FK_NarudzbeDetalji_Narudzbe] FOREIGN KEY([NarudzbaId])
REFERENCES [dbo].[Narudzbe] ([Id])
GO
ALTER TABLE [dbo].[NarudzbeDetalji] CHECK CONSTRAINT [FK_NarudzbeDetalji_Narudzbe]
GO
/****** Object:  ForeignKey [FK_NarudzbeDetalji_Proizvodi]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[NarudzbeDetalji]  WITH CHECK ADD  CONSTRAINT [FK_NarudzbeDetalji_Proizvodi] FOREIGN KEY([ProizvodId])
REFERENCES [dbo].[Proizvodi] ([Id])
GO
ALTER TABLE [dbo].[NarudzbeDetalji] CHECK CONSTRAINT [FK_NarudzbeDetalji_Proizvodi]
GO
/****** Object:  ForeignKey [FK_Proizvodi_MjereProizvoda]    Script Date: 11/25/2015 12:31:37 ******/
ALTER TABLE [dbo].[Proizvodi]  WITH CHECK ADD  CONSTRAINT [FK_Proizvodi_MjereProizvoda] FOREIGN KEY([MjeraProizvodaId])
REFERENCES [dbo].[MjereProizvoda] ([Id])
GO
ALTER TABLE [dbo].[Proizvodi] CHECK CONSTRAINT [FK_Proizvodi_MjereProizvoda]
GO
