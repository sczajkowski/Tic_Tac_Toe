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
using Newtonsoft.Json;

namespace Menu
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Remove(path.Length - 14, 14);
            path = path + "winners.json";
            string fileName = path;

            string chkString = fileName.Substring(fileName.Length - 5);
            
                    StreamReader r = new StreamReader(fileName);
                    try
                    {
                        var json = r.ReadToEnd();
                        var app = JsonConvert.DeserializeObject<App>(json);
                        r.Close();
                        r.Dispose();
                        var winners = app.Winners;
                        foreach(var item in winners)
                        {
                            lbxR.Items.Add(item);
                        }

                    }
                    catch
                    {
                        MessageBox.Show("winners.json missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
        }
    }
}
