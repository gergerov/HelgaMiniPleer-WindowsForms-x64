using Pleer.Data;
using Pleer.Singleton;
using System.ComponentModel;
using System.Xml.Linq;


namespace Pleer.UI;

public class clHPlaylistUI
{
    public static int CONTWITH = 430;
    public static int BTNWIDTH = 32;

    public FMain fmain;
    public FlowLayoutPanel LayPlaylists;
    public SortedList<string, TableLayoutPanel> OLayPlaylists;
    public ImageList HIMList20;
    public ToolTip tt;
    public TextBox SearchBox;

    public clHPlaylistAudioUI? PlaylistAudioUI;
    public clHAudioUI? SelectAudioUI;

    public clHPlaylistUI(FMain fmain, FlowLayoutPanel LayPlaylists, ImageList HIMList20,
                            ToolTip tt, TextBox searchbox)
    {
        this.fmain = fmain;
        this.LayPlaylists = LayPlaylists;
        this.HIMList20 = HIMList20;
        this.tt = tt;
        this.SearchBox = searchbox;
        this.OLayPlaylists = new SortedList<string, TableLayoutPanel>();
        
        ButtonRefreshModeList();
    }

    public Label AddHPlaylistLabel(HPlaylist playlist)
    {
        var name = new Label();
        tt.SetToolTip(name, playlist.Name);
        name.AllowDrop = true;
        name.TextAlign = ContentAlignment.MiddleLeft;
        name.Text = playlist.Name;
        name.Font = new Font("Segoe UI", 9);
        name.Dock = DockStyle.Fill;
        name.Width = CONTWITH - BTNWIDTH;
        name.Tag = playlist;
        return name;
    }

    public TableLayoutPanel AddHPlaylistPanel(HPlaylist playlist)
    {
        var container = new TableLayoutPanel();
        container.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        container.AllowDrop = false;
        container.Capture = false;
        container.Margin = new Padding(1, 0, 0, 0);
        container.Width = CONTWITH;
        container.Tag = playlist;
        container.ColumnCount = 4;
        container.RowCount = 1;
        container.AutoSize = true;
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, CONTWITH - BTNWIDTH * 3 ));
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        return container;
    }

    public void AddHPlaylist(HPlaylist playlist)
    {
        var container = AddHPlaylistPanel(playlist);
        var name = AddHPlaylistLabel(playlist);
        var btnedit = AddHPlaylistButtonEdit(playlist);
        var btnaudio = AddHPlaylistButtonAudio(playlist);
        var btndelete = AddHPlaylistButtonDelete(playlist);

        container.Controls.Add(btnedit, 1, 0);
        container.Controls.Add(btnaudio, 0, 0);
        container.Controls.Add(name, 2, 0);
        container.Controls.Add(btndelete, 3, 0);

        container.MouseEnter += Container_MouseEnter;
        container.MouseLeave += Container_MouseLeave;

        EventHandler onEnter = (_, __) => Container_MouseEnter(container, EventArgs.Empty);
        EventHandler onLeave = (_, __) => Container_MouseLeave(container, EventArgs.Empty);

        name.MouseEnter += onEnter;
        name.MouseLeave += onLeave;

        LayPlaylists.Controls.Add(container);
        OLayPlaylists.TryAdd(playlist.Name, container);
        fmain.HPlaylist.AddHPlaylist(playlist);
    }

    public Button AddHPlaylistButtonEdit(HPlaylist playlist)
    {
        var btn = new Button();
        tt.SetToolTip(btn, "Редактировать");
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 52;
        btn.Tag = playlist;
        btn.Click += ButtonEdit_Click;
        return btn;
    }

    public Button AddHPlaylistButtonAudio(HPlaylist playlist)
    {
        var btn = new Button();
        tt.SetToolTip(btn, "Список аудио");
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 53;
        btn.Tag = playlist;
        btn.Click += ButtonAudio_Click;
        return btn;
    }
    public Button AddHPlaylistButtonDelete(HPlaylist playlist)
    {
        var btn = new Button();
        tt.SetToolTip(btn, "Удалить");
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 11;
        btn.Tag = playlist;
        btn.AutoSize = true;
        btn.Click += ButtonDelete_Click;
        return btn;
    }

    public TextBox AddHPlaylistTextBox(HPlaylist playlist)
    {
        var tb = new TextBox();
        tb.TextAlign = HorizontalAlignment.Left;
        tb.Text = playlist.Name;
        tb.Font = new Font("Segoe UI", 13);
        tb.Dock = DockStyle.Fill;
        tb.Width = CONTWITH - BTNWIDTH;
        tb.Tag = playlist;
        return tb;
    }

    public Button AddHPlaylistButtonApply(HPlaylist playlist)
    {
        var btnpapply = new Button();
        btnpapply.FlatStyle = FlatStyle.Flat;
        btnpapply.FlatAppearance.BorderSize = 0;
        btnpapply.Size = new Size(BTNWIDTH, BTNWIDTH);
        btnpapply.Text = "";
        btnpapply.ImageList = this.HIMList20;
        btnpapply.ImageIndex = 8;
        btnpapply.Tag = playlist;
        btnpapply.Click += ButtonApply_Click;
        return btnpapply;
    }

    public void SetupLabel(Label lbl)
    {
        if (lbl.Tag != null)
        {
            if (lbl.Tag is HPlaylist pl)
            {
                EventHandler onEnter = (_, __) => Container_MouseEnter(OLayPlaylists[pl.Name], EventArgs.Empty);
                EventHandler onLeave = (_, __) => Container_MouseLeave(OLayPlaylists[pl.Name], EventArgs.Empty);

                lbl.MouseEnter += onEnter;
                lbl.MouseLeave += onLeave;
            }
        }
    }

    public void ButtonRefreshModeView()
    {
        if (PlaylistAudioUI != null)
        {
            fmain.btnRefreshPlaylists_.Click -= fmain.btnRefreshPlaylists_Click;
            fmain.btnRefreshPlaylists_.Click += PlaylistAudioUI.ButtonRefresh_Click;
        }
        SearchBox.Visible = true;
        fmain.btnToPlaylists_.Visible = true;
        fmain.btnAddPlaylist_.Visible = false;
    }

    public void ButtonRefreshModeList()
    {
        if (PlaylistAudioUI != null)
        {
            fmain.btnRefreshPlaylists_.Click += fmain.btnRefreshPlaylists_Click;
            fmain.btnRefreshPlaylists_.Click -= PlaylistAudioUI.ButtonRefresh_Click;
            PlaylistAudioUI.Free();
        }
        LayPlaylists.Controls.Clear();
        OLayPlaylists.Clear();
        PlaylistAudioUI = null;
        SearchBox.Visible = false;
        fmain.btnToPlaylists_.Visible = false;
        fmain.btnAddPlaylist_.Visible = true;
        fmain.btnAddDirToPlaylist_.Visible = false;
    }

    public void ModeView(HPlaylist playlist)
    {
        LayPlaylists.SuspendLayout();

        PlaylistAudioUI?.Free();
        PlaylistAudioUI = null;
        PlaylistAudioUI = new clHPlaylistAudioUI(fmain, LayPlaylists, HIMList20, tt, SearchBox, playlist);

        foreach (var audio in playlist.HAudios.Values)
        {
            PlaylistAudioUI.AddHAudio(audio);
        }

        fmain.btnRefreshPlaylists_.Click -= fmain.btnRefreshPlaylists_Click;
        fmain.btnRefreshPlaylists_.Click += PlaylistAudioUI.ButtonRefresh_Click;
        //fmain.btnAddAudioToPlaylist_.Click += PlaylistAudioUI.ButtonAddAudio_Click;
        fmain.btnAddAudioToPlaylist_.Visible = true;
        fmain.btnAddDirToPlaylist_.Visible = true;
        ButtonRefreshModeView();

        if (SingletonBass.Instance.Audio != null)
        {
            PlaylistAudioUI.SetupButtonsPlay(SingletonBass.Instance.Audio);
        }

        LayPlaylists.ResumeLayout(true);
    }

    private void ButtonApply_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag != null)
            {
                if (btn.Tag is HPlaylist pl)
                {
                    LayPlaylists.SuspendLayout();

                    var tb = OLayPlaylists[pl.Name].Controls.OfType<TextBox>().First();
                    var oldname = pl.Name;
                    var container = OLayPlaylists[oldname];
                    var res = SingletonHPlaylist.Instance.Rename(pl, tb.Text);
                    
                    var name = AddHPlaylistLabel(pl);
                    container.Controls.Remove(tb);
                    container.Controls.Add(name, 2, 0);
                    SetupLabel(name);

                    var btnedit = AddHPlaylistButtonEdit(pl);
                    container.Controls.Remove(btn);
                    container.Controls.Add(btnedit, 1, 0);
                    
                    if (res)
                    {
                        OLayPlaylists.Remove(oldname);
                        OLayPlaylists.Add(pl.Name, container);
                    }
                    else
                    {
                        if (pl.Name != tb.Text)
                        {
                            MessageBox.Show("Плейлист с таким именем уже существует");
                        }
                    }

                    LayPlaylists.ResumeLayout();
                }
            }
        }
    }

    private void ButtonEdit_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag != null)
            {
                if (btn.Tag is HPlaylist pl)
                {
                    LayPlaylists.SuspendLayout();

                    var lbl = OLayPlaylists[pl.Name].Controls.OfType<Label>().First();
                    var name = AddHPlaylistTextBox(pl);

                    OLayPlaylists[pl.Name].Controls.Remove(lbl);
                    OLayPlaylists[pl.Name].Controls.Add(name, 2, 0);

                    var btnapply = AddHPlaylistButtonApply(pl);
                    OLayPlaylists[pl.Name].Controls.Remove(btn);
                    OLayPlaylists[pl.Name].Controls.Add(btnapply, 1, 0);

                    LayPlaylists.ResumeLayout();
                }
            }
        }
    }

    public void ButtonAudio_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag != null)
            {
                if (btn.Tag is HPlaylist pl)
                {
                    LayPlaylists.Controls.Clear();
                    OLayPlaylists.Clear();
                    ModeView(pl);
                }
            }
        }
    }

    private void ButtonDelete_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn.Tag != null)
            {
                if (btn.Tag is HPlaylist pl)
                {
                    LayPlaylists.Controls.Remove(OLayPlaylists[pl.Name]);
                    OLayPlaylists.Remove(pl.Name);
                    SingletonHPlaylist.Instance.RemoveHPlaylist(pl);
                    SingletonHPlaylist.Instance.SaveToDisk();
                }
            }
        }
    }

    private void Container_MouseEnter(object? sender, EventArgs e)
    {
        if (sender is Control control)
        {
            control.BackColor = SystemColors.ControlLight;
        }
    }

    private void Container_MouseLeave(object? sender, EventArgs e)
    {
        if (sender is Control control)
        {
            control.BackColor = Color.White;
        }
    }
}
