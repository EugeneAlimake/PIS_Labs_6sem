using System;
using System.Web;

namespace lab1
{
    public class Task1 : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            res.Write("Hello world");
            string result = "GET-Http-NEV: ParamA = " + context.Request.QueryString["ParamA"] + ", ParamB = " + context.Request.QueryString["ParamB"];
            context.Response.Write(result);
        }

        #endregion
    }
}
