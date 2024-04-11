using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace QUANLYNHANSU
{
    public partial class trogiuplienhevoichungtoi : Form
    {
        public trogiuplienhevoichungtoi()
        {
            InitializeComponent();
            InitializeUI();
        }
        private string selectedImagePath;
        private void InitializeUI()
        {
            // Đặt thuộc tính của PictureBox để chấp nhận các loại hình ảnh
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
        }
        private void trogiuplienhevoichungtoi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
           
        }

        private void btngui_Click(object sender, EventArgs e)
        {
        
        }

        private void btngui_Click_1(object sender, EventArgs e)
        {

            /*   string toEmail = txtemail.Text;
               string subject = txtsubject.Text;
               string body = txtnoidung.Text;

               // Kiểm tra xem đã nhập đầy đủ thông tin chưa
               if (string.IsNullOrWhiteSpace(toEmail) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body) || pictureBox.Image == null)
               {
                   MessageBox.Show("Vui lòng nhập đầy đủ thông tin và chọn hình ảnh trước khi gửi.");
                   return;
               }

               try
               {
                   using (MailMessage mail = new MailMessage())
                   {
                       mail.From = new MailAddress("namnam290703@gmail.com"); // Địa chỉ email của bạn
                       mail.To.Add(toEmail);
                       mail.Subject = subject;
                       mail.Body = body;

                       // Đính kèm hình ảnh
                       using (MemoryStream ms = new MemoryStream())
                       {
                           pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                           byte[] imageBytes = ms.ToArray();
                           mail.Attachments.Add(new Attachment(new MemoryStream(imageBytes), "image.jpg"));
                       }

                       using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                       {
                           smtp.Port = 587;
                           smtp.Credentials = new NetworkCredential("namnam290703@gmail.com", "Kemduyenclgt1"); // Thay thế bằng email và mật khẩu của bạn
                           smtp.EnableSsl = true;
                           smtp.Send(mail);
                       }

                       MessageBox.Show("Email đã được gửi thành công ! \n Chúng tôi sẽ sớm phản hồi và giải quyết vấn đề của bạn !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
               }*/
            
        }

        private void pictureBox_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox.ImageLocation = selectedImagePath;
            }
        }
    }
}
