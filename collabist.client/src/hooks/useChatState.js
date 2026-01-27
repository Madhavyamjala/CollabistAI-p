import { useState } from "react";

/*useChatState
    Purpose
        Manages chat sessions and messages for the in-app view.
    Responsibilities
        Stores chat list
        Tracks active chat
        Appends messages to chats
    Notes
        This is frontend-only state
        Persistence will be added later
    TODO
        Add backend persistence
        Add message streaming support
*/

export default function useChatState() {
    const [chats, setChats] = useState([
        {
            id: "chat-1",
            title: "New Chat",
            messages: []
        }
    ]);

    const [activeChatId, setActiveChatId] = useState("chat-1");

    function getActiveChat() {
        return chats.find(c => c.id === activeChatId);
    }

    function sendMessage(content) {
        setChats(prev =>
            prev.map(chat =>
                chat.id === activeChatId
                    ? {
                        ...chat,
                        messages: [...chat.messages, { role: "user", content }]
                    }
                    : chat
            )
        );

        fetch("/api/chat", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ message: content })
        })
            .then(res => res.json())
            .then(data => {
                setChats(prev =>
                    prev.map(chat =>
                        chat.id === activeChatId
                            ? {
                                ...chat,
                                messages: [
                                    ...chat.messages,
                                    { role: "assistant", content: data.reply }
                                ]
                            }
                            : chat
                    )
                );
            });
    }


    return {
        chats,
        activeChatId,
        setActiveChatId,
        getActiveChat,
        sendMessage
    };
}
