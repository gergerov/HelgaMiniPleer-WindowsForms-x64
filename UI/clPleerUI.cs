using Pleer.Data;
using Pleer.Singleton;


namespace Pleer.UI;

public class clPleerUI
{
    public enum Looping
    {
        None,
        Track,
        Files,
        Playlist,
    }

    public Looping Loop = Looping.None;
    public bool IsMix = false;

    public bool InHistory = false;

    public FMain fmain;
    public TextBox PleerDescription;
    public ToolTip tt;
    public TrackBar tbPositionSec;
    public TrackBar tbVolume;
    public TextBox tbPleerCommonTime;
    public TextBox tbPleerCurrentTime;
    public float AudioLength;
    public float AudioCurrentTime;

    public System.Windows.Forms.Timer? PleerCommonTimeSetterTimer;
    public System.Windows.Forms.Timer? SecPositionTimer;
    public System.Windows.Forms.Timer? TrackBarSecPositionTimer;

    public bool IsTrackBarTimerStopped;

    public Button btnMix;
    public Button btnLoop;
    public Button btnPrev;
    public Button btnPlay;
    public Button btnNext;

    public clPleerUI(FMain fmain, TextBox PleerDescription, ToolTip tt, TrackBar tbPositionSec,
                        TextBox tbPleerCommonTime, TextBox tbPleerCurrentTime,
                        Button btnMix, Button btnLoop, Button btnPrev, Button btnPlay, Button btnNext,
                        TrackBar tbVolume)
    {
        this.fmain = fmain;

        this.btnLoop = btnLoop;
        this.btnMix = btnMix;
        this.btnPlay = btnPlay;
        this.btnPrev = btnPrev;
        this.btnNext = btnNext;

        this.btnLoop.Click += btnLoop_Click;
        this.btnMix.Click += btnMix_Click;
        this.btnPlay.Click += btnPlay_Click;
        this.btnNext.Click += btnNext_Click;
        this.btnPrev.Click += btnPrev_Click;

        this.tt = tt;

        this.PleerDescription = PleerDescription;
        this.tbPositionSec = tbPositionSec;
        this.tbPleerCommonTime = tbPleerCommonTime;
        this.tbPleerCommonTime.Text = SecToString(0.0f);
        this.tbPleerCurrentTime = tbPleerCurrentTime;
        this.tbVolume = tbVolume;

        this.tbVolume.Scroll += tbVolume_Scroll;
        this.tbVolume.MouseDown += tbVolume_MouseDown;

        SetTimers();
        IsTrackBarTimerStopped = false;

        SingletonBass.Instance.TrackEnded += TrackEndCallback;
    }

    public void SetIsTrackBarTimerStopped(bool value)
    {
        if (value != IsTrackBarTimerStopped)
        {
            IsTrackBarTimerStopped = value;
            if (value)
            {
                TrackBarSecPositionTimer?.Stop();
            }
            else
            {
                TrackBarSecPositionTimer?.Start();
            }
        }
    }

    public string SecToString(float sec)
    {
        if (sec == 0.0f)
        {
            return "00:00";
        }

        string StringSec = "";
        int minutes = (int)Math.Ceiling(sec / 60) - 1;
        int secundes = (int)Math.Ceiling(sec - (minutes * 60));
        StringSec = $"{minutes:d02}:{secundes:d02}";
        return StringSec;
    }

    public void StopAudio(bool IsPause = true)
    {
        fmain.HAudioUI.SetupButtonPause();
        fmain.PlaylistUI.PlaylistAudioUI?.SetupButtonPause();

        if (IsPause)
        {
            SingletonBass.Instance.Pause();
        }
        else
        {
            SingletonBass.Instance.Stop();
        }

        btnPlay.ImageIndex = 21;
        btnPlay.Click -= btnStop_Click;
        btnPlay.Click += btnPlay_Click;
    }

    public void SetAudio(HAudio audio)
    {
        if (!audio.IsExists())
        {
            fmain.UpdateLvHDirs();
            fmain.UpdateLvHAudios();
            return;
        }

        SingletonHAudioHistory.Instance.Add(audio);
        this.PleerDescription.Text = audio.Name;
        this.PleerCommonTimeSetterTimer?.Start();
        this.tt.SetToolTip(this.PleerDescription, "Сейчас играет: " + audio.Path);
        this.fmain.HAudioUI.SetupButtonsPlay(audio);
        this.fmain.PlaylistUI.PlaylistAudioUI?.SetupButtonsPlay(audio);

        if (SingletonBass.Instance.Audio?.Path == audio.Path)
        {
            if (Math.Abs(AudioLength - AudioCurrentTime) < 0.1f)
            {
                StopAudio(false);
                SingletonBass.Instance.Play(audio);
            }
            else
            {
                if (AudioCurrentTime == 0.0f)
                {
                    SingletonBass.Instance.Play(audio);
                }
                else
                {
                    SingletonBass.Instance.PlayResume();
                }
            }
        }
        else
        {
            SingletonBass.Instance.Play(audio);
        }

        fmain.HAudioUI.TrySelectLayAudio(audio);
        fmain.PlaylistUI.PlaylistAudioUI?.TrySelectLayAudio(audio);
        btnPlay.ImageIndex = 34;
        btnPlay.Click -= btnPlay_Click;
        btnPlay.Click += btnStop_Click;

        SecPositionTimer?.Start();
    }

    private void btnPlay_Click(object? sender, EventArgs e)
    {
        if (SingletonBass.Instance.Audio != null)
        {
            SetAudio(SingletonBass.Instance.Audio);
        }
        else
        {
            if (SingletonHAudio.Instance.OHAudios.Count > 0)
            {
                SetAudio(SingletonHAudio.Instance.OHAudios[SingletonHAudio.Instance.OHAudios.Keys[0]]);
            }
        }
    }

    private void btnStop_Click(object? sender, EventArgs e)
    {
        StopAudio();
    }

    public void TrackEndCallback(object? sender, EventArgs args)
    {
        AudioCurrentTime = 0.0f;

        if (SingletonBass.Instance.Audio != null)
        {
            if (Loop == Looping.Files)
            {
                var audio = SingletonHAudio.Instance.GetNext(SingletonBass.Instance.Audio);
                if (audio != null)
                {
                    SetAudio(audio);
                }
            }
            else if (Loop == Looping.Track)
            {
                SetAudio(SingletonBass.Instance.Audio);
            }
            else if (Loop == Looping.Playlist)
            {

            }
            else if (Loop == Looping.None)
            {
                StopAudio(false);
            }
        }
    }

    public void SetTimers()
    {
        SecPositionTimer = new System.Windows.Forms.Timer();
        SecPositionTimer.Interval = 100;
        SecPositionTimer.Tick += SecPositionTimerTick;
        SecPositionTimer.Start();

        PleerCommonTimeSetterTimer = new System.Windows.Forms.Timer();
        PleerCommonTimeSetterTimer.Interval = 100;
        PleerCommonTimeSetterTimer.Tick += PleerCommonTimeSetterTimerTick;

        TrackBarSecPositionTimer = new System.Windows.Forms.Timer();
        TrackBarSecPositionTimer.Interval = 100;
        TrackBarSecPositionTimer.Tick += TrackBarSecPositionTimerTick;
        TrackBarSecPositionTimer.Start();
    }

    public void SecPositionTimerTick(object? sender, EventArgs e)
    {
        var sec = SingletonBass.Instance.GetPositionSec();

        if (sec < 0.0f)
        {
            AudioCurrentTime = 0.0f;
            tbPleerCurrentTime.Text = SecToString(AudioCurrentTime);
            SecPositionTimer?.Stop();
            return;
        }

        AudioCurrentTime = sec;
        tbPleerCurrentTime.Text = SecToString(AudioCurrentTime);
        return;
    }

    public void PleerCommonTimeSetterTimerTick(object? sender, EventArgs e)
    {
        SingletonBass.Instance.SetLengthSec();
        var l = SingletonBass.Instance.GetLengthSec();

        if (l != 0.0f)
        {
            AudioLength = l;
            PleerCommonTimeSetterTimer?.Stop();
            tbPositionSec.Maximum = (int)(AudioLength * 100);
            tbPleerCommonTime.Text = SecToString(AudioLength);
            return;
        }
    }

    public void TrackBarSecPositionTimerTick(object? sender, EventArgs e)
    {
        if ((int)(AudioCurrentTime * 100) > tbPositionSec.Maximum)
        {
            return;
        }

        if ((int)(AudioCurrentTime * 100) < 0)
        {
            tbPositionSec.Value = 0;
            return;
        }

        tbPositionSec.Value = (int)(AudioCurrentTime * 100);
    }

    private void btnMix_Click(object? sender, EventArgs e)
    {
        IsMix = !IsMix;
        if (IsMix)
        {
            btnMix.ImageIndex = 23;
        }
        else
        {
            btnMix.ImageIndex = 22;
        }
    }

    private void btnNext_Click(object? sender, EventArgs e)
    {
        HAudio? audio = null;
        // Если есть история

        // Если перемешано
        if (IsMix)
        {
            audio = SingletonHAudio.Instance.GetRand();
            if (audio != null)
            {
                SetAudio(audio);
            }
            return;
        }

        // Если не перемешано
        if (SingletonBass.Instance.Audio != null)
        {
            audio = SingletonHAudio.Instance.GetNext(SingletonBass.Instance.Audio);
            if (audio != null)
            {
                SetAudio(audio);
            }
        }

        if (SingletonBass.Instance.Audio == null)
        {
            if (SingletonHAudio.Instance.HAudios.Count > 0)
            {
                SingletonBass.Instance.Audio = SingletonHAudio.Instance.HAudios[SingletonHAudio.Instance.HAudios.Keys.First()];
            }
            audio = SingletonHAudio.Instance.GetNext(SingletonBass.Instance.Audio);
            if (audio != null)
            {
                SetAudio(audio);
            }
        }
    }

    private void btnPrev_Click(object? sender, EventArgs e)
    {
        HAudio? audio = null;
        
        // Если перемешано
        if (IsMix)
        {
            audio = SingletonHAudio.Instance.GetRand();
            if (audio != null)
            {
                SetAudio(audio);
            }
            return;
        }

        // Если не перемешано
        if (SingletonBass.Instance.Audio != null)
        {
            audio = SingletonHAudio.Instance.GetPrev(SingletonBass.Instance.Audio);
            if (audio != null)
            {
                SetAudio(audio);
                return;
            }
        }
    }

    private void btnLoop_Click(object? sender, EventArgs e)
    {
        if (Loop == Looping.None)
        {
            Loop = Looping.Track;
            btnLoop.ImageIndex = 21;
        }
        else if (Loop == Looping.Track)
        {
            Loop = Looping.Files;
            btnLoop.ImageIndex = 19;
        }
        else if (Loop == Looping.Files)
        {
            Loop = Looping.None;
            btnLoop.ImageIndex = 20;
        }
    }

    private void tbVolume_Scroll(object? sender, EventArgs e)
    {
        SingletonBass.Instance.SetVolume(((float)tbVolume.Value / 1000));
    }

    private void tbVolume_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender == null) { return; }
        if (e.Button != MouseButtons.Left) return;

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

        SingletonBass.Instance.SetVolume(((float)tbVolume.Value / 1000));
    }
}
