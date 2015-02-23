using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomListView;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using System.Runtime.InteropServices;

namespace LocalizeTextTool
{
    public partial class MainForm : Form
    {
        private LocalizeStringParser textParser = new LocalizeStringParser();
        private LocalizeTotalFileParser locParser = new LocalizeTotalFileParser();
        private DataClass dataClass = new DataClass();

        private bool bChanged = false;
        private int nLocalListSelectIndex = -1;
        private ListViewItem lastListViewItem;

        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        public MainForm()
        {
            InitializeComponent();
            SetInitData();

            listBox1.SelectedIndex = 0;
            listViewEx1.AddSubItem = false;

            listViewEx1.AddEditableCell( -1, 0 );
			listViewEx1.AddEditableCell( -1, 1 );
            listViewEx1.AddEditableCell( -1, 2 );
        }

        ~MainForm()
        {
            Dispose();
        }

        public T CopyData<T>(object obj)
        {
            MemoryStream memStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(memStream, obj);
            memStream.Seek(0, 0);

            return (T)formatter.Deserialize(memStream);
        }

        public void FindText(string text, bool textType)
        {
            string dummyString;
            for (int i = 0; i < listViewEx1.Items.Count; ++i)
            {
                for(int j = 0; j < listViewEx1.Items[i].SubItems.Count; ++j)
                {
                    dummyString = listViewEx1.Items[i].SubItems[j].Text;

                    if( dummyString.Contains(text))
                    {
                        MessageBox.Show("index : " + i + " subindex : " + j);
                    }
                }
            }

        }

        public void AllChangeText(string orginText, string changeText, bool textType)
        {
            string dummyString;

            for (int i = 0; i < listViewEx1.Items.Count; ++i)
            {
                for (int j = 0; j < listViewEx1.Items[i].SubItems.Count; ++j)
                {
                    dummyString = listViewEx1.Items[i].SubItems[j].Text;

                    if (dummyString.Contains(orginText))
                    {
                        listViewEx1.Items[i].SubItems[j].Text = dummyString.Replace(orginText, changeText);
                        ;

                        listViewEx1.Items[i].ForeColor = System.Drawing.Color.Red;
                        bChanged = true;
                    }
                }
            }

            listViewEx1.Update();
        }

        private void SetInitData()  // 데이터 초기화 맟 기본적인데이터 세팅
        {
            List<string> typeList = dataClass.GetLocalTypeList();

            foreach (string Item in typeList)
            {
                listBox1.Items.Add(Item);
                listViewEx1.Columns.Add(Item, 300);
            }
        }

        private void SetLocalData(string fileName, int listSelectIndex) // 데이터클래스에 데이터 세팅
        {
            dataClass.SetOpenLocalFileName(listSelectIndex, fileName);

            // Data 세팅
            textParser.OpenTextFile(fileName);

            Dictionary<string, string> stringTableMap = textParser.GetTableData();

            dataClass.ClearLocalData(listSelectIndex);

            foreach (KeyValuePair<string, string> Item in stringTableMap)
                dataClass.AddLocalData(Item.Key, listSelectIndex, Item.Value);
        }

        private void SetListView()  // 툴 업데이트
        {
            listViewEx1.Items.Clear();

            // ListView 세팅
            List<Dictionary<string, string>> localData = dataClass.GetAllLocalData();
            int maxCount = dataClass.LocalTypeDataCount();

            for (int index = 0; index < maxCount; ++index)
            {
                foreach (KeyValuePair<string, string> Item in localData[index])
                {
                    if (listViewEx1.Items.ContainsKey(Item.Key))
                    {
                        ListViewItem listItem = listViewEx1.Items[Item.Key];
                        listItem.SubItems[index + 1].Text = Item.Value;
                    }
                    else
                    {
                        ListViewItem listItem = new ListViewItem(Item.Key);

                        if (Item.Key[0] == '#')
                        {
                            listItem.ForeColor = System.Drawing.Color.DarkOrange;
                        }

                        for (int count = 0; count < maxCount; ++count)
                            listItem.SubItems.Add("");

                        listItem.SubItems[index + 1].Text = Item.Value;
                        listItem.Name = Item.Key;
                        listViewEx1.Items.Add(listItem);
                    }
                }
            }

            listViewEx1.Update();
        }

        private void SetFormLabel()
        {
            List<string> localTypeList = dataClass.GetLocalTypeList();
            List<string> fileList = dataClass.GetOpenLocalFileList();

            string dummyLocalTypeName = "";
            string dummyFileName = "";


            for(int index = 0; index < dataClass.LocalTypeDataCount() ; ++index)
            {
                StringBuilder builder = new StringBuilder( 256 );

                dummyLocalTypeName = localTypeList[index];

                if (fileList[index] == "")
                    continue;

                int stringIndex = fileList[index].LastIndexOf("\\");
                dummyFileName = fileList[index].Substring(stringIndex + 1);

                builder.Append(dummyLocalTypeName);
                builder.Append(" : " );
                builder.Append(dummyFileName);

                listViewEx1.Columns[index+1].Text = builder.ToString();
            }
        }

        private void SaveLocalData(string fileName, int selectListIndex)
        {
            foreach (ListViewItem items in listViewEx1.Items)
            {
                dataClass.AddLocalData(items.Text, selectListIndex, items.SubItems[selectListIndex + 1].Text);
            }

            Dictionary<string, string> localData = dataClass.GetLocalData(selectListIndex);

            bool bSuccess = true;
            if( fileName != "")
                bSuccess = textParser.SaveTextFile(fileName, localData);

            if( bSuccess )
                MessageBox.Show("저장에 성공하였습니다.");
            else
                MessageBox.Show("저장에 실패하였습니다.");
               
        }

        private void totalOpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.Filter = "Local Project Files(*.lcp) |*.lcp| All Files(*.*) | *.*";
            odlg.FilterIndex = 1;

            if (odlg.ShowDialog() == DialogResult.OK)
            {
                List<string> fileList = locParser.OpenBinaryFile(odlg.FileName);
                for (int count = 0; count < fileList.Count; ++count )
                    SetLocalData(fileList[count], count);

                SetListView();
                SetFormLabel();
            }
        }

        private void totalSaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.FileName = "";
            sdlg.Filter = "Local Project Files(*.lcp)|*.lcp";
            sdlg.FilterIndex = 1;

            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                locParser.SaveBinaryFile(sdlg.FileName, dataClass.GetOpenLocalFileMap());
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("국가를 선택해 주세요");
                return;
            }

            OpenFileDialog odlg = new OpenFileDialog();
            odlg.Filter = "Text Files(*.txt) |*.txt| All Files(*.*) | *.*";
            odlg.FilterIndex = 1;

            if (odlg.ShowDialog() == DialogResult.OK)
            {
                SetLocalData(odlg.FileName, nLocalListSelectIndex);
                SetListView();
                SetFormLabel();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("국가를 선택해 주세요");
                return;
            }

            List<string> fileList = dataClass.GetOpenLocalFileList();

            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.FileName = fileList[nLocalListSelectIndex];
            sdlg.Filter = "Text Files(*.txt)|*.txt";
            sdlg.FilterIndex = 1;

            if (sdlg.ShowDialog() == DialogResult.OK)
                SaveLocalData(sdlg.FileName, nLocalListSelectIndex);
        }

        private void addLocTypeBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("국가를 선택해 주세요");
                return;
            }

            MessageBox.Show("미 작업");
        }

        private void delLocalTypeBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("국가를 선택해 주세요");
                return;
            }

            dataClass.ClearAllLocalData();
            listViewEx1.Items.Clear();
            listViewEx1.Update();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( bChanged )
            {
                //폼을 닫을건지 취소 할 것인지 결정
                DialogResult dr = MessageBox.Show("수정한 내용이 저장되지 않았습니다.\n 저장하시겠습니까?", "종료확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    List<string> fileList = dataClass.GetOpenLocalFileList();

                    for (int count = 0; count < fileList.Count; ++count)
                        SaveLocalData(fileList[count], count);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nLocalListSelectIndex = listBox1.SelectedIndex;
        }

        private void listViewEx1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                lastListViewItem = CopyData<ListViewItem>(e.Item);
            }
            else
            {
                if( lastListViewItem == null)
                    return;

                for (int index = 0; index < lastListViewItem.SubItems.Count; ++index )
                {
                    if ( lastListViewItem.SubItems[index].Text != e.Item.SubItems[index].Text )
                    {
                        e.Item.ForeColor = System.Drawing.Color.Red;
                        bChanged = true;
                    }
                }

                lastListViewItem = null;
            }
        }

        private void allSaveBtn_Click(object sender, EventArgs e)
        {
            List<string> fileList = dataClass.GetOpenLocalFileList();

            for (int count = 0; count < fileList.Count; ++count)
                SaveLocalData(fileList[count], count);
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            ModalForm modalForm = new ModalForm(this);
            modalForm.Show();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            ModalForm modalForm = new ModalForm(this);
            modalForm.Show();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == (int)0x312)
            {
                if( m.WParam == (IntPtr)1)
                    totalOpenBtn_Click(null, null);
                if (m.WParam == (IntPtr)2)
                    totalSaveBtn_Click(null, null);
                if (m.WParam == (IntPtr)3)
                    openBtn_Click(null, null);
                if (m.WParam == (IntPtr)4)
                    saveBtn_Click(null, null);
                if (m.WParam == (IntPtr)5)
                    allSaveBtn_Click(null, null);
                if (m.WParam == (IntPtr)6)
                    delLocalTypeBtn_Click(null, null);
                if (m.WParam == (IntPtr)7)
                    findBtn_Click(null, null);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            RegisterHotKey((int)this.Handle, 1, 0x2, (int)Keys.E);
            RegisterHotKey((int)this.Handle, 2, 0x2, (int)Keys.W);
            RegisterHotKey((int)this.Handle, 3, 0x2, (int)Keys.O);
            RegisterHotKey((int)this.Handle, 4, 0x2, (int)Keys.S);
            RegisterHotKey((int)this.Handle, 5, 0x2, (int)Keys.A);
            RegisterHotKey((int)this.Handle, 6, 0x2, (int)Keys.R);
            RegisterHotKey((int)this.Handle, 7, 0x2, (int)Keys.F);
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            UnregisterHotKey((int)this.Handle, 1);
            UnregisterHotKey((int)this.Handle, 2);
            UnregisterHotKey((int)this.Handle, 3);
            UnregisterHotKey((int)this.Handle, 4);
            UnregisterHotKey((int)this.Handle, 5);
            UnregisterHotKey((int)this.Handle, 6);
            UnregisterHotKey((int)this.Handle, 7);
        }
    }
}
