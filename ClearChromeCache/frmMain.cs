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

namespace ClearChromeCache
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string folder = dialog.SelectedPath;

                Task.Run(() =>
                {
                    string[] defaults = Directory.GetDirectories(folder, "Default", SearchOption.AllDirectories);
                    foreach (var profile in defaults)
                    {
                        labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = profile; });
                        string cache = profile + "\\Cache\\Cache_Data";
                        string code_cache1 = profile + "\\Code Cache\\js";
                        string code_cache2 = profile + "\\Code Cache\\wasm";
                        string gpu_cache = profile + "\\GPUCache";
                        if (Directory.Exists(cache))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Clear Cache"; });
                            Directory.Delete(cache, true);
                        }
                        if (Directory.Exists(code_cache1))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Code Cache js"; });
                            Directory.Delete(code_cache1, true);
                        }
                        if (Directory.Exists(code_cache2))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Code Cache wasm"; });
                            Directory.Delete(code_cache2, true);
                        }
                        if (Directory.Exists(gpu_cache))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "GPUCache"; });
                            foreach (var item in Directory.GetFiles(gpu_cache))
                            {
                                File.Delete(item);
                            }
                        }
                    }
                    string[] profiles = Directory.GetDirectories(folder, "Profile ", SearchOption.AllDirectories);
                    foreach (var profile in profiles)
                    {
                        labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = profile; });
                        string cache = profile + "\\Cache\\Cache_Data";
                        string code_cache1 = profile + "\\Code Cache\\js";
                        string code_cache2 = profile + "\\Code Cache\\wasm";
                        string gpu_cache = profile + "\\GPUCache";
                        if (Directory.Exists(cache))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Clear Cache"; });
                            Directory.Delete(cache, true);
                        }
                        if (Directory.Exists(code_cache1))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Code Cache js"; });
                            Directory.Delete(code_cache1, true);
                        }
                        if (Directory.Exists(code_cache2))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Code Cache wasm"; });
                            Directory.Delete(code_cache2, true);
                        }
                        if (Directory.Exists(gpu_cache))
                        {
                            labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "GPUCache"; });
                            foreach (var item in Directory.GetFiles(gpu_cache))
                            {
                                File.Delete(item);
                            }
                        }
                    }
                    labelStatus.Invoke((MethodInvoker)delegate { labelStatus.Text = "Clear Done"; });
                    MessageBox.Show("Clear Done");
                });
            }
        }
    }
}
