using Microsoft.VisualBasic.Devices;
using Pleer.Data;
using Pleer.Singleton;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Pleer.UI;

public class clHAudioUISelect: clHAudioUI
{
    public FSelect fselect;
    public HPlaylist Playlist;
    public SingletonHAudio HAudios;
    public HAudio? SelectedAudio;

    public clHAudioUISelect(FMain fmain, FlowLayoutPanel LayAudios, ImageList HIMList20,
                        ToolTip tt, TextBox searchbox, HPlaylist playlist, FSelect fselect) 
                            : base(fmain, LayAudios, HIMList20, tt, searchbox)
    {
        this.fmain = fmain;
        this.fselect = fselect;
        this.LayAudios = LayAudios;
        this.HIMList20 = HIMList20;
        this.tt = tt;
        this.dd = new clHAudioUIDragAndDrop(LayAudios);
        this.Playlist = playlist;
        this.HAudios = SingletonHAudio.Instance;

        this.SearchBox = searchbox;
        this.SearchBox.TextChanged += SearchBox_TextChanged;
        this.SearchBoxTimer = new();

        this.OLayAudios = [];

        Update();
    }
    public Button AddHAudioButtonSelect(HAudio audio)
    {
        var btn = new Button();
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 8;
        btn.Tag = audio;
        btn.Click += btnHAudioSelect_Click;
        btn.Name = "btnselect_" + audio.Name;
        return btn;
    }

    public override void AddHAudio(HAudio audio)
    {
        var container = AddHAudioContainer(audio);

        var path = new Label();
        tt.SetToolTip(path, audio.Path);
        path.AllowDrop = true;
        path.TextAlign = ContentAlignment.MiddleLeft;
        path.Text = audio.Name;
        path.Dock = DockStyle.Fill;
        path.Width = CONTWITH - BTNWIDTH;
        path.Tag = audio;

        var btn = AddHAudioButtonSelect(audio);

        container.Controls.Add(btn, 0, 0);
        container.Controls.Add(path, 1, 0);

        container.MouseEnter += Container_MouseEnter;
        container.MouseLeave += Container_MouseLeave;

        EventHandler onEnter = (_, __) => Container_MouseEnter(container, EventArgs.Empty);
        EventHandler onLeave = (_, __) => Container_MouseLeave(container, EventArgs.Empty);

        path.MouseEnter += onEnter;
        path.MouseLeave += onLeave;

        btn.MouseEnter += onEnter;
        btn.MouseLeave += onLeave;

        LayAudios.Controls.Add(container);
        OLayAudios.Add(audio.Path, container);
    }

    public new void Update()
    {
        LayAudios.SuspendLayout();

        LayAudios.Controls.Clear();
        OLayAudios.Clear();
        HAudios.LoadFromDirs();

        var paths = new List<string>();
        foreach (var audio in Playlist.HAudios.Values)
        {
            paths.Add(audio.Path);
        }

        foreach (HAudio audio in HAudios.HAudios.Values)
        {
            if (!paths.Contains(audio.Path))
            {
                AddHAudio(audio);
            }
        }

        if (SingletonBass.Instance.Audio != null)
        {
            SetupButtonsPlay(SingletonBass.Instance.Audio);
        }

        LayAudios.ResumeLayout();
    }

    public void btnHAudioSelect_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HAudio audio)
            {
                SelectedAudio = audio;
            }
        }
        fselect.DialogResult = DialogResult.OK;
    }
}
