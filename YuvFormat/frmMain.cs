using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Accord.Video.FFMPEG;
using Vlc.DotNet.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace YuvFormat
{
    public partial class frmMain : Form
    {
        string destinationFolder;

        public frmMain()
        {
            InitializeComponent();
            destinationFolder =  ConfigurationManager.AppSettings["DestinationFolder"].ToString();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            if (GlobalAyarlar.GoruntuBoy==0 || GlobalAyarlar.GoruntuEn==0 || string.IsNullOrEmpty(GlobalAyarlar.YuvFormat))
            {
                XtraMessageBox.Show("Ayarların yapıldığında emin olun!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                int byteLength = 0;
                openFileDialog1.Multiselect = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    splashScreenManager1.ShowWaitForm();
                    txtDosyaDizin.Text = openFileDialog1.FileName;
                    string uzantisizDosyaAdi = openFileDialog1.FileName.Replace(".yuv", "");

                    byte[] yuvBytes = File.ReadAllBytes(openFileDialog1.FileName);
                    int frameSize = ResimBoyutuGetir();
                    int frameCount = yuvBytes.Length / frameSize;
                    int startIndex = 0;
                    string[] resimAdlari = new string[frameCount];

                    for (int i = 0; i < frameCount; i++)
                    {
                        byte[] yuv1 = new byte[frameSize];
                        Array.Copy(yuvBytes, startIndex, yuv1, 0, frameSize);
                        int[] data;

                        if (GlobalAyarlar.YuvFormat == "4:4:4")
                        {
                            data = yuv2rgb444(yuv1, GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy);
                        }
                        else if (GlobalAyarlar.YuvFormat == "4:2:2")
                        {
                            data = yuv2rgb422(yuv1, GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy);
                        }
                        else
                        {
                            data = yuv2rgb420(yuv1, GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy);
                        }


                        byteLength = yuvBytes.Length;
                        startIndex += frameSize;
                        Bitmap bm = CopyDataToBitmap(data);
                        ColorPalette pal = bm.Palette;
                        for (int j = 0; j < 256; j++)
                        {
                            pal.Entries[j] = Color.FromArgb(255, j, j, j);
                        }
                        bm.Palette = pal;

                        string imageName = (uzantisizDosyaAdi + i + ".bmp").Split('\\').Last();
                        string imagePath = destinationFolder + imageName;
                        bm.Save(imagePath);
                        resimAdlari[i] = imagePath;
                    }

                    string videoAdi = openFileDialog1.FileName.Split('\\').Last().Replace(".yuv", ".avi");

                    CreateVideo(resimAdlari, destinationFolder+videoAdi);
                }
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show("İşlem gerçekleştirilirken hata oluştu : "+ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int[] yuv2rgb420(byte[] yuv, int width, int height)
        {
            int total = width * height;
            int[] rgb = new int[total];
            int Y, Cb = 0, Cr = 0, index = 0;
            int R, G, B;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Y = yuv[y * width + x];
                    if (Y < 0)
                        Y += 255;

                    if ((x & 1) == 0)
                    {
                        Cr = yuv[(y >> 1) * (width) + x + total];
                        Cb = yuv[(y >> 1) * (width) + x + total + 1];

                        if (Cb < 0) Cb += 127; else Cb -= 128;
                        if (Cr < 0) Cr += 127; else Cr -= 128;
                    }

                    //R = Y + Cr + (Cr >> 2) + (Cr >> 3) + (Cr >> 5);
                    //G = Y - (Cb >> 2) + (Cb >> 4) + (Cb >> 5) - (Cr >> 1) + (Cr >> 3) + (Cr >> 4) + (Cr >> 5);
                    //B = Y + Cb + (Cb >> 1) + (Cb >> 2) + (Cb >> 6);


                    R = Y;
                    G = Y;
                    B = Y;

                    // Approximation
                    //				R = (int) (Y + 1.40200 * Cr);
                    //			    G = (int) (Y - 0.34414 * Cb - 0.71414 * Cr);
                    //				B = (int) (Y + 1.77200 * Cb);

                    if (R < 0)
                        R = 0;
                    else if 
                        (R > 255) R = 255;
                    if (G < 0)
                        G = 0;
                    else if 
                        (G > 255) G = 255;
                    if (B < 0)
                        B = 0;
                    else if (B > 255)
                        B = 255;

                    //rgb[index++] = 0xff000000 + (R << 16) + (G << 8) + B;
                    rgb[index++]= Y;
                }
            }

            return rgb;
        }

        public static int[] yuv2rgb444(byte[] yuv, int width, int height)
        {
            int pixelCount = width * height;
            int[] rgb = new int[pixelCount];
            int index = 0;

            for (int i = 0; i < pixelCount; i++)
            {
                rgb[index]= yuv[i];
                index++;
            }
            return rgb;
        }

        public static int[] yuv2rgb422(byte[] yuv, int width, int height)
        {
            int pixelCount = width * height;
            int[] rgb = new int[pixelCount];
            int index = 0;

            for (int i = 0; i < pixelCount; i ++)
            {
                rgb[index] = yuv[i];
                index++;
            }
            return rgb;
        }

        public void CreateVideo(string[] bmpFiles,string videoFileName)
        {
            var videoFileWriter = new VideoFileWriter();
            videoFileWriter.Open(videoFileName, GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy);

            foreach (var item in bmpFiles)
            {
                Bitmap image = new Bitmap(item);
                videoFileWriter.WriteVideoFrame(image);
            }
            vlcControl1.SetMedia(new FileInfo(videoFileName), null);
            splashScreenManager1.CloseWaitForm();
            XtraMessageBox.Show("Video başarıyla kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Bitmap CopyDataToBitmap(int[] data)
        {

            byte[] mydata = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                mydata[i] = Convert.ToByte(data[i]);
            }

            Bitmap bmp;

            if (GlobalAyarlar.YuvFormat == "4:4:4")
                bmp = new Bitmap(GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy, PixelFormat.Format8bppIndexed);
            else if (GlobalAyarlar.YuvFormat == "4:2:2")
                bmp = new Bitmap(GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy, PixelFormat.Format8bppIndexed);
            else
                bmp = new Bitmap(GlobalAyarlar.GoruntuEn, GlobalAyarlar.GoruntuBoy, PixelFormat.Format8bppIndexed);

            BitmapData bmpData = bmp.LockBits(
                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            Marshal.Copy(mydata, 0, bmpData.Scan0, data.Length);

            bmp.UnlockBits(bmpData);
            return bmp;
        }

        public int ResimBoyutuGetir()
        {
            int sonuc = 0;
            if (GlobalAyarlar.YuvFormat=="4:4:4")
            {
                sonuc = GlobalAyarlar.GoruntuEn * GlobalAyarlar.GoruntuBoy * 3;
            }
            else if (GlobalAyarlar.YuvFormat == "4:2:2")
            {
                sonuc = GlobalAyarlar.GoruntuEn * GlobalAyarlar.GoruntuBoy * 2;
            }
            else
            {
                sonuc = GlobalAyarlar.GoruntuEn * GlobalAyarlar.GoruntuBoy * 3 / 2;
            }

            return sonuc;
        }

        private void btnOynat_Click(object sender, EventArgs e)
        {
            vlcControl1.Play();
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            vlcControl1.Pause();
        }
    }
}
