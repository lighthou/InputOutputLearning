using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputOutputLearning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //WRITE INTO FILE
        {
            
            // Example #1: Write an array of strings to a file.
            // Create a string array that consists of three lines.
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Ryan\Documents\MyProjects\InputOutputLearning\InputOutputLearning\InputOutputLearning\TestWritesReads\WriteLines.txt", lines);

            // Example #2: Write one string to a text file.
            string fileName = textBox2.Text; //Grab Filename from TextBox
            string toWrite = textBox1.Text; //Grab what you're writing
            string filePath = @"C:\Users\Ryan\Documents\MyProjects\InputOutputLearning\InputOutputLearning\InputOutputLearning\TestWritesReads\";
            string writePath = filePath + fileName;
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(writePath, toWrite);

            // Example #3: Write only some strings in an array to a file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
            // encodes the output as text.

            using (System.IO.StreamWriter file =  new StreamWriter(@"C:\Users\Ryan\Documents\MyProjects\InputOutputLearning\InputOutputLearning\InputOutputLearning\TestWritesReads\WriteSomeLines.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            // Example #4: Append new text to an existing file.
            // The using statement automatically flushes AND CLOSES the stream and calls 
            // IDisposable.Dispose on the stream object.
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Ryan\Documents\MyProjects\InputOutputLearning\InputOutputLearning\InputOutputLearning\TestWritesReads\WriteSomeLines.txt", true))
            {
                file.WriteLine("Fourth line");
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) //GET OUTPUT FROM FILE
        {
            // Example #1
            // Read the file as one string.
            string filePath =
                @"C:\Users\Ryan\Documents\MyProjects\InputOutputLearning\InputOutputLearning\InputOutputLearning\TestWritesReads\";
            string fileName = textBox3.Text;
            string text = System.IO.File.ReadAllText(filePath+fileName);

            // Display the file contents to the console. Variable text is a string.
            textBox4.Text = text;
            //Also write to console because why not
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(filePath + fileName);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
        }
    }
}
