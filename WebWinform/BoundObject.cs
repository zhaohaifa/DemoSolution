using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描   述：代码改变世界                                                    
*│　作   者：ZhaoHaiFa                                              
*│　版   本：1.0                                                 
*│　创建时间：2020/10/26 23:16:35                             
*└──────────────────────────────────────────────────────────────┘
*/
namespace WebWinform
{
    public class BoundObject
    {
        public  Action<string> OnOk;
        public  Action OnClose;
        public  Action OnClear;

        private IJavascriptCallback callback;

        public void SetCallBack(IJavascriptCallback callback)
        {
            this.callback = callback;
            this.callback.ExecuteAsync("后台数据");
        }
        public void BeforeOk(string carNo)
        {
            OnOk?.Invoke(carNo);
        }
        public void BeforeClose()
        {
            OnClose?.Invoke();
        }
        public void BeforeClear()
        {
            OnClear?.Invoke();
        }
    }
}
