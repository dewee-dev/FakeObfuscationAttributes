using System;
using System.IO;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace FakeObfuscationAttributes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region DragDrop
        public string DirectoryName = "";
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (array != null)
                {
                    string text = array.GetValue(0).ToString();
                    int num = text.LastIndexOf(".", StringComparison.Ordinal);
                    if (num != -1)
                    {
                        string text2 = text.Substring(num);
                        text2 = text2.ToLower();
                        if (text2 == ".exe" || text2 == ".dll")
                        {
                            Activate();
                            textBox1.Text = text;
                            int num2 = text.LastIndexOf("\\", StringComparison.Ordinal);
                            if (num2 != -1)
                            { DirectoryName = text.Remove(num2, text.Length - num2); }
                            if (DirectoryName.Length == 2)
                            { DirectoryName += "\\"; }
                        }
                    }
                }
            }
            catch { }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            { e.Effect = DragDropEffects.Copy; }
            else
            { e.Effect = DragDropEffects.None; }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the file is empty
            if (textBox1.Text == "")
            {
                MessageBox.Show("Drag / Drop the file.", "Prab#3268");
            }

            ModuleDefMD module = ModuleDefMD.Load(textBox1.Text);

            // ConfuserEx
            if (CfexPro.Checked)
            {
                Fake.confuserex(module.Assembly);
            }
            // babel
            if (babelpro.Checked)
            {
                Fake.babel(module.Assembly);
            }
            // dotfuscator
            if (dotfuscatorpro.Checked)
            {
                Fake.dotfuscator(module.Assembly);
            }
            // ninerays
            if (ninerayspro.Checked)
            {
                Fake.ninerays(module.Assembly);
            }
            // mango
            if (mangopro.Checked)
            {
                Fake.mango(module.Assembly);
            }
            // bithelmet
            if (bithelmetpro.Checked)
            {
                Fake.bithelmet(module.Assembly);
            }
            // crypto
            if (cryptopro.Checked)
            {
                Fake.crypto(module.Assembly);
            }
            // yano
            if (yanopro.Checked)
            {
                Fake.yano(module.Assembly);
            }
            // dnguard
            if (dnguardpro.Checked)
            {
                Fake.dnguard(module.Assembly);
            }
            // goliath
            if (goliathpro.Checked)
            {
                Fake.goliath(module.Assembly);
            }
            // agile
            if (agilepro.Checked)
            {
                Fake.agile(module.Assembly);
            }
            // smartassembly
            if (smartassemblypro.Checked)
            {
                Fake.smartassembly(module.Assembly);
            }
            // xenocode
            if (xenocodepro.Checked)
            {
                Fake.xenocode(module.Assembly);
            }

            #region Path
            string text2 = Path.GetDirectoryName(textBox1.Text);

            if (!text2.EndsWith("\\"))
            {
                text2 += "\\";
            }
            string path = text2 + Path.GetFileNameWithoutExtension(textBox1.Text) + "_WithFakeObfuscationAttributes" + Path.GetExtension(textBox1.Text);

            var opts = new ModuleWriterOptions(module);

            opts.PEHeadersOptions.NumberOfRvaAndSizes = 13;

            opts.MetadataOptions.TablesHeapOptions.ExtraData = 0x1337;

            opts.Logger = DummyLogger.NoThrowInstance;
            module.Write(path, opts);
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                CfexPro.Checked = true;
                babelpro.Checked = true;
                dotfuscatorpro.Checked = true;
                ninerayspro.Checked = true;
                mangopro.Checked = true;
                bithelmetpro.Checked = true;
                cryptopro.Checked = true;
                yanopro.Checked = true;
                dnguardpro.Checked = true;
                goliathpro.Checked = true;
                agilepro.Checked = true;
                smartassemblypro.Checked = true;
                xenocodepro.Checked = true;
            }

            if (checkBox1.Checked == false)
            {
                clearProtections();
            }
        }
        public void clearProtections()
        {
            CfexPro.Checked = false;
            babelpro.Checked = false;
            dotfuscatorpro.Checked = false;
            ninerayspro.Checked = false;
            mangopro.Checked = false;
            bithelmetpro.Checked = false;
            cryptopro.Checked = false;
            yanopro.Checked = false;
            dnguardpro.Checked = false;
            goliathpro.Checked = false;
            agilepro.Checked = false;
            smartassemblypro.Checked = false;
            xenocodepro.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                clearProtections();
            }
        }
    }
}
