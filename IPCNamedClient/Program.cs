﻿using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

/*
 * This is an example representing how two processes can communicate through NamedPipe
 */

namespace IPCNamedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pipe Client is being executed ...");
            Console.WriteLine("[Client] waiting to receive a message");

            var server = new NamedPipeServerStream("PipesOfConcurrency");
            server.WaitForConnection();

            StreamReader reader = new StreamReader(server);

            while (true){
                String msg = reader.ReadLine();
                if (String.IsNullOrEmpty(msg)) // Finish if nothing is entered
                    break;
                else
                {
                    Console.WriteLine(msg); // Print the message received
                    Console.WriteLine(String.Join("", msg.Reverse())); // Print the reverse of the received message

                }
            }
        }
    }
}
