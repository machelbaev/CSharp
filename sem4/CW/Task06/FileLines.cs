/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 6
*/

using System.Collections;
using System.IO;

namespace Task06
{
    public class FileLines : IEnumerable
    {
        StreamReader file;

        string path;

        public FileLines(string path)
        {
            this.path = path;
            file = new StreamReader(path);
        }

        public IEnumerator GetEnumerator()
        {
            return new FileEnumerator(file, path);
        }

        class FileEnumerator : IEnumerator
        {
            StreamReader file;

            string path;

            string line;

            public FileEnumerator(StreamReader file, string path)
            {
                this.file = file;
                this.path = path;
            }

            public object Current
            {
                get
                {
                    return line;
                }
            }

            public bool MoveNext()
            {
                if ((line = file.ReadLine()) != null)
                    return true;
                return false;
            }

            public void Reset()
            {
                file.Close();
                file = new StreamReader(path);
            }

            public void Dispose()
            {
                file.Dispose();
            }

            ~FileEnumerator()
            {
                Dispose();
            }
        }
    }
}


