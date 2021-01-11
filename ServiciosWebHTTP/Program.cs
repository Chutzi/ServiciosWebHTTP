using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiciosWebHTTP.Libreria
{
    class Program 
    {
        static async Task Main(string[] args)
        {
            Methods solicitud = new Methods();

            List<Post> data1 = await solicitud.GetMethod();
            solicitud.Verify(data1, "Get");

            Post data2 = await solicitud.PostMethod();
            solicitud.Verify(data2, "Post");

            Post data3 = await solicitud.PutMethod(); 
            solicitud.Verify(data3, "Put");

            bool data4 = await solicitud.DeleteMethod();
            solicitud.Verify(data4, "Delete");
        }
    }
}
