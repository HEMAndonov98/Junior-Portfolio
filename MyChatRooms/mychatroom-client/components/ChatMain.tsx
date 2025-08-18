'use client'
import { IconArrowUp } from '@tabler/icons-react'
import React, { useState, useEffect } from 'react'
import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr'

const Chat = () => {

    const [connection, setConnection] = useState<HubConnection | null>(null);
    const [messages, setMessages] = useState<{ user: string, message: string }[]>([]);
    const [message, setMessage] = useState('');

    useEffect(() => {
        const createConnection = async () => {
            const newConnection = new HubConnectionBuilder()
                .withUrl('http://localhost:5116/chathub', {
                    withCredentials: true,
                    transport: HttpTransportType.WebSockets,
                })
                .withAutomaticReconnect()
                .configureLogging(LogLevel.Information)
                .build()

            newConnection.on('ReceiveMessage', (user, message) => {
                setMessages((prevMessages) => [...prevMessages, { user, message }]);
            });

            console.log('Receive Message configured');

            newConnection.on("MessageHistory", (messageHistory: { user: string, message: string }[]) => {
                setMessages(messageHistory);
                console.log('Reinstated local server history')

            });
            console.log("MessageHistory configured");
            try {
                await newConnection.start();
                console.log('SignalR connection established');
                setConnection(newConnection);
            }
            catch (error) {
                console.log('Error connecting to SignalR hub:', error);
            }


        };

        createConnection();

        return () => {
            if (connection) {
                connection.off('ReceiveMessage');
                connection.off('MessageHistory');
                console.log("ReceiveMessage and MessageHistory turned off");
            }
        };
    }, []);

    const sendMessage = async () => {
        if (connection && message.trim() != '') {
            try {
                await connection.invoke('SendMessage', message);
                console.log('message successfuly sent');
                setMessage('');
            }
            catch (error) {
                console.log('error while sending message', error);
            }
        }

    };
    return (
        <div className='flex flex-col w-full h-screen items-center justify-between bg-[#16213E]'>
            <div className='border-1 rounded-2xl w-[50vw] h-screen flex flex-col-reverse items-end p-5 mt-2 text-white'>
                {messages.toReversed().map((msg, index) => (
                    <p key={index}>{msg.message} <strong>{msg.user}</strong></p>
                ))}
            </div>
            <div className='mb-8 mt-5 flex justify-center items-center relative'>
                <input type="text" name="chat" value={message} onChange={(e) => setMessage(e.target.value)} className='border-1 border-gray-50 rounded-sm h-[2.4em] w-[50vw] text-white text-xl px-5' />
                <IconArrowUp onClick={sendMessage} onKeyDown={(e) => { if (e.key == 'Enter') { sendMessage(); } }} className={`scale-120 border-1 cursor-pointer border-gray-50 bg-white rounded-full absolute top-3 right-5 text-black transition-transform duration-[0.4s] ${message ? 'rotate-0' : 'rotate-90'}`} />
            </div>
        </div>
    )
}

export default Chat