using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.PlaylistSongTest
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private readonly PlaylistService _service;


        public PlaylistServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _service = new(_mockPlaylistValidationService);
        }

        [Fact]
        public void AddSongPlayList_AddSong_ReturnTrue()
        {
            //Arrange
            
            List<Song> songs = new List<Song>();

            Playlist playlist = new() { Songs = songs, MaxSongs = 3};

            Song song1 = new() { Title = "título1", Artist = "artista1" };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1).Returns(true);

            //Act
            bool result = _service.AddSongToPlaylist(playlist, song1);
            
            //Assert
            result.Should().BeTrue();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, song1);
            playlist.Should().NotBeNull();
            songs.Should().NotBeEmpty();
            
        }

        [Fact]
        public void AddSongPlayList_AddSong_ReturnNull()
        {
            //Arrange

            List<Song> songs = new List<Song>();

            Playlist playlist = new() { Songs = songs, MaxSongs = 3 };


            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, null).Returns(true);

            //Act
            bool result = _service.AddSongToPlaylist(playlist, null);

            //Assert
            result.Should().BeTrue();
            playlist.Should().NotBeNull();
            songs[0].Should().BeNull();

        }

        [Fact]
        public void AddSongPlayList_AddSong_ReturnFalse()
        {
            //Arrange

            List<Song> songs = new List<Song>();

            Playlist playlist = new() { Songs = songs, MaxSongs = 0 };

            Song song1 = new() { Title = "título1", Artist = "artista1" };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1).Returns(false);

            //Act
            bool result = _service.AddSongToPlaylist(playlist, song1);

            //Assert
            result.Should().BeFalse();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, song1);
            

        }

        [Fact]
        public void AddSongPlayList_AddSongs_ReturnSongsAdded()
        {
            //Arrange

            List<Song> songs = new List<Song>();

            Playlist playlist = new() { Songs = songs, MaxSongs = 7 }; 

            Song song1 = new() { Title = "título1", Artist = "artista1" };
            Song song2 = new() { Title = "título2", Artist = "artista2" };
            Song song3 = new() { Title = "título3", Artist = "artista3" };

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);


            //Act
            var songsToAdd = songs.ToList();
            _service.AddSongsToPlaylist(playlist, songsToAdd);

            //Assert
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
            playlist.Songs.Should().Contain(song3);
            playlist.Songs.Should().HaveCount(6);

        }

        [Fact]
        public void AddSongPlayList_AddSongs_ReturnASongNotAdded()
        {
            //Arrange

            List<Song> songs = new List<Song>();

            Playlist playlist = new() { Songs = songs, MaxSongs = 7 };

            Song song1 = new() { Title = "título1", Artist = "artista1" };
            Song song2 = new() { Title = "título2", Artist = "artista2" };
            Song song3 = new() { Title = "título3", Artist = "artista3" };

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1).Returns(true);
            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song2).Returns(true);
            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3).Returns(false);


            //Act
            var songsToAdd = songs.ToList();
            _service.AddSongsToPlaylist(playlist, songsToAdd);

            //Assert
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
            playlist.Songs.Should().HaveCount(5);

        }



    }
}
