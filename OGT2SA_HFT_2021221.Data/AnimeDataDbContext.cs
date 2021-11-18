using Microsoft.EntityFrameworkCore;
using OGT2SA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGT2SA_HFT_2021221.Data
{
    public class AnimeDataDbContext : DbContext
    {
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }
        public AnimeDataDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity
                .HasOne(anime => anime.Studios)
                .WithMany(studios => studios.Animes)
                .HasForeignKey(anime => anime.studio_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Character>(entity =>
            {
                entity
                .HasOne(character => character.Studios)
                .WithMany(studios => studios.Characters)
                .HasForeignKey(character => character.studio_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Character>(entity =>
            {
                entity
                .HasOne(character => character.Animes)
                .WithMany(animes => animes.Characters)
                .HasForeignKey(character => character.anime_id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            //Animes
            Anime eightysix = new Anime() { anime_id = 1, anime_name = "Eighty Six", type = "TV", aired = "2021.04.11", source = "Light Novel", studio_id = 5 };
            Anime angelbeats = new Anime() { anime_id = 2, anime_name = "Angel Beats!", type = "TV", aired = "2010.04.03", source = "Original", studio_id = 3 };
            Anime guiltycrown = new Anime() { anime_id = 3, anime_name = "Guilty Crown", type = "TV", aired = "2011.10.14", source = "Original", studio_id = 7 };
            Anime mushokutensei = new Anime() { anime_id = 4, anime_name = "Mushoku Tensei", type = "TV", aired = "2021.01.11", source = "Light Novel", studio_id = 6 };
            Anime swordartonline = new Anime() { anime_id = 5, anime_name = "Sword Art Online", type = "TV", aired = "2012.07.08", source = "Light Novel", studio_id = 5 };
            Anime killlakillspecials = new Anime() { anime_id = 6, anime_name = "Kill la Kill Specials", type = "Special", aired = "2014.09.03", source = "Original", studio_id = 2 };
            Anime kizumonogatari = new Anime() { anime_id = 7, anime_name = "Kizumonogatari I: Tekketsu-hen", type = "Movie", aired = "2016.0.08", source = "Light Novel", studio_id = 4 };
            Anime carnivalphantasm = new Anime() { anime_id = 8, anime_name = "Carnival Phantasm", type = "OVA", aired = "2011.08.14", source = "Manga", studio_id = 8 };
            Anime angelbeatsspecials = new Anime() { anime_id = 9, anime_name = "Angel Beats! Specials", type = "Special", aired = "2010.12.22", source = "Original", studio_id = 3 };
            Anime mahoukakoukou = new Anime() { anime_id = 10, anime_name = "Mahouka Koukou no Rettousei", type = "TV", aired = "2014.04.06", source = "Light Novel", studio_id = 1 };
            Anime killlakill = new Anime() { anime_id = 11, anime_name = "Kill La Kill", type = "TV", aired = "2013.10.04", source = "Original", studio_id = 2 };
            //Characters
            Character vladilena = new Character() { anime_id = 1, character_id = 1, main_character = "Milizé Vladilena", main_voice = "Hasegawa Ikumi", studio_id = 5, support_character = "Emma Anju", support_voice = "Hayami Saori" };
            Character kanade = new Character() { anime_id = 2, character_id = 2, main_character = "Tachibana Kanade", main_voice = "Hanazawa Kana", studio_id = 3, support_character = "Naoi Ayato", support_voice = "Ogata Megumi" };
            Character kazuto = new Character() { anime_id = 5, character_id = 3, main_character = "Kirigaya Kazuto", main_voice = "Matsuoka Yoshitsugu", studio_id = 5, support_character = "Kayaba Akihiko", support_voice = "Yamadera Kouichi" };
            Character inori = new Character() { anime_id = 3, character_id = 4, main_character = "Yuzuriha Inori", main_voice = "Kayano Ai", studio_id = 7, support_character = "Tsugumi", support_voice = "Taketatsu Ayana" };
            Character koyomi = new Character() { anime_id = 7, character_id = 5, main_character = "Araragi Koyomi", main_voice = "Kamiya Hiroshi", studio_id = 4, support_character = "Oshino Meme", support_voice = "Sakurai Takahiro" };
            Character eris = new Character() { anime_id = 4, character_id = 6, main_character = "Greyrat Eris Boreas", main_voice = "Kakuma Ai", studio_id = 6, support_character = "Greyrat Zenith", support_voice = "Kanemoto Hisako" };
            Character yuzuru = new Character() { anime_id = 9, character_id = 7, main_character = "Otonashi Yuzuru", main_voice = "Kamiya Hiroshi", studio_id = 3, support_character = "Ooyama", support_voice = "Kobayashi Yumiko" };
            Character tatsuya = new Character() { anime_id = 10, character_id = 8, main_character = "Shiba Tatsuya", main_voice = "Nakamura Yuuichi", studio_id = 1, support_character = "Saegusa Mayumi", support_voice = "Hanazawa Kana" };
            Character ryuuko = new Character() { anime_id = 11, character_id = 9, main_character = "Matoi Ryuuko", main_voice = "Koshimizu Ami", studio_id = 2, support_character = "Jakuzure Nonon", support_voice = "Shintani Mayumi" };
            Character rin = new Character() { anime_id = 8, character_id = 10, main_character = "Toosaka Rin", main_voice = "Ueda Kana", studio_id = 8, support_character = "Archer", support_voice = "Suwabe Junichi" };
            Character matoiryuuko = new Character() { anime_id = 6, character_id = 11, main_character = "Matoi Ryuuko", main_voice = "Koshimizu Ami", studio_id = 2, support_character = "Jakuzure Nonon", support_voice = "Shintani Mayumi" };
            //Studios
            Studio madhouse = new Studio() { studio_id = 1, studio_name = "Madhouse", founded = "1972.10.17", founder = "Masao Maruyama", headquarters = "Nakano" };
            Studio trigger = new Studio() { studio_id = 2, studio_name = "Trigger", founded = "2011.08.22", founder = "Hiroyuki Imaishi", headquarters = "Tokyo" };
            Studio paworks = new Studio() { studio_id = 3, studio_name = "P.A. Works", founded = "2000.11.10", founder = "Horikava Kendzsi", headquarters = "Nanto" };
            Studio shaft = new Studio() { studio_id = 4, studio_name = "Shaft", founded = "1975.09.01", founder = "Hiroshi Wakao", headquarters = "Suginami" };
            Studio a1pictures = new Studio() { studio_id = 5, studio_name = "A-1 Pictures", founded = "2005.05.09", founder = "Ivata Mikihiro", headquarters = "Szuginami" };
            Studio studiobind = new Studio() { studio_id = 6, studio_name = "Studio Bind", founded = "2018.11.01", founder = "Toshiya Otomo", headquarters = "Suginami" };
            Studio productiopnsig = new Studio() { studio_id = 7, studio_name = "Productions I.G", founded = "1987.12.15", founder = "Isikava Micuhisza", headquarters = "Kokubundzsi" };
            Studio lerche = new Studio() { studio_id = 8, studio_name = "Lerche", founded = "2011.01.01", founder = "Seiji Kishi", headquarters = "Nerima" };

            modelBuilder.Entity<Anime>().HasData(eightysix, angelbeats, guiltycrown, mushokutensei, swordartonline, killlakillspecials, kizumonogatari, carnivalphantasm, angelbeatsspecials, mahoukakoukou, killlakill );
            modelBuilder.Entity<Character>().HasData(vladilena, kanade, kazuto, inori, koyomi, eris, yuzuru, tatsuya, ryuuko, rin, matoiryuuko);
            modelBuilder.Entity<Studio>().HasData(madhouse, trigger, paworks, shaft, a1pictures, studiobind, productiopnsig, lerche);
        }
        
    }
}
