using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadSMTHNK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async void Method ()
        {
            while(!label1.Text.Contains("100%"))
            {
                await Task.Delay(1000);
                label1.Text = "Download is done.\n\r Чекай рабочий стол";
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            string path = @"https://dl144.dlmate01.xyz/?file=M3R4SUNiN3JsOHJ6WWQ2a3NQS1Y5ZGlxVlZIOCtyZ0drZGsyM2xzTEJMbGVyNE1vdyt1dWFQcEhJYlViM3NHV0dOVmcraldUTlBUYmRWYXE4N3gyQjFIVXN2SnQvQjNzdHFweEhKRlRIVEg1bU82cXFXQW0wVmZsTU5YZFFmNVFaSHQrbkZCaXh5N09pYVB5b0JydHAyaXZvZ2pSU2lrYTVuNVpHL2VWbzdsaXdFajdiYWZOeWFZbXVobk9zc0laeXI2UXBGV3d4TGN4NWVsVUdFRnNZNWxQM0k3ODB2V1I5QkZPMWMxUGpocnkvYVMxRDRRd1FmVEtMbU1pWjNwUCt2bXlXQmxK";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += (a, ee) => 
                {
                    string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1056784).ToString("#.# MB");
                    progressBar1.Value = ee.ProgressPercentage; 
                    label1.Text = $"Size: {size}\r\n{((double)ee.BytesReceived/ 1056784).ToString("#.# MB")}\r\n{ee.ProgressPercentage}% done.";
                };
                wc.DownloadFileAsync(new Uri(path), $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/OpenThisVideo.mp4");
            }
            
                Method();
        }
    }
}
