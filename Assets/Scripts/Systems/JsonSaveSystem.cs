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
        _pathDataStorage = Path.Combine(Application.persistentDataPath, "data.json");
        _pathUpgraderInfo = Path.Combine(Application.persistentDataPath, "upgraderData.json");

        DataStatsStorage storage = LoadData<DataStatsStorage>(_pathDataStorage);
        _statsData.StatsModel.SetDataValues(storage);
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
        DataStatsStorage storage = new DataStatsStorage();
        StatsModel model = _statsData.StatsModel;
        storage.Coins = model.Coins;
        storage.CoinsPerClick = model.CoinsPerClick;
        storage.Defence = model.Defence;
        storage.Damage = model.Damage;
        storage.Health = model.Health;
        storage.Experience = model.Experience;
        storage.Level = model.Level;
        storage.MaxExperinece = model.MaxExperinece;

        SaveData<DataStatsStorage>(_pathDataStorage, storage);
    }

    private void SaveUpgraders()
    {
        SaveData<UpgraderData>(_pathUpgraderInfo, _upgradeData);
    }
}
