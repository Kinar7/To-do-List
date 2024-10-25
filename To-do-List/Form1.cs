using System;
using System.IO;
using System.Windows.Forms;


namespace To_do_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTasks();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void AddTask_Click(object sender, EventArgs e) // �������� �����/������
        {
            string task = textNewTask.Text.Trim(); // "Trim" ������� ������ � ������ � � �����

            if (!string.IsNullOrEmpty(task))  // �������� �� ������, ���� ��������� ���� �����
            {
                AdTask();
            }
            else
            {
                MessageBox.Show("������� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textNewTask_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListTask_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void DeleteTask_Click(object sender, EventArgs e) // ������� ��������� �����  
        {
            if (ListTask.SelectedItem != null)
            {
                ListTask.Items.Remove(ListTask.SelectedItem);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning); // �������� �� ������, ����� ����� �� ������
            }
        }

        private void ListTask_DoubleClick(object sender, EventArgs e) // ������� �������, ��� �� �������� ����������� ������
        {
            if (ListTask.SelectedItem != null)
            {
                int index = ListTask.SelectedIndex;
                string task = ListTask.SelectedItem.ToString();
                if (!task.StartsWith("[X] "))
                {
                    ListTask.Items[index] = "[X] " + task;
                }
                else
                {
                    ListTask.Items[index] = task.Substring(4);
                }
            }
        }

        private void SafeTask_Click(object sender, EventArgs e) // ��������� ���� �����
        {
            string filePath = "Task.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var item in ListTask.Items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
            MessageBox.Show("���������� ������ �������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTask_Click(object sender, EventArgs e)
        {
            string filePath = "Task.txt";
            if (File.Exists(filePath))
            {


                using (StreamReader sr = new StreamReader(filePath))
                {
                    string task;
                    while ((task = sr.ReadLine()) != null)
                    {
                        ListTask.Items.Add(task);
                    }
                }
                MessageBox.Show("�������� ������ �������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("��������� ������ �������� �����", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditTask_Click(object sender, EventArgs e)
        {
            EditSelectedTask();
        }

        private void EditSelectedTask()
        {
            if (ListTask.SelectedItem != null)
            {
                string selectedTask = ListTask.SelectedItem.ToString();
                string imput = Microsoft.VisualBasic.Interaction.InputBox("�������� ������: ", "��������������� ������", selectedTask);

                if (!string.IsNullOrEmpty(imput))
                {
                    int index = ListTask.SelectedIndex;
                    ListTask.Items[index] = imput;
                }
            }
            else
            {
                MessageBox.Show("���������� �������� ������ ��� ���������������", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string filePath = "Task.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in ListTask.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� ���������� �����: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadTasks()
        {
            try
            {
                string filePath = "Task.txt";

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string task;
                        while ((task = reader.ReadLine()) != null)
                        {
                            ListTask.Items.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("������ ��� �������� �����: " + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdTask()
        {
            string task = textNewTask.Text.Trim();
            ListTask.Items.Add($"{task}");
        }

        private void textNewTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!string.IsNullOrEmpty(textNewTask.Text))
                {
                    AdTask();
                }
            }
        }
        private void DelTask()
        {
            if (ListTask.SelectedItems.Count >0 )
            {
                List <object> ItemsToRemove = new List<object>(); //������� ������ ������, ��� ��������� ��������� �������� ��� ��������
                foreach (var item in ListTask.SelectedItems) 
                {
                    ItemsToRemove.Add(item); //��������� ��������� ������� � ������
                }
                // ������� ��������� �������� �� ListTask ������� ��������� � ������
                foreach (var item in ItemsToRemove)
                {
                    ListTask.Items.Remove(item);
                }
                
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ��������", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ListTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                DelTask();
            }
            else if (e.KeyCode == Keys.F2)
            {
                EditSelectedTask();

            }
        }
    }
}
