using System;
using System.Web;

namespace lab1
{
    public class Task2 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var paramA = context.Request.Form["ParamA"];
            var paramB = context.Request.Form["ParamB"];
            string result = "Post-Http-NEV: ParamA = " + paramA+ ", ParamB = " + paramB;
            context.Response.Write(result);
        }

        #endregion
    }
}
