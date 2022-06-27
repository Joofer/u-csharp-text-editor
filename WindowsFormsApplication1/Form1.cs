using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    richTextBox1.Text = "";
                    FileCreate();
                    break;
                case 2:
                    FileRead();
                    break;
                case 3:
                    FileWrite();
                    break;
                case 4:
                    WriteAs();
                    break;
                case 5:
                    FileEncrypt();
                    break;
                case 6:
                    FileDecrypt();
                    break;
            }
            Form1.ActiveForm.Text = openFileDialog1.FileName;
        }

        private void FileCreate()
        {
            StreamWriter stream;

            saveFileDialog1.Filter = "txt files(*.txt)|*txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                stream = File.CreateText(saveFileDialog1.FileName + ".txt");
                openFileDialog1.FileName = saveFileDialog1.FileName + ".txt";
                stream.Close();
            }
        }

        private void FileRead()
        {
            StreamReader stream;
            string file = "";
            string s;

            openFileDialog1.Filter = "txt files(*.txt)|*txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                file = openFileDialog1.FileName;
            }

            if (file != "")
            {
                stream = File.OpenText(file);
                s = stream.ReadToEnd();
                stream.Close();

                richTextBox1.Text = s;
            }
        }

        private void FileWrite()
        {
            StreamWriter stream;
            string file = "";
            string s;

            s = richTextBox1.Text;

            if (openFileDialog1.CheckFileExists == false)
            {
                openFileDialog1.Filter = "txt files(*.txt)|*txt";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    file = openFileDialog1.FileName;
                }
            }
            else
            {
                file = openFileDialog1.FileName;
            }

            stream = File.CreateText(file);
            stream.Write(s);
            stream.Close();
        }

        private void WriteAs()
        {
            FileCreate();
            FileWrite();
        }

        private void FileEncrypt()
        {
            
        }

        private void FileDecrypt()
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Слов: " + (richTextBox1.Text.Split(' ').Length + richTextBox1.Text.Split('\n').Length - 1) + " абзацев: " + richTextBox1.Text.Split('\n').Length + " символов: " + richTextBox1.Text.Length;
        }
    }
}
