using Pleer.Data;
using Pleer.Singleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pleer.UI;

public class clHDirsUI
{
    public static int CONTWITH = 420;
    public static int BTNWIDTH = 32;

    public FMain fmain;
    public SingletonHDir HDirs;
    public FlowLayoutPanel LayDirs;
    public ImageList HIMList20;
    public ToolTip tt;
    public Button? AddButton;

    public clHDirsUI(FMain fmain, SingletonHDir HDirs, FlowLayoutPanel LayDirs, ImageList HIMList20, ToolTip tt)
    {
        this.fmain = fmain;
        this.HDirs = HDirs;
        this.LayDirs = LayDirs;
        this.HIMList20 = HIMList20;
        this.tt = tt;
    }

    public TableLayoutPanel AddHDirEmpty()
    {
        var container = new TableLayoutPanel();
        container.Margin = new Padding(1, 0, 0, 0);
        container.Width = CONTWITH;
        container.ColumnCount = 3;
        container.RowCount = 1;
        container.AutoSize = true;
        container.Dock = DockStyle.Fill;

        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH*2)); // Для кнопки
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, CONTWITH - BTNWIDTH*2)); // Для пути
        //container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        
        var btn = AddHDirButtonAdd();
        var l = new Label();
        l.TextAlign = ContentAlignment.MiddleLeft;
        l.Text = "Перетащите папку с аудио или добавьте с помощью кнопки..";
        l.Font = new("Segoe UI", 14);
        l.AutoSize = true;
        l.TextAlign = ContentAlignment.MiddleCenter;
        l.Dock = DockStyle.Fill;
        l.Width = CONTWITH - BTNWIDTH - BTNWIDTH;

        container.Controls.Add(l, 1, 1);
        container.Controls.Add(btn, 0, 1);
        return container;
    }

    public Label AddHDirLabel(HDir dir)
    {
        var path = new Label();
        path.TextAlign = ContentAlignment.MiddleLeft;
        path.Text = dir.Path;
        path.Dock = DockStyle.Fill;
        path.Width = CONTWITH - BTNWIDTH - BTNWIDTH;
        path.Tag = dir;
        return path;
    }
    public System.Windows.Forms.Button AddHDirButtonAdd()
    {
        var btn = new System.Windows.Forms.Button();
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH*2, BTNWIDTH*2);
        btn.ImageList = HIMList20;
        btn.ImageIndex = 3;
        btn.Click += fmain.btnAddDir_Click;
        tt.SetToolTip(btn, "Добавить папку");
        return btn;
    }

    public System.Windows.Forms.Button AddHDirButtonDelete(HDir dir)
    {
        var btndel = new System.Windows.Forms.Button();
        btndel.FlatStyle = FlatStyle.Flat;
        btndel.FlatAppearance.BorderSize = 0;
        btndel.Size = new Size(32, 32);
        btndel.Text = "";
        btndel.ImageList = this.HIMList20;
        btndel.ImageIndex = 13;
        btndel.Tag = dir;
        btndel.Click += btnHDirDelete_Click;
        tt.SetToolTip(btndel, "Удалить папку");
        return btndel;
    }

    public System.Windows.Forms.Button AddHDirButtonExplore(HDir dir)
    {
        var btnexp = new System.Windows.Forms.Button();
        btnexp.FlatStyle = FlatStyle.Flat;
        btnexp.FlatAppearance.BorderSize = 0;
        btnexp.Size = new Size(32, 32);
        btnexp.Text = "";
        btnexp.ImageList = this.HIMList20;
        btnexp.ImageIndex = 45;
        btnexp.Tag = dir;
        btnexp.Click += btnHDirExplore_Click;
        tt.SetToolTip(btnexp, "Открыть в проводнике..");
        return btnexp;
    }

    public TableLayoutPanel AddHDirsContainer(HDir dir)
    {
        var container = new TableLayoutPanel();
        container.Margin = new Padding(1, 0, 0, 0);
        container.Width = CONTWITH;
        container.Tag = dir;
        container.ColumnCount = 3;
        container.RowCount = 1;
        container.AutoSize = true;
        return container;
    }

    public virtual void AddHDirs(HDir dir)
    {
        var container = AddHDirsContainer(dir);
        var path = AddHDirLabel(dir);
        var btndel = AddHDirButtonDelete(dir);
        var btnexp = AddHDirButtonExplore(dir);

        container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, CONTWITH - BTNWIDTH - BTNWIDTH)); // Для пути
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки

        container.Controls.Add(path, 0, 1);
        container.Controls.Add(btndel, 2, 1);
        container.Controls.Add(btnexp, 1, 1);

        container.MouseEnter += Container_MouseEnter;
        container.MouseLeave += Container_MouseLeave;

        EventHandler onEnter = (_, __) => Container_MouseEnter(container, EventArgs.Empty);
        EventHandler onLeave = (_, __) => Container_MouseLeave(container, EventArgs.Empty);

        path.MouseEnter += onEnter;
        path.MouseLeave += onLeave;

        btndel.MouseEnter += onEnter;
        btndel.MouseLeave += onLeave;

        btnexp.MouseEnter += onEnter;
        btnexp.MouseLeave += onLeave;

        LayDirs.Controls.Add(container);
    }

    private void btnHDirDelete_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HDir dir)
            {
                HDirs.RemoveHDir(dir);
                LayDirs.Controls.Remove(btn.Parent);
                fmain.UpdateLvHAudios();
                fmain.UpdateLvHDirs();
            }
        }
    }

    private void btnHDirExplore_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HDir dir)
            {
                Process.Start("explorer.exe", $"/select,\"{dir.Path}\"");
            }
        }
    }

    protected void Container_MouseEnter(object? sender, EventArgs e)
    {
        if (sender is Control control)
        {
            control.BackColor = SystemColors.ControlLight;
        }
    }

    protected void Container_MouseLeave(object? sender, EventArgs e)
    {
        if (sender is Control control)
        {
            control.BackColor = Color.White;
        }
    }
}
