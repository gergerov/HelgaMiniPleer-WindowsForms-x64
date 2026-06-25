using ManagedBass;
using Pleer.Data;


namespace Pleer.Singleton;

public sealed class SingletonBass
{
    private int _playbackChannel = 0;
    private float LengthSec;
    private float Volume = 1.0f;
    public HAudio? Audio;
    public event EventHandler? TrackEnded;
    private static readonly Lazy<SingletonBass> lazy = new Lazy<SingletonBass>(() => new SingletonBass());
    private readonly SynchronizationContext? _synccontext;

    private SingletonBass()
    {
        bool initResult = Bass.Init();
        if (!initResult)
        {
            MessageBox.Show("Ошибка инициализации BASS!");
        }
        this._synccontext = SynchronizationContext.Current;
    }

    public static SingletonBass Instance => lazy.Value;

    public float GetLengthSec()
    {
        return LengthSec;
    }

    public void SetLengthSec()
    {
        LengthSec = 0.0f;

        if (_playbackChannel == 0)
        {
            LengthSec = 0.0f;
            return;
        }

        var state = Bass.ChannelIsActive(_playbackChannel);
        if (state == PlaybackState.Stopped || state == PlaybackState.Stalled)
        {
            LengthSec = 0.0f;
            return;
        }

        long lengthInBytes = Bass.ChannelGetLength(_playbackChannel);
        if (lengthInBytes == -1)
        {
            LengthSec = 0.0f;
            MessageBox.Show($"Ошибка получения длины: {Bass.LastError}");
            return;
        }

        LengthSec = (float)Bass.ChannelBytes2Seconds(_playbackChannel, lengthInBytes);
    }

    public float GetPositionSec()
    {
        if (_playbackChannel == 0)
        {
            return 0.0f;
        }

        long bytes = Bass.ChannelGetPosition(_playbackChannel);
        double seconds = Bass.ChannelBytes2Seconds(_playbackChannel, bytes);
        return (float)seconds;
    }

    public void SetPositionSec(float secundes)
    {
        if (_playbackChannel == 0)
        {
            return;
        }

        var bytes = Bass.ChannelSeconds2Bytes(_playbackChannel, (double)secundes);
        Bass.ChannelSetPosition(_playbackChannel, bytes);
    }

    public void PlayResume()
    {
        if (_playbackChannel != 0)
        {
            Bass.ChannelPlay(_playbackChannel); // Продолжаем или начинаем воспроизведение
        }
    }

    public void Play(HAudio audio)
    {
        Audio = audio;
        FreeResources();
        _playbackChannel = Bass.CreateStream(audio.Path, 0, 0, BassFlags.Default | BassFlags.Prescan | BassFlags.AutoFree);

        if (_playbackChannel == 0)
        {
            MessageBox.Show($"Не удалось открыть файл.\nКод ошибки: {Bass.LastError}");
            return;
        }
        long param = 0;
        Bass.ChannelSetSync(_playbackChannel, SyncFlags.Onetime | SyncFlags.End, param, EndSyncProc);
        Bass.ChannelSetAttribute(_playbackChannel, ChannelAttribute.Volume, this.Volume);
        Bass.ChannelPlay(_playbackChannel); // Продолжаем или начинаем воспроизведение
    }

    public void SetVolume(float value)
    {
        if (value < 0)
        {
            value = 0.0f;
        }
        if (value > 1)
        {
            value = 1.0f;
        }
        Volume = value;

        if (_playbackChannel != 0)
        {
            Bass.ChannelSetAttribute(_playbackChannel, ChannelAttribute.Volume, this.Volume);
        }
    }

    private void EndSyncProc(int handle, int channel, int data, IntPtr user)
    {
        this._synccontext?.Post(_ => OnTrackEnded(), null);
    }

    public void Pause()
    {
        if (_playbackChannel != 0 && Bass.ChannelIsActive(_playbackChannel) != PlaybackState.Stopped)
        {
            Bass.ChannelPause(_playbackChannel);
        }
    }

    public void Stop()
    {
        if (_playbackChannel != 0 && Bass.ChannelIsActive(_playbackChannel) != PlaybackState.Stopped)
        {
            Bass.ChannelStop(_playbackChannel);
            Bass.ChannelSetPosition(_playbackChannel, 0);
        }
    }

    public void FreeResources()
    {
        if (_playbackChannel != 0)
        {
            Bass.StreamFree(_playbackChannel);
        }
    }

    private void OnTrackEnded()
    {
        Stop();
        FreeResources();
        TrackEnded?.Invoke(this, EventArgs.Empty);
    }
}
