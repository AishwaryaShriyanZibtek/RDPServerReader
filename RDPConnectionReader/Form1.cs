using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;

namespace RDPConnectionReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("TestServer", PipeDirection.Out))
            {
                // Wait for a connection
                pipeServer.WaitForConnection();

                // Send signal to client
                using (StreamWriter writer = new StreamWriter(pipeServer))
                {
                    ServerStatus.Text = "Server started";
                    writer.WriteLine("ServerStarted");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}