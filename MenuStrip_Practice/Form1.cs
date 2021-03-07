using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MenuStrip_Practice
{
    public partial class Form1 : Form
    {
        string path = string.Empty;
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Безымянный - Блокнот";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                textBox1.Text = File.ReadAllText(path);
                string name = string.Empty;

                for (int i = path.Length - 1; i > 0; i--)
                {
                   if (path[i] == '\\')
                    {
                        break;
                    }
                   else
                    {
                        name += path[i];
                    }
                }

                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                name = new string(arr);

                this.Text = $"{name} - Блокнот";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.Text != "Блокнот" && this.Text[0] != '*')
            {
                string name = "*" + this.Text;
                this.Text = name;
            }

            if ((sender as TextBox).Text != "")
            {
                отменитьToolStripMenuItem.Enabled = true;
                вырезатьToolStripMenuItem.Enabled = true;
                копироватьToolStripMenuItem.Enabled = true;
                вставитьToolStripMenuItem.Enabled = true;
            }
            else
            {
                отменитьToolStripMenuItem.Enabled = false;
                вырезатьToolStripMenuItem.Enabled = false;
                копироватьToolStripMenuItem.Enabled = false;
                вставитьToolStripMenuItem.Enabled = false;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != string.Empty)
            {
                File.WriteAllText(path, textBox1.Text);

                string name = string.Empty;
                for (int i = 1; i < this.Text.Length; i++)
                {
                    name += this.Text[i];
                }

                this.Text = name;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    File.WriteAllText(path, textBox1.Text);
                }

                path = saveFileDialog.FileName;
                //textBox1.Text = File.ReadAllText(path);
                string name = string.Empty;

                for (int i = path.Length - 1; i > 0; i--)
                {
                    if (path[i] == '\\')
                    {
                        break;
                    }
                    else
                    {
                        name += path[i];
                    }
                }

                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                name = new string(arr);

                this.Text = $"{name} - Блокнот";
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                File.WriteAllText(path, textBox1.Text);
            }          
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }
    }
}
