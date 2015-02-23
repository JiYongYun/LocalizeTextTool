using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DataClass
{
    private int nLocalTypeMax;

    // 로컬 데이타 종류(한국, 대만)
    private List<string> localTypeList = new List<string>();

    // 읽은 로컬데이터 파일이름
    private Dictionary<string, string> localFileNameMap = new Dictionary<string, string>();

    // 로컬 데이터
    private List<Dictionary<string, string>> localDataList = new List<Dictionary<string, string>>();

    public int LocalTypeDataCount() { return nLocalTypeMax; }
    public Dictionary<string, string> GetOpenLocalFileMap() { return localFileNameMap; }
    public List<string> GetOpenLocalFileList() { return localFileNameMap.Values.ToList(); }
    public List<string> GetLocalTypeList() { return localTypeList; }
    public List<Dictionary<string, string>> GetAllLocalData() { return localDataList; }

    public DataClass()
    {
        localTypeList.Add("한국");
        localTypeList.Add("대만");

        nLocalTypeMax = localTypeList.Count;

        for (int index = 0; index < nLocalTypeMax; ++index)
        {
            localFileNameMap.Add(localTypeList[index], "");

            Dictionary<string, string> localData = new Dictionary<string, string>();
            localDataList.Add(localData);
        }
    }

    /// <summary>
    /// 해당 로컬라이즈 텍스트 데이터 추가 :
    /// key = id, localType = ListBox index, valueString = string
    /// </summary>
    public void AddLocalData(string keyString, int localType, string valueString)
    {
        if (localType >= localDataList.Count)
            return;

        Dictionary<string, string> localData = localDataList[localType];
        if (localData.ContainsKey(keyString))
        {
            localData[keyString] = valueString;
        }
        else
        {
            localData.Add(keyString, valueString);
        }
    }

    /// <summary>
    /// 해당 로컬라이즈 텍스트 데이터 가져오기 :
    /// localType = ListBox index
    /// </summary>
    public Dictionary<string, string> GetLocalData(int localType)
    {
        Dictionary<string, string> dummyLocalData = localDataList[localType];

        return dummyLocalData;
    }

    public void ClearLocalData(int localType)
    {
        Dictionary<string, string> dummyLocalData = localDataList[localType];
        dummyLocalData.Clear();
    }

    public void SetOpenLocalFileName(int localType, string fileName)
    {
        string key = localTypeList[localType];
        localFileNameMap[key] = fileName;
    }

    public void ClearAllLocalData()
    {
        localDataList.Clear();

        for (int index = 0; index < nLocalTypeMax; ++index)
        {
            Dictionary<string, string> localData = new Dictionary<string, string>();
            localDataList.Add(localData);
        }
    }
}
