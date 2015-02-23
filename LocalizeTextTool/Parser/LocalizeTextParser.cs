using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class LocalizeStringParser
{
    private Dictionary<string, string> stringTableMap = new Dictionary<string, string>();
    public Dictionary<string, string> GetTableData()    { return stringTableMap; }

    public void OpenTextFile(string fileName)
    {
        stringTableMap.Clear();
        StreamReader sr = new StreamReader(fileName);
        string sLineString;
        string key = "";
        string val = "";
        int lineCount = 0;

        while (!sr.EndOfStream)
        {
            sLineString = sr.ReadLine();
            lineCount++;

            if (sLineString.Length == 0)
                continue;


            if (sLineString[0] == '#')
            {   // #이 들어간건 주석내용
                key = sLineString;
                val = "";
            }
            else
            {   // key와 string값
                int idx = sLineString.IndexOf('=');
                if (idx == -1)
                {
                    MessageBox.Show( lineCount + " : Line\nCant find \"=\"\n file : " + fileName);
                    continue;
                }

                key = sLineString.Substring(0, idx);
                val = sLineString.Substring(idx + 1);

                if (key.Length == 0 )
                {
                    MessageBox.Show( lineCount + " : Line\n key is null. file : " + fileName);
                    continue;
                }
                else if (val.Length == 0)
                {
                    MessageBox.Show(lineCount + " : Line\n value is null. file : " + fileName);
                    continue;
                }
//                val = val.Replace("\\n", "\n");
            }

            if (stringTableMap.ContainsKey(key))
                stringTableMap.Remove(key);

            stringTableMap.Add(key, val);
        }

        sr.Close();

    }

    public bool SaveTextFile(string fileName, Dictionary<string, string> localTableData)
    {
        if (localTableData.Count < 1)
            return false;

        if (fileName == "")
            return false;


        FileStream file = new FileStream(fileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(file);

        string key;
        string val;

        foreach (KeyValuePair<string, string> Item in localTableData)
        {
            key = Item.Key;
            val = Item.Value;

            if (key[0] == '#')
            {   // 주석문은 그대로
                sw.WriteLine("{0}", key);
            }
            else
            {   // 스트링
                if (val == "")
                    continue;

//                val = val.Replace("\n", "\\n");

                sw.WriteLine("{0}={1}", key, val);
            }
        }

        sw.Close();
 
        return true;
    }

    public void OpenBinaryFile(string fileName)
    {
        stringTableMap.Clear();

        FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(file);

        string sLineString = "";
        string key = "";
        string val = "";

        long index = 0;

        while (true)
        {
            index = br.BaseStream.Position;

            if (index >= br.BaseStream.Length)
                break;

            sLineString = br.ReadString();
            if (sLineString[0] == '#')
            {
                key = sLineString;
                val = "";
            }
            else
            {
                key = sLineString;
                sLineString = br.ReadString();
                val = sLineString;
            }

//            val = val.Replace("\\n", "\n");

            if (stringTableMap.ContainsKey(key))
                stringTableMap.Remove(key);

            stringTableMap.Add(key, val);
        }
        br.Close();
    }

    public bool SaveBinaryFile(string fileName, Dictionary<string, string> localTableData)
    {
        if (localTableData.Count < 1)
            return false;

        FileStream file = new FileStream(fileName, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(file);

        string key;
        string val;

        foreach (KeyValuePair<string, string> Item in localTableData)
        {
            key = Item.Key;
            val = Item.Value;

            if (key[0] == '#')
            {   // 주석문은 그대로
                bw.Write(key);
            }
            else
            {   // 스트링
                if (val == "")
                    continue;

//                val = val.Replace("\n", "\\n");

                bw.Write(key);
                bw.Write(val);
            }
        }

        bw.Close();

        return true;
    }

}
