using System;
using System.IO;
using UnityEngine;

namespace DarkFramework
{
    public class DataManager : MonoBehaviour
    {
        public LocalData m_LocalData;
        
        string SavePath => $"{Application.persistentDataPath}/LocalData.json";

        private void Start()
        {
            LoadData();
        }

        private void LoadData()
        {
            m_LocalData = new LocalData();
            
            if (File.Exists(SavePath)) 
            {
                Debug.Log($"<color=olive>Reading local data json</color>");

                try
                {
                    JsonUtility.FromJsonOverwrite(File.ReadAllText(SavePath), m_LocalData);
                } 
                catch (Exception e)
                {
                    Debug.LogError($"<color=olive>Unable to parse data from existing json, a new set of data will be created: {e.Message}</color>");
                    m_LocalData = new LocalData(); //Can happen when data is broken or file has been tampered
                }
            }

            m_LocalData.ClampVariables(); //Prevents tampering
            WriteLocalFile(); //Writes a new set of data, or overwrites/deletes any unused variables/adds any new variables
        }
        
        /// <summary> Overrides json file with local data instance </summary>
        private void WriteLocalFile()
        {
            File.WriteAllText(SavePath, JsonUtility.ToJson(m_LocalData));
        }
    }
}