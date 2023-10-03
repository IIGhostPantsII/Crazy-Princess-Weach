using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private GameObject _soundManager;
    [SerializeField] private GameObject _dataSaved;
    [SerializeField] private GameObject _dataLoaded;

    private string _savePath;

    private string _encryptionKey = "OhMyGodItsAKey";

    private void Start()
    {
        _savePath = Application.persistentDataPath + "/saveData.json";
    }

    public void SaveData()
    {
        SaveData data = new SaveData();
        data.playerPosition = _player.transform.position;
        data.currentLevel = GetComponent<LevelManager>()._currentLevel;
        string json = JsonUtility.ToJson(data);
        byte[] encryptedData = Encrypt(Encoding.UTF8.GetBytes(json));
        File.WriteAllBytes(_savePath, encryptedData);
        StartCoroutine(DataSaved());
    }

    public void LoadData()
    {
        StartCoroutine(LoadTime());
    }

    IEnumerator LoadTime()
    {
        _blackScreen.SetActive(true);
        _soundManager.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if(File.Exists(_savePath))
        {
            byte[] encryptedData = File.ReadAllBytes(_savePath);
            string json = Decrypt(encryptedData);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _player.transform.position = data.playerPosition;
            GetComponent<LevelManager>()._currentLevel = data.currentLevel;
        }
        _soundManager.SetActive(true);
        _blackScreen.SetActive(false);
        _dataLoaded.SetActive(true);
        yield return new WaitForSeconds(2f);
        _dataLoaded.SetActive(false);
    }

    IEnumerator DataSaved()
    {
        _dataSaved.SetActive(true);
        yield return new WaitForSeconds(2f);
        _dataSaved.SetActive(false);
    }

    private byte[] Encrypt(byte[] data)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(_encryptionKey);
        byte[] encryptedData = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            encryptedData[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return encryptedData;
    }

    private string Decrypt(byte[] data)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(_encryptionKey);
        byte[] decryptedData = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            decryptedData[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Encoding.UTF8.GetString(decryptedData);
    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public Level currentLevel;
}
