using System.Net;
using System.Net.Sockets;
using System.Text;
// You can use print statements as follows for debugging, they'll be visible
// when running tests.
Console.WriteLine("Logs from your program will appear here!");
// Uncomment this block to pass the first stage
TcpListener server = new TcpListener(IPAddress.Any, 4221);
server.Start();
server.AcceptSocket(); // wait for client

TcpClient client = await listener.AcceptTcpClientAsync();
NetworkStream stream = client.GetStream();

// Create a buffer to store the incoming data.
byte[] buffer = new byte[client.ReceiveBufferSize];
// Read the data. This is not used for now, but will be useful in later stages.
int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

string response = "HTTP/1.1 200 OK\r\n\r\n";
byte[] responseBytes = Encoding.ASCII.GetBytes(response);
await stream.WriteAsync(responseBytes, 0, responseBytes.Length);

stream.Close();
client.Close();