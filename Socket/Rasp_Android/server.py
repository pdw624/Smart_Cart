import socket
import time

host = '192.168.0.139' # Symbolic name meaning all available interfaces
port = 9999 # Arbitrary non-privileged port
 

server_sock = socket.socket(socket.AF_INET)
server_sock.bind((host, port))
server_sock.listen(1)

print("waiting")
client_sock, addr = server_sock.accept()
#client_sock = server_sock.accept()
#addr = server_sock.accept()

print('Connected by', addr)

data2 = client_sock.recv(1024)
print(data2.decode("utf-8"), len(data2))

while(True):
    data = input("sent : ")
    
    data = data.encode('utf-8')
    #length = len(data)
    #data2 = str(data2, 'utf-8')
    #client_sock.send(data2)


    #print(data2.encode())
    client_sock.send(data)
    print("test !!!!!!!!!!!!!!! ")
    #client_sock.close()
    #client_sock.sendall(data)
    #client_sock.sendall(length.to_bytes(4, byteorder='little'))
    #client_sock.sendall(data)
    i = 2
    
    #client_sock.send(data2.to_bytes(4, byteorder='little'))
    

    #data2 = client_sock.recv(1024)
    #data2.decode('utf-8')
    
    #length2 = int.from_bytes(data2, 'little')
    #data2 = client_sock.recv(length)

    #recvMsg = data2.decode()
    #print(recvMsg)

    #print(data2.decode("utf-8"), len(data2))
   

    #print(data, len(data))

    
   # if(data2 == 99):
   #     break;

#i=99
#client_sock.send(i.to_bytes(4, byteorder='little'))
#client_sock.close()
#server_sock.close()
closesocket(client_sock)
closesocket(server_sock)
