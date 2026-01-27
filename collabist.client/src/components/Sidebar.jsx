/*Sidebar
    Purpose
        Displays chat sessions and navigation.
    Responsibilities
        Lists available chats
        Allows selecting active chat
    Notes
        Styling is minimal
    TODO
        Add new chat creation
        Add chat deletion
*/

export default function Sidebar({ chats, activeChatId, onSelectChat }) {
    return (
        <div style={{ width: "260px", borderRight: "1px solid #ccc", padding: "12px" }}>
            <h3>Collabist</h3>

            <ul>
                {chats.map(chat => (
                    <li
                        key={chat.id}
                        style={{
                            cursor: "pointer",
                            fontWeight: chat.id === activeChatId ? "bold" : "normal"
                        }}
                        onClick={() => onSelectChat(chat.id)}
                    >
                        {chat.title}
                    </li>
                ))}
            </ul>

            <button>Settings</button>
        </div>
    );
}
