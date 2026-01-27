import Sidebar from "../components/Sidebar";
import MainPanel from "../components/MainPanel";
import useChatState from "../hooks/useChatState";

/*InAppView
    Purpose
        Acts as the main application workspace after onboarding.
    Responsibilities
        Owns chat state
        Coordinates sidebar and main panel
    Notes
        Chat logic is frontend-only for now
    TODO
        Integrate AI responses
        Persist chats to backend
*/

export default function InAppView() {
    const chatState = useChatState();

    return (
        <div style={{ display: "flex", height: "100vh" }}>
            <Sidebar
                chats={chatState.chats}
                activeChatId={chatState.activeChatId}
                onSelectChat={chatState.setActiveChatId}
            />
            <MainPanel
                chat={chatState.getActiveChat()}
                onSendMessage={chatState.sendMessage}
            />
        </div>
    );
}
