using CefSharp;
using CefSharp.DevTools.Network;
using CefSharp.Internals;
using CefSharp.Web;
using CefSharp.WinForms;
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
    public partial class WebMainForm : Form
    {
        public event Action<string> OnOk;
        public event Action OnClose;
        public event Action OnClear;
        private readonly ChromiumWebBrowser browser;
        private bool _enableDebug;
        public WebMainForm(bool enableDebug = false)
        {

            InitializeComponent();
            CefSharpSettings.WcfEnabled = true;

            //HtmlString html = HtmlString.FromFile("车牌键盘.html");
            //调试设定
            if (enableDebug)
            {
                _enableDebug = true;
                var setting = new CefSettings { RemoteDebuggingPort = 7777 };
                Cef.Initialize(setting);
            }

            browser = new ChromiumWebBrowser(Environment.CurrentDirectory + "\\车牌键盘.html");
            // 前端调后端 sync
            browser.JavascriptObjectRepository.ResolveObject += JavascriptObjectRepository_ResolveObject;
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }

        /// <summary>
        /// 屏蔽本窗口焦点
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_CHILD = 0x40000000;
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_CHILD;
                cp.ExStyle |= WS_EX_NOACTIVATE;
                return cp;
            }
        }

        /// <summary>
        /// 绑定JS对象事件
        /// </summary>
        private void JavascriptObjectRepository_ResolveObject(object sender, CefSharp.Event.JavascriptBindingEventArgs e)
        {
            var repo = e.ObjectRepository;
            switch (e.ObjectName)
            {
                case "bound":
                    repo.Register("bound", new BoundObject() { OnOk = OnOk, OnClose = OnClose, OnClear = OnClear }, isAsync: false, options: BindingOptions.DefaultBinder);

                    break;
                case "boundAsync":
                    repo.Register("boundAsync", new BoundObject() { OnOk = OnOk, OnClose = OnClose, OnClear = OnClear }, isAsync: true, options: BindingOptions.DefaultBinder);
                    break;
                default:
                    break;
            }
        }
        //状态改变
        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            if (args.IsLoading)
            {
                if (_enableDebug) browser.ShowDevTools();
            }
        }

        //加载完毕
        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Console.WriteLine("Load OK");
        }
        /// <summary>
        /// 后端向前端 设置输入文本
        /// </summary>
        /// <param name="carNo">车牌号</param>
        public void SetCarNo(string carNo)
        {
            browser.GetBrowser().MainFrame.EvaluateScriptAsync($"setCarNo('{carNo}' )").ContinueWith(c =>
            {
                if (c.Result.Success)
                {

                }
                else
                {
                    MessageBox.Show(c.Result.Message);
                }
            }
           );
        }

        /// <summary>
        /// 后端向前端 清空
        /// </summary>
        public void ClearCarNo()
        {
            browser.GetBrowser().MainFrame.EvaluateScriptAsync($"setClear()").ContinueWith(c =>
            {
                if (c.Result.Success)
                {

                }
                else
                {
                    MessageBox.Show(c.Result.Message);
                }
            }
           );
        }
        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "CefSharp";
            this.Controls.Add(browser);
        }
    }
}
