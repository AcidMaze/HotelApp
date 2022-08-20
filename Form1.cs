using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Conn;
using MySql.Data.MySqlClient;

namespace HotelApp
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        private bool connOpen = false;
        public Form1()
        {
            InitializeComponent();
            try
            {
                if (connOpen == false)
                {
                    conn.Open();
                    connOpen = true;
                }
            }
            catch
            {
                connOpen = false;
                conn.Close();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected == true) // Выбран гость
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                GuestInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
                GuestInfo.Name = row.Cells[1].Value.ToString();
                GuestInfo.Phone = row.Cells[2].Value.ToString();
                GuestInfo.Passport = row.Cells[3].Value.ToString();
                GuestInfo.roomID = Int32.Parse(row.Cells[4].Value.ToString());
                if (connOpen == true)
                {
                    MySqlDataReader dataReader;
                    MySqlDataReader dataReader2;
                    GuestInfo.Arrival_Date = DateTime.Today;
                    GuestInfo.Depart_Date = DateTime.Today;
                    string query = "SELECT `arrival_date`, `depart_date` FROM `roms_orders` WHERE `idRoom` = " + RoomInfo.ID + " AND " + "`idGuest` = " + GuestInfo.ID;
                    MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                    dataReader = command.ExecuteReader(); // Отправка запроса
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        GuestInfo.Arrival_Date = dataReader.GetDateTime(0);
                        GuestInfo.Depart_Date = dataReader.GetDateTime(1);
                        dataReader.Close();
                        string qry = "SELECT `title` FROM `rooms` WHERE `id` = " + GuestInfo.roomID;
                        MySqlCommand cmd = new MySqlCommand(qry, conn);// Обращение к БД
                        dataReader2 = cmd.ExecuteReader(); // Отправка запроса
                        if (dataReader2.HasRows)
                        {
                            dataReader2.Read();
                            GuestInfo.Room = dataReader2.GetString(0);
                        }
                        dataReader2.Close();
                    }
                    dataReader.Close();
                }

            }
            else if (treeView1.Nodes[1].IsSelected == true) // Выбрана комната
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                RoomInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
                RoomInfo.Title = row.Cells[1].Value.ToString();

            }
            else if (treeView1.Nodes[2].IsSelected == true) // Выбран сотрудник
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                PersonalListInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
                PersonalListInfo.Name = row.Cells[1].Value.ToString();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (PersonalInfo.isAuth != true)
            {
                this.Hide();
                Form Auth = new Auth();
                Auth.ShowDialog();
            }
            else
            {
                SelectNodeByName(treeView1, "Постояльцы");
            }
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected == true)
            {
                Form AddUser = new Form2();
                AddUser.ShowDialog();
            }
            else if (treeView1.Nodes[1].IsSelected == true)
            {
                Form AddRoom = new Form3();
                AddRoom.ShowDialog();
            }
            else if (treeView1.Nodes[2].IsSelected == true)
            {
                if(PersonalInfo.isAdmin == true)
                {
                    Form AddPersonal = new Form4();
                    AddPersonal.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ошибка! У вас не хватает прав для этого действия.", "Закрыть");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(PersonalInfo.isAuth == false) // Закрыть программу если пользователь не авторизован
            {
                this.Close();
            }
        }

        public void SelectNodeByName(TreeView treeView, string nameNode)
        {
            foreach (TreeNode item in treeView.Nodes)
            {
                if (item.Text == nameNode)
                {
                    treeView.SelectedNode = item; 
                }
            }

        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (connOpen == true)
            {
                switch (Convert.ToInt32(e.Node.Index))
                {
                    case 0:
                        {
                            dataGridView1.ContextMenuStrip = contextMenu;
                            MySqlDataReader dataReader;
                            string query = "SELECT * FROM `guests`";
                            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                            dataReader = cmd.ExecuteReader(); // Отправка запроса
                            if (dataReader.HasRows)
                            {
                                dataGridView1.DataSource = UpdateGrid(dataReader);
                                dataGridView1.Columns[0].HeaderText = "№";
                                dataGridView1.Columns[1].HeaderText = "ФИО";
                                dataGridView1.Columns[2].HeaderText = "Моб.телефон";
                                dataGridView1.Columns[3].HeaderText = "Паспорт";
                                dataGridView1.Columns[4].Visible = false;
                            }   
                            dataReader.Close();
                            GC.Collect();
                            break;
                        }
                    case 1:
                        {
                            MySqlDataReader dataReader;
                            string query = "SELECT * FROM `rooms`";
                            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                            dataReader = cmd.ExecuteReader(); // Отправка запроса
                            if (dataReader.HasRows)
                            {
                                dataGridView1.DataSource = UpdateGrid(dataReader);
                                dataGridView1.Columns[0].HeaderText = "№";
                                dataGridView1.Columns[1].HeaderText = "Название";
                                dataGridView1.Columns[2].Visible = false;
                                dataGridView1.Columns[3].HeaderText = "Мебель";
                                dataGridView1.Columns[4].HeaderText = "Кол-во кроватей";
                            }
                            dataReader.Close();
                            GC.Collect();
                            dataGridView1.ContextMenuStrip = contextMenu;
                            break;
                        }
                    case 2:
                        {
                            MySqlDataReader dataReader;
                            string query = "SELECT * FROM `personal`";
                            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                            dataReader = cmd.ExecuteReader(); // Отправка запроса
                            if (dataReader.HasRows)
                            {
                                dataGridView1.DataSource = UpdateGrid(dataReader);
                                dataGridView1.Columns[0].HeaderText = "№";
                                dataGridView1.Columns[1].HeaderText = "ФИО";
                                dataGridView1.Columns[2].HeaderText = "Должность";
                                dataGridView1.Columns[3].HeaderText = "Мобильный телефон";
                            }
                            dataReader.Close();
                            GC.Collect();
                            dataGridView1.ContextMenuStrip = null;
                            break;
                        }
                }
            }
        }
        private DataTable UpdateGrid(MySqlDataReader dataReader)
        {
            DataTable table = new DataTable();
            table.Load(dataReader);
            return table;
        }

        private void информацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected == true)
            {
                Form GuestInfForm = new Form7();
                GuestInfForm.Text = "Информация и постояльце - " + GuestInfo.Name;
                GuestInfForm.ShowDialog();
            }
            else if (treeView1.Nodes[1].IsSelected == true)
            {
                Form ShowRoomInfo = new Form5();
                ShowRoomInfo.Text = "Информация и №" + RoomInfo.ID + " " + RoomInfo.Title;
                ShowRoomInfo.ShowDialog();
            }

        }
        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected == true)
            {
                string name = GuestInfo.Name;
                DialogResult dialogResult = MessageBox.Show("Вы действительно удалить гостя  - " + name + "?", "Удалить", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM `guest` WHERE `id` = " + GuestInfo.ID;
                    MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                    command.ExecuteNonQuery(); // Отправка запроса
                    MessageBox.Show("Гость - " + name + "успешно удалён из", "Закрыть");
                    GC.Collect();
                }
            }
            else if (treeView1.Nodes[1].IsSelected == true)
            {
                string title = RoomInfo.Title;
                DialogResult dialogResult = MessageBox.Show("Вы действительно удалить комнату №" + RoomInfo.ID + " " + title + "?", "Удалить", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM `rooms` WHERE `id` = " + RoomInfo.ID;
                    MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                    command.ExecuteNonQuery(); // Отправка запроса
                    MessageBox.Show("Комната - " + title + "успешно удалёна", "Закрыть");
                    GC.Collect();
                }
            }
            else if (treeView1.Nodes[2].IsSelected == true)
            {
                if (PersonalInfo.isAuth == true)
                {
                    string title = PersonalListInfo.Name;
                    DialogResult dialogResult = MessageBox.Show("Вы действительно удалить сотрудника - " + title + "?", "Удалить", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "DELETE FROM `personal` WHERE `id` = " + PersonalListInfo.ID;
                        MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                        command.ExecuteNonQuery(); // Отправка запроса
                        MessageBox.Show("Сотрудник - " + title + " успешно удалён", "Закрыть");
                        GC.Collect();
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка! У вас не хватает прав для этого действия.", "Закрыть");
                }
            }
        }
    }
    class RoomInfo
    {
        static public int ID { get; set; }
        static public string Title { get; set; }
    }
    class GuestInfo
    {
        static public int ID { get; set; }
        static public int roomID { get; set; }
        static public string Name { get; set; }
        static public string Passport { get; set; }
        static public string Phone { get; set; }
        static public DateTime Arrival_Date { get; set; }
        static public DateTime Depart_Date { get; set; }
        static public string Room { get; set; }
    }
    class PersonalInfo
    {
        static public bool isAuth { get; set; }
        static public bool isAdmin { get; set; }
        static public int ID { get; set; }
        static public string Name { get; set; }
    }
    class PersonalListInfo
    {
        static public int ID { get; set; }
        static public string Name { get; set; }
    }

}
