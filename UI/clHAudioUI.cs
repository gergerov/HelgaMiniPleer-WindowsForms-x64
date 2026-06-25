using Microsoft.VisualBasic.Devices;
using Pleer.Data;
using Pleer.Singleton;


namespace Pleer.UI;

public class clHAudioUI
{
    public static int CONTWITH = 400;
    public static int BTNWIDTH = 32;

    public FMain fmain;
    public FlowLayoutPanel LayAudios;
    public ImageList HIMList20;
    public ToolTip tt;
    public clHAudioUIDragAndDrop dd;

    public TextBox SearchBox;
    public System.Windows.Forms.Timer? SearchBoxTimer;

    public Button? AudioButton;
    public TableLayoutPanel? AudioPanel;
    public SortedList<string, TableLayoutPanel> OLayAudios;

    public clHAudioUI(FMain fmain, FlowLayoutPanel LayAudios, ImageList HIMList20,
                        ToolTip tt, TextBox searchbox)
    {
        this.fmain = fmain;
        this.LayAudios = LayAudios;
        this.HIMList20 = HIMList20;
        this.tt = tt;
        this.dd = new clHAudioUIDragAndDrop(LayAudios);

        this.SearchBox = searchbox;
        this.SearchBox.TextChanged += SearchBox_TextChanged;
        this.SearchBoxTimer = new();

        this.OLayAudios = [];
    }

    public void Update()
    {
        LayAudios.SuspendLayout();

        LayAudios.Controls.Clear();
        OLayAudios.Clear();
        SingletonHAudio.Instance.Update();
        foreach (HAudio audio in SingletonHAudio.Instance.OHAudios.Values)
        {
            AddHAudio(audio);
        }
        if (SingletonBass.Instance.Audio != null)
        {
            SetupButtonsPlay(SingletonBass.Instance.Audio);
        }

        LayAudios.ResumeLayout();
    }

    public void SetAudioPanel(TableLayoutPanel panel)
    {
        AudioPanel?.BackColor = Color.White;
        AudioPanel = panel;
        AudioPanel.BackColor = Color.Aqua;
    }

    public void TrySelectLayAudio(HAudio audio)
    {
        TableLayoutPanel? l;
        OLayAudios.TryGetValue(audio.Path, out l);
        l?.Select();
    }

    public void SetHAudioButtonPlay(Button btn)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 21;
        btn.Click -= btnHAudioPause_Click;
        btn.Click += btnHAudioPlay_Click;
    }

    public void SetHAudioButtonPause(Button btn)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Size = new Size(BTNWIDTH, BTNWIDTH);
        btn.Text = "";
        btn.ImageList = this.HIMList20;
        btn.ImageIndex = 34;
        btn.Click -= btnHAudioPlay_Click;
        btn.Click += btnHAudioPause_Click;
    }

    public Button AddHAudioButtonPlay(HAudio audio)
    {
        var btnplay = new Button();
        btnplay.FlatStyle = FlatStyle.Flat;
        btnplay.FlatAppearance.BorderSize = 0;
        btnplay.Size = new Size(BTNWIDTH, BTNWIDTH);
        btnplay.Text = "";
        btnplay.ImageList = this.HIMList20;
        btnplay.ImageIndex = 21;
        btnplay.Tag = audio;
        btnplay.Click += btnHAudioPlay_Click;
        btnplay.Name = "btnplay_" + audio.Name;
        return btnplay;
    }


    public virtual TableLayoutPanel AddHAudioContainer(HAudio audio)
    {
        var container = new TableLayoutPanel();
        container.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        container.AllowDrop = false;
        container.Capture = false;
        container.Margin = new Padding(1, 0, 0, 0);
        container.Width = CONTWITH;
        container.Tag = audio;
        container.ColumnCount = 2;
        container.RowCount = 1;
        container.AutoSize = true;

        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, BTNWIDTH)); // Для кнопки
        container.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, CONTWITH - BTNWIDTH)); // Для пути

        return container;
    }

    public virtual void AddHAudio(HAudio audio)
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

        var btnplay = AddHAudioButtonPlay(audio);
        if (audio.Path == SingletonBass.Instance.Audio?.Path)
        {
            SetHAudioButtonPause(btnplay);
            SingletonBass.Instance.Audio = audio;
        }

        container.Controls.Add(btnplay, 0, 0);
        container.Controls.Add(path, 1, 0);

        container.MouseEnter += Container_MouseEnter;
        container.MouseLeave += Container_MouseLeave;

        EventHandler onEnter = (_, __) => Container_MouseEnter(container, EventArgs.Empty);
        EventHandler onLeave = (_, __) => Container_MouseLeave(container, EventArgs.Empty);

        path.MouseEnter += onEnter;
        path.MouseLeave += onLeave;

        btnplay.MouseEnter += onEnter;
        btnplay.MouseLeave += onLeave;

        LayAudios.Controls.Add(container);
        OLayAudios.Add(audio.Path, container);
    }

    public void SetupButtonPause()
    {
        if (AudioButton != null)
        {
            SetHAudioButtonPlay(AudioButton);
        }
    }

    private void btnHAudioPause_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HAudio audio)
            {
                fmain.PleerUI.StopAudio();
            }
        }
    }

    private void btnHAudioPlay_Click(object? sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (btn?.Tag is HAudio audio)
            {
                fmain.PleerUI.SetAudio(audio);
            }
        }
    }

    public void SetupButtonsPlay(HAudio audio)
    {
        if (AudioButton != null)
        {
            SetHAudioButtonPlay(AudioButton);
        }

        OLayAudios.TryGetValue(audio.Path, out var tlp);
        if (tlp == null)
        {
            return;
        }

        SetAudioPanel(tlp);
        foreach (var button in tlp.Controls.OfType<Button>())
        {
            if (button.Tag != null)
            {
                if (button.Tag is HAudio a)
                {
                    if (a.Path == audio.Path & button.Name == "btnplay_" + a.Name)
                    {
                        SetHAudioButtonPause(button);
                        AudioButton = button;
                    }
                }
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
            if (control == AudioPanel | control.Parent == AudioPanel)
            {
                control.BackColor = Color.Aqua;
            }
        }
    }

    public void SearchBox_TextChanged(object? sender, EventArgs e)
    {
        SearchBoxTimer?.Stop();
        SearchBoxTimer?.Interval = 500;
        SearchBoxTimer?.Tick += SearchBoxTimerTick;
        SearchBoxTimer?.Start();
    }

    public void SearchBoxTimerTick(object? sender, EventArgs e)
    {
        LayAudios.SuspendLayout();

        foreach (Control control in LayAudios.Controls)
        {
            control.Visible = true;
        }

        if (SearchBox.Text != string.Empty)
        {
            foreach (Control control in LayAudios.Controls)
            {
                if (control.Tag is HAudio audio)
                {
                    if (audio.Path.IndexOf(SearchBox.Text, StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        control.Visible = false;
                    }
                }
            }
        }

        LayAudios.ResumeLayout(true);
        SearchBoxTimer?.Stop();
        SearchBoxTimer?.Tick -= SearchBoxTimerTick;
    }
}
