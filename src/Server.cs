using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class SimpleHttpServer
{
    static void Main()
    {
        // Define the host and port on which the server will listen
        string host = "127.0.0.1";  // Use "0.0.0.0" to listen on all available interfaces
        int port = 8080;

        // Create a TCP listener
        TcpListener listener = new TcpListener(IPAddress.Parse(host), port);

        try
        {
            // Start listening for incoming connections
            listener.Start();
            Console.WriteLine($"Server listening on {host}:{port}");

            while (true)
            {
                // Accept a client connection
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine($"Accepted connection from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                // Send an HTTP response with a 200 OK status
                string response = "HTTP/1.1 200 OK\r\n\r\n";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                NetworkStream stream = client.GetStream();
                stream.Write(responseData, 0, responseData.Length);

                // Close the connection
                client.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Stop listening for incoming connections
            listener.Stop();
        }
    }
}
