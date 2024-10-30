using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            comboBox2.Items.Add("Отображение полной информации о странах");
            comboBox2.Items.Add("Отображение частичной информации о странах");
            comboBox2.Items.Add("Отображение информации о конкретной стране");
            comboBox2.Items.Add("Отображение информации о городах конкретной страны");
            comboBox2.Items.Add("Отображение всех стран, чьё имя начинается с буквы");
            comboBox2.Items.Add("Отображение всех столиц, чьё имя начинается с буквы");
            comboBox2.Items.Add("Показать топ-3 столиц с наименьшим количеством жителей");
            comboBox2.Items.Add("Показать топ-3 стран с наименьшим количеством жителей");
            comboBox2.Items.Add("Показать среднее количество жителей в столицах по каждой части света");
            comboBox2.Items.Add("Показать топ-3 стран по каждой части света с наименьшим количеством жителей");
            comboBox2.Items.Add("Показать топ-3 стран по каждой части света с наибольшим количеством жителей");
            comboBox2.Items.Add("Показать среднее количество жителей в конкретной стране");
            comboBox2.Items.Add("Показать город с наименьшим количеством жителей в конкретной стране");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> queries = new Dictionary<string, string>()
            {
                { "Отображение полной информации о странах", "SELECT * FROM Countries;" },
                { "Отображение частичной информации о странах", "SELECT Name, Population FROM Countries;" },
                { "Показать топ-3 столиц с наименьшим количеством жителей", "SELECT TOP 3 CapitalName, Population FROM Capitals ORDER BY Population ASC;" },
                { "Показать топ-3 стран с наименьшим количеством жителей", "SELECT TOP 3 CountryName, Population FROM Countries ORDER BY Population ASC;" },
                { "Показать среднее количество жителей в столицах по каждой части света", "SELECT Continent, AVG(Population) AS AvgPopulation FROM Capitals GROUP BY Continent;" },
                { "Показать топ-3 стран по каждой части света с наименьшим количеством жителей", "SELECT CountryName, Population FROM (SELECT CountryName, Population, ROW_NUMBER() OVER(PARTITION BY Continent ORDER BY Population ASC) AS RowNum FROM Countries) AS CountryList WHERE RowNum <= 3;" },
                { "Показать топ-3 стран по каждой части света с наибольшим количеством жителей", "SELECT CountryName, Population FROM (SELECT CountryName, Population, ROW_NUMBER() OVER(PARTITION BY Continent ORDER BY Population DESC) AS RowNum FROM Countries) AS CountryList WHERE RowNum <= 3;" },

            };

            string selectedQuery = comboBox2.SelectedItem.ToString();

            if (queries.ContainsKey(selectedQuery))
            {
                textBoxQuery.Text = queries[selectedQuery];
            }
            else
            {
                textBoxQuery.Text = "Запрос не найден.";
            }
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
        }

        private void buttonExecuteQuery_Click(object sender, EventArgs e)
        {
            ExecuteQueryAsync(textBoxQuery.Text).ConfigureAwait(false);
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

        private async void button2_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                DbDataAdapter adapter = fact.CreateDataAdapter();
                adapter.SelectCommand = conn.CreateCommand();
                adapter.SelectCommand.CommandText = textBoxQuery.Text.ToString();

                DataTable table = new DataTable();

                // Заполняем DataTable с помощью асинхронного выполнения
                await Task.Run(() => adapter.Fill(table));

                // Проверяем, заполнен ли textBox1
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    // Если textBox1 заполнен, записываем данные в файл
                    WriteDataTableToFile(table, textBox1.Text);
                }
                else
                {
                    // Если textBox1 пуст, заполняем DataGridView
                    if (table.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = null; // Сбрасываем источник данных
                        dataGridView1.DataSource = table; // Присваиваем новый источник данных
                    }
                    else
                    {
                        MessageBox.Show("Запрос не вернул никаких данных.");
                    }
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = textBoxQuery.Text.Length > 5;
        }

        private async Task ExecuteQueryAsync(string query)
        {
            if (conn != null)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    DbDataAdapter adapter = fact.CreateDataAdapter();
                    adapter.SelectCommand = conn.CreateCommand();
                    adapter.SelectCommand.CommandText = query;

                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));

                    dataGridView1.DataSource = table;

                    stopwatch.Stop();
                    MessageBox.Show($"Время выполнения запроса: {stopwatch.Elapsed.TotalSeconds} секунд");

                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        WriteDataTableToFile(table, textBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        private void WriteDataTableToFile(DataTable table, string filePath)
        {
            try
            {
                var columnNames = string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName));

                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(columnNames);

                    foreach (DataRow row in table.Rows)
                    {
                        var rowData = string.Join(",", row.ItemArray.Select(item => item.ToString()));
                        writer.WriteLine(rowData);
                    }
                }
                MessageBox.Show("Данные успешно записаны в файл.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи в файл: " + ex.Message);
            }
        }
    }
}
