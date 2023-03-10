USE [master]
GO
/****** Object:  Database [CollabChatDatabase]    Script Date: 3/4/2023 1:13:56 PM ******/
CREATE DATABASE [CollabChatDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CollabChatDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CollabChatDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CollabChatDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CollabChatDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CollabChatDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CollabChatDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CollabChatDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CollabChatDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CollabChatDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CollabChatDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CollabChatDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CollabChatDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [CollabChatDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CollabChatDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CollabChatDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CollabChatDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CollabChatDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CollabChatDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CollabChatDatabase] SET QUERY_STORE = OFF
GO
USE [CollabChatDatabase]
GO
/****** Object:  Table [dbo].[BlockedUsers]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlockedUsers](
	[user_id] [int] NOT NULL,
	[blocked_user_id] [int] NOT NULL,
	[created_at] [date] NOT NULL,
 CONSTRAINT [PK_BlockedUsers_1] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[blocked_user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[chat_room_id] [int] IDENTITY(1,1) NOT NULL,
	[creator_id] [int] NOT NULL,
	[chat_room_name] [nvarchar](50) NOT NULL,
	[chat_room_picture_url] [nvarchar](50) NOT NULL,
	[created_at] [date] NOT NULL,
 CONSTRAINT [PK_ChatRoom] PRIMARY KEY CLUSTERED 
(
	[chat_room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatRoomMessage]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoomMessage](
	[chat_room_id] [int] NOT NULL,
	[message_id] [int] NOT NULL,
 CONSTRAINT [PK_ChatRoomMessage] PRIMARY KEY CLUSTERED 
(
	[chat_room_id] ASC,
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatRoomUsers]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoomUsers](
	[chat_room_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_ChatRoomUsers_1] PRIMARY KEY CLUSTERED 
(
	[chat_room_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[file_id] [int] IDENTITY(1,1) NOT NULL,
	[message_id] [int] NOT NULL,
	[message_url] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friendship]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friendship](
	[friendship_id] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NOT NULL,
	[receiver_id] [int] NOT NULL,
	[is_accepted] [bit] NOT NULL,
	[created_date] [date] NOT NULL,
	[accepted_date] [date] NOT NULL,
 CONSTRAINT [PK_Friendship] PRIMARY KEY CLUSTERED 
(
	[friendship_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inbox]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inbox](
	[inbox_id] [int] IDENTITY(1,1) NOT NULL,
	[user1_id] [int] NOT NULL,
	[user2_id] [int] NOT NULL,
 CONSTRAINT [PK_Inbox] PRIMARY KEY CLUSTERED 
(
	[inbox_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InboxMessage]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboxMessage](
	[inbox_id] [int] NOT NULL,
	[message_id] [int] NOT NULL,
 CONSTRAINT [PK_InboxMessage] PRIMARY KEY CLUSTERED 
(
	[inbox_id] ASC,
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[timestamp] [date] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/4/2023 1:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password_hash] [nvarchar](150) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[about_me] [nvarchar](150) NULL,
	[profile_picture_url] [nvarchar](50) NULL,
	[created_date] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatRoom] ON 

INSERT [dbo].[ChatRoom] ([chat_room_id], [creator_id], [chat_room_name], [chat_room_picture_url], [created_at]) VALUES (1, 1, N'1', N'1', CAST(N'2001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[ChatRoom] OFF
GO
INSERT [dbo].[ChatRoomUsers] ([chat_room_id], [user_id]) VALUES (1, 1)
INSERT [dbo].[ChatRoomUsers] ([chat_room_id], [user_id]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [email], [password_hash], [username], [about_me], [profile_picture_url], [created_date]) VALUES (1, N'1', N'1', N'1', N'1', N'1', CAST(N'2001-01-01' AS Date))
INSERT [dbo].[User] ([user_id], [email], [password_hash], [username], [about_me], [profile_picture_url], [created_date]) VALUES (2, N'2', N'2', N'2', N'2', N'2', CAST(N'2002-02-02' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[BlockedUsers]  WITH CHECK ADD  CONSTRAINT [FK_BlockedUsers_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[BlockedUsers] CHECK CONSTRAINT [FK_BlockedUsers_User]
GO
ALTER TABLE [dbo].[BlockedUsers]  WITH CHECK ADD  CONSTRAINT [FK_BlockedUsers_User1] FOREIGN KEY([blocked_user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[BlockedUsers] CHECK CONSTRAINT [FK_BlockedUsers_User1]
GO
ALTER TABLE [dbo].[ChatRoom]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoom_User] FOREIGN KEY([creator_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[ChatRoom] CHECK CONSTRAINT [FK_ChatRoom_User]
GO
ALTER TABLE [dbo].[ChatRoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomMessage_ChatRoom] FOREIGN KEY([chat_room_id])
REFERENCES [dbo].[ChatRoom] ([chat_room_id])
GO
ALTER TABLE [dbo].[ChatRoomMessage] CHECK CONSTRAINT [FK_ChatRoomMessage_ChatRoom]
GO
ALTER TABLE [dbo].[ChatRoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomMessage_Message] FOREIGN KEY([message_id])
REFERENCES [dbo].[Message] ([message_id])
GO
ALTER TABLE [dbo].[ChatRoomMessage] CHECK CONSTRAINT [FK_ChatRoomMessage_Message]
GO
ALTER TABLE [dbo].[ChatRoomUsers]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomUsers_ChatRoom] FOREIGN KEY([chat_room_id])
REFERENCES [dbo].[ChatRoom] ([chat_room_id])
GO
ALTER TABLE [dbo].[ChatRoomUsers] CHECK CONSTRAINT [FK_ChatRoomUsers_ChatRoom]
GO
ALTER TABLE [dbo].[ChatRoomUsers]  WITH CHECK ADD  CONSTRAINT [FK_ChatRoomUsers_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[ChatRoomUsers] CHECK CONSTRAINT [FK_ChatRoomUsers_User]
GO
ALTER TABLE [dbo].[File]  WITH CHECK ADD  CONSTRAINT [FK_File_Message] FOREIGN KEY([message_id])
REFERENCES [dbo].[Message] ([message_id])
GO
ALTER TABLE [dbo].[File] CHECK CONSTRAINT [FK_File_Message]
GO
ALTER TABLE [dbo].[Friendship]  WITH CHECK ADD  CONSTRAINT [FK_Friendship_User] FOREIGN KEY([sender_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friendship] CHECK CONSTRAINT [FK_Friendship_User]
GO
ALTER TABLE [dbo].[Friendship]  WITH CHECK ADD  CONSTRAINT [FK_Friendship_User1] FOREIGN KEY([receiver_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friendship] CHECK CONSTRAINT [FK_Friendship_User1]
GO
ALTER TABLE [dbo].[Inbox]  WITH CHECK ADD  CONSTRAINT [FK_Inbox_User] FOREIGN KEY([user1_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Inbox] CHECK CONSTRAINT [FK_Inbox_User]
GO
ALTER TABLE [dbo].[Inbox]  WITH CHECK ADD  CONSTRAINT [FK_Inbox_User1] FOREIGN KEY([user2_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Inbox] CHECK CONSTRAINT [FK_Inbox_User1]
GO
ALTER TABLE [dbo].[InboxMessage]  WITH CHECK ADD  CONSTRAINT [FK_InboxMessage_Inbox] FOREIGN KEY([inbox_id])
REFERENCES [dbo].[Inbox] ([inbox_id])
GO
ALTER TABLE [dbo].[InboxMessage] CHECK CONSTRAINT [FK_InboxMessage_Inbox]
GO
ALTER TABLE [dbo].[InboxMessage]  WITH CHECK ADD  CONSTRAINT [FK_InboxMessage_Message] FOREIGN KEY([message_id])
REFERENCES [dbo].[Message] ([message_id])
GO
ALTER TABLE [dbo].[InboxMessage] CHECK CONSTRAINT [FK_InboxMessage_Message]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([sender_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
USE [master]
GO
ALTER DATABASE [CollabChatDatabase] SET  READ_WRITE 
GO
