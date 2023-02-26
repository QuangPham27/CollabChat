using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Database.DataAccess
{
    public partial class CollabChatDatabaseContext : DbContext
    {
        public CollabChatDatabaseContext()
        {
        }

        public CollabChatDatabaseContext(DbContextOptions<CollabChatDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlockedUser> BlockedUsers { get; set; }
        public virtual DbSet<ChatRoom> ChatRooms { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Inbox> Inboxes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("CollabChatDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockedUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BlockedUserId })
                    .HasName("PK_BlockedUsers_1");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BlockedUserId).HasColumnName("blocked_user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.HasOne(d => d.BlockedUserNavigation)
                    .WithMany(p => p.BlockedUserBlockedUserNavigations)
                    .HasForeignKey(d => d.BlockedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockedUsers_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BlockedUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockedUsers_User");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.ToTable("ChatRoom");

                entity.Property(e => e.ChatRoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("chat_room_id");

                entity.Property(e => e.ChatRoomName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("chat_room_name");

                entity.Property(e => e.ChatRoomPictureUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("chat_room_picture_url");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ChatRooms)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatRoom_User");

                entity.HasMany(d => d.Messages)
                    .WithMany(p => p.ChatRooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChatRoomMessage",
                        l => l.HasOne<Message>().WithMany().HasForeignKey("MessageId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ChatRoomMessage_Message"),
                        r => r.HasOne<ChatRoom>().WithMany().HasForeignKey("ChatRoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ChatRoomMessage_ChatRoom"),
                        j =>
                        {
                            j.HasKey("ChatRoomId", "MessageId");

                            j.ToTable("ChatRoomMessage");

                            j.IndexerProperty<int>("ChatRoomId").HasColumnName("chat_room_id");

                            j.IndexerProperty<int>("MessageId").HasColumnName("message_id");
                        });

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.ChatRoomsNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChatRoomUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ChatRoomUsers_User"),
                        r => r.HasOne<ChatRoom>().WithMany().HasForeignKey("ChatRoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ChatRoomUsers_ChatRoom"),
                        j =>
                        {
                            j.HasKey("ChatRoomId", "UserId").HasName("PK_ChatRoomUsers_1");

                            j.ToTable("ChatRoomUsers");

                            j.IndexerProperty<int>("ChatRoomId").HasColumnName("chat_room_id");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        });
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.Property(e => e.FileId)
                    .ValueGeneratedNever()
                    .HasColumnName("file_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.MessageUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("message_url");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_File_Message");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.ToTable("Friendship");

                entity.Property(e => e.FriendshipId)
                    .ValueGeneratedNever()
                    .HasColumnName("friendship_id");

                entity.Property(e => e.AcceptedDate)
                    .HasColumnType("date")
                    .HasColumnName("accepted_date");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.IsAccepted).HasColumnName("is_accepted");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.FriendshipReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friendship_User1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.FriendshipSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friendship_User");
            });

            modelBuilder.Entity<Inbox>(entity =>
            {
                entity.ToTable("Inbox");

                entity.Property(e => e.InboxId)
                    .ValueGeneratedNever()
                    .HasColumnName("inbox_id");

                entity.Property(e => e.User1Id).HasColumnName("user1_id");

                entity.Property(e => e.User2Id).HasColumnName("user2_id");

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.InboxUser1s)
                    .HasForeignKey(d => d.User1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inbox_User");

                entity.HasOne(d => d.User2)
                    .WithMany(p => p.InboxUser2s)
                    .HasForeignKey(d => d.User2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inbox_User1");

                entity.HasMany(d => d.Messages)
                    .WithMany(p => p.Inboxes)
                    .UsingEntity<Dictionary<string, object>>(
                        "InboxMessage",
                        l => l.HasOne<Message>().WithMany().HasForeignKey("MessageId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InboxMessage_Message"),
                        r => r.HasOne<Inbox>().WithMany().HasForeignKey("InboxId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InboxMessage_Inbox"),
                        j =>
                        {
                            j.HasKey("InboxId", "MessageId");

                            j.ToTable("InboxMessage");

                            j.IndexerProperty<int>("InboxId").HasColumnName("inbox_id");

                            j.IndexerProperty<int>("MessageId").HasColumnName("message_id");
                        });
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId)
                    .ValueGeneratedNever()
                    .HasColumnName("message_id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("date")
                    .HasColumnName("timestamp");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(150)
                    .HasColumnName("about_me");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("password_hash");

                entity.Property(e => e.ProfilePictureUrl)
                    .HasMaxLength(50)
                    .HasColumnName("profile_picture_url");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
