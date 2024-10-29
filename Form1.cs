using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DbConnection conn = null;
        DbProviderFactory fact = null;
        string providerName = "";

        public Form1()
        {
            InitializeComponent();
            buttonExecuteQuery.Enabled = false;
            buttonReadData.Enabled = false;
            buttonUpdateData.Enabled = false;
            buttonDeleteData.Enabled = false;
        }

        private void buttonGetProviders_Click(object sender, EventArgs e)
        {
            DataTable t = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = t;
            comboBox1.Items.Clear();

            foreach (DataRow dr in t.Rows)
            {
                comboBox1.Items.Add(dr["InvariantName"]);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fact = DbProviderFactories.GetFactory(comboBox1.SelectedItem.ToString());
            conn = fact.CreateConnection();
            providerName = GetConnectionStringByProvider(comboBox1.SelectedItem.ToString());

            if (providerName != null)
            {
                textBoxConnectionString.Text = providerName;
                conn.ConnectionString = providerName;
                EnableButtons();
            }
            else
            {
                MessageBox.Show("Строка подключения не найдена.");
            }
        }

        private void EnableButtons()
        {
            buttonExecuteQuery.Enabled = true;
            buttonReadData.Enabled = true;
            buttonUpdateData.Enabled = true;
            buttonDeleteData.Enabled = true;
        }

        private void buttonExecuteQuery_Click(object sender, EventArgs e)
        {
            ExecuteQueryAsync(textBoxQuery.Text).ConfigureAwait(false);
        }

        private async Task ExecuteQueryAsync(string query)
        {
            if (conn != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                DbDataAdapter adapter = fact.CreateDataAdapter();
                adapter.SelectCommand = conn.CreateCommand();
                adapter.SelectCommand.CommandText = query;

                DataTable table = new DataTable();
                await Task.Run(() => adapter.Fill(table));

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;

                stopwatch.Stop();
                MessageBox.Show($"Время выполнения запроса: {stopwatch.Elapsed.TotalSeconds} секунд");
            }
        }


        private async void buttonReadData_Click(object sender, EventArgs e)
        {
            textBoxQuery.Text = "SELECT * FROM Grades";
        }


        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            textBoxQuery.Text = "UPDATE Grades SET AvgGrade = @avgGrade, MinSubject = @minSubject, MaxSubject = @maxSubject WHERE StudentFullName = @studentName";
        }

        private void AddParameter(DbCommand command, string parameterName, object value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }


        private void buttonDeleteData_Click(object sender, EventArgs e)
        {
            textBoxQuery.Text = "DELETE FROM Grades WHERE StudentFullName = @studentName";
        }


        private void textBoxQuery_TextChanged(object sender, EventArgs e)
        {
            buttonExecuteQuery.Enabled = textBoxQuery.Text.Length > 5;
        }

        static string GetConnectionStringByProvider(string providerName)
        {
            string returnValue = null;
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        returnValue = cs.ConnectionString;
                        break;
                    }
                }
            }
            return returnValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable t = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = t;
            comboBox1.Items.Clear();

            foreach (DataRow dr in t.Rows)
            {
                comboBox1.Items.Add(dr["InvariantName"]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                DbDataAdapter adapter = fact.CreateDataAdapter();
                adapter.SelectCommand = conn.CreateCommand();
                adapter.SelectCommand.CommandText = textBoxQuery.Text.ToString();

                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = textBoxQuery.Text.Length > 5;
        }
    }
}
