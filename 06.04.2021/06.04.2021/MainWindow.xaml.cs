using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace _06._04._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Track> Tracks { get; set; }
        private bool _isPlaying;
        private readonly RelayCommand _playCommand;
        public bool isPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                OnPropertyChanged("isPlaying");
            }
        }
        public ICommand PlayCommand
        {
            get
            {
                return _playCommand ?? new RelayCommand((x) =>
                {
                    var buttonType = x.ToString();

                    if (null != buttonType)
                    {
                        if (buttonType.Contains("Play"))
                        {
                            isPlaying = false;
                        }
                        else if (buttonType.Contains("Stop"))
                        {
                            isPlaying = true;
                        }
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ReadTracks()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Data/Playlist.xml");
            foreach (XmlElement xmlElement in xDoc.DocumentElement)
            {
                Tracks.Add(new Track
                {
                    Name = xmlElement.ChildNodes[0].InnerText,
                    Author = xmlElement.ChildNodes[1].InnerText,
                    Album = xmlElement.ChildNodes[2].InnerText
                });
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Tracks = new ObservableCollection<Track>();
            ReadTracks();
            DataContext = this;

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0)
            };
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan))
            {
                pbStatus.Minimum = 0;
                sStatus.Minimum = 0;
                pbStatus.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sStatus.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
                pbStatus.Value = mePlayer.Position.TotalSeconds;
                tbStatus.Text = $"{new DateTime().AddSeconds(mePlayer.Position.TotalSeconds):mm:ss}/{new DateTime().AddSeconds(mePlayer.NaturalDuration.TimeSpan.TotalSeconds):mm:ss}";
            }
        }

        private void TimerChanged(object sender, RoutedEventArgs e)
        {
            mePlayer.Position = TimeSpan.FromSeconds(((Slider)sender).Value);
        }

        private void SkipClick(object sender, RoutedEventArgs e)
        {
            if (lvPlaylist.SelectedIndex == Tracks.Count - 1)
                lvPlaylist.SelectedIndex = 0;
            else
                lvPlaylist.SelectedIndex++;
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (lvPlaylist.SelectedIndex <= 0)
                lvPlaylist.SelectedIndex = Tracks.Count - 1;
            else
                lvPlaylist.SelectedIndex--;
        }

        private void SelectTrack(object sender, RoutedEventArgs e)
        {
            Track track = (Track)((ListView)sender).SelectedItem;

            ibAlbum.ImageSource = new BitmapImage(new Uri($"Images/Music/{track.Name}.jpg", UriKind.Relative));
            tbName.Text = track.Name;
            tbAuthor.Text = track.Author;
            tbalbum.Text = track.Album;
            mePlayer.Source = new Uri($"Music/{track.Name}.mp3", UriKind.Relative);
        }

        private void ShufflePlaylist(object sender, RoutedEventArgs e)
        {
            Tracks = new ObservableCollection<Track>(Tracks.OrderBy(i => Guid.NewGuid()).ToList());
            lvPlaylist.GetBindingExpression(ItemsControl.ItemsSourceProperty)
                      .UpdateTarget();
            DataContext = this;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {

            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
