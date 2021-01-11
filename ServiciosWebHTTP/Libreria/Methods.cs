﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiciosWebHTTP.Libreria
{
    class Methods
    {
        public async Task<List<Post>> GetMethod()
        {
            List<Post> Posts;
            
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                Posts = JsonSerializer.Deserialize<List<Post>>(content);
                return Posts;
            }
            
            return default(List<Post>);
        }
        public async Task<Post> PostMethod()
        {
            Post postResult;
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            Post post = new Post()
            {
                userId = 1,
                body = "Metodo Post",
                title = "Hey"
            };

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                postResult = JsonSerializer.Deserialize<Post>(result);
                return postResult;
            }
            return default(Post);
            
        }
        public async Task<Post> PutMethod()
        {
            Post postResult;
            string url = "https://jsonplaceholder.typicode.com/posts/99";
            HttpClient client = new HttpClient();

            Post post = new Post()
            {
                userId = 1,
                body = "Metodo Post",
                title = "Hey"
            };

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var httpResponse = await client.PutAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                postResult = JsonSerializer.Deserialize<Post>(result);
                return postResult;
            }
            return default(Post);
        }
        public async Task<bool> DeleteMethod()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/99";
            HttpClient client = new HttpClient();

            Post post = new Post()
            {
                userId = 1,
                body = "Metodo Post",
                title = "Hey"
            };

            var httpResponse = await client.DeleteAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }
        public void Verify<T>(T data, string text) 
        {
            if (!data.Equals(default(T)))
                Console.WriteLine($"{text} con exito");
            else
                Console.WriteLine($"{text} sin exito");
        }

    }
}