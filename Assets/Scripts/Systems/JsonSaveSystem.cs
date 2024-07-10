using System;
using System.IO;
using UnityEngine;
using Zenject;

public class JsonSaveSystem : IInitializable, IDisposable
{
    private StatsData _statsData;
    private UpgraderData _upgradeData;

    private string _pathDataStorage;
    private string _pathUpgraderInfo;

    [Inject]
    private void Construct(StatsData statsData, UpgraderData upgraderData)
    {
        _statsData = statsData;
        _upgradeData = upgraderData;
    }

    public void Initialize()
    {
        _pathDataStorage = Path.Combine(Application.persistentDataPath, "/data.json");
        _pathUpgraderInfo = Path.Combine(Application.persistentDataPath, "/upgraderData.json");

        _statsData = LoadData<StatsData>(_pathDataStorage);
        _upgradeData = LoadData<UpgraderData>(_pathUpgraderInfo);
    }

    public void Dispose()
    {
        SaveStats();
        SaveUpgraders();
    }

    public T LoadData<T>(string path)
    {
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }

        return default(T);
    }

    public void SaveData<T>(string path, T data)
    {
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    private void SaveStats()
    {
        SaveData<StatsData>(_pathDataStorage, _statsData);
    }

    private void SaveUpgraders()
    {
        SaveData<UpgraderData>(_pathUpgraderInfo, _upgradeData);
    }
}
