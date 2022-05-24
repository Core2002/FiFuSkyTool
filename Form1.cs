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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            IsLand island;
            textBox1.BackColor = SystemColors.Window;
            try
            {
                island = Sky.GetIsland(textBox1.Text);
                label5.Text = island.GetInfo();
            }
            catch (Exception)
            {
                textBox1.BackColor = Color.Red;
                label5.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://www.fifu.fun");
        }
    }
}