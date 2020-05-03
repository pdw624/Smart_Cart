#-*- coding:utf-8 -*-

import socket
import time



host = '192.168.0.154' 
port = 9999 
 

server_sock = socket.socket(socket.AF_INET)
server_sock.bind((host, port))
server_sock.listen(1)

print("기다리는 중")
client_sock, addr = server_sock.accept()
                                                                                                                         
print('Connected by', addr)

def server():
    data2 = client_sock.recv(1024)
    print(data2.decode("utf-8"), len(data2))

    while(True):
        data= input("보낼 값 : ")
        data=data.encode('utf-8')
        
        client_sock.send(data)
        
server()    

closesoket(client_sock)
closesoket(server_sock)



