namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFiles(@"D:\", listBox1);

            LoadFiles(@"C:\", listBox2);
        }


        private void LoadFiles(string folderPath, ListBox listBox)
        {
            try
            {
                string[] subDirs = Directory.GetDirectories(folderPath);
                foreach (var dir in subDirs)
                {
                    listBox.Items.Add(Path.GetFileName(dir));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            bool found = false;

            string c = Path.Combine(@"C:\", fileName);
            string d = Path.Combine(@"D:\", fileName);
            foreach (var file in listBox2.Items)
            {
                if (file.ToString() == fileName)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                MessageBox.Show("File not found");
            else
            {
                if (Directory.Exists(c))
                {
                    DirectoryCopy(c, d,true);
                    listBox2.Items.Remove(fileName);
                    listBox1.Items.Add(fileName);
                    // Directory.Delete(c);
                    MessageBox.Show("File moved from C to D!");
                }
            }
        }
        private void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                MessageBox.Show("Source directory does not exist: ");

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDir);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDir, file.Name);
                file.CopyTo(tempPath, true);
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            bool found = false;

            string c = Path.Combine(@"C:\", fileName);
            string d = Path.Combine(@"D:\", fileName);
            foreach (var file in listBox2.Items)
            {
                if (file.ToString() == fileName)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                MessageBox.Show("File not found");
            else
            {
                if (Directory.Exists(c))
                {  
                    DirectoryCopy(c, d, true);
                    listBox1.Items.Add(fileName);
                    MessageBox.Show("File copied from C to D!");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
