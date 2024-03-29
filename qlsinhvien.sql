USE [master]
GO
/****** Object:  Database [SinhVienDB]    Script Date: 04/12/2011 18:07:52 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SinhVienDB')
BEGIN
CREATE DATABASE [SinhVienDB] 
END
GO
USE [SinhVienDB]
GO
/****** Object:  ForeignKey [f_KQ_MH]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[f_KQ_MH]') AND parent_object_id = OBJECT_ID(N'[dbo].[KETQUA]'))
ALTER TABLE [dbo].[KETQUA] DROP CONSTRAINT [f_KQ_MH]
GO
/****** Object:  ForeignKey [FK_Users_NhomNguoiDung]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_NhomNguoiDung]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_NhomNguoiDung]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateSinhVien]    Script Date: 04/12/2011 18:08:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateSinhVien]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_updateSinhVien]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_NhomNguoiDung]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_NhomNguoiDung]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[KETQUA]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[f_KQ_MH]') AND parent_object_id = OBJECT_ID(N'[dbo].[KETQUA]'))
ALTER TABLE [dbo].[KETQUA] DROP CONSTRAINT [f_KQ_MH]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KETQUA]') AND type in (N'U'))
DROP TABLE [dbo].[KETQUA]
GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KHOA]') AND type in (N'U'))
DROP TABLE [dbo].[KHOA]
GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SINHVIEN]') AND type in (N'U'))
DROP TABLE [dbo].[SINHVIEN]
GO
/****** Object:  Table [dbo].[NhomNguoiDung]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhomNguoiDung]') AND type in (N'U'))
DROP TABLE [dbo].[NhomNguoiDung]
GO
/****** Object:  Table [dbo].[temp_MaSV]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_MaSV]') AND type in (N'U'))
DROP TABLE [dbo].[temp_MaSV]
GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 04/12/2011 18:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MONHOC]') AND type in (N'U'))
DROP TABLE [dbo].[MONHOC]
GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MONHOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MONHOC](
	[MaMH] [varchar](5) NOT NULL,
	[TENMH] [varchar](50) NULL,
	[SoTietLT] [smallint] NULL,
	[SoTietTH] [smallint] NULL,
 CONSTRAINT [p_MH] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'AV', N'Anh van so cap', 50, 10)
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'CSDL', N'Co so du lieu', 45, 35)
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'CTDL', N'Cau truc du lieu', 60, 30)
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'DT', N'Dam thoai', 60, 60)
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'TH', N'Triet hoc', 60, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TENMH], [SoTietLT], [SoTietTH]) VALUES (N'VP', N'Van pham', 60, 0)
/****** Object:  Table [dbo].[temp_MaSV]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[temp_MaSV]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[temp_MaSV](
	[MaSV] [varchar](5) NOT NULL,
	[MaMH] [varchar](5) NOT NULL,
	[LanThi] [varchar](1) NOT NULL,
	[Diem] [smallint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_MaSV] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV012', N'CTDL', N'1', 5)
/****** Object:  Table [dbo].[NhomNguoiDung]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhomNguoiDung]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NhomNguoiDung](
	[MaNhom] [nvarchar](10) NOT NULL,
	[TenNhom] [nchar](30) NULL,
 CONSTRAINT [PK_NhomNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom]) VALUES (N'N001', N'Administrator                 ')
INSERT [dbo].[NhomNguoiDung] ([MaNhom], [TenNhom]) VALUES (N'N002', N'Giáo vụ                       ')
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SINHVIEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SINHVIEN](
	[MaSV] [varchar](5) NOT NULL,
	[TenSV] [varchar](50) NOT NULL,
	[NgaySinh] [smalldatetime] NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [varchar](50) NULL,
	[Tinh] [varchar](50) NULL,
	[MaKhoa] [varchar](5) NOT NULL,
	[HocBong] [int] NULL,
 CONSTRAINT [p_SV] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV002', N'Nguyen Ha Da Thao4543', CAST(0x9FAF0000 AS SmallDateTime), 0, N'115 Nguyen Du', N'TPHCM', N'CNTT', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV003', N'Pham Nguyen Anh Huy', CAST(0x6A0E0000 AS SmallDateTime), 1, N'17/6 Tran Phu', N'TPHCM', N'CNTT', 120000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV004', N'Nguyen Ngoc Thuan', CAST(0x6BA60000 AS SmallDateTime), 1, N'52 Bau Cat-Q.TB', N'TPHCM', N'CNTT', 80)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV005', N'Le Thanh Trung', CAST(0x6BAD0000 AS SmallDateTime), 1, N'23/18 Le Hong Phong', N'Long An', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV007', N'Nguyen Hong Van', CAST(0x6BC10000 AS SmallDateTime), 0, N'43/17 Tran Hung Dao', N'TPHCM', N'AV', 120000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV009', N'Truong Kim Quang', CAST(0x67280000 AS SmallDateTime), 1, N'236 Le Quang Dinh-Q.BT', N'Nha Trang', N'AV', 80000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV010', N'Ton That Quyen', CAST(0x65FC0000 AS SmallDateTime), 1, N'340/4 Dong Ho', N'Nha Trang', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV011', N'Vo Thi Kim Loan', CAST(0x69B60000 AS SmallDateTime), 0, N'69 Trung Nhi', N'Long An', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV012', N'Bui Van Anh', CAST(0x6EEC0000 AS SmallDateTime), 1, N'466 Hung Phu', N'Nha Trang', N'CNTT', 120000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV013', N'Ha Thi Giang Long', CAST(0x6D3A0000 AS SmallDateTime), 0, N'43A Trang Tu', N'Long An', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV014', N'Phan Thi Anh Thu', CAST(0x6F3E0000 AS SmallDateTime), 0, N'143 Lac Long Quan', N'TPHCM', N'CNTT', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV015', N'Pham Van Hien', CAST(0x6CF90000 AS SmallDateTime), 1, N'17/6 Tran Phu', N'TPHCM', N'AV', 80000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV016', N'Tran Minh Sang', CAST(0x6E820000 AS SmallDateTime), 1, N'49/1 Ho Bieu Chanh', N'TPHCM', N'CNTT', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV017', N'Huynh Thanh Lam', CAST(0x6F000000 AS SmallDateTime), 1, N'243/16 Phu My-Phu Tan', N'Nha Trang', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV018', N'Phan Van Hoang', CAST(0x6DE00000 AS SmallDateTime), 1, N'28 Binh Gia', N'Nha Trang', N'CNTT', 120000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV019', N'Phan Van Hai', CAST(0x6DDF0000 AS SmallDateTime), 1, N'322 Xo Viet Nghe Tinh', N'Long An', N'AV', 80000)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV020', N'Tran Quang Cuong', CAST(0x6F9C0000 AS SmallDateTime), 1, N'516 Le Van Sy', N'Nha Trang', N'CNTT', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV021', N'Le Huu Chi432', CAST(0x9FAF0000 AS SmallDateTime), 1, N'236 Vo Thi Sau', N'Long An', N'AV', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV022', N'Vo Thanh Cong', CAST(0x6E8D0000 AS SmallDateTime), 1, N'B8 Cx 155 To Hien Thanh', N'Nha Trang', N'CNTT', 0)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV023', N'43124', CAST(0x9F720000 AS SmallDateTime), 0, N'12432', N'3214', N'CNTT', NULL)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV024', N'Nguy?n H?ng Phú', CAST(0x81420000 AS SmallDateTime), 0, N'207', N'HCM', N'CNTT', NULL)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV025', N'Nguyen Van A', CAST(0x9F540000 AS SmallDateTime), 0, N'321321', N'321321', N'CNTT', NULL)
INSERT [dbo].[SINHVIEN] ([MaSV], [TenSV], [NgaySinh], [GioiTinh], [DiaChi], [Tinh], [MaKhoa], [HocBong]) VALUES (N'SV026', N'353', CAST(0x9FAF0000 AS SmallDateTime), 0, N'542343254', N'2542354', N'CNTT', NULL)
/****** Object:  Table [dbo].[KHOA]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KHOA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KHOA](
	[MaKhoa] [varchar](5) NOT NULL,
	[TenKhoa] [varchar](50) NULL,
	[SoCBGD] [smallint] NULL,
 CONSTRAINT [p_KH] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[KHOA] ([MaKhoa], [TenKhoa], [SoCBGD]) VALUES (N'AV', N'Anh van', 17)
INSERT [dbo].[KHOA] ([MaKhoa], [TenKhoa], [SoCBGD]) VALUES (N'CNTT', N'Cong nghe thong tin', 26)
INSERT [dbo].[KHOA] ([MaKhoa], [TenKhoa], [SoCBGD]) VALUES (N'TR', N'Triet hoc', 14)
/****** Object:  Table [dbo].[KETQUA]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KETQUA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KETQUA](
	[MaSV] [varchar](5) NOT NULL,
	[MaMH] [varchar](5) NOT NULL,
	[LanThi] [varchar](1) NOT NULL,
	[Diem] [smallint] NULL,
 CONSTRAINT [p_KQ] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaMH] ASC,
	[LanThi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV002', N'DT', N'1', 4)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV003', N'DT', N'2', 5)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV004', N'CTDL', N'1', 6)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV005', N'CTDL', N'1', 9)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV006', N'DT', N'1', 7)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV007', N'CTDL', N'1', 7)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV008', N'DT', N'1', 9)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV009', N'CTDL', N'1', 8)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [LanThi], [Diem]) VALUES (N'SV010', N'CSDL', N'1', 8)
/****** Object:  Table [dbo].[Users]    Script Date: 04/12/2011 18:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[HoTen] [nchar](30) NULL,
	[MaNhom] [nvarchar](10) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[Users] ([Username], [Password], [HoTen], [MaNhom]) VALUES (N'admin', N'202cb962ac59075b964b07152d234b70', N'Nguyễn Hồng Phú               ', N'N001')
INSERT [dbo].[Users] ([Username], [Password], [HoTen], [MaNhom]) VALUES (N'hongphu', N'202cb962ac59075b964b07152d234b70', N'Nguyễn Hồng Phú               ', N'N002')
/****** Object:  StoredProcedure [dbo].[sp_updateSinhVien]    Script Date: 04/12/2011 18:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_updateSinhVien]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[sp_updateSinhVien]
	@masv_old as nvarchar(20),
	@masv_new as nvarchar(20)
AS
BEGIN
	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = ''temp_MaSV'')
	DROP TABLE temp_MaSV
	-- tao bang tam ket qua
		SELECT * INTO temp_MaSV
		from KETQUA
		WHERE MaSV = @masv_old 
	-- xoa sinh vien trong ket qua
		DELETE FROM KETQUA WHERE MaSV = @masv_old
	-- sua masv trong sinhvien
		UPDATE SINHVIEN SET MaSV = @masv_new 
		WHERE MaSV = @masv_old
	-- sua masv moi trong bang ta,
		UPDATE temp_MaSV SET MaSV = @masv_new 
	-- them vao ket qua bang tam do
		INSERT INTO KETQUA SELECT * FROM temp_MaSV

END;' 
END
GO
/****** Object:  ForeignKey [f_KQ_MH]    Script Date: 04/12/2011 18:07:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[f_KQ_MH]') AND parent_object_id = OBJECT_ID(N'[dbo].[KETQUA]'))
ALTER TABLE [dbo].[KETQUA]  WITH CHECK ADD  CONSTRAINT [f_KQ_MH] FOREIGN KEY([MaMH])
REFERENCES [dbo].[MONHOC] ([MaMH])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[f_KQ_MH]') AND parent_object_id = OBJECT_ID(N'[dbo].[KETQUA]'))
ALTER TABLE [dbo].[KETQUA] CHECK CONSTRAINT [f_KQ_MH]
GO
/****** Object:  ForeignKey [FK_Users_NhomNguoiDung]    Script Date: 04/12/2011 18:07:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_NhomNguoiDung]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_NhomNguoiDung] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[NhomNguoiDung] ([MaNhom])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_NhomNguoiDung]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_NhomNguoiDung]
GO
