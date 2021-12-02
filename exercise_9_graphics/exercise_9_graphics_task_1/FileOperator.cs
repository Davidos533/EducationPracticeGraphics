using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace exercise_9_graphics_task_1
{
    class FileOperator
    {
        private string m_thisAssemblyPath;
        private FileStream m_stream;

        public string m_fileName { get; set; }
        public string outData { get; private set; }

        public FileOperator()
        {
            m_thisAssemblyPath =Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        // метод для создания файла с данными
        public void MakeFileWith(double[] numbers )
        {
            // обработка исключений
            try
            {
                // инициализация объекта класса файлового потока, для асинхронной ззаписи в файл
                using (m_stream = new FileStream($"{m_thisAssemblyPath}/{m_fileName}", FileMode.Create))
                {
                    BinaryWriter bR = new BinaryWriter(m_stream);
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        bR.Write(numbers[i]);
                    }
                    bR.Close();
                }
            }
            catch (Exception exception)
            {
                outData= exception.Message;
            }
        }
        public void ReadFile(double max)
        {

            try
            {
                using (m_stream = new FileStream($"{m_thisAssemblyPath}/{m_fileName}", FileMode.Open))
                {
                    BinaryReader bR = new BinaryReader(m_stream);
                    byte[] bytes = bR.ReadBytes((int)m_stream.Length);
                    double[] values = new double[m_stream.Length / 8];
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = BitConverter.ToDouble(bytes, i * 8);
                    }
                    bR.Close();

                    StringBuilder outDat = new StringBuilder();

                    for (int i = 0; i < values.Length; i++)
                    {
                        if ((i+1) % 2 == 0 && values[i] < max)
                        {
                            outDat.Append($"{values[i].ToString()} ");
                        }
                    }
                    outData = outDat.ToString();
                }

            }
            catch (Exception exception)
            {
                outData = exception.Message;
            }
        }

    }
}
