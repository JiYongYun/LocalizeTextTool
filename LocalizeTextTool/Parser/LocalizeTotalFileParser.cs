using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LocalizeTotalFileParser
{
    public List<string> OpenBinaryFile(string fileName)
    {
        Dictionary<string, string> stringList = new Dictionary<string, string>();

        FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(file);

        int count = br.ReadInt32();
        string key = "";
        string value = "";

        for (int index = 0; index < count; ++index)
        {
            key = br.ReadString();
            value = br.ReadString();

            if (value != " ")
                stringList.Add(key, value);
            else
                stringList.Add(key, "");
        }

        br.Close();

        return stringList.Values.ToList();
    }

    public bool SaveBinaryFile(string fileName, Dictionary<string, string> fileListData)
    {
        if (fileListData.Count < 1)
            return false;

        FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(file);

        Int32 count = fileListData.Count;
        bw.Write(count);

        foreach (KeyValuePair<string, string> name in fileListData)
        {
            bw.Write(name.Key);

            if (name.Value != "")
                bw.Write(name.Value);
            else
            {
               string dummyString = " ";
               bw.Write(dummyString);
            }
        }

        bw.Close();

        return true;
    }
}
