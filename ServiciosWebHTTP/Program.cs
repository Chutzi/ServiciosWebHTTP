using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiciosWebHTTP.Libreria
{
    class Program 
    {
        static async Task Main(string[] args)
        {
            //https://jsonplaceholder.typicode.com/
            Methods solicitud = new Methods();

            var data1 = await solicitud.GetMethod();
            solicitud.Verify(data1, "Get");

            var data2 = await solicitud.PostMethod();
            solicitud.Verify(data2, "Post");

            var data3 = await solicitud.PutMethod(); 
            solicitud.Verify(data3, "Put");

            var data4 = await solicitud.DeleteMethod();
            solicitud.Verify(data4, "Delete");
        }
    }
}
