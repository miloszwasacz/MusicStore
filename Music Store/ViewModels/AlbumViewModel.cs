using Avalonia.Media.Imaging;
using Music_Store.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.ViewModels
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly Album _album;
        private Bitmap? _cover;
        public string Artist => _album.Artist;
        public string Title => _album.Title;
        public Bitmap Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public AlbumViewModel(Album album)
        {
            _album = album;
        }

        public async Task LoadCover()
        {
            await using (var imageStream = await _album.LoadCoverBitmapAsync())
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
            }
        }

        public async Task SaveToDiskAsync()
        {
            await _album.SaveAsync();

            if (Cover != null)
            {
                var bitmap = Cover;
                await Task.Run(() =>
                {
                    using (var fs = _album.SaveCoverBitmapSteam())
                    {
                        bitmap.Save(fs);
                    }
                });
            }
        }
    }
}
