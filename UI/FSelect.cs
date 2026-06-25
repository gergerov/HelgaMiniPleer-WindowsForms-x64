using Pleer.Data;
using Pleer.Singleton;


namespace Pleer.UI;

public partial class FSelect : Form
{
    public FMain fmain;
    public ImageList HIMList20;
    public ToolTip tt;
    public TextBox SearchBox;
    public HPlaylist Playlist;
    public clHAudioUISelect? AudioUISelect;
    public clHDirsUISelect? DirsUISelect;
    public bool IsDirMode;
    public FSelect(FMain fmain, ImageList HIMList20,
                        ToolTip tt, HPlaylist playlist, bool dirmode = false)
    {
        InitializeComponent();
        this.Icon = fmain.Icon;
        this.fmain = fmain;
        this.HIMList20 = HIMList20;
        this.tt = tt;
        this.SearchBox = tbSearchAudio;
        this.Playlist = playlist;
        this.IsDirMode = dirmode;
        
        if (!this.IsDirMode)
        {
            this.AudioUISelect = new(fmain, LayContent, HIMList20, tt, tbSearchAudio, Playlist, this);
        }
        else
        {
            this.DirsUISelect = new(fmain, SingletonHDir.Instance, LayContent, HIMList20, tt, this);
        }
    }


}
