namespace AsyncAndAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int CountCharacter()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("D:\\Textbox\\logic.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }
            return count;
        }
        private async void btnProcessFile_Click(object sender, EventArgs e)
        {
            Task<int> taskAsync = new Task<int>(CountCharacter);
            taskAsync.Start();
            lblCount.Text = "Processing File.Please Wait....";
            //int count = CountCharacter();
            int count = await taskAsync;
            lblCount.Text = count.ToString() + "Characters in File";
        }
    }
}