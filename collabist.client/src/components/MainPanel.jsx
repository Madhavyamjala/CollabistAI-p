import { useState } from "react";

/*MainPanel
    Purpose
        Displays messages of the active chat.
    Responsibilities
        Renders message list
        Accepts user input
        Sends messages upstream
    Notes
        Assistant replies are not implemented yet
    TODO
        Add assistant message rendering
        Add message streaming
*/

export default function MainPanel({ chat, onSendMessage }) {
    const [input, setInput] = useState("");

    function submit() {
        if (!input.trim()) return;
        onSendMessage(input);
        setInput("");
    }

    return (
        <div style={{ flex: 1, padding: "16px", display: "flex", flexDirection: "column" }}>
            <div style={{ flex: 1 }}>
                {chat.messages.map((msg, index) => (
                    <div key={index}>
                        <strong>{msg.role}:</strong> {msg.content}
                    </div>
                ))}
            </div>

            <div>
                <input
                    value={input}
                    onChange={e => setInput(e.target.value)}
                    placeholder="Type your message"
                />
                <button onClick={submit}>Send</button>
            </div>
        </div>
    );
}
