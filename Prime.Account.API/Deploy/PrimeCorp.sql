USE [PrimeCorp]
GO
/****** Object:  Table [dbo].[BusinessEntity]    Script Date: 12/03/2021 10:53:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessEntity](
	[BusinessEntityID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK__Business__88984337ADB7C42A] PRIMARY KEY CLUSTERED 
(
	[BusinessEntityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/03/2021 10:53:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[BusinessEntityID] [bigint] NOT NULL,
	[Title] [nvarchar](3) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Suffix] [nvarchar](10) NULL,
	[Age] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonAddress]    Script Date: 12/03/2021 10:53:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAddress](
	[BusinessEntityID] [bigint] NOT NULL,
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](60) NOT NULL,
	[AddressLine2] [nvarchar](60) NULL,
	[City] [nvarchar](30) NOT NULL,
	[PostalCode] [nvarchar](15) NOT NULL,
	[CountryRegionCode] [nvarchar](3) NOT NULL,
	[AddressTypeID] [int] NOT NULL,
 CONSTRAINT [PK_PersonAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonAddressType]    Script Date: 12/03/2021 10:53:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAddressType](
	[AddressTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersonAddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonCountryRegion]    Script Date: 12/03/2021 10:53:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCountryRegion](
	[CountryRegionCode] [nvarchar](3) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersonCountryRegion] PRIMARY KEY CLUSTERED 
(
	[CountryRegionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusinessEntity] ON 
GO
INSERT [dbo].[BusinessEntity] ([BusinessEntityID], [CreatedOn], [Username], [Password]) VALUES (4, CAST(N'2020-06-03T17:52:23.897' AS DateTime), N'rvluzuriaga', N'UQn/TJyZlYkZjM7TAg4GSg==')
GO
INSERT [dbo].[BusinessEntity] ([BusinessEntityID], [CreatedOn], [Username], [Password]) VALUES (5, CAST(N'2020-06-10T21:07:21.653' AS DateTime), N'ddelacruz', N'UQn/TJyZlYkZjM7TAg4GSg==')
GO
INSERT [dbo].[BusinessEntity] ([BusinessEntityID], [CreatedOn], [Username], [Password]) VALUES (6, CAST(N'2021-03-05T17:04:00.243' AS DateTime), N'admin', N'+dqLYwN8LslKA5ibqLm20Q==')
GO
SET IDENTITY_INSERT [dbo].[BusinessEntity] OFF
GO
INSERT [dbo].[Person] ([BusinessEntityID], [Title], [FirstName], [MiddleName], [LastName], [Suffix], [Age]) VALUES (4, N'Mr', N'Ralf Von', N'Regalado', N'Luzuriaga', NULL, 25)
GO
INSERT [dbo].[Person] ([BusinessEntityID], [Title], [FirstName], [MiddleName], [LastName], [Suffix], [Age]) VALUES (5, N'Mr', N'Danny', N'', N'Dela Cruz', N'Jr', 28)
GO
SET IDENTITY_INSERT [dbo].[PersonAddress] ON 
GO
INSERT [dbo].[PersonAddress] ([BusinessEntityID], [AddressID], [AddressLine1], [AddressLine2], [City], [PostalCode], [CountryRegionCode], [AddressTypeID]) VALUES (4, 1, N'Ayala Triangle', NULL, N'Makati City', N'1407', N'PH', 5)
GO
INSERT [dbo].[PersonAddress] ([BusinessEntityID], [AddressID], [AddressLine1], [AddressLine2], [City], [PostalCode], [CountryRegionCode], [AddressTypeID]) VALUES (5, 2, N'Tabayog St.', NULL, N'Mandaluyong City', N'1408', N'PH', 5)
GO
SET IDENTITY_INSERT [dbo].[PersonAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonAddressType] ON 
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (1, N'Archive')
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (2, N'Billing')
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (3, N'Home')
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (4, N'Main Office')
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (5, N'Primary')
GO
INSERT [dbo].[PersonAddressType] ([AddressTypeID], [Name]) VALUES (6, N'Shipping')
GO
SET IDENTITY_INSERT [dbo].[PersonAddressType] OFF
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AD', N'Andorra')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AE', N'United Arab Emirates')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AF', N'Afghanistan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AG', N'Antigua and Barbuda')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AI', N'Anguilla')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AL', N'Albania')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AM', N'Armenia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AN', N'Netherlands Antilles')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AO', N'Angola')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AQ', N'Antarctica')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AR', N'Argentina')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AS', N'American Samoa')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AT', N'Austria')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AU', N'Australia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AW', N'Aruba')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'AZ', N'Azerbaijan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BA', N'Bosnia and Herzegovina')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BB', N'Barbados')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BD', N'Bangladesh')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BE', N'Belgium')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BF', N'Burkina Faso')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BG', N'Bulgaria')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BH', N'Bahrain')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BI', N'Burundi')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BJ', N'Benin')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BM', N'Bermuda')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BN', N'Brunei')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BO', N'Bolivia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BR', N'Brazil')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BS', N'Bahamas, The')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BT', N'Bhutan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BV', N'Bouvet Island')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BW', N'Botswana')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BY', N'Belarus')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'BZ', N'Belize')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CA', N'Canada')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CC', N'Cocos (Keeling) Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CD', N'Congo (DRC)')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CF', N'Central African Republic')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CG', N'Congo')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CH', N'Switzerland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CI', N'Côte d''Ivoire')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CK', N'Cook Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CL', N'Chile')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CM', N'Cameroon')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CN', N'China')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CO', N'Colombia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CR', N'Costa Rica')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CS', N'Serbia and Montenegro')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CU', N'Cuba')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CV', N'Cape Verde')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CX', N'Christmas Island')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CY', N'Cyprus')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'CZ', N'Czech Republic')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DE', N'Germany')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DJ', N'Djibouti')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DK', N'Denmark')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DM', N'Dominica')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DO', N'Dominican Republic')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'DZ', N'Algeria')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'EC', N'Ecuador')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'EE', N'Estonia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'EG', N'Egypt')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ER', N'Eritrea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ES', N'Spain')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ET', N'Ethiopia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FI', N'Finland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FJ', N'Fiji Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FK', N'Falkland Islands (Islas Malvinas)')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FM', N'Micronesia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FO', N'Faroe Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'FR', N'France')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GA', N'Gabon')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GB', N'United Kingdom')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GD', N'Grenada')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GE', N'Georgia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GF', N'French Guiana')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GH', N'Ghana')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GI', N'Gibraltar')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GL', N'Greenland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GM', N'Gambia, The')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GN', N'Guinea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GP', N'Guadeloupe')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GQ', N'Equatorial Guinea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GR', N'Greece')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GS', N'South Georgia and the South Sandwich Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GT', N'Guatemala')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GU', N'Guam')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GW', N'Guinea-Bissau')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'GY', N'Guyana')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HK', N'Hong Kong SAR')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HM', N'Heard Island and McDonald Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HN', N'Honduras')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HR', N'Croatia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HT', N'Haiti')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'HU', N'Hungary')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ID', N'Indonesia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IE', N'Ireland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IL', N'Israel')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IN', N'India')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IO', N'British Indian Ocean Territory')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IQ', N'Iraq')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IR', N'Iran')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IS', N'Iceland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'IT', N'Italy')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'JM', N'Jamaica')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'JO', N'Jordan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'JP', N'Japan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KE', N'Kenya')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KG', N'Kyrgyzstan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KH', N'Cambodia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KI', N'Kiribati')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KM', N'Comoros')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KN', N'Saint Kitts and Nevis')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KP', N'North Korea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KR', N'Korea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KW', N'Kuwait')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KY', N'Cayman Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'KZ', N'Kazakhstan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LA', N'Laos')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LB', N'Lebanon')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LC', N'Saint Lucia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LI', N'Liechtenstein')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LK', N'Sri Lanka')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LR', N'Liberia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LS', N'Lesotho')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LT', N'Lithuania')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LU', N'Luxembourg')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LV', N'Latvia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'LY', N'Libya')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MA', N'Morocco')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MC', N'Monaco')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MD', N'Moldova')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MG', N'Madagascar')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MH', N'Marshall Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MK', N'Macedonia, Former Yugoslav Republic of')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ML', N'Mali')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MM', N'Myanmar')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MN', N'Mongolia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MO', N'Macao SAR')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MP', N'Northern Mariana Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MQ', N'Martinique')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MR', N'Mauritania')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MS', N'Montserrat')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MT', N'Malta')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MU', N'Mauritius')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MV', N'Maldives')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MW', N'Malawi')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MX', N'Mexico')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MY', N'Malaysia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'MZ', N'Mozambique')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NA', N'Namibia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NC', N'New Caledonia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NE', N'Niger')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NF', N'Norfolk Island')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NG', N'Nigeria')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NI', N'Nicaragua')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NL', N'Netherlands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NO', N'Norway')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NP', N'Nepal')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NR', N'Nauru')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NU', N'Niue')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'NZ', N'New Zealand')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'OM', N'Oman')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PA', N'Panama')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PE', N'Peru')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PF', N'French Polynesia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PG', N'Papua New Guinea')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PH', N'Philippines')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PK', N'Pakistan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PL', N'Poland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PM', N'Saint Pierre and Miquelon')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PN', N'Pitcairn Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PR', N'Puerto Rico')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PS', N'Palestinian Authority')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PT', N'Portugal')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PW', N'Palau')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'PY', N'Paraguay')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'QA', N'Qatar')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'RE', N'Réunion')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'RO', N'Romania')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'RU', N'Russia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'RW', N'Rwanda')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SA', N'Saudi Arabia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SB', N'Solomon Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SC', N'Seychelles')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SD', N'Sudan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SE', N'Sweden')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SG', N'Singapore')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SH', N'Saint Helena')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SI', N'Slovenia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SJ', N'Svalbard and Jan Mayen')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SK', N'Slovakia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SL', N'Sierra Leone')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SM', N'San Marino')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SN', N'Senegal')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SO', N'Somalia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SR', N'Suriname')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ST', N'São Tomé and Príncipe')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SV', N'El Salvador')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SY', N'Syria')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'SZ', N'Swaziland')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TC', N'Turks and Caicos Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TD', N'Chad')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TF', N'French Southern and Antarctic Lands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TG', N'Togo')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TH', N'Thailand')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TJ', N'Tajikistan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TK', N'Tokelau')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TL', N'Timor-Leste')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TM', N'Turkmenistan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TN', N'Tunisia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TO', N'Tonga')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TR', N'Turkey')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TT', N'Trinidad and Tobago')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TV', N'Tuvalu')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TW', N'Taiwan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'TZ', N'Tanzania')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'UA', N'Ukraine')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'UG', N'Uganda')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'UM', N'U.S. Minor Outlying Islands')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'US', N'United States')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'UY', N'Uruguay')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'UZ', N'Uzbekistan')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VA', N'Vatican City')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VC', N'Saint Vincent and the Grenadine')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VE', N'Venezuela')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VG', N'Virgin Islands, British')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VI', N'Virgin Islands, U.S.')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VN', N'Vietnam')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'VU', N'Vanuatu')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'WF', N'Wallis and Futuna')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'WS', N'Samoa')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'YE', N'Yemen')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'YT', N'Mayotte')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ZA', N'South Africa')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ZM', N'Zambia')
GO
INSERT [dbo].[PersonCountryRegion] ([CountryRegionCode], [Name]) VALUES (N'ZW', N'Zimbabwe')
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_BusinessEntity] FOREIGN KEY([BusinessEntityID])
REFERENCES [dbo].[BusinessEntity] ([BusinessEntityID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_BusinessEntity]
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAddress_BusinessEntity] FOREIGN KEY([BusinessEntityID])
REFERENCES [dbo].[BusinessEntity] ([BusinessEntityID])
GO
ALTER TABLE [dbo].[PersonAddress] CHECK CONSTRAINT [FK_PersonAddress_BusinessEntity]
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAddress_PersonAddressType] FOREIGN KEY([AddressTypeID])
REFERENCES [dbo].[PersonAddressType] ([AddressTypeID])
GO
ALTER TABLE [dbo].[PersonAddress] CHECK CONSTRAINT [FK_PersonAddress_PersonAddressType]
GO
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAddress_PersonCountryRegion] FOREIGN KEY([CountryRegionCode])
REFERENCES [dbo].[PersonCountryRegion] ([CountryRegionCode])
GO
ALTER TABLE [dbo].[PersonAddress] CHECK CONSTRAINT [FK_PersonAddress_PersonCountryRegion]
GO
