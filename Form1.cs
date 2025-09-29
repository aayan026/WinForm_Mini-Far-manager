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
            comboBox1.Items.Add("D:\\");
            comboBox1.Items.Add("C:\\");
            comboBox1.SelectedIndex = 1;
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
            string disk = comboBox1.SelectedItem.ToString();
            string sourcePath = Path.Combine(disk, fileName);
            string destDisk = (disk == @"C:\") ? @"D:\" : @"C:\";
            string destPath = Path.Combine(destDisk, Path.GetFileName(sourcePath));

            ListBox sourceListBox = (disk == @"C:\") ? listBox2 : listBox1;
            ListBox destListBox = (disk == @"C:\") ? listBox1 : listBox2;

            if (!sourceListBox.Items.Contains(fileName))
                MessageBox.Show("File not found");
            else
            {
                if (Directory.Exists(sourcePath))
                {
                    try
                    {
                        DirectoryCopy(sourcePath, destPath, true);
                        Directory.Delete(sourcePath, true);
                        sourceListBox.Items.Remove(fileName);
                        destListBox.Items.Add(fileName);
                        MessageBox.Show($"File moved from {disk} to {destDisk}!");

                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access denied! Cannot move this folder.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            bool found = false;
            string disk = comboBox1.SelectedItem.ToString();
            string sourcePath = Path.Combine(disk, fileName);
            string destDisk = (disk == @"C:\") ? @"D:\" : @"C:\";
            string destPath = Path.Combine(destDisk, Path.GetFileName(sourcePath));

            ListBox sourceListBox = (disk == @"C:\") ? listBox2 : listBox1;
            ListBox destListBox = (disk == @"C:\") ? listBox1 : listBox2;

            if (!sourceListBox.Items.Contains(fileName))
                MessageBox.Show("File not found");
            else
            {
                if (Directory.Exists(sourcePath))
                {
                    DirectoryCopy(sourcePath, destPath, true);
                    destListBox.Items.Add(fileName);
                    MessageBox.Show($"File copied from {disk} to {destDisk}!");
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
