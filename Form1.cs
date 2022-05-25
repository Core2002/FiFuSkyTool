namespace FiFu空岛相关工具_第二弹_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            IsLand island;
            textBox2.BackColor = SystemColors.Window;
            try
            {
                var t = textBox2.Text.Split(',');
                (int, int) Loc = (int.Parse(t[0]), int.Parse(t[1]));
                (int, int) SkyLoc = (Sky.GetSkyR(Loc.Item1), Sky.GetSkyR(Loc.Item2));
                island = Sky.GetIsland(SkyLoc.Item1, SkyLoc.Item2);
                if (island.IsOverflow())
                    textBox2.BackColor = Color.Yellow;
                textBox3.Text = island.ToLocString();
            }
            catch (Exception)
            {
                textBox2.BackColor = Color.Red;
                textBox3.Text = "";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IsLand island;
            textBox1.BackColor = SystemColors.Window;
            try
            {
                island = Sky.GetIsland(textBox1.Text);
                if (island.IsOverflow())
                    textBox1.BackColor = Color.Yellow;
                textBox4.Text = island.GetInfo();
            }
            catch (Exception)
            {
                textBox1.BackColor = Color.Red;
                textBox4.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.fifu.fun");
        }
    }
}