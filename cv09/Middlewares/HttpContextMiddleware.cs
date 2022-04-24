using System.Text;

namespace cv09.Middlewares
{
    public class HttpContextMiddleware
    {
        private readonly RequestDelegate _next;
        
        public HttpContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                
                var stream = new StreamReader(context.Request.Body);
                var body = await stream.ReadToEndAsync();

                Console.WriteLine("POST request body:");
                Console.WriteLine(body);

                context.Request.Body.Position = 0;
            }

            await _next(context);
        }
    }
}
