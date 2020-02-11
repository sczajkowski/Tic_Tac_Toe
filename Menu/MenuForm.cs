using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;
using Newtonsoft.Json;
using System.IO;

namespace Menu
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            try
            {

                var p1 = new Player(tbxP1.Text);
                p1.Validate();
                var p2 = new Player(tbxP2.Text);
                p2.Validate();
                if(p1.Name == p2.Name)
                {
                    throw new Exception("Player names are the same");
                }
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Game.GameForm GameF = new Game.GameForm())
            {
                GameF.p1 = tbxP1.Text;
                GameF.p2 = tbxP2.Text;
                GameF.ShowDialog(this);
                var win = new Winner(GameF.winner, GameF.w_count,GameF.o_count, GameF.opponent);
                MessageBox.Show($"{GameF.winner} won", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    path = path.Remove(path.Length-14,14);
                    path = path+"winners.json";
                    string fileName = path;

                    StreamReader r = new StreamReader(fileName);
                    var json = r.ReadToEnd();
                    var app = JsonConvert.DeserializeObject<App>(json);
                    r.Dispose();
                    r.Close();
                    (app.Winners).Add(win as Winner);

                    using StreamWriter streamWriter = new StreamWriter(fileName);

                    var save = JsonConvert.SerializeObject(app);

                    streamWriter.Write(save);
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
                catch
                {
                    MessageBox.Show("winners.json missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BtnResults_Click(object sender, EventArgs e)
        {
            using (ResultsForm ResultForm = new ResultsForm())
            {
                ResultForm.ShowDialog(this);
            }
        }
    }
}
