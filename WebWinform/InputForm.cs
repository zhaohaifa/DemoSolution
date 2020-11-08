using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebWinform
{
    public partial class InputForm : Form
    {
        WebMainForm carForm;
        public InputForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Txt_CarNo.GotFocus += Txt_CarNo_GotFocus;
            Txt_CarNo.LostFocus += Txt_CarNo_LostFocus;
        }

        private void Txt_CarNo_LostFocus(object sender, EventArgs e)
        {
            //carForm?.Hide();
        }

        //清空回调
        private void CarForm_OnClear()
        {
            Console.WriteLine("JS 点击了清空");
            Txt_CarNo.Clear();
        }
        //关闭回调
        private void CarForm_OnClose()
        {
            carForm?.Hide();
        }
        //确认回调
        private void CarForm_OnOk(string obj)
        {
            Txt_CarNo.Text = obj;
            carForm.Hide();
        }

        /// <summary>
        /// 测试界面输入框获得焦点
        /// </summary>
        private void Txt_CarNo_GotFocus(object sender, EventArgs e)
        {
            if (carForm is null)
            {
                carForm = new WebMainForm();
                carForm.OnOk += CarForm_OnOk;
                carForm.OnClose += CarForm_OnClose;
                carForm.OnClear += CarForm_OnClear;
                carForm.Dock = DockStyle.Fill;
                carForm.TopLevel = false;
                Pnl_Input.Controls.Add(carForm);
            }

            carForm.Show();

            if (!string.IsNullOrWhiteSpace(Txt_CarNo.Text))
            {
                carForm.SetCarNo(Txt_CarNo.Text.ToUpper().Trim());
            }
        }
    }
}
