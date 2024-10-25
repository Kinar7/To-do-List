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

        private void AddTask_Click(object sender, EventArgs e) // Создания Таска/Текста
        {
            string task = textNewTask.Text.Trim(); // "Trim" уберает пробел в начале и в конце

            if (!string.IsNullOrEmpty(task))  // Сообщает об ошибке, если текстовое поле пусто
            {
                AdTask();
            }
            else
            {
                MessageBox.Show("Введите Задачу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textNewTask_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListTask_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }

        private void DeleteTask_Click(object sender, EventArgs e) // Удаляет Выбранный Текст  
        {
            if (ListTask.SelectedItem != null)
            {
                ListTask.Items.Remove(ListTask.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Сообщает об ошибке, когда текст не выбран
            }
        }

        private void ListTask_DoubleClick(object sender, EventArgs e) // Создает Крестик, что бы отметить выполненную задачу
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

        private void SafeTask_Click(object sender, EventArgs e) // Сохраняет весь текст
        {
            string filePath = "Task.txt";
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var item in ListTask.Items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
            MessageBox.Show("Сохранение прошло успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Загрузка прошла успешно", "Загруженно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Произошла ошибка загрузки файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string imput = Microsoft.VisualBasic.Interaction.InputBox("Измените задачу: ", "Редактированние задачи", selectedTask);

                if (!string.IsNullOrEmpty(imput))
                {
                    int index = ListTask.SelectedIndex;
                    ListTask.Items[index] = imput;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите задачу для редактированния", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Ошибка при сохранении задач: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Ошибка при загрузке задач: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                List <object> ItemsToRemove = new List<object>(); //Создаем пустой массив, Где сохраняем выбранные элементы для удаления
                foreach (var item in ListTask.SelectedItems) 
                {
                    ItemsToRemove.Add(item); //Добавляем выбранный элемент в массив
                }
                // Удаляем выбранные элементы из ListTask которые хранились в массив
                foreach (var item in ItemsToRemove)
                {
                    ListTask.Items.Remove(item);
                }
                
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
