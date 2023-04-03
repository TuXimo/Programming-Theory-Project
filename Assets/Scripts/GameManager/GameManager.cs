using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameManager
{
    public class GameManager : MonoBehaviour {

        [SerializeField] Text lastNameText;
        [SerializeField] InputField nameField;

        public string playerName;
        public static GameManager Instance;

        private void Awake() {
            if(Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadGameInfo();
        }

        private void Start() {
            if(playerName != "")
            {
                lastNameText.text = "User: " + playerName;
            }
        }

        public void SetName() {
            playerName = name;
            SaveGameInfo();
            Debug.Log("Player: " + name);
        }

        public void StartNew() {
            if(nameField.text != "") {
                name = nameField.text;
                SceneManager.LoadScene(1);
            } else {
                Debug.LogWarning("Please enter a name!");
            }

            SetName();
        }

        public void Exit() {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
        }

        [System.Serializable]
        class SaveData {
            public string name;
        }

        public void SaveGameInfo() {
            SaveData data = new SaveData();
            data.name = playerName;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        public void LoadGameInfo() {
            string path = Application.persistentDataPath + "/savefile.json";

            if(File.Exists(path)) {
                string json = File.ReadAllText(path);

                SaveData data = JsonUtility.FromJson<SaveData>(json);

                playerName = data.name;
            }
        }
    }
}