using System.Net;
using System.Net.Sockets;
using System.Text;

// You can use print statements as follows for debugging, they'll be visible
// when running tests.
Console.WriteLine("Logs from your program will appear here!");
// Uncomment this block to pass the first stage
TcpListener server = new TcpListener("43.250.142.47", 4221);
server.Start();
server.AcceptSocket(); // wait for client
Socket socket = server.AcceptSocket(); // wait for client
var buffer = new byte[1024];
socket.Receive(buffer);
socket.Send(Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\n\r\n"));

socket.Close();