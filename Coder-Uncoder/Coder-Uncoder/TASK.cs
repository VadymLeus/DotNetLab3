using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace Coder_Uncoder
{
    public partial class TASK : Form
    {
        private BackgroundWorker encryptionWorker;
        private BackgroundWorker decryptionWorker;
        private long encryptedFileSize;
        private long decryptionStartTime;
        private Stopwatch stopwatch = new Stopwatch();
        public TASK()
        {
            InitializeComponent();

            encryptionWorker = new BackgroundWorker();
            encryptionWorker.DoWork += EncryptionWorker_DoWork;
            encryptionWorker.ProgressChanged += EncryptionWorker_ProgressChanged;
            encryptionWorker.RunWorkerCompleted += EncryptionWorker_RunWorkerCompleted;
            encryptionWorker.WorkerReportsProgress = true;

            decryptionWorker = new BackgroundWorker();
            decryptionWorker.DoWork += DecryptionWorker_DoWork;
            decryptionWorker.RunWorkerCompleted += DecryptionWorker_RunWorkerCompleted;
            decryptionWorker.WorkerReportsProgress = true;
        }
        private void FileCodBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileCodTB.Text = openFileDialog.FileName;
            }
        }
        private void KatCodBTN_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                KatCodTB.Text = saveFileDialog.FileName;
            }
        }
        private void CodBNT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FileCodTB.Text) || string.IsNullOrWhiteSpace(KatCodTB.Text) || string.IsNullOrWhiteSpace(KeyCodTB.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            string inputFile = FileCodTB.Text;
            string outputFile = KatCodTB.Text;
            string key = KeyCodTB.Text;

            if (inputFile == outputFile)
            {
                MessageBox.Show("Введення та виведення файлу не можуть бути однаковими. Будь ласка, оберіть інший файл для виведення.");
                return;
            }

            encryptedFileSize = new FileInfo(inputFile).Length;

            decryptionStartTime = DateTime.Now.Ticks;
            encryptionWorker.RunWorkerAsync(new EncryptionData(inputFile, outputFile, key));
        }
        private void EncryptionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            EncryptionData data = (EncryptionData)e.Argument;
            using (FileStream inputFileStream = new FileStream(data.InputFile, FileMode.Open))
            using (FileStream outputFileStream = new FileStream(data.OutputFile, FileMode.Create))
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(data.Key.PadRight(32, '0')).Take(32).ToArray();
                aesAlg.Mode = CipherMode.CFB;

                aesAlg.GenerateIV();
                outputFileStream.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                using (CryptoStream csEncrypt = new CryptoStream(outputFileStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    long totalBytes = 0;
                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        csEncrypt.Write(buffer, 0, bytesRead);
                        totalBytes += bytesRead;
                        int progressPercentage = (int)((totalBytes * 100) / inputFileStream.Length);
                        encryptionWorker.ReportProgress(progressPercentage);
                    }
                }
            }
        }
        private void EncryptionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarCod.Value = e.ProgressPercentage;
        }
        private void EncryptionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Помилка: {e.Error.Message}");
            }
            else
            {
                string encryptedFileName = Path.GetFileName(FileCodTB.Text);
                string encryptedText = ReadFirst10WordsFromFile(KatCodTB.Text, 25);

                long encryptionEndTime = DateTime.Now.Ticks;
                TimeSpan encryptionTime = new TimeSpan(encryptionEndTime - decryptionStartTime);

                MessageBox.Show($"Файл '{encryptedFileName}' успішно зашифровано.\nПерші 10 слів тексту: {encryptedText}\nЧас шифрування: {encryptionTime.TotalMilliseconds} мс\nРозмір файлу: {encryptedFileSize} байт");
            }
        }
        private void FileUncodBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileUncodTB.Text = openFileDialog.FileName;
            }
        }
        private void KatUnodBTN_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                KatUncodTB.Text = saveFileDialog.FileName;
            }
        }
        private void UncodBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FileUncodTB.Text) || string.IsNullOrWhiteSpace(KatUncodTB.Text) || string.IsNullOrWhiteSpace(KeyUncodTB.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }
            string inputFile = FileUncodTB.Text;
            string outputFile = KatUncodTB.Text;
            string key = KeyUncodTB.Text;
            if (inputFile == outputFile)
            {
                MessageBox.Show("Введення та виведення файлу не можуть бути однаковими. Будь ласка, оберіть інший файл для виведення.");
                return;
            }
            encryptedFileSize = new FileInfo(inputFile).Length;
            decryptionStartTime = DateTime.Now.Ticks;
            decryptionWorker.RunWorkerAsync(new DecryptionData(inputFile, outputFile, key));
        }
        private void DecryptionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DecryptionData data = (DecryptionData)e.Argument;
            using (FileStream inputFileStream = new FileStream(data.InputFile, FileMode.Open))
            using (FileStream outputFileStream = new FileStream(data.OutputFile, FileMode.Create))
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(data.Key.PadRight(32, '0')).Take(32).ToArray();
                aesAlg.Mode = CipherMode.CFB;
                byte[] iv = new byte[aesAlg.BlockSize / 8];
                inputFileStream.Read(iv, 0, iv.Length);
                aesAlg.IV = iv;

                using (CryptoStream csDecrypt = new CryptoStream(outputFileStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        csDecrypt.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
        private void DecryptionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Помилка: {e.Error.Message}");
            }
            else
            {
                string decryptedFileName = Path.GetFileName(FileUncodTB.Text);
                string decryptedText = ReadFirst10WordsFromFile(KatUncodTB.Text, 25);

                long decryptionEndTime = DateTime.Now.Ticks;
                TimeSpan decryptionTime = new TimeSpan(decryptionEndTime - decryptionStartTime);

                FileInfo decryptedFile = new FileInfo(FileUncodTB.Text);

                MessageBox.Show($"Файл '{decryptedFileName}' успішно розшифровано.\nПерші 10 слов тексту: {decryptedText}\nЧас розшифровки: {decryptionTime.TotalMilliseconds} мс\nРозмір файлу: {decryptedFile.Length} байт");
            }
        }
        private string ReadFirst10WordsFromFile(string filePath, int maxLength)
        {
            string text = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    text = reader.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Помилка читання файлу: {ex.Message}");
            }
            if (text.Length > maxLength)
            {
                text = text.Substring(0, maxLength) + "...";
            }
            return text;
        }
        private class EncryptionData
        {
            public string InputFile { get; }
            public string OutputFile { get; }
            public string Key { get; }
            public EncryptionData(string inputFile, string outputFile, string key)
            {
                InputFile = inputFile;
                OutputFile = outputFile;
                Key = key;
            }
        }
        private class DecryptionData
        {
            public string InputFile { get; }
            public string OutputFile { get; }
            public string Key { get; }
            public DecryptionData(string inputFile, string outputFile, string key)
            {
                InputFile = inputFile;
                OutputFile = outputFile;
                Key = key;
            }
        }
        private void GenerationCodBTN_Click(object sender, EventArgs e)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[32];
                rng.GetBytes(keyBytes);
                KeyCodTB.Text = Convert.ToBase64String(keyBytes);
            }
        }

        private void KeyUncodBTN_Click(object sender, EventArgs e)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] keyBytes = new byte[32];
                rng.GetBytes(keyBytes);
                KeyUncodTB.Text = Convert.ToBase64String(keyBytes);
            }
        }
    }
}