using System;
using System.Web;

namespace lab1
{
    public class Task5 : IHttpHandler
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
            if (context.Request.HttpMethod == "GET")
            {
                var response = context.Response;
                response.WriteFile("C:\\Users\\thesi\\Desktop\\6\\ПИС\\Лабки\\lab1\\lab1\\Task5.html");
            }
            else if (context.Request.HttpMethod == "POST")
            {
                int x = Convert.ToInt32(context.Request.Form.Get("x"));
                int y = Convert.ToInt32(context.Request.Form.Get("y"));
                int mul = x * y;
                context.Response.Write(mul);
            }
        }

        #endregion
    }
}
