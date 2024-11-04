using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace MyFps
{
    //게임 데이터 파일 저장/가져오기 구현 - 이진화 
    public static class SaveLoad
    {
        public static void SaveData()
        {
            //파일이름,경로지정
            string path = Application.persistentDataPath + "/playData.dat";

            //저장할 데이터를 이진화 준비
            BinaryFormatter formatter = new BinaryFormatter();
            //파일접근 - 존재하면 파일 가져오기 , 존재하지 않으면 파일 새로 생성
            FileStream fs = new FileStream(path,FileMode.Create);

            //저장할 데이터 셋팅
            PlayData playData = new PlayData();
            Debug.Log($"Save SceneNumber: {playData.sceneNumber}");

            //준비한 데이터를 이진화 저장
            formatter.Serialize(fs, playData);

            fs.Close();
        }
        public static PlayData LoadData()
        {
            PlayData playData;

            //파일이름,경로지정
            string path = Application.persistentDataPath + "/playData.dat";

            //파일이 존재하는지 확인
            if (File.Exists(path))
            {
                //저장된 데이터를 이진화 준비
                BinaryFormatter formatter = new BinaryFormatter();

                //파일 접근 - 파일 열기
                FileStream fs = new FileStream(path, FileMode.Open);

                //파일에서 데이터를 이진화로 불러오기
                playData = formatter.Deserialize(fs) as PlayData;

                fs.Close();

                Debug.Log($"Load SceneNumber: {playData.sceneNumber}");
                return playData;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null; // 파일이 없을 경우 null 반환
            }

            
        }
        public static void DeleteData()
        {
            string path = Application.persistentDataPath + "/playData.dat";

            if (File.Exists(path))
            {
                File.Delete(path);
                Debug.Log("Save file deleted successfully.");
            }
            else
            {
                Debug.LogWarning("Save file not found, nothing to delete.");
            }
        }
    }
}