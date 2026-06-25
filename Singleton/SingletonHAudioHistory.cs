using Pleer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleer.Singleton;

public class SingletonHAudioHistory
{
    private static readonly Lazy<SingletonHAudioHistory> lazy =
        new Lazy<SingletonHAudioHistory>(() => new SingletonHAudioHistory());

    private SingletonHAudioHistory()
    {
        HOHAudios = new SortedList<int, HAudio>();
    }

    public static SingletonHAudioHistory Instance => lazy.Value;
    public SortedList<int, HAudio> HOHAudios;

    public void Add(HAudio audio)
    {
        HOHAudios.Add(HOHAudios.Count, audio);
    }
}
