using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewProcesses.ColumnCount = 5;
            dataGridViewProcesses.Columns[0].Name = "ProcessName";
            dataGridViewProcesses.Columns[1].Name = "MemoryUsage";
            dataGridViewProcesses.Columns[2].Name = "StartTime";
            dataGridViewProcesses.Columns[3].Name = "Priority";
            dataGridViewProcesses.Columns[4].Name = "ThreadCount";
        }
        private void NotebookBTN_Click(object sender, EventArgs e)
        {
            StartProcess("notepad.exe");
        }

        private void CalculatorBTN_Click(object sender, EventArgs e)
        {
            StartProcess("calc.exe");
        }

        private void ConductorBTN_Click(object sender, EventArgs e)
        {
            StartProcess("explorer.exe");
        }

        private void WordBTN_Click(object sender, EventArgs e)
        {
            StartProcess("winword.exe");
        }

        private void ExcelBTN_Click(object sender, EventArgs e)
        {
            StartProcess("excel.exe");
        }

        private void PowerPointBTN_Click(object sender, EventArgs e)
        {
            StartProcess("powerpnt.exe");
        }

        private void RefreshProcessesList()
        {
            dataGridViewProcesses.Rows.Clear();
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                string name = process.ProcessName;
                long memoryUsage = process.WorkingSet64;
                DateTime startTime = process.StartTime;
                int priority = process.BasePriority;
                int threadCount = process.Threads.Count;

                dataGridViewProcesses.Rows.Add(name, memoryUsage, startTime, priority, threadCount);
            }
        }

        private void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
                RefreshProcessesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка запуску процесу: " + ex.Message);
            }
        }

        private void StopProsBTN_Click(object sender, EventArgs e)
        {
            if (dataGridViewProcesses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewProcesses.SelectedRows[0];
                string processName = selectedRow.Cells[0].Value.ToString();

                KillProcessByName(processName);
            }
        }

        private void KillProcessByName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                process.CloseMainWindow();
            }

            RefreshProcessesList();
        }
    }
}