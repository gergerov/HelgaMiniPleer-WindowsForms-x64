using Microsoft.VisualBasic.Devices;
using Pleer.Data;
using Pleer.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleer.UI;

public class clHDirsUISelect : clHDirsUI
{
    public FSelect fselect;
    public HDir? SelectedDir;
    public clHDirsUISelect(FMain fmain, SingletonHDir HDirs, FlowLayoutPanel LayDirs,
                            ImageList HIMList20, ToolTip tt, FSelect fselect) :
        base(fmain, HDirs, LayDirs, HIMList20, tt)
    {
        this.fselect = fselect;
        Update();
    }

    public void Update()
    {
        LayDirs.SuspendLayout();
        LayDirs.Controls.Clear();
        foreach (HDir dir in HDirs.HDirs.Values)
        {
            AddHDirs(dir);
        }
        LayDirs.ResumeLayout(true);
    }

    public Button AddHDirsButtonSelect(HDir dir)
    {
        var btn = new System.Windows.Forms.Button();
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(32, 32);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 8;
        btn.Tag = dir;
        btn.Click += btnHDirSelect_Click;
        tt.SetToolTip(btn, "Выбрать папку");
        return btn;
    }

    public override void AddHDirs(HDir dir)
    {
        var container = AddHDirsContainer(dir);
        var path = AddHDirLabel(dir);
        var btnselect = AddHDirsButtonSelect(dir);

        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, CONTWITH - BTNWIDTH)); // Для пути
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки

        container.Controls.Add(path, 0, 1);
        container.Controls.Add(btnselect, 1, 1);

        container.MouseEnter += base.Container_MouseEnter;
        container.MouseLeave += base.Container_MouseLeave;

        EventHandler onEnter = (_, __) => Container_MouseEnter(container, EventArgs.Empty);
        EventHandler onLeave = (_, __) => Container_MouseLeave(container, EventArgs.Empty);

        path.MouseEnter += onEnter;
        path.MouseLeave += onLeave;

        btnselect.MouseEnter += onEnter;
        btnselect.MouseLeave += onLeave;

        LayDirs.Controls.Add(container);
    }

    private void btnHDirSelect_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HDir dir)
            {
                SelectedDir = dir;
            }
        }
        fselect.DialogResult = DialogResult.OK;
    }

    public void SetResults()
    {
        var exists = new List<string>();
        foreach (var audio in fselect.Playlist.HAudios.Values)
        {
            exists.Add(audio.Path);
        }

        if (SelectedDir != null)
        {
            foreach (var e in HAudioExtension.Exes())
            {
                var files = Directory.EnumerateFiles(SelectedDir.Path, "*" + e).ToList();
                foreach (var f in files)
                {
                    if (!exists.Contains(f))
                    {
                        var audio = new HAudio(Path.GetFileName(f), f, f);
                        fselect.Playlist.HAudios.Add(audio.Path, audio);
                    }
                }
            }
        }
        SingletonHPlaylist.Instance.SaveToDisk();
    }
}
