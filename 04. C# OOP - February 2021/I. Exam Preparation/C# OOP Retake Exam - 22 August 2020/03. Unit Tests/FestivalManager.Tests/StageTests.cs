using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using System;
    using System.Linq;
    
    using NUnit.Framework;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
        }

        [Test]
        public void AddPerformer_ThrowsException_WhenPerformerIsNull()
        {
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformer_ThrowsException_WhenPerformerAgeIsInvalid()
        {
            Performer performer = new Performer("Ivan", "Ivanov", 17);

            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer), "You can only add performers that are at least 18.");
        }

        [Test]
        public void AddPerformer_AddsPerformer()
        {
            Performer performer = new Performer("Ivan", "Ivanov", 18);

            this.stage.AddPerformer(performer);

            Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddSong_ThrowsException_WhenSongIsNull()
        {
            Song song = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddSong_ThrowsException_WhenDurationIsInvalid()
        {
            TimeSpan time = new TimeSpan(0);

            Song song = new Song("Macarena", time);

            Assert.Throws<ArgumentException>(() => this.stage.AddSong(song), "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void AddSongToPerformer_ThrowsException_WhenSongOrPerformerIsNull()
        {
            this.AddSong_ThrowsException_WhenSongIsNull();
            this.AddPerformer_ThrowsException_WhenPerformerIsNull();
        }

        [Test]
        public void AddSongToPerformer_AddsTheSongToThePerformersSongList()
        {
            Performer performer = new Performer("Ivan", "Ivanov", 18);
            Song song = new Song("Macarena", new TimeSpan(0, 10, 10));

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            string result = this.stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.That(performer.SongList.Contains(song));
            Assert.That(result, Is.EqualTo($"{song} will be performed by {performer}"));
        }

        [Test]
        public void Play_SongsCount()
        {
            Performer performer = new Performer("Ivan", "Ivanov", 18);
            Song song1 = new Song("Macarena", new TimeSpan(0, 10, 10));
            Song song2 = new Song("Party time", new TimeSpan(0, 10, 12));

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song1);
            this.stage.AddSong(song2);

            this.stage.AddSongToPerformer(song1.Name, performer.FullName);
            this.stage.AddSongToPerformer(song2.Name, performer.FullName);

            int songsCount = this.stage.Performers.Sum(p => p.SongList.Count());

            Assert.That(songsCount, Is.EqualTo(2));
            Assert.That(this.stage.Play(), Is.EqualTo($"{this.stage.Performers.Count} performers played {songsCount} songs"));
        }
    }
}