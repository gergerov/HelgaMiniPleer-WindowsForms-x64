using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using Pleer.Data;
using Pleer.Ext;
using Pleer.Singleton;
using Pleer.UI;


namespace Pleer;

public partial class FMain : Form
{
    public static string companyName = "gergerovsoft";
    public static string appName = "Helga-mini";
    public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public static string appFolderPath = Path.Combine(appDataPath, companyName, appName);
    public static string IcoPath = "Icons/application-v1.ico";

    public SingletonHDir HDirs;
    public SingletonHAudio HAudios;
    public SingletonHPlaylist HPlaylist;

    public clHDirsUI HDirsUI;
    public clHAudioUI HAudioUI;
    public clPleerUI PleerUI;
    public clHPlaylistUI PlaylistUI;

    public Button btnToPlaylists_;
    public Button btnRefreshPlaylists_;
    public Button btnAddPlaylist_;
    public Button btnAddAudioToPlaylist_;
    public Button btnAddDirToPlaylist_;
    public FMain()
    {
        InitializeComponent();
        if (!Path.Exists(appFolderPath))
        {
            Directory.CreateDirectory(appFolderPath);
        }

        this.AllowDrop = true;
        this.DragEnter += FMain_DragEnter;
        this.DragDrop += FMain_DragDrop;

        this.btnToPlaylists_ = this.btnToPlaylists;
        this.btnRefreshPlaylists_ = this.btnRefreshPlaylists;
        this.btnAddPlaylist_ = this.btnAddPlaylist;
        this.btnAddAudioToPlaylist_ = this.btnAddAudioToPlaylist;
        this.btnAddDirToPlaylist_ = this.btnAddDirToPlaylist;

        HDirs = SingletonHDir.Instance;
        HAudios = SingletonHAudio.Instance;
        HPlaylist = SingletonHPlaylist.Instance;

        HDirsUI = new(this, HDirs, LayDirs, HIMList20, ttCom);
        HAudioUI = new(this, LayFiles, HIMList20, ttCom, tbSearchFiles);
        PlaylistUI = new(this, LayPlaylists, HIMList20, ttCom, tbSearchAudio);
        PleerUI = new(this, tbPleerDescription, ttCom, tbPositionSec,
                        tbPleerCommonTime, tbPleerCurrentTime,
                        btnMix, btnLoop, btnPrev, btnPlay, btnNext,
                        tbVolume);


        typeof(Panel).GetProperty(
            "DoubleBuffered", 
            System.Reflection.BindingFlags.NonPublic | 
            System.Reflection.BindingFlags.Instance
            )?.SetValue(LayPlaylists, true, null);
    }
    public void btnOff_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnDirs_Click(object sender, EventArgs e)
    {
        tcMain.SelectedIndex = 0;
        btnDirs.BackColor = Color.SkyBlue;
        btnPlaylists.BackColor = Color.White;
        btnFiles.BackColor = Color.White;
    }

    private void btnPlaylists_Click(object sender, EventArgs e)
    {
        tcMain.SelectedIndex = 1;
        btnDirs.BackColor = Color.White;
        btnPlaylists.BackColor = Color.SkyBlue;
        btnFiles.BackColor = Color.White;
    }

    private void btnFiles_Click(object sender, EventArgs e)
    {
        tcMain.SelectedIndex = 2;
        btnFiles.Focus();
        if (SingletonBass.Instance.Audio != null)
        {
            HAudioUI.TrySelectLayAudio(SingletonBass.Instance.Audio);
        }

        btnDirs.BackColor = Color.White;
        btnPlaylists.BackColor = Color.White;
        btnFiles.BackColor = Color.SkyBlue;
    }

    public void btnAddDir_Click(object? sender, EventArgs e)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        using (FolderBrowserDialog folderDlg = new FolderBrowserDialog())
        {
            folderDlg.SelectedPath = path;
            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedPath = folderDlg.SelectedPath;
                DirectoryInfo dirInfo = new DirectoryInfo(selectedPath);
                HDir dir = new(dirInfo.Name, selectedPath);
                if (HDirs.AddHDir(dir))
                {
                    UpdateLvHDirs();
                    UpdateLvHAudios();
                }
            }
        }
    }

    private void FMain_Load(object sender, EventArgs e)
    {
        UpdateLvHDirs();
        UpdateLvHAudios();
        UpdateLvHPlaylists();
        LayFiles.AutoScroll = true;
        LayDirs.AutoScroll = true;
        LayPlaylists.AutoScroll = true;

        var a = SingletonBass.Instance;
        this.Icon = new Icon(FMain.IcoPath);
    }

    public void UpdateLvHDirs()
    {
        LayDirs.SuspendLayout();

        LayDirs.Controls.Clear();
        foreach (HDir dir in HDirs.HDirs.Values)
        {
            HDirsUI.AddHDirs(dir);
        }

        if (HDirs.HDirs.Values.Count < 1)
        {
            LayDirs.Controls.Add(HDirsUI.AddHDirEmpty());
        }

        LayDirs.ResumeLayout();
    }
    public void UpdateLvHAudios()
    {
        HAudioUI.Update();
    }

    public void UpdateLvHPlaylists()
    {
        LayPlaylists.SuspendLayout();

        LayPlaylists.Controls.Clear();
        PlaylistUI.OLayPlaylists.Clear();
        HPlaylist.LoadFromDisk();
        foreach (HPlaylist playlist in HPlaylist.HPlaylists.Values)
        {
            PlaylistUI.AddHPlaylist(playlist);
        }

        LayPlaylists.ResumeLayout();
    }

    private void btnRefreshDir_Click(object sender, EventArgs e)
    {
        UpdateLvHDirs();
        UpdateLvHAudios();
    }

    private void btnRefreshFiles_Click(object sender, EventArgs e)
    {
        UpdateLvHDirs();
        UpdateLvHAudios();
    }

    private void tbPositionSec_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            PleerUI.SetIsTrackBarTimerStopped(true);

            var trackBar = (System.Windows.Forms.TrackBar)sender;
            int thumbWidth = SystemInformation.HorizontalScrollBarThumbWidth;
            int clickableZoneWidth = trackBar.ClientSize.Width - thumbWidth;
            if (clickableZoneWidth <= 0)
                clickableZoneWidth = 0;
            float clickOffsetFromCenter = e.X - (thumbWidth / 2f);
            clickOffsetFromCenter = Math.Max(0, Math.Min(clickOffsetFromCenter, clickableZoneWidth));
            double proportion = clickOffsetFromCenter / (double)clickableZoneWidth;
            long newValue = trackBar.Minimum + (long)(proportion * (trackBar.Maximum - trackBar.Minimum));
            trackBar.Value = (int)newValue;

            SingletonBass.Instance.SetPositionSec(tbPositionSec.Value / 100);
        }
    }

    private void tbPositionSec_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            PleerUI.SetIsTrackBarTimerStopped(false);
        }
    }

    private void tbPositionSec_Scroll(object sender, EventArgs e)
    {
        SingletonBass.Instance.SetPositionSec(tbPositionSec.Value / 100);
    }

    private void FMain_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
    private void FMain_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data == null) { return; }

        var data = e.Data.GetData(DataFormats.FileDrop);
        var files = data as string[];

        if (files != null)
        {
            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    var pdir = Path.GetDirectoryName(file);
                    var idir = new DirectoryInfo(pdir);
                    var dir = new HDir(idir.Name, idir.FullName);
                    SingletonHDir.Instance.AddHDir(dir);

                    var ifile = new FileInfo(Path.GetFullPath(file));
                    if (HAudioExtension.Exes().Contains(ifile.Extension.ToLower()))
                    {
                        if (SingletonHAudio.Instance.HAudios.ContainsKey(ifile.Name))
                        {
                            PleerUI.SetAudio(SingletonHAudio.Instance.HAudios[ifile.Name]);
                        }
                        else
                        {
                            var audio = new HAudio(ifile.Name, ifile.FullName, ifile.FullName);
                            SingletonHAudio.Instance.AddHAudio(audio);
                            PleerUI.SetAudio(audio);
                        }
                    }
                }

                else if (Directory.Exists(file))
                {
                    var idir = new DirectoryInfo(file);
                    var dir = new HDir(idir.Name, idir.FullName);
                    SingletonHDir.Instance.AddHDir(dir);
                }
                UpdateLvHDirs();
                UpdateLvHAudios();
            }
        }
    }

    private void btnAddPlaylist_Click(object sender, EventArgs e)
    {
        string PlaylistName = Interaction.InputBox(
            "Введите название плейлиста",
            "Заголовок плейлиста",
            "Плейлист",
            this.Location.X,
            this.Location.Y + this.Height / 3
        );

        if (string.IsNullOrWhiteSpace(PlaylistName))
        {
            return;
        }

        if (SingletonHPlaylist.Instance.HPlaylists.ContainsKey(PlaylistName))
        {
            MessageBox.Show("Плейлист с таким именем уже существует!");
            return;
        }

        var playlist = new HPlaylist(PlaylistName, []);
        PlaylistUI.AddHPlaylist(playlist);
    }

    public void btnRefreshPlaylists_Click(object? sender, EventArgs e)
    {
        UpdateLvHPlaylists();
    }

    private void btnToPlaylists_Click(object sender, EventArgs e)
    {
        PlaylistUI.ButtonRefreshModeList();
        /*if (PlaylistUI.PlaylistAudioUI != null)
        {
            btnAddAudioToPlaylist_.Click -= PlaylistUI.PlaylistAudioUI.ButtonAddAudio_Click;
        }*/
        btnAddAudioToPlaylist_.Visible = false;
        UpdateLvHPlaylists();
    }
}
