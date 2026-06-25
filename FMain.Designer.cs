namespace Pleer;

partial class FMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        ImageList HIList32;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
        LayMain = new FlowLayoutPanel();
        btnDirs = new Button();
        btnPlaylists = new Button();
        btnFiles = new Button();
        btnSave = new Button();
        btnOff = new Button();
        tcMain = new TabControl();
        tpDirs = new TabPage();
        LayDirs = new FlowLayoutPanel();
        LayHDirsPanel = new FlowLayoutPanel();
        btnAddDir = new Button();
        btnRefreshDir = new Button();
        tpPlaylists = new TabPage();
        tbSearchAudio = new TextBox();
        LayPlaylists = new FlowLayoutPanel();
        LayHPlaylistsPanel = new FlowLayoutPanel();
        btnToPlaylists = new Button();
        btnAddPlaylist = new Button();
        btnRefreshPlaylists = new Button();
        btnAddAudioToPlaylist = new Button();
        btnAddDirToPlaylist = new Button();
        tpFiles = new TabPage();
        tbSearchFiles = new TextBox();
        LayFilesPanel = new FlowLayoutPanel();
        btnRefreshFiles = new Button();
        LayFiles = new FlowLayoutPanel();
        LayPleerDescription = new TableLayoutPanel();
        tbPleerDescription = new TextBox();
        LayPleerAudioRoad = new TableLayoutPanel();
        tbPleerCurrentTime = new TextBox();
        tbPleerCommonTime = new TextBox();
        tbPositionSec = new TrackBar();
        LayPleerButtons = new TableLayoutPanel();
        btnLoop = new Button();
        HIMList23 = new ImageList(components);
        btnMix = new Button();
        btnPrev = new Button();
        btnPlay = new Button();
        btnNext = new Button();
        tbVolume = new TrackBar();
        HIMList20 = new ImageList(components);
        HIMList26 = new ImageList(components);
        ttCom = new ToolTip(components);
        HIList32 = new ImageList(components);
        LayMain.SuspendLayout();
        tcMain.SuspendLayout();
        tpDirs.SuspendLayout();
        LayHDirsPanel.SuspendLayout();
        tpPlaylists.SuspendLayout();
        LayHPlaylistsPanel.SuspendLayout();
        tpFiles.SuspendLayout();
        LayFilesPanel.SuspendLayout();
        LayPleerDescription.SuspendLayout();
        LayPleerAudioRoad.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tbPositionSec).BeginInit();
        LayPleerButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tbVolume).BeginInit();
        SuspendLayout();
        // 
        // HIList32
        // 
        HIList32.ColorDepth = ColorDepth.Depth32Bit;
        HIList32.ImageStream = (ImageListStreamer)resources.GetObject("HIList32.ImageStream");
        HIList32.TransparentColor = Color.Transparent;
        HIList32.Images.SetKeyName(0, "add-128-V1.ico");
        HIList32.Images.SetKeyName(1, "add-512-V1.ico");
        HIList32.Images.SetKeyName(2, "add-dir-48-v1.ico");
        HIList32.Images.SetKeyName(3, "addfolder-512-V1.ico");
        HIList32.Images.SetKeyName(4, "add-music-128-V1.ico");
        HIList32.Images.SetKeyName(5, "add-music-512-V1.ico");
        HIList32.Images.SetKeyName(6, "add-music-512-V2.ico");
        HIList32.Images.SetKeyName(7, "application-v1.ico");
        HIList32.Images.SetKeyName(8, "apply-256-V1.ico");
        HIList32.Images.SetKeyName(9, "back-128-V1.ico");
        HIList32.Images.SetKeyName(10, "close-256-v1.ico");
        HIList32.Images.SetKeyName(11, "delete-512-v1.ico");
        HIList32.Images.SetKeyName(12, "delete-512-v2.ico");
        HIList32.Images.SetKeyName(13, "deletefolder-256-V1.ico");
        HIList32.Images.SetKeyName(14, "dirs-64-v1.ico");
        HIList32.Images.SetKeyName(15, "dirs-256-v2.ico");
        HIList32.Images.SetKeyName(16, "files-64-v1.ico");
        HIList32.Images.SetKeyName(17, "hide-256-v1.ico");
        HIList32.Images.SetKeyName(18, "home-96-v1.ico");
        HIList32.Images.SetKeyName(19, "musicall-512-v1.ico");
        HIList32.Images.SetKeyName(20, "offservice-256-V1.ico");
        HIList32.Images.SetKeyName(21, "play-512-V1.ico");
        HIList32.Images.SetKeyName(22, "play-512-V2.ico");
        HIList32.Images.SetKeyName(23, "play-512-V3.ico");
        HIList32.Images.SetKeyName(24, "playlists-64-v1.ico");
        HIList32.Images.SetKeyName(25, "playlists-256-v2.ico");
        HIList32.Images.SetKeyName(26, "restart-128-V2.ico");
        HIList32.Images.SetKeyName(27, "restart-512-V1.ico");
        HIList32.Images.SetKeyName(28, "restart-512-v3.ico");
        HIList32.Images.SetKeyName(29, "restart-512-V4.ico");
        HIList32.Images.SetKeyName(30, "restart-512-V5.ico");
        HIList32.Images.SetKeyName(31, "save-96-v1.ico");
        HIList32.Images.SetKeyName(32, "startapp-512-V1.ico");
        HIList32.Images.SetKeyName(33, "stop-512-V1.ico");
        HIList32.Images.SetKeyName(34, "stop-512-V2.ico");
        HIList32.Images.SetKeyName(35, "tools-512-V1.ico");
        HIList32.Images.SetKeyName(36, "tools-512-V2.ico");
        HIList32.Images.SetKeyName(37, "tray-main-1-32.png");
        HIList32.Images.SetKeyName(38, "tray-main-1-32-v2.png");
        HIList32.Images.SetKeyName(39, "volume-128-V4.ico");
        HIList32.Images.SetKeyName(40, "volume-512-v1.ico");
        HIList32.Images.SetKeyName(41, "volume-512-v2.ico");
        HIList32.Images.SetKeyName(42, "volume-512-v2.png");
        HIList32.Images.SetKeyName(43, "volume-512-v3.ico");
        HIList32.Images.SetKeyName(44, "next-png-v1.png");
        HIList32.Images.SetKeyName(45, "next-512-v3.ico");
        HIList32.Images.SetKeyName(46, "prev-512-v3.ico");
        HIList32.Images.SetKeyName(47, "loop-all-v1.ico");
        HIList32.Images.SetKeyName(48, "loop-no-v1.ico");
        HIList32.Images.SetKeyName(49, "loop-one-v1.png");
        HIList32.Images.SetKeyName(50, "mix-512-v1.ico");
        HIList32.Images.SetKeyName(51, "mixon-512-v1.png");
        // 
        // LayMain
        // 
        resources.ApplyResources(LayMain, "LayMain");
        LayMain.BackColor = SystemColors.ButtonHighlight;
        LayMain.Controls.Add(btnDirs);
        LayMain.Controls.Add(btnPlaylists);
        LayMain.Controls.Add(btnFiles);
        LayMain.Controls.Add(btnSave);
        LayMain.Controls.Add(btnOff);
        LayMain.Controls.Add(tcMain);
        LayMain.Controls.Add(LayPleerDescription);
        LayMain.Controls.Add(LayPleerAudioRoad);
        LayMain.Controls.Add(LayPleerButtons);
        LayMain.Name = "LayMain";
        ttCom.SetToolTip(LayMain, resources.GetString("LayMain.ToolTip"));
        // 
        // btnDirs
        // 
        resources.ApplyResources(btnDirs, "btnDirs");
        btnDirs.FlatAppearance.BorderSize = 0;
        btnDirs.ImageList = HIList32;
        btnDirs.Name = "btnDirs";
        ttCom.SetToolTip(btnDirs, resources.GetString("btnDirs.ToolTip"));
        btnDirs.UseVisualStyleBackColor = true;
        btnDirs.Click += btnDirs_Click;
        // 
        // btnPlaylists
        // 
        resources.ApplyResources(btnPlaylists, "btnPlaylists");
        btnPlaylists.FlatAppearance.BorderSize = 0;
        btnPlaylists.ImageList = HIList32;
        btnPlaylists.Name = "btnPlaylists";
        ttCom.SetToolTip(btnPlaylists, resources.GetString("btnPlaylists.ToolTip"));
        btnPlaylists.UseVisualStyleBackColor = true;
        btnPlaylists.Click += btnPlaylists_Click;
        // 
        // btnFiles
        // 
        resources.ApplyResources(btnFiles, "btnFiles");
        btnFiles.FlatAppearance.BorderSize = 0;
        btnFiles.ImageList = HIList32;
        btnFiles.Name = "btnFiles";
        ttCom.SetToolTip(btnFiles, resources.GetString("btnFiles.ToolTip"));
        btnFiles.UseVisualStyleBackColor = true;
        btnFiles.Click += btnFiles_Click;
        // 
        // btnSave
        // 
        resources.ApplyResources(btnSave, "btnSave");
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.ImageList = HIList32;
        btnSave.Name = "btnSave";
        ttCom.SetToolTip(btnSave, resources.GetString("btnSave.ToolTip"));
        btnSave.UseVisualStyleBackColor = true;
        // 
        // btnOff
        // 
        resources.ApplyResources(btnOff, "btnOff");
        btnOff.FlatAppearance.BorderSize = 0;
        btnOff.ImageList = HIList32;
        btnOff.Name = "btnOff";
        ttCom.SetToolTip(btnOff, resources.GetString("btnOff.ToolTip"));
        btnOff.UseVisualStyleBackColor = true;
        btnOff.Click += btnOff_Click;
        // 
        // tcMain
        // 
        resources.ApplyResources(tcMain, "tcMain");
        tcMain.Controls.Add(tpDirs);
        tcMain.Controls.Add(tpPlaylists);
        tcMain.Controls.Add(tpFiles);
        tcMain.Name = "tcMain";
        tcMain.SelectedIndex = 0;
        ttCom.SetToolTip(tcMain, resources.GetString("tcMain.ToolTip"));
        // 
        // tpDirs
        // 
        resources.ApplyResources(tpDirs, "tpDirs");
        tpDirs.BackColor = SystemColors.ButtonHighlight;
        tpDirs.Controls.Add(LayDirs);
        tpDirs.Controls.Add(LayHDirsPanel);
        tpDirs.Name = "tpDirs";
        ttCom.SetToolTip(tpDirs, resources.GetString("tpDirs.ToolTip"));
        // 
        // LayDirs
        // 
        resources.ApplyResources(LayDirs, "LayDirs");
        LayDirs.BackColor = SystemColors.ButtonHighlight;
        LayDirs.Name = "LayDirs";
        ttCom.SetToolTip(LayDirs, resources.GetString("LayDirs.ToolTip"));
        // 
        // LayHDirsPanel
        // 
        resources.ApplyResources(LayHDirsPanel, "LayHDirsPanel");
        LayHDirsPanel.BackColor = SystemColors.ButtonHighlight;
        LayHDirsPanel.Controls.Add(btnAddDir);
        LayHDirsPanel.Controls.Add(btnRefreshDir);
        LayHDirsPanel.Name = "LayHDirsPanel";
        ttCom.SetToolTip(LayHDirsPanel, resources.GetString("LayHDirsPanel.ToolTip"));
        // 
        // btnAddDir
        // 
        resources.ApplyResources(btnAddDir, "btnAddDir");
        btnAddDir.FlatAppearance.BorderSize = 0;
        btnAddDir.ImageList = HIList32;
        btnAddDir.Name = "btnAddDir";
        ttCom.SetToolTip(btnAddDir, resources.GetString("btnAddDir.ToolTip"));
        btnAddDir.UseVisualStyleBackColor = true;
        btnAddDir.Click += btnAddDir_Click;
        // 
        // btnRefreshDir
        // 
        resources.ApplyResources(btnRefreshDir, "btnRefreshDir");
        btnRefreshDir.FlatAppearance.BorderSize = 0;
        btnRefreshDir.ImageList = HIList32;
        btnRefreshDir.Name = "btnRefreshDir";
        ttCom.SetToolTip(btnRefreshDir, resources.GetString("btnRefreshDir.ToolTip"));
        btnRefreshDir.UseVisualStyleBackColor = true;
        btnRefreshDir.Click += btnRefreshDir_Click;
        // 
        // tpPlaylists
        // 
        resources.ApplyResources(tpPlaylists, "tpPlaylists");
        tpPlaylists.BackColor = SystemColors.ButtonHighlight;
        tpPlaylists.Controls.Add(tbSearchAudio);
        tpPlaylists.Controls.Add(LayPlaylists);
        tpPlaylists.Controls.Add(LayHPlaylistsPanel);
        tpPlaylists.Name = "tpPlaylists";
        ttCom.SetToolTip(tpPlaylists, resources.GetString("tpPlaylists.ToolTip"));
        // 
        // tbSearchAudio
        // 
        resources.ApplyResources(tbSearchAudio, "tbSearchAudio");
        tbSearchAudio.BorderStyle = BorderStyle.None;
        tbSearchAudio.Name = "tbSearchAudio";
        ttCom.SetToolTip(tbSearchAudio, resources.GetString("tbSearchAudio.ToolTip"));
        // 
        // LayPlaylists
        // 
        resources.ApplyResources(LayPlaylists, "LayPlaylists");
        LayPlaylists.BackColor = SystemColors.ButtonHighlight;
        LayPlaylists.Name = "LayPlaylists";
        ttCom.SetToolTip(LayPlaylists, resources.GetString("LayPlaylists.ToolTip"));
        // 
        // LayHPlaylistsPanel
        // 
        resources.ApplyResources(LayHPlaylistsPanel, "LayHPlaylistsPanel");
        LayHPlaylistsPanel.BackColor = SystemColors.ButtonHighlight;
        LayHPlaylistsPanel.Controls.Add(btnToPlaylists);
        LayHPlaylistsPanel.Controls.Add(btnAddPlaylist);
        LayHPlaylistsPanel.Controls.Add(btnRefreshPlaylists);
        LayHPlaylistsPanel.Controls.Add(btnAddAudioToPlaylist);
        LayHPlaylistsPanel.Controls.Add(btnAddDirToPlaylist);
        LayHPlaylistsPanel.Name = "LayHPlaylistsPanel";
        ttCom.SetToolTip(LayHPlaylistsPanel, resources.GetString("LayHPlaylistsPanel.ToolTip"));
        // 
        // btnToPlaylists
        // 
        resources.ApplyResources(btnToPlaylists, "btnToPlaylists");
        btnToPlaylists.FlatAppearance.BorderSize = 0;
        btnToPlaylists.ImageList = HIList32;
        btnToPlaylists.Name = "btnToPlaylists";
        ttCom.SetToolTip(btnToPlaylists, resources.GetString("btnToPlaylists.ToolTip"));
        btnToPlaylists.UseVisualStyleBackColor = true;
        btnToPlaylists.Click += btnToPlaylists_Click;
        // 
        // btnAddPlaylist
        // 
        resources.ApplyResources(btnAddPlaylist, "btnAddPlaylist");
        btnAddPlaylist.FlatAppearance.BorderSize = 0;
        btnAddPlaylist.ImageList = HIList32;
        btnAddPlaylist.Name = "btnAddPlaylist";
        ttCom.SetToolTip(btnAddPlaylist, resources.GetString("btnAddPlaylist.ToolTip"));
        btnAddPlaylist.UseVisualStyleBackColor = true;
        btnAddPlaylist.Click += btnAddPlaylist_Click;
        // 
        // btnRefreshPlaylists
        // 
        resources.ApplyResources(btnRefreshPlaylists, "btnRefreshPlaylists");
        btnRefreshPlaylists.FlatAppearance.BorderSize = 0;
        btnRefreshPlaylists.ImageList = HIList32;
        btnRefreshPlaylists.Name = "btnRefreshPlaylists";
        ttCom.SetToolTip(btnRefreshPlaylists, resources.GetString("btnRefreshPlaylists.ToolTip"));
        btnRefreshPlaylists.UseVisualStyleBackColor = true;
        btnRefreshPlaylists.Click += btnRefreshPlaylists_Click;
        // 
        // btnAddAudioToPlaylist
        // 
        resources.ApplyResources(btnAddAudioToPlaylist, "btnAddAudioToPlaylist");
        btnAddAudioToPlaylist.FlatAppearance.BorderSize = 0;
        btnAddAudioToPlaylist.ImageList = HIList32;
        btnAddAudioToPlaylist.Name = "btnAddAudioToPlaylist";
        ttCom.SetToolTip(btnAddAudioToPlaylist, resources.GetString("btnAddAudioToPlaylist.ToolTip"));
        btnAddAudioToPlaylist.UseVisualStyleBackColor = true;
        // 
        // btnAddDirToPlaylist
        // 
        resources.ApplyResources(btnAddDirToPlaylist, "btnAddDirToPlaylist");
        btnAddDirToPlaylist.FlatAppearance.BorderSize = 0;
        btnAddDirToPlaylist.ImageList = HIList32;
        btnAddDirToPlaylist.Name = "btnAddDirToPlaylist";
        ttCom.SetToolTip(btnAddDirToPlaylist, resources.GetString("btnAddDirToPlaylist.ToolTip"));
        btnAddDirToPlaylist.UseVisualStyleBackColor = true;
        // 
        // tpFiles
        // 
        resources.ApplyResources(tpFiles, "tpFiles");
        tpFiles.BackColor = SystemColors.ButtonHighlight;
        tpFiles.Controls.Add(tbSearchFiles);
        tpFiles.Controls.Add(LayFilesPanel);
        tpFiles.Controls.Add(LayFiles);
        tpFiles.Name = "tpFiles";
        ttCom.SetToolTip(tpFiles, resources.GetString("tpFiles.ToolTip"));
        // 
        // tbSearchFiles
        // 
        resources.ApplyResources(tbSearchFiles, "tbSearchFiles");
        tbSearchFiles.BorderStyle = BorderStyle.None;
        tbSearchFiles.Name = "tbSearchFiles";
        ttCom.SetToolTip(tbSearchFiles, resources.GetString("tbSearchFiles.ToolTip"));
        // 
        // LayFilesPanel
        // 
        resources.ApplyResources(LayFilesPanel, "LayFilesPanel");
        LayFilesPanel.BackColor = SystemColors.ButtonHighlight;
        LayFilesPanel.Controls.Add(btnRefreshFiles);
        LayFilesPanel.Name = "LayFilesPanel";
        ttCom.SetToolTip(LayFilesPanel, resources.GetString("LayFilesPanel.ToolTip"));
        // 
        // btnRefreshFiles
        // 
        resources.ApplyResources(btnRefreshFiles, "btnRefreshFiles");
        btnRefreshFiles.FlatAppearance.BorderSize = 0;
        btnRefreshFiles.ImageList = HIList32;
        btnRefreshFiles.Name = "btnRefreshFiles";
        ttCom.SetToolTip(btnRefreshFiles, resources.GetString("btnRefreshFiles.ToolTip"));
        btnRefreshFiles.UseVisualStyleBackColor = true;
        btnRefreshFiles.Click += btnRefreshFiles_Click;
        // 
        // LayFiles
        // 
        resources.ApplyResources(LayFiles, "LayFiles");
        LayFiles.AllowDrop = true;
        LayFiles.BackColor = SystemColors.ButtonHighlight;
        LayFiles.Name = "LayFiles";
        ttCom.SetToolTip(LayFiles, resources.GetString("LayFiles.ToolTip"));
        // 
        // LayPleerDescription
        // 
        resources.ApplyResources(LayPleerDescription, "LayPleerDescription");
        LayPleerDescription.BackColor = SystemColors.ButtonHighlight;
        LayPleerDescription.Controls.Add(tbPleerDescription, 0, 0);
        LayPleerDescription.Name = "LayPleerDescription";
        ttCom.SetToolTip(LayPleerDescription, resources.GetString("LayPleerDescription.ToolTip"));
        // 
        // tbPleerDescription
        // 
        resources.ApplyResources(tbPleerDescription, "tbPleerDescription");
        tbPleerDescription.BackColor = SystemColors.ButtonHighlight;
        tbPleerDescription.BorderStyle = BorderStyle.None;
        tbPleerDescription.Name = "tbPleerDescription";
        tbPleerDescription.ReadOnly = true;
        ttCom.SetToolTip(tbPleerDescription, resources.GetString("tbPleerDescription.ToolTip"));
        // 
        // LayPleerAudioRoad
        // 
        resources.ApplyResources(LayPleerAudioRoad, "LayPleerAudioRoad");
        LayPleerAudioRoad.BackColor = SystemColors.ButtonHighlight;
        LayPleerAudioRoad.Controls.Add(tbPleerCurrentTime, 0, 0);
        LayPleerAudioRoad.Controls.Add(tbPleerCommonTime, 2, 0);
        LayPleerAudioRoad.Controls.Add(tbPositionSec, 1, 0);
        LayPleerAudioRoad.Name = "LayPleerAudioRoad";
        ttCom.SetToolTip(LayPleerAudioRoad, resources.GetString("LayPleerAudioRoad.ToolTip"));
        // 
        // tbPleerCurrentTime
        // 
        resources.ApplyResources(tbPleerCurrentTime, "tbPleerCurrentTime");
        tbPleerCurrentTime.BackColor = SystemColors.ButtonHighlight;
        tbPleerCurrentTime.BorderStyle = BorderStyle.None;
        tbPleerCurrentTime.Name = "tbPleerCurrentTime";
        tbPleerCurrentTime.ReadOnly = true;
        ttCom.SetToolTip(tbPleerCurrentTime, resources.GetString("tbPleerCurrentTime.ToolTip"));
        // 
        // tbPleerCommonTime
        // 
        resources.ApplyResources(tbPleerCommonTime, "tbPleerCommonTime");
        tbPleerCommonTime.BackColor = SystemColors.ButtonHighlight;
        tbPleerCommonTime.BorderStyle = BorderStyle.None;
        tbPleerCommonTime.Name = "tbPleerCommonTime";
        tbPleerCommonTime.ReadOnly = true;
        ttCom.SetToolTip(tbPleerCommonTime, resources.GetString("tbPleerCommonTime.ToolTip"));
        // 
        // tbPositionSec
        // 
        resources.ApplyResources(tbPositionSec, "tbPositionSec");
        tbPositionSec.BackColor = SystemColors.ButtonHighlight;
        tbPositionSec.Cursor = Cursors.Hand;
        tbPositionSec.Maximum = 1000;
        tbPositionSec.Name = "tbPositionSec";
        ttCom.SetToolTip(tbPositionSec, resources.GetString("tbPositionSec.ToolTip"));
        tbPositionSec.Value = 388;
        tbPositionSec.Scroll += tbPositionSec_Scroll;
        tbPositionSec.MouseDown += tbPositionSec_MouseDown;
        tbPositionSec.MouseUp += tbPositionSec_MouseUp;
        // 
        // LayPleerButtons
        // 
        resources.ApplyResources(LayPleerButtons, "LayPleerButtons");
        LayPleerButtons.Controls.Add(btnLoop, 1, 0);
        LayPleerButtons.Controls.Add(btnMix, 0, 0);
        LayPleerButtons.Controls.Add(btnPrev, 4, 0);
        LayPleerButtons.Controls.Add(btnPlay, 5, 0);
        LayPleerButtons.Controls.Add(btnNext, 6, 0);
        LayPleerButtons.Controls.Add(tbVolume, 8, 1);
        LayPleerButtons.Name = "LayPleerButtons";
        ttCom.SetToolTip(LayPleerButtons, resources.GetString("LayPleerButtons.ToolTip"));
        // 
        // btnLoop
        // 
        resources.ApplyResources(btnLoop, "btnLoop");
        btnLoop.FlatAppearance.BorderSize = 0;
        btnLoop.ImageList = HIMList23;
        btnLoop.Name = "btnLoop";
        ttCom.SetToolTip(btnLoop, resources.GetString("btnLoop.ToolTip"));
        btnLoop.UseVisualStyleBackColor = true;
        // 
        // HIMList23
        // 
        HIMList23.ColorDepth = ColorDepth.Depth32Bit;
        HIMList23.ImageStream = (ImageListStreamer)resources.GetObject("HIMList23.ImageStream");
        HIMList23.TransparentColor = Color.Transparent;
        HIMList23.Images.SetKeyName(0, "add-128-V1.ico");
        HIMList23.Images.SetKeyName(1, "add-512-V1.ico");
        HIMList23.Images.SetKeyName(2, "add-dir-48-v1.ico");
        HIMList23.Images.SetKeyName(3, "addfolder-512-V1.ico");
        HIMList23.Images.SetKeyName(4, "add-music-128-V1.ico");
        HIMList23.Images.SetKeyName(5, "add-music-512-V1.ico");
        HIMList23.Images.SetKeyName(6, "add-music-512-V2.ico");
        HIMList23.Images.SetKeyName(7, "application-v1.ico");
        HIMList23.Images.SetKeyName(8, "apply-256-V1.ico");
        HIMList23.Images.SetKeyName(9, "back-128-V1.ico");
        HIMList23.Images.SetKeyName(10, "close-256-v1.ico");
        HIMList23.Images.SetKeyName(11, "delete-512-v1.ico");
        HIMList23.Images.SetKeyName(12, "delete-512-v2.ico");
        HIMList23.Images.SetKeyName(13, "deletefolder-256-V1.ico");
        HIMList23.Images.SetKeyName(14, "dirs-64-v1.ico");
        HIMList23.Images.SetKeyName(15, "dirs-256-v2.ico");
        HIMList23.Images.SetKeyName(16, "files-64-v1.ico");
        HIMList23.Images.SetKeyName(17, "hide-256-v1.ico");
        HIMList23.Images.SetKeyName(18, "home-96-v1.ico");
        HIMList23.Images.SetKeyName(19, "loop-all-v1.ico");
        HIMList23.Images.SetKeyName(20, "loop-no-v1.ico");
        HIMList23.Images.SetKeyName(21, "loop-one-v1.png");
        HIMList23.Images.SetKeyName(22, "mix-512-v1.ico");
        HIMList23.Images.SetKeyName(23, "mixon-512-v1.png");
        HIMList23.Images.SetKeyName(24, "musicall-512-v1.ico");
        HIMList23.Images.SetKeyName(25, "next-512-v3.ico");
        HIMList23.Images.SetKeyName(26, "next-png-v1.png");
        HIMList23.Images.SetKeyName(27, "offservice-256-V1.ico");
        HIMList23.Images.SetKeyName(28, "openfolder-512-v3.ico");
        HIMList23.Images.SetKeyName(29, "play-512-V1.ico");
        HIMList23.Images.SetKeyName(30, "play-512-V2.ico");
        HIMList23.Images.SetKeyName(31, "play-512-V3.ico");
        HIMList23.Images.SetKeyName(32, "playlists-64-v1.ico");
        HIMList23.Images.SetKeyName(33, "playlists-256-v2.ico");
        HIMList23.Images.SetKeyName(34, "prev-512-v3.ico");
        HIMList23.Images.SetKeyName(35, "restart-128-V2.ico");
        HIMList23.Images.SetKeyName(36, "restart-512-V1.ico");
        HIMList23.Images.SetKeyName(37, "restart-512-v3.ico");
        HIMList23.Images.SetKeyName(38, "restart-512-V4.ico");
        HIMList23.Images.SetKeyName(39, "restart-512-V5.ico");
        HIMList23.Images.SetKeyName(40, "save-96-v1.ico");
        HIMList23.Images.SetKeyName(41, "startapp-512-V1.ico");
        HIMList23.Images.SetKeyName(42, "stop-512-V1.ico");
        HIMList23.Images.SetKeyName(43, "stop-512-V2.ico");
        HIMList23.Images.SetKeyName(44, "stop-512-v3.ico");
        HIMList23.Images.SetKeyName(45, "tools-512-V1.ico");
        HIMList23.Images.SetKeyName(46, "tools-512-V2.ico");
        HIMList23.Images.SetKeyName(47, "tray-main-1-32.png");
        HIMList23.Images.SetKeyName(48, "tray-main-1-32-v2.png");
        HIMList23.Images.SetKeyName(49, "volume-128-V4.ico");
        HIMList23.Images.SetKeyName(50, "volume-512-v1.ico");
        HIMList23.Images.SetKeyName(51, "volume-512-v2.ico");
        HIMList23.Images.SetKeyName(52, "volume-512-v2.png");
        HIMList23.Images.SetKeyName(53, "volume-512-v3.ico");
        // 
        // btnMix
        // 
        resources.ApplyResources(btnMix, "btnMix");
        btnMix.FlatAppearance.BorderSize = 0;
        btnMix.ImageList = HIMList23;
        btnMix.Name = "btnMix";
        ttCom.SetToolTip(btnMix, resources.GetString("btnMix.ToolTip"));
        btnMix.UseVisualStyleBackColor = true;
        // 
        // btnPrev
        // 
        resources.ApplyResources(btnPrev, "btnPrev");
        btnPrev.FlatAppearance.BorderSize = 0;
        btnPrev.ImageList = HIList32;
        btnPrev.Name = "btnPrev";
        ttCom.SetToolTip(btnPrev, resources.GetString("btnPrev.ToolTip"));
        btnPrev.UseVisualStyleBackColor = true;
        // 
        // btnPlay
        // 
        resources.ApplyResources(btnPlay, "btnPlay");
        btnPlay.FlatAppearance.BorderSize = 0;
        btnPlay.ImageList = HIList32;
        btnPlay.Name = "btnPlay";
        ttCom.SetToolTip(btnPlay, resources.GetString("btnPlay.ToolTip"));
        btnPlay.UseVisualStyleBackColor = true;
        // 
        // btnNext
        // 
        resources.ApplyResources(btnNext, "btnNext");
        btnNext.FlatAppearance.BorderSize = 0;
        btnNext.ImageList = HIList32;
        btnNext.Name = "btnNext";
        ttCom.SetToolTip(btnNext, resources.GetString("btnNext.ToolTip"));
        btnNext.UseVisualStyleBackColor = true;
        // 
        // tbVolume
        // 
        resources.ApplyResources(tbVolume, "tbVolume");
        tbVolume.Cursor = Cursors.Hand;
        tbVolume.Maximum = 1000;
        tbVolume.Name = "tbVolume";
        tbVolume.TickFrequency = 10;
        ttCom.SetToolTip(tbVolume, resources.GetString("tbVolume.ToolTip"));
        tbVolume.Value = 1000;
        // 
        // HIMList20
        // 
        HIMList20.ColorDepth = ColorDepth.Depth32Bit;
        HIMList20.ImageStream = (ImageListStreamer)resources.GetObject("HIMList20.ImageStream");
        HIMList20.TransparentColor = Color.Transparent;
        HIMList20.Images.SetKeyName(0, "add-128-V1.ico");
        HIMList20.Images.SetKeyName(1, "add-512-V1.ico");
        HIMList20.Images.SetKeyName(2, "add-dir-48-v1.ico");
        HIMList20.Images.SetKeyName(3, "addfolder-512-V1.ico");
        HIMList20.Images.SetKeyName(4, "add-music-128-V1.ico");
        HIMList20.Images.SetKeyName(5, "add-music-512-V1.ico");
        HIMList20.Images.SetKeyName(6, "add-music-512-V2.ico");
        HIMList20.Images.SetKeyName(7, "application-v1.ico");
        HIMList20.Images.SetKeyName(8, "apply-256-V1.ico");
        HIMList20.Images.SetKeyName(9, "back-128-V1.ico");
        HIMList20.Images.SetKeyName(10, "close-256-v1.ico");
        HIMList20.Images.SetKeyName(11, "delete-512-v1.ico");
        HIMList20.Images.SetKeyName(12, "delete-512-v2.ico");
        HIMList20.Images.SetKeyName(13, "deletefolder-256-V1.ico");
        HIMList20.Images.SetKeyName(14, "dirs-64-v1.ico");
        HIMList20.Images.SetKeyName(15, "dirs-256-v2.ico");
        HIMList20.Images.SetKeyName(16, "files-64-v1.ico");
        HIMList20.Images.SetKeyName(17, "hide-256-v1.ico");
        HIMList20.Images.SetKeyName(18, "home-96-v1.ico");
        HIMList20.Images.SetKeyName(19, "musicall-512-v1.ico");
        HIMList20.Images.SetKeyName(20, "offservice-256-V1.ico");
        HIMList20.Images.SetKeyName(21, "play-512-V1.ico");
        HIMList20.Images.SetKeyName(22, "play-512-V2.ico");
        HIMList20.Images.SetKeyName(23, "play-512-V3.ico");
        HIMList20.Images.SetKeyName(24, "playlists-64-v1.ico");
        HIMList20.Images.SetKeyName(25, "playlists-256-v2.ico");
        HIMList20.Images.SetKeyName(26, "restart-128-V2.ico");
        HIMList20.Images.SetKeyName(27, "restart-512-V1.ico");
        HIMList20.Images.SetKeyName(28, "restart-512-v3.ico");
        HIMList20.Images.SetKeyName(29, "restart-512-V4.ico");
        HIMList20.Images.SetKeyName(30, "restart-512-V5.ico");
        HIMList20.Images.SetKeyName(31, "save-96-v1.ico");
        HIMList20.Images.SetKeyName(32, "startapp-512-V1.ico");
        HIMList20.Images.SetKeyName(33, "stop-512-V1.ico");
        HIMList20.Images.SetKeyName(34, "stop-512-V2.ico");
        HIMList20.Images.SetKeyName(35, "tools-512-V1.ico");
        HIMList20.Images.SetKeyName(36, "tools-512-V2.ico");
        HIMList20.Images.SetKeyName(37, "tray-main-1-32.png");
        HIMList20.Images.SetKeyName(38, "tray-main-1-32-v2.png");
        HIMList20.Images.SetKeyName(39, "volume-128-V4.ico");
        HIMList20.Images.SetKeyName(40, "volume-512-v1.ico");
        HIMList20.Images.SetKeyName(41, "volume-512-v2.ico");
        HIMList20.Images.SetKeyName(42, "volume-512-v2.png");
        HIMList20.Images.SetKeyName(43, "volume-512-v3.ico");
        HIMList20.Images.SetKeyName(44, "stop-512-v3.ico");
        HIMList20.Images.SetKeyName(45, "openfolder-512-v3.ico");
        HIMList20.Images.SetKeyName(46, "loop-all-v1.ico");
        HIMList20.Images.SetKeyName(47, "loop-no-v1.ico");
        HIMList20.Images.SetKeyName(48, "loop-one-v1.png");
        HIMList20.Images.SetKeyName(49, "mix-512-v1.ico");
        HIMList20.Images.SetKeyName(50, "mixon-512-v1.png");
        HIMList20.Images.SetKeyName(51, "edit-512-v1.ico");
        HIMList20.Images.SetKeyName(52, "edit-512-v2.ico");
        HIMList20.Images.SetKeyName(53, "music-128-v1.ico");
        // 
        // HIMList26
        // 
        HIMList26.ColorDepth = ColorDepth.Depth32Bit;
        HIMList26.ImageStream = (ImageListStreamer)resources.GetObject("HIMList26.ImageStream");
        HIMList26.TransparentColor = Color.Transparent;
        HIMList26.Images.SetKeyName(0, "add-128-V1.ico");
        HIMList26.Images.SetKeyName(1, "add-512-V1.ico");
        HIMList26.Images.SetKeyName(2, "add-dir-48-v1.ico");
        HIMList26.Images.SetKeyName(3, "addfolder-512-V1.ico");
        HIMList26.Images.SetKeyName(4, "add-music-128-V1.ico");
        HIMList26.Images.SetKeyName(5, "add-music-512-V1.ico");
        HIMList26.Images.SetKeyName(6, "add-music-512-V2.ico");
        HIMList26.Images.SetKeyName(7, "application-v1.ico");
        HIMList26.Images.SetKeyName(8, "apply-256-V1.ico");
        HIMList26.Images.SetKeyName(9, "back-128-V1.ico");
        HIMList26.Images.SetKeyName(10, "close-256-v1.ico");
        HIMList26.Images.SetKeyName(11, "delete-512-v1.ico");
        HIMList26.Images.SetKeyName(12, "delete-512-v2.ico");
        HIMList26.Images.SetKeyName(13, "deletefolder-256-V1.ico");
        HIMList26.Images.SetKeyName(14, "dirs-64-v1.ico");
        HIMList26.Images.SetKeyName(15, "dirs-256-v2.ico");
        HIMList26.Images.SetKeyName(16, "files-64-v1.ico");
        HIMList26.Images.SetKeyName(17, "hide-256-v1.ico");
        HIMList26.Images.SetKeyName(18, "home-96-v1.ico");
        HIMList26.Images.SetKeyName(19, "loop-all-v1.ico");
        HIMList26.Images.SetKeyName(20, "loop-no-v1.ico");
        HIMList26.Images.SetKeyName(21, "loop-one-v1.png");
        HIMList26.Images.SetKeyName(22, "musicall-512-v1.ico");
        HIMList26.Images.SetKeyName(23, "next-512-v3.ico");
        HIMList26.Images.SetKeyName(24, "next-png-v1.png");
        HIMList26.Images.SetKeyName(25, "offservice-256-V1.ico");
        HIMList26.Images.SetKeyName(26, "openfolder-512-v3.ico");
        HIMList26.Images.SetKeyName(27, "play-512-V1.ico");
        HIMList26.Images.SetKeyName(28, "play-512-V2.ico");
        HIMList26.Images.SetKeyName(29, "play-512-V3.ico");
        HIMList26.Images.SetKeyName(30, "playlists-64-v1.ico");
        HIMList26.Images.SetKeyName(31, "playlists-256-v2.ico");
        HIMList26.Images.SetKeyName(32, "prev-512-v3.ico");
        HIMList26.Images.SetKeyName(33, "restart-128-V2.ico");
        HIMList26.Images.SetKeyName(34, "restart-512-V1.ico");
        HIMList26.Images.SetKeyName(35, "restart-512-v3.ico");
        HIMList26.Images.SetKeyName(36, "restart-512-V4.ico");
        HIMList26.Images.SetKeyName(37, "restart-512-V5.ico");
        HIMList26.Images.SetKeyName(38, "save-96-v1.ico");
        HIMList26.Images.SetKeyName(39, "startapp-512-V1.ico");
        HIMList26.Images.SetKeyName(40, "stop-512-V1.ico");
        HIMList26.Images.SetKeyName(41, "stop-512-V2.ico");
        HIMList26.Images.SetKeyName(42, "stop-512-v3.ico");
        HIMList26.Images.SetKeyName(43, "tools-512-V1.ico");
        HIMList26.Images.SetKeyName(44, "tools-512-V2.ico");
        HIMList26.Images.SetKeyName(45, "tray-main-1-32.png");
        HIMList26.Images.SetKeyName(46, "tray-main-1-32-v2.png");
        HIMList26.Images.SetKeyName(47, "volume-128-V4.ico");
        HIMList26.Images.SetKeyName(48, "volume-512-v1.ico");
        HIMList26.Images.SetKeyName(49, "volume-512-v2.ico");
        HIMList26.Images.SetKeyName(50, "volume-512-v2.png");
        HIMList26.Images.SetKeyName(51, "volume-512-v3.ico");
        HIMList26.Images.SetKeyName(52, "mix-512-v1.ico");
        // 
        // ttCom
        // 
        ttCom.ToolTipTitle = "Описание:";
        // 
        // FMain
        // 
        resources.ApplyResources(this, "$this");
        AllowDrop = true;
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ButtonHighlight;
        Controls.Add(LayMain);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FMain";
        ttCom.SetToolTip(this, resources.GetString("$this.ToolTip"));
        Load += FMain_Load;
        LayMain.ResumeLayout(false);
        tcMain.ResumeLayout(false);
        tpDirs.ResumeLayout(false);
        LayHDirsPanel.ResumeLayout(false);
        tpPlaylists.ResumeLayout(false);
        tpPlaylists.PerformLayout();
        LayHPlaylistsPanel.ResumeLayout(false);
        tpFiles.ResumeLayout(false);
        tpFiles.PerformLayout();
        LayFilesPanel.ResumeLayout(false);
        LayPleerDescription.ResumeLayout(false);
        LayPleerDescription.PerformLayout();
        LayPleerAudioRoad.ResumeLayout(false);
        LayPleerAudioRoad.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tbPositionSec).EndInit();
        LayPleerButtons.ResumeLayout(false);
        LayPleerButtons.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tbVolume).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel LayMain;
    private Button btnAddDir;
    public ImageList HIList32;
    private Button btnDirs;
    private Button btnPlaylists;
    private Button btnOff;
    private Button btnFiles;
    private Button btnSave;
    private TabControl tcMain;
    private TabPage tpDirs;
    private TabPage tpPlaylists;
    private TabPage tpFiles;
    private ToolTip ttCom;
    private FlowLayoutPanel LayHDirsPanel;
    private FlowLayoutPanel LayDirs;
    private ImageList HIMList20;
    private FlowLayoutPanel LayHPlaylistsPanel;
    private Button btnAddPlaylist;
    private FlowLayoutPanel LayPlaylists;
    private FlowLayoutPanel LayFilesPanel;
    private FlowLayoutPanel LayFiles;
    private TextBox tbSearchFiles;
    private Button btnRefreshDir;
    private Button btnRefreshFiles;
    private TableLayoutPanel LayPleerDescription;
    private TextBox tbPleerDescription;
    private TableLayoutPanel LayPleerAudioRoad;
    private TrackBar tbPositionSec;
    private TextBox tbPleerCurrentTime;
    private TextBox tbPleerCommonTime;
    private TableLayoutPanel LayPleerButtons;
    private Button btnLoop;
    private Button btnMix;
    private Button btnPrev;
    private Button btnPlay;
    private Button btnNext;
    private ImageList HIMList26;
    private ImageList HIMList23;
    private TrackBar tbVolume;
    private TextBox tbSearchAudio;
    private Button btnRefreshPlaylists;
    private Button btnToPlaylists;
    private Button btnAddAudioToPlaylist;
    private Button btnAddDirToPlaylist;
}
