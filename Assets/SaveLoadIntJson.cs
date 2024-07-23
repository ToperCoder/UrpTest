using UnityEngine;
using TMPro;

[System.Serializable]
public class IntData
{
    public int value;
}

public class SaveLoadIntJson : MonoBehaviour
{
    public TMP_Text textPro;
    public int score;
    private string Key = "IntData";

    void Start() {
        score = LoadInt();
        textPro.text = "Your score:"+score;
    }

    public void SaveInt(int number)
    {
        IntData data = new IntData { value = score + number };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, json);
        PlayerPrefs.Save();
        
        score = data.value;
        textPro.text = "Your score:" + data.value;
    }

    public int LoadInt()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string json = PlayerPrefs.GetString(Key);
            IntData data = JsonUtility.FromJson<IntData>(json);
            return data.value;
        }
        return 0;
    }
}
