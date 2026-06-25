using Pleer.Data;
using Pleer.Singleton;


namespace Pleer.UI;

public class clHPlaylistAudioUI : clHAudioUI
{
    public HPlaylist Playlist;
    public clHPlaylistAudioUI(
        FMain fmain,
        FlowLayoutPanel LayAudios,
        ImageList HIMList20,
        ToolTip tt,
        TextBox searchbox,
        HPlaylist playlist)
        : base(fmain, LayAudios, HIMList20, tt, searchbox)
    {
        this.Playlist = playlist;
        fmain.btnAddDirToPlaylist_.Click += ButtonAddAudioDir_Click;
        fmain.btnAddAudioToPlaylist_.Click += ButtonAddAudio_Click;
    }

    public new void Update()
    {
        LayAudios.SuspendLayout();

        LayAudios.Controls.Clear();
        OLayAudios.Clear();

        foreach (var audio in Playlist.HAudios.Values)
        {
            AddHAudio(audio);
        }
        if (SingletonBass.Instance.Audio != null)
        {
            SetupButtonsPlay(SingletonBass.Instance.Audio);
        }

        LayAudios.ResumeLayout(true);
    }

    public override TableLayoutPanel AddHAudioContainer(HAudio audio)
    {
        var container = base.AddHAudioContainer(audio);
        container.ColumnCount = 3;
        container.ColumnStyles[1].Width = CONTWITH - BTNWIDTH * 2 + 15;
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH));
        return container;
    }

    public override void AddHAudio(HAudio audio)
    {
        base.AddHAudio(audio);
        OLayAudios[audio.Path].Controls.Add(AddHAudioButtonDelete(audio), 2, 0);
    }
    public Button AddHAudioButtonDelete(HAudio audio)
    {
        var btn = new Button();
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 11;
        btn.Tag = audio;
        btn.Click += ButtonDelAudio_Click;
        return btn;
    }

    public void ButtonRefresh_Click(object? sender, EventArgs e)
    {
        Update();
    }

    public void ButtonAddAudio_Click(object? sender, EventArgs e)
    {
        var fselect = new FSelect(fmain, HIMList20, tt, Playlist);
        if (fselect.ShowDialog() == DialogResult.OK)
        {
            var audio = fselect.AudioUISelect?.SelectedAudio;
            if (audio != null)
            {
                AddHAudio(audio);
                Playlist.HAudios.Add(audio.Path, audio);
                SingletonHPlaylist.Instance.SaveToDisk();
            }
        }
    }

    public void ButtonAddAudioDir_Click(object? sender, EventArgs e)
    {
        var fselect = new FSelect(fmain, HIMList20, tt, Playlist, true);
        if (fselect.ShowDialog() == DialogResult.OK)
        {
            fselect.DirsUISelect?.SetResults();
            Update();
        }
    }

    public void ButtonDelAudio_Click(Object? sender, EventArgs e)
    {
        LayAudios.SuspendLayout();
        if (sender != null)
        {
            if (sender is Button btn)
            {
                if (btn.Tag != null)
                {
                    if (btn.Tag is HAudio audio)
                    {
                        var layaudio = OLayAudios[audio.Path];
                        LayAudios.Controls.Remove(layaudio);
                        OLayAudios.Remove(audio.Path);
                        Playlist.HAudios.Remove(audio.Path);
                    }
                }
            }
        }
        SingletonHPlaylist.Instance.SaveToDisk();
        LayAudios.ResumeLayout(true);
    }

    public void Free()
    {
        fmain.btnAddDirToPlaylist_.Click -= ButtonAddAudioDir_Click;
        fmain.btnAddAudioToPlaylist_.Click -= ButtonAddAudio_Click;
    }
}
