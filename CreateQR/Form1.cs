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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using QRCoder;

namespace CreateQR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtLink.Text;
            int so_ban = Convert.ToInt32(txtSoBan.Text);

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(so_ban.ToString()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            SaveQrCodesToPdf(url, so_ban);
        }

        private void SaveQrCodesToPdf(string url, int so_ban)
        {
            PdfDocument pdfDoc = new PdfDocument();

            // Kích thước trang A4
            double pageWidth = 595; 
            double pageHeight = 842;

            // Kích thước mỗi mã QR
            double qrSize = 240;
            double margin = 40; 
            double xOffset = (pageWidth - 2 * qrSize - margin) / 3; 
            double yOffset = (pageHeight - 2 * qrSize - margin) / 3;

            int currentQRCode = 1;

            while (currentQRCode <= so_ban)
            {
                PdfPage page = pdfDoc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                for (int j = 0; j < 4 && currentQRCode <= so_ban; j++)
                {
                    int row = j / 2;
                    int col = j % 2;

                    // Tạo mã QR từ URL, thêm số bàn vào URL
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(url + $"{currentQRCode}", QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);

                    // Tạo hình ảnh mã QR
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    // Lưu mã QR thành file PNG tạm thời
                    string tempFilePath = SaveBitmapToTempFile(qrCodeImage);

                    // Tính toán vị trí của mã QR (căn giữa theo hàng và cột)
                    double x = margin + col * (qrSize + xOffset);
                    double y = margin + row * (qrSize + yOffset);

                    // Vẽ mã QR từ file PNG tạm
                    XImage xImage = XImage.FromFile(tempFilePath);
                    gfx.DrawImage(xImage, x, y, qrSize, qrSize);

                    // Thêm mô tả dưới mã QR
                    XFont font = new XFont("Arial", 12);
                    double textWidth = gfx.MeasureString($"Bàn {currentQRCode}", font).Width;
                    double textX = x + (qrSize - textWidth) / 2;
                    double textY = y + qrSize + 5;
                    gfx.DrawString($"Bàn {currentQRCode}", font, XBrushes.Black, textX, textY);

                    currentQRCode++;

                    File.Delete(tempFilePath);
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pdfDoc.Save(saveFileDialog.FileName);
                MessageBox.Show("PDF đã được lưu thành công!");
            }
        }

        private string SaveBitmapToTempFile(Bitmap bitmap)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");

            bitmap.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png);
            return tempFilePath;
        }

    }
}
